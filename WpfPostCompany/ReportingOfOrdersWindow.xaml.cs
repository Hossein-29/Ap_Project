using System;
using CsvHelper;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using DataAccess.Models;
using System.Diagnostics;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Input;
using System.Globalization;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Runtime.InteropServices;
using DataAccess;
using System.Data.Entity;

namespace WpfPostCompany
{
    /// <summary>
    /// Interaction logic for ReportingOfOrdersWindow.xaml
    /// </summary>
    public partial class ReportingOfOrdersWindow : Window
    {
        string Path = @"C:\\Users\\Abolfazl\\source\\repos\\Ap_Project\\DataAccess\\AdvancedSearchResult\\Employee_Order.csv";
        PostCompanyEntities _db = new PostCompanyEntities();
        Employee Employee { get; set; }
        public ReportingOfOrdersWindow(Employee employee)
        {
            InitializeComponent();
            Employee = employee;
            EmployeeUserName.Content += Employee.UserName;
        }

        private void BackToEmployeePanel(object sender, RoutedEventArgs e)
        {
            var Window = new EmployeePanel(Employee);
            Window.Show();
            this.Close();
        }
        private void AdvancedSearchBtn(object sender, RoutedEventArgs e)
        {
            string SSN = CustomerSSNText.Text, Price = PriceText.Text, Weight = PackageWeightText.Text;
            int PackageType = PackageTypeCombo.SelectedIndex, PostType = PostTypeCombo.SelectedIndex;
            List<Order> Orders = (from order in _db.Orders
                                  select order).ToList();
            try
            {
                var Result = SearchingOrders.AdvancedSearch(Price, Weight, PackageType, PostType, _db, Orders, "Employee", SSN);
                SearchingOrders.SaveOrdersInCSV(Result, Path);
                var Window = new EmployeePanel(Employee);
                Window.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
