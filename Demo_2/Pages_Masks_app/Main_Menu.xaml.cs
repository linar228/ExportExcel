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
    /// Логика взаимодействия для Main_Menu.xaml
    /// </summary>
    public partial class Main_Menu : Page
    {
        public static ObservableCollection<my_ado.Employee> employees { get; set; }
        public static ObservableCollection<my_ado.Session> session { get; set; }
        public static ObservableCollection<my_ado.Fine> fine { get; set; }
        public Main_Menu()
        {
            InitializeComponent();
            employees = new ObservableCollection<my_ado.Employee>(class_Masks_app.Bd_Connection.connection.Employee.Where(a => a.Working == false).ToList());
            session = new ObservableCollection<my_ado.Session>(class_Masks_app.Bd_Connection.connection.Session.ToList());
            fine = new ObservableCollection<my_ado.Fine>(class_Masks_app.Bd_Connection.connection.Fine.ToList());
            this.DataContext = this;
            StartSession.IsEnabled = false;
        }

        private void StartSession_Click(object sender, RoutedEventArgs e)
        {
            

            DateTime current_day = DateTime.Now;
            //DateTime current_day = new DateTime(2021, 11, 08, 08, 31, 00);
            string[] data = DateTime.Now.ToString().Split(' ')[0].Split('.');
            DateTime normal = new DateTime(Convert.ToInt32(data[2]), Convert.ToInt32(data[1]), Convert.ToInt32(data[0]), 08, 00, 00);
            int late = Convert.ToInt32(current_day.Hour * 60 - normal.Hour * 60 + current_day.Minute - normal.Minute);
            var s = new my_ado.Session();
            var em = Empl.SelectedItem as my_ado.Employee;
            var ep = class_Masks_app.Bd_Connection.connection.Employee.Where(a => a.ID_Employee == em.ID_Employee).FirstOrDefault();
            s.ID_Employee = em.ID_Employee;
            s.Time_Start = DateTime.Now;
            
            if (late >= 10 && late < 30)
            {
                s.ID_Fine = 1;
                var f = class_Masks_app.Bd_Connection.connection.Fine.Where(a => a.ID_Fine == s.ID_Fine).FirstOrDefault();
                ep.Balance -= f.Sum_Fine;//500
                class_Masks_app.Bd_Connection.connection.SaveChanges();
            }
            else if (late == 30)
            {
                s.ID_Fine = 2;
                var f = class_Masks_app.Bd_Connection.connection.Fine.Where(a => a.ID_Fine == s.ID_Fine).FirstOrDefault();
                ep.Balance -= f.Sum_Fine;//1000
                class_Masks_app.Bd_Connection.connection.SaveChanges();
            }
            else if (late > 30)
            {
                s.ID_Fine = 3;
                var f = class_Masks_app.Bd_Connection.connection.Fine.Where(a => a.ID_Fine == s.ID_Fine).FirstOrDefault();
                ep.Balance -= f.Sum_Fine;//2000
                class_Masks_app.Bd_Connection.connection.SaveChanges();
            }
            else
            {
                s.ID_Fine = null;
                class_Masks_app.Bd_Connection.connection.SaveChanges();
            }
            ep.Working = true;
            class_Masks_app.Bd_Connection.connection.Session.Add(s);
            class_Masks_app.Bd_Connection.connection.SaveChanges();
            if (late > 0)
            {
                MessageBox.Show($"Сотрудник {ep.FIO} вошёл с опозданием {late} минут");
            }
            else
            {
                MessageBox.Show($"Сотрудник {ep.FIO} вошёл без опоздания ");
            }
            NavigationService.Navigate(new Main_Menu());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            
            var emps = class_Masks_app.Bd_Connection.connection.Employee.ToList();
            foreach(var item in emps)
            {
                item.Working = false;
                class_Masks_app.Bd_Connection.connection.SaveChanges();
            }
            
            NavigationService.Navigate(new Main_Menu());
        }

        private void Empl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Empl.ItemsSource = new ObservableCollection<my_ado.Employee>(class_Masks_app.Bd_Connection.connection.Employee.Where(a => a.Working == false)).ToList();

            if (Empl.SelectedValue != null && Empl.SelectedValue.ToString() != "")
            {
                StartSession.IsEnabled = true;
            }
        }
    }
}
