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
    /// Interaction logic for PackageInfoWindow.xaml
    /// </summary>
    public partial class PackageInfoWindow : Window
    {
        public Customer customer;
        public PackageInfoWindow(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
        }

        private void search_btn_Click(object sender, RoutedEventArgs e)
        {
            PostCompanyEntities dbContext = new PostCompanyEntities();
            int curOrderId = Convert.ToInt16(order_id_txtbox.Text);
            var orders = dbContext.Orders.Where(o => o.OrderID == curOrderId && o.CustomerSSN == customer.SSN).ToList();
            if (orders.Count == 0)
                MessageBox.Show("No order with this id was found", "search", MessageBoxButton.OK);
            else
            {
                order_panel.Visibility = Visibility.Visible;
                Order order = orders[0];
                order_info_label.Content = order.SenderAaddress + "\n" +
                                            order.SenderAaddress + "\n" +
                                            order.Weight + "\n" +
                                            order.CustomerSSN;
                if(order.ShippingStatus == 1)
                {
                    submit_btn.IsEnabled = true;
                }
                                            
            }

        }
    }
}
