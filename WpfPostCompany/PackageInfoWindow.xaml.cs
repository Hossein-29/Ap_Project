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
using CsvHelper.Configuration.Attributes;
using DataAccess;
using DataAccess.Models;

namespace WpfPostCompany
{
    /// <summary>
    /// Interaction logic for PackageInfoWindow.xaml
    /// </summary>
    public partial class PackageInfoWindow : Window
    {
        PostCompanyEntities dbContext = new PostCompanyEntities();
        public Customer customer;
        Order Order;
        public PackageInfoWindow(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
        }

        private void search_btn_Click(object sender, RoutedEventArgs e)
        {
            order_panel.Visibility = Visibility.Hidden;
            try
            {
                int curOrderId = Convert.ToInt16(order_id_txtbox.Text);
                var order = dbContext.Orders.Where(o => o.OrderID == curOrderId && o.CustomerSSN == customer.SSN).FirstOrDefault();

                
                else if (order == null)
                {
                    order_id_txtbox.Text = "";
                    throw new Exception("order not found");
                }

                else
                {
                    order_panel.Visibility = Visibility.Visible;
                    Order = order;
                    order_info_label.Content = Order.SenderAddress + "\n" +
                                                Order.ReceiverAddress + "\n" +
                                                Order.Weight + "\n" +
                                                Order.CustomerSSN;

                    if (order.Comment != null)
                    {
                        CommentTxt.Text = order.Comment;
                        CommentTxt.IsReadOnly = true;
                    }
                    else if (Order.ShippingStatus == 3)
                    {
                        submit_btn.IsEnabled = true;
                        CommentTxt.IsReadOnly = false;
                    }
                    else
                        throw new Exception("order has not been deliverded");
                    order_id_txtbox.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SubmitCommentButton(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CommentTxt.Text == "")
                    throw new Exception("please enter comment");
                Order.Comment = CommentTxt.Text;
                dbContext.SaveChanges();
                var Window = new CustomerWindow(customer);
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
