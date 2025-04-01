using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;
using static MaterialDesignThemes.Wpf.Theme;

namespace CRM_Tele2
{
    /// <summary>
    /// Логика взаимодействия для AddNumberWindow.xaml
    /// </summary>
    public partial class AddNumberWindow : Window
    {
        public AddNumberWindow()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[e.Text.Length - 1]))
            {
                e.Handled = true;
            }
        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(adress.Text) || string.IsNullOrWhiteSpace(dateOfScheduledCall.ToString()))
            {
                MessageBox.Show("Пожалуйста, заполните необходимые поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if(comment.Text.Length == 0) { comment.Text = "Первая запись"; }

            Person person = new Person(phoneNumber.Text, name.Text, adress.Text);

            AddPersonToDataBase(person);
        }

        private void AddPersonToDataBase(Person person)
        {
            using (SqlConnection connection = DataBase.GetConnection())
            {
                try
                {
                    connection.Open();

                    string query = "" +
                        $"INSERT INTO [CRM Tele2].dbo.Clients (PhoneNumber, Name, Address) VALUES ('{person.PhoneNumber}', '{person.Name}', '{person.Address}');" +
                        $"INSERT [CRM Tele2].dbo.Calls VALUES ('{person.PhoneNumber}', '{comment.Text}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                        $"'{dateOfScheduledCall.SelectedDate.Value.ToString("yyyy-MM-dd HH:mm:ss")}', 0);";

                    SqlCommand command = new SqlCommand(query, connection);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Данные успешно добавлены в базу данных.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка подключения к базе данных: Возможно, пользователь с таким номером уже существует.\n" + ex.Message);
                }
            }
        }
    }
    
}
