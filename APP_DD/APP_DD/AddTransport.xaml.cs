using APP_DD.Entity_Framework;
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
    /// Логика взаимодействия для AddTransport.xaml
    /// </summary>
    public partial class AddTransport : Window
    {
        public string messageBoxText = ""; // сообщение при добавлении\изменении предмета
        internal static DatabaseContext db = DB.connector;
        private readonly ResourceDictionary ruDict = new ResourceDictionary() { Source = new Uri("Resources/langRU.xaml", UriKind.Relative) };
        public AddTransport()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Resources.MergedDictionaries.Add(ruDict); // словарь русских слов
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string comment = CommTextBox.Text;
            Entities.Review review = new()
            {
                Comment = comment,
            };
            db.Review.Add(review);
            _ = db.SaveChanges();

            _ = MessageBox.Show("Спасибо за ваш отзыв!!!!!");

        }
        private void AddressTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
