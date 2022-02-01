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
using System.Collections.ObjectModel;

namespace Demo_2.Pages_Masks_app
{
    /// <summary>
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {
        

        public static string Password = "123";
        public Autho()
        {
            InitializeComponent();
            
        }
        private void Authorize(object sender, RoutedEventArgs e)
        {
            if (Password_txt.Text == Password)
            {
                MessageBox.Show("добро пожаловать");
                Windows_Masks_app.Menu menu = new Windows_Masks_app.Menu();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Пароль неверный");
            }
            
        }
    }
}
