using APP_DD.Entity_Framework;
using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static APP_DD.Entities;

namespace APP_DD
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        internal static DatabaseContext db = DB.connector;
        public Registration()
        {
            InitializeComponent();
        }

        private void DescriptionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void LoadImageFile(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Изображения (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage();

                image.BeginInit();
                image.UriSource = new Uri(openFileDialog.FileName);
                image.EndInit();

                AddressTextBox_Copy.Content = image.UriSource.AbsoluteUri; // использование полного пути к файлу
            }
        }
        private void OnSubmit(object sender, RoutedEventArgs e)
        {
            try
            {
                bool IsNew;
                string img = AddressTextBox_Copy.Content.ToString();
                string model = AddressTextBox.Text;
                int total = Convert.ToInt32(PriceTextBox.Text);
                string shortdescription = RidedTextBox.Text;
                if (IsNewOrNot.Text == "Новое")
                {
                    IsNew = true;
                }
                else
                {
                    IsNew = false;
                }
                string Description = DescriptionTextBox.Text;

                // проверяем почту на уникальность
                if (db.Cars.Any(u => u.photo == img))
                {
                    throw new Exception("Такое объявление уже есть");
                }
                Cars newcars = new()
                {
                    model = model,
                    total = total,
                    descriptionshort = shortdescription,
                    descriptionlarge = Description,
                    IsNewOrNot = IsNew,
                    isfavourite = false,
                    photo = img,
                };
                // добавляем новый дом в контекст данных
                _ = db.Cars.Add(newcars);
                _ = db.SaveChanges();

                // выводим сообщение об успешном завершении 
                _ = MessageBox.Show("Заполнение прошло успешно!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);

                Close();
            }
            catch (Exception ex)
            {
                // выводим сообщение об ошибке
                _ = MessageBox.Show($"Ошибка при добавлении объявления: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
