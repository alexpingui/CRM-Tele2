using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRM_Tele2
{
    /// <summary>
    /// Логика взаимодействия для OutGoingCall.xaml
    /// </summary>
    public partial class OutGoingCall : Window
    {
        private string _phoneNumber;
        public OutGoingCall(string phoneNumber)
        {
            InitializeComponent();
            _phoneNumber = phoneNumber;
            LoadClientData(phoneNumber);
        }

        private void LoadClientData(string phoneNumber)
        {
            if(phoneNumber == null) { return; }

            using (SqlConnection connection = DataBase.GetConnection())
            {
                try
                {
                    connection.Open();

                    // Первый запрос к таблице Calls
                    string query1 =
                        "SELECT Comment AS Комментарий, " +
                        "FORMAT(DateOfCall, 'dd.MM.yyyy HH:mm') AS 'Предыдущий контакт', " +
                        "FORMAT(DateOfScheduledCall, 'dd.MM.yyyy HH:mm') AS 'Назначенный звонок' " +
                        "FROM [CRM Tele2].dbo.Calls " +
                        "WHERE ClientPhoneNumber = @PhoneNumber;";

                    SqlCommand command1 = new SqlCommand(query1, connection);
                    command1.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                    using (SqlDataReader reader1 = command1.ExecuteReader())
                    {
                        if (reader1.HasRows)
                        {
                            DataTable callHistory = new DataTable();
                            callHistory.Load(reader1);
                            CallHistory.ItemsSource = callHistory.DefaultView;
                        }
                        else
                        {
                            MessageBox.Show("Нет данных для истории звонков.");
                        }
                    }

                    // Второй запрос к таблице Clients
                    string query2 =
                        "SELECT Name, Address " +
                        "FROM [CRM Tele2].dbo.Clients " +
                        "WHERE PhoneNumber = @PhoneNumber;";

                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                    using (SqlDataReader reader2 = command2.ExecuteReader())
                    {
                        if (reader2.HasRows)
                        {
                            if (reader2.Read())
                            {
                                PhoneNumber.Text = phoneNumber;
                                Name.Text = reader2["Name"].ToString();
                                Address.Text = reader2["Address"].ToString();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Клиент с указанным номером телефона не найден.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message);
                }
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(dateOfScheduledCall.SelectedDate.HasValue)
            {
                using (SqlConnection connection = DataBase.GetConnection())
                {
                    try
                    {
                        connection.Open();
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            string query =
                                "UPDATE [CRM Tele2].dbo.Calls " +
                                "SET IsMade = 1 " +
                                "WHERE ClientPhoneNumber = @PhoneNumber; " +
                                "INSERT INTO [CRM Tele2].dbo.Calls " +
                                "(ClientPhoneNumber, Comment, DateOfCall, DateOfScheduledCall, IsMade) " +
                                "VALUES (@PhoneNumber, @Comment, @DateOfCall, @DateOfScheduledCall, @IsMade); ";

                            SqlCommand command = new SqlCommand(query, connection, transaction);
                            command.Parameters.AddWithValue("@PhoneNumber", _phoneNumber);
                            command.Parameters.AddWithValue("@Comment", Comment.Text);
                            command.Parameters.AddWithValue("@DateOfCall", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            command.Parameters.AddWithValue("@DateOfScheduledCall", dateOfScheduledCall.SelectedDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                            command.Parameters.AddWithValue("@IsMade", 0);

                            command.ExecuteNonQuery();
                            transaction.Commit();

                            MessageBox.Show("Данные успешно обновлены, звонок назначен!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message);
                    }
                }

            }
            else
            {
                using (SqlConnection connection = DataBase.GetConnection())
                {
                    try
                    {
                        connection.Open();
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            string query =
                                "INSERT INTO [CRM Tele2].dbo.Calls " +
                                "(ClientPhoneNumber, Comment, DateOfCall, DateOfScheduledCall, IsMade) " +
                                "VALUES (@PhoneNumber, @Comment, @DateOfCall, @DateOfScheduledCall, @IsMade); " +
                                "UPDATE [CRM Tele2].dbo.Calls " +
                                "SET IsMade = 1 " +
                                "WHERE ClientPhoneNumber = @PhoneNumber;";

                            SqlCommand command = new SqlCommand(query, connection, transaction);
                            command.Parameters.AddWithValue("@PhoneNumber", _phoneNumber);
                            command.Parameters.AddWithValue("@Comment", Comment.Text);
                            command.Parameters.AddWithValue("@DateOfCall", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            command.Parameters.AddWithValue("@DateOfScheduledCall", DBNull.Value);
                            command.Parameters.AddWithValue("@IsMade", 1);

                            command.ExecuteNonQuery();
                            transaction.Commit();

                            MessageBox.Show("Данные успешно обновлены, звонок удалён!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message);
                    }
                }

            }
            Close();
        }
    }
}
