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
        public CustomerWindow(Customer customer)
        {
            InitializeComponent();
        }

        private void report_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void package_info_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void wallet_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void profile_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
