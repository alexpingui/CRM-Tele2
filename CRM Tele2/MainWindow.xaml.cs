using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRM_Tele2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddNumberWindow addNumberWindow = new AddNumberWindow();
            addNumberWindow.ShowDialog();
            LoadData();
        }

        private void OutGoingCallButton_Click(object sender, RoutedEventArgs e)
        {
            OutGoingCall outGoingCall = new OutGoingCall(null);
            outGoingCall.ShowDialog();
            LoadData();
        }



        private void LoadData()
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "" +
                        "SELECT c.Name AS Имя, " +
                        "c.Address AS Адрес, " +
                        "cl.ClientPhoneNumber AS 'Номер телефона', " +
                        "cl.Comment AS 'Комментарий', " +
                        "FORMAT(cl.DateOfCall, 'dd.MM.yyyy HH:mm') AS 'Предыдущий контакт', " +
                        "FORMAT(cl.DateOfScheduledCall, 'dd.MM.yyyy HH:mm') AS 'Назначенный звонок' " +
                        "FROM [CRM Tele2].dbo.Clients c " +
                        "INNER JOIN [CRM Tele2].dbo.Calls cl ON c.PhoneNumber = cl.ClientPhoneNumber " +
                        "WHERE cl.IsMade = 0 AND cl.DateOfScheduledCall < CONVERT(date, GETDATE() + 1);";

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    mainDataGrid.ItemsSource = dataTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message);
                }
            }
        }

        private void mainDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (mainDataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = mainDataGrid.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    string selectedPhoneNumber = selectedRow["Номер телефона"].ToString();
                    OutGoingCall outGoingCall = new OutGoingCall(selectedPhoneNumber);
                    outGoingCall.ShowDialog();
                    LoadData();
                }
            }
        }


    }
}
