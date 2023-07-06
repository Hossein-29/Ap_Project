using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using DataAccess;
using DataAccess.Models;

namespace WpfPostCompany
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        string Path = @"C:\\Users\\Abolfazl\\source\\repos\\Ap_Project\\DataAccess\\AdvancedSearchResult\\Customer_Order.csv";
        PostCompanyEntities dbContext = new PostCompanyEntities();
        public Customer customer;
        public ReportWindow(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            CustomerUserNameTxt.Content += customer.UserName;
        }

        private void AdvancedSearchBtn(object sender, RoutedEventArgs e)
        {
            string Price = PriceText.Text, Weight = PackageWeightText.Text;
            int PackageType = PackageTypeCombo.SelectedIndex, PostType = PostTypeCombo.SelectedIndex;
            List<Order> Orders = (from order in dbContext.Orders
                                  where order.CustomerSSN == customer.SSN
                                  select order).ToList();
            try
            {
                var Result = SearchingOrders.AdvancedSearch(Price, Weight, PackageType, PostType, dbContext, Orders, "Customer", "");
                SearchingOrders.SaveOrdersInCSV(Result, Path);
                var Window = new CustomerWindow(customer);
                Window.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackToCustomerPanel(object sender, RoutedEventArgs e)
        {
            var Window = new CustomerWindow(customer);
            Window.Show();
            this.Close();
        }
    }
}
