using APP_DD.Entity_Framework;
using APP_DD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static APP_DD.Entities;
using RentalAvenue;

namespace APP_DD
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Regist : Window
    {
        private const string AdminEmail = "admin@admin.com";
        internal static DatabaseContext db = DB.connector;
        public Regist()
        {
            InitializeComponent();
        }
        public void LogIn(object sender, ExecutedRoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string name = LogTextBox.Text;


            Entities.User? user = db.Users.FirstOrDefault(u => u.Email == email && u.Login == name);
            if (user != null)
            {
                if (user.Email == AdminEmail)
                {
                    // Пользователь найден и это админ, делаем редирект на AdminWindow
                    Admin adminWindow = new()
                    {
                        WindowStartupLocation = WindowStartupLocation.CenterScreen
                    };
                    adminWindow.Show();
                    Close();
                }
                else
                {
                    // Пользователь найден, делаем редирект на MainWindow
                    MainWindow mainWindow = new()
                    {
                        WindowStartupLocation = WindowStartupLocation.CenterScreen
                    };
                    mainWindow.Show();
                    Close();
                }
            }
            else
            {
                try
                {
                    // считываем данные из полей ввода

                    // проверяем почту на уникальность
                    if (db.Users.Any(u => u.Email == email && u.Login != name))
                    {
                        throw new Exception("Пользователь с такой почтой уже существует, но логин другой");
                    }

                    // проверяем правильность ввода почты и телефона с помощью regex
                    string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                    if (!Regex.IsMatch(email, emailPattern))
                    {
                        throw new Exception("Неправильный формат почты");
                    }


                    // создаем новый объект User
                    User newUser = new()
                    {
                        Login = name,
                        Email = email,
                        IsAdmin = false
                    };

                    // добавляем нового пользователя в контекст данных
                    _ = db.Users.Add(newUser);
                    _ = db.SaveChanges();


                    // выводим сообщение об успешной регистрации
                    _ = MessageBox.Show("Регистрация прошла успешно!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    //Regist = new();
                    //loginPage.Show();
                    Close();
                }
                catch (Exception ex)
                {
                    // выводим сообщение об ошибке
                    _ = MessageBox.Show($"Ошибка при регистрации нового пользователя: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

    }
}
