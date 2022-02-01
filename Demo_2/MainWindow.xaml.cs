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
using Excel = Microsoft.Office.Interop.Excel;

namespace Demo_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private my_ado.bazaEntities db = new my_ado.bazaEntities();
        public static string Password = "123";
        public MainWindow()
        {
            InitializeComponent();
            

        }


        private void Authorize(object sender, RoutedEventArgs e)
        {
            var allUsers = db.Employee.ToList().OrderBy(p => p.FIO).ToList();

            var application = new Excel.Application();
            application.SheetsInNewWorkbook = 1;

            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);

            int startRowIndex = 1;
            for (int i = 0; i != 1; i++)
            {
                Excel.Worksheet worksheet = application.Worksheets.Item[i + 1];
                worksheet.Name = "Экспорт";
                
                
                worksheet.Cells[1][startRowIndex] = "Имя";
                
                startRowIndex++;
                var users = allUsers;
                foreach (var user in users)
                {
                    Excel.Range headerRange = worksheet.Range[worksheet.Cells[1][startRowIndex], worksheet.Cells[5][startRowIndex]];
                    headerRange.Merge();
                    headerRange.Value = user.FIO;
                    startRowIndex++;
                    
                }
            }
            application.Visible = true;
        }


    }
}
