using APP_DD.Entity_Framework;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

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

    }
}
