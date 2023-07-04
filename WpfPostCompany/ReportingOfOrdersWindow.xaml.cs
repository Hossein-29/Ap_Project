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

namespace WpfPostCompany
{
    /// <summary>
    /// Interaction logic for ReportingOfOrdersWindow.xaml
    /// </summary>
    public partial class ReportingOfOrdersWindow : Window
    {
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

        private List<Order> SearchBySSN(string ssn)
        {
            var Orders = (from order in _db.Orders
                          where order.CustomerSSN == ssn
                          select order).ToList();
            return Orders;
        }

        private List<Order> SearchByPrice(string price)
        {
            var Orders = (from order in _db.Orders
                          where order.FinalPrice.ToString() == price
                          select order).ToList();
            return Orders;
        }
        private List<Order> SearchByWeight(string weight)
        {
            var Orders = (from order in _db.Orders
                          where order.Weight.ToString() == weight
                          select order).ToList();
            return Orders;
        }
        private List<Order> SearchByPackageType(int index)
        {
            var Orders = (from order in _db.Orders
                          where order.PackageType == index
                          select order).ToList();
            return Orders;
        }
        private List<Order> SearchByPostType(int index)
        {
            var Orders = (from order in _db.Orders
                          where order.PostType == index
                          select order).ToList();
            return Orders;
        }

        private void AdvancedSearch()
        {
            string SSN = CustomerSSNText.Text, Price = PriceText.Text, Weight = PackageWeightText.Text;
            int PackageType = PackageTypeCombo.SelectedIndex, PostType = PostTypeCombo.SelectedIndex;

            List<Order> Orders = (from order in _db.Orders
                                  select order).ToList();

            if (SSN != "")
            {
                Orders = (from order in Orders
                          select order).Intersect(SearchBySSN(SSN)).ToList();
            }

            if (Price != "")
            {
                Orders = (from order in Orders
                          select order).Intersect(SearchByPrice(Price)).ToList();
            }
            if (Weight != "")
            {
                Orders = (from order in Orders
                          select order).Intersect(SearchByWeight(Weight)).ToList();
            }

            if (PackageType != -1)
            {
                Orders = (from order in Orders
                          select order).Intersect(SearchByPackageType(PackageType)).ToList();
            }

            if (PostType != -1)
            {
                Orders = (from order in Orders
                          select order).Intersect(SearchByPostType(PostType)).ToList();
            }

            SaveOrdersInCSV(SortListByDateTime(Orders));
            var Window = new EmployeePanel(Employee);
            Window.Show();
            this.Close();
        }

        private List<Order> SortListByDateTime(List<Order> list)
        {
            var Orders = list.OrderBy(x => x.Date).Select(n => n).ToList();
            return Orders;
        }

        private void SaveOrdersInCSV(List<Order> Orders)
        {
            string Path = @"C:\\Users\\Abolfazl\\source\\repos\\Ap_Project\\DataAccess\\AdvancedSearchResult\\Order.csv";
            using (var writer = new StreamWriter(Path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(Orders);
            }
            MessageBox.Show("result saved in order.csv file successfully");
        }
        private void AdvancedSearchBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                AdvancedSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
