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
using System.Collections.ObjectModel;

namespace Demo_2.Windows_Masks_app
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public static ObservableCollection<my_ado.Employee> employees { get; set; }
        public static ObservableCollection<my_ado.Session> session { get; set; }
        public static ObservableCollection<my_ado.Fine> fine { get; set; }
        
        
        public Menu()
        {
            InitializeComponent();
            employees = new ObservableCollection<my_ado.Employee>(class_Masks_app.Bd_Connection.connection.Employee.Where(a => a.Working == false).ToList());
            session = new ObservableCollection<my_ado.Session>(class_Masks_app.Bd_Connection.connection.Session.ToList());
            fine = new ObservableCollection<my_ado.Fine>(class_Masks_app.Bd_Connection.connection.Fine.ToList());
            this.DataContext = this;
            frame_main.NavigationService.Navigate(new Pages_Masks_app.Main_Menu());
        }

        private void StartSession_Click(object sender, RoutedEventArgs e)
        {

            //DateTime normal = new DateTime(2021, 11, 08, 08, 00, 00);
            //DateTime enter = DateTime.Now;
            //var em = Emps.SelectedItem as my_ado.Employee;
            //int late =(enter.Hour*60 - normal.Hour*60) + (enter.Minute - normal.Minute);
            //var s = new my_ado.Session();
            //var ep = class_Masks_app.Bd_Connection.connection.Employee.Where(a => a.ID_Employee == em.ID_Employee).FirstOrDefault();
            //s.ID_Employee = em.ID_Employee;
            //s.Time_Start = DateTime.Now;
            //if (late >= 10 && late <30)
            //{
            //    s.ID_Fine = 1;
            //    ep.Balance -= 500;
            //    class_Masks_app.Bd_Connection.connection.SaveChanges();
            //}
            //else if (late == 30)
            //{
            //    s.ID_Fine = 2;
            //    ep.Balance -= 1000;
            //    class_Masks_app.Bd_Connection.connection.SaveChanges();
            //}
            //else if (late > 30)
            //{
            //    s.ID_Fine = 3;
            //    ep.Balance -= 2000;
            //    class_Masks_app.Bd_Connection.connection.SaveChanges();
            //}
            //else
            //{
            //    s.ID_Fine = null;
            //    class_Masks_app.Bd_Connection.connection.SaveChanges();
            //}
            //ep.Working = true;
            //class_Masks_app.Bd_Connection.connection.Session.Add(s);
            //class_Masks_app.Bd_Connection.connection.SaveChanges();
            //if (late > 0)
            //{
            //    MessageBox.Show($"Сотрудник {em.FIO} вошёл с опозданием {late} минут");
            //}
            //else
            //{
            //    MessageBox.Show($"Сотрудник {em.FIO} вошёл без опоздания ");
            //}
            
            //Menu menu = new Menu();
            //menu.Show();
            //this.Close();
            //this.DataContext = this;

        }

        private void Emps_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
