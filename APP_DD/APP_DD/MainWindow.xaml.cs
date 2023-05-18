using APP_DD.Entity_Framework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static APP_DD.Entities;

namespace APP_DD
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static DatabaseContext db = DB.connector;
        public MainWindow()
        {
            InitializeComponent();
            db.Cars.Load();
            ItemsList.ItemsSource = db.Cars.ToList();

        }

        private void MenuToggleButton_Click(object sender, RoutedEventArgs e)
        {
            popupMenu.IsOpen = !popupMenu.IsOpen;
        }

        private void ItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // Открываем ссылку в браузере
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
        private void AllState_Click(object sender, RoutedEventArgs e)
       {
            db.Cars.Load();
            ItemsList.ItemsSource = db.Cars.ToList();
        }
        private void NewState_Click(object sender, RoutedEventArgs e)
        {
            db.Cars.Load();
            ItemsList.ItemsSource = db.Cars.ToList().Where(car => car.IsNewOrNot == true);
        }
        private void BadState_Click(object sender, RoutedEventArgs e)
        {
            db.Cars.Load();
            ItemsList.ItemsSource = db.Cars.ToList().Where(car => car.IsNewOrNot == false);
        }
        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            if (isAscending)
            {
                // Сортировка по убыванию
                ItemsList.ItemsSource = db.Cars.OrderByDescending(car => car.total).ToList();
            }
            else
            {
                // Сортировка по возрастанию
                ItemsList.ItemsSource = db.Cars.OrderBy(car => car.total).ToList();
            }

            isAscending = !isAscending;
        }

        private void SearchField_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = searchField.Text; // Получаем текст из TextBox

            db.Cars.Load();
            ItemsList.ItemsSource = db.Cars.ToList().Where(car => car.model.Contains(searchText));
        }

        private void ShowAdditionalInformation(object sender, RoutedEventArgs e)
        {

        }
        private bool isAscending = true;

    }
}

        //private void ToggleButton_Click(object sender, RoutedEventArgs e)
        //{
        //    using (var context = new DatabaseContext())
        //    {
        //        var query = context.Cars.AsQueryable();

        //        if (ToggleButtonAny.IsChecked == true)
        //        {
        //            // Показать все предложения
        //        }
        //        else if (ToggleButtonNew.IsChecked == true)
        //        {
        //            query = query.Where(car => car.IsNewOrNot);
        //        }
        //        else if (ToggleButtonUsed.IsChecked == true)
        //        {
        //            query = query.Where(car => !car.IsNewOrNot);
        //        }

        //        var filteredCars = query.ToList();

        //    }
        //}

        
