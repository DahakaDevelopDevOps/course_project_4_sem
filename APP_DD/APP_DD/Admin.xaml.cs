using APP_DD.Entity_Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using static APP_DD.Entities;

namespace APP_DD
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        internal static DatabaseContext db = DB.connector;
        //private List<Review> _reviews;

        // Индекс текущего отзыва
        private int _currentIndex = 0;
        private readonly ResourceDictionary ruDict = new ResourceDictionary() { Source = new Uri("Resources/langRU.xaml", UriKind.Relative) };
        public string messageBoxText = ""; // сообщение при добавлении\изменении предмета
        public Admin()
        {
            InitializeComponent();
            Resources.MergedDictionaries.Add(ruDict); // словарь русских слов
            //_reviews = LoadReviews();
            db.Cars.Load();
            db.Users.Load();
            Database.ItemsSource = db.Cars.ToList();
            Database1.ItemsSource = db.Users.ToList();
            //DataContext = admin;
            //// Отображаем первый отзыв
            //ShowCurrentReview();
        }
        private void OnPrevClick(object sender, RoutedEventArgs e)
        {
            // Переходим к предыдущему отзыву
            if (_currentIndex > 0)
            {
                _currentIndex--;
               // ShowCurrentReview();
            }
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            mainWindow.Show();
        }

        // Обработчик нажатия на кнопку "Вперед"
        private void OnNextClick(object sender, RoutedEventArgs e)
        {
            // Переходим к следующему отзыву
            //if (_currentIndex < _reviews.Count - 1)
            //{
            //    _currentIndex++;
            //   // ShowCurrentReview();
            //}
        }
        private void LoadImageFile(object sender, RoutedEventArgs e) // функция загрузки изображения
        {
            var openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Изображения (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp"; // фильтр

            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage();

                image.BeginInit();
                image.UriSource = new Uri(openFileDialog.FileName);
                image.EndInit();

                AddImageButton.Content = "./" + image.UriSource.Segments[image.UriSource.Segments.Length - 2] + image.UriSource.Segments[image.UriSource.Segments.Length - 1]; // обрезка пути, использование только нужной
            }

        }
        private void DatabaseSelectionChanged(object sender, SelectionChangedEventArgs e) // закидывает выделенный товар в поля формы для изменения
        {
            if (Database.SelectedItem != null)
            {
                Cars selectedModel = (Cars)Database.SelectedItem;

                newItemID.Text = selectedModel.Id.ToString();
                newItemProperty.Text = selectedModel.model;
                newItemAddres.Text = selectedModel.IsNewOrNot.ToString();
                newItemDesc.Text = selectedModel.descriptionshort;
                newItemDesc.Text = selectedModel.descriptionlarge;
                newItemPrice.Text = selectedModel.total.ToString();
                AddImageButton.Content = selectedModel.photo;

                AddItemButton.Content = "Изменить товар";
            }
        }
        private void ClearForm(object sender, RoutedEventArgs e) // очищает форму
        {

            newItemID.Clear();
            newItemProperty.Clear();
            newItemAddres.Clear();
            newItemPrice.Clear();
            newItemDesc.Clear();


            AddImageButton.Content = "";
            AddItemButton.Content = "Добавить товар";
            MessageBox.Show("Форма очищена!");

        }
        private void MenuToggleButton_Click(object sender, RoutedEventArgs e)
        {
            popupMenu.IsOpen = !popupMenu.IsOpen;
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registration newCar = new Registration();
            newCar.Show();
        }

        private void Button_Click_Suggestion(object sender, RoutedEventArgs e)
        {
            AddTransport newsuggestion = new AddTransport();
            newsuggestion.Show();
        }

        private void Button_Click_PersonalCab(object sender, RoutedEventArgs e)
        {
            PersonalCab newPersonalCab = new PersonalCab();
            newPersonalCab.Show();
        }

        private void MenuCompanyPolicyClick(object sender, RoutedEventArgs e)
        {
            CompanyPolitics openPoliticsObject = new CompanyPolitics();
            openPoliticsObject.Show();
        }

        private void EnterIntoAccount(object sender, RoutedEventArgs e)
        {
            Regist regist = new Regist();
            regist.ShowDialog();
        }
    }
}
