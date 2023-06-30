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
using DataAccess.Models;

namespace WpfPostCompany
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public Customer curCustomer;
        public CustomerWindow()
        {
            InitializeComponent();
        }

        private void report_btn_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow reportWindow = new ReportWindow(curCustomer);
            this.Hide();
            reportWindow.ShowDialog();
            this.ShowDialog();
        }

        private void package_info_btn_Click(object sender, RoutedEventArgs e)
        {
            PostCompanyEntities db = new PostCompanyEntities();
            var customer = new Customer()
            {
                FirstName = "hossein",
                LastName = "baba",
                SSN = "lsflksjf",
                Email = "laslkfj",
                Phone = "sfkljslf",
                UserName = "ksl;fskljf",
                Password ="sfkskdf",
                AccountBalance = 0
            };
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        private void wallet_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void profile_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
