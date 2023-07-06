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
        public Customer customer;
        public CustomerWindow(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            customer_info_lbl.Content = "Username : " + customer.UserName + "\n" +
                                        "Full name : " + customer.FirstName + " " + customer.LastName + "\n" +
                                        "Phone : " + customer.Phone + "\n" +
                                        "SSN : " + customer.SSN + "\n" +
                                        "Email : " + customer.Email + "\n";
        }

        private void report_btn_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow Window = new ReportWindow(customer);
            this.Hide();
            Window.ShowDialog();
            this.ShowDialog();
        }

        private void package_info_btn_Click(object sender, RoutedEventArgs e)
        {
            PackageInfoWindow Window = new PackageInfoWindow(customer);
            this.Hide();
            Window.ShowDialog();
            this.ShowDialog();
        }

        private void wallet_btn_Click(object sender, RoutedEventArgs e)
        {
            WalletWindow Window = new WalletWindow(customer);
            this.Hide();
            Window.ShowDialog();
            this.ShowDialog();
        }

        private void profile_btn_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow Window = new ProfileWindow(customer);
            this.Hide();
            Window.ShowDialog();
            this.ShowDialog();
        }
    }
}
