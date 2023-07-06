using DataAccess;
using DataAccess.Models;
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

namespace WpfPostCompany
{
    /// <summary>
    /// Interaction logic for OrderInformation.xaml
    /// </summary>
    public partial class OrderInformation : Window
    {
        PostCompanyEntities _db = new PostCompanyEntities();
        int Id { get; set; }
        Employee Employee { get; set; }
        public OrderInformation(Employee employee, int id)
        {
            InitializeComponent();
            Employee = employee;
            Id = id;
            EmployeeUserName.Content += Employee.UserName;
            DisplayOrderInfo();
            if (ShippingStatus.SelectedIndex == 3)
            {
                var ParentContainer = SaveChangeButton.Parent as Panel;
                ParentContainer.Children.Remove(SaveChangeButton);
            }
        }
        public Order ReturnOrder(int id)
        {
            var Order = (from order in _db.Orders
                         where order.OrderID == id
                         select order).FirstOrDefault();
            return Order;
        }

        public void DisplayOrderInfo()
        {
            Order Order = ReturnOrder(Id);
            ShippingStatus.SelectedIndex = Order.ShippingStatus;

            if (ShippingStatus.SelectedIndex == 3)
                ShippingStatus.IsEnabled = false;

            OrderID.Content += Id.ToString();
            SenderAddress.Content += Order.SenderAddress;
            ReceiverAddress.Content += Order.ReceiverAddress;
            Weight.Content += Order.Weight.ToString();
            PackageType.Content += DataCreator.PackageType(Order.PackageType);
            PostType.Content += DataCreator.PostType(Order.PostType);
            HasExpensiveContent.Content += DataCreator.HasExpensiveContent(Order.HasExpensiveContent);
            Phone.Content += Order.Phone;
            Price.Content += Order.FinalPrice.ToString();
        }
        private string DeliveryEmailFormat(Order order)
        {
            string Result = $"Your Package With Id = {Id} Was Delivered.\nOrder Information :\n";
            Result += $"Sender Address : {order.SenderAddress}\nReciever Address : {order.ReceiverAddress}\nPost Type : {DataCreator.PostType(order.PostType)}" +
                $"\nPackage Type : {DataCreator.PackageType(order.PackageType)}\nHas Expensive Content : {DataCreator.HasExpensiveContent(order.HasExpensiveContent)}\n" +
                $"Final Price : {order.FinalPrice}\nPhone : {order.Phone}\nCreation Date : {order.CreatedAt}\n";
            Result += "Please Share Us Your Comment.";
            return Result;
        }
        public void SaveChanges()
        {
            Order Order = ReturnOrder(Id);
            Order.ShippingStatus = ShippingStatus.SelectedIndex;
            _db.SaveChanges();
            string CurCustomerSSN = Order.CustomerSSN;
            var CurCustomerEmail = _db.Customers.Where(n => n.SSN == CurCustomerSSN).Select(n => n.Email).First();
            if (ShippingStatus.SelectedIndex == 3)
                EmailSender.SendEmail("Delivery", DeliveryEmailFormat(Order), CurCustomerEmail);

            var Window = new EmployeePanel(Employee);
            Window.Show();
            this.Close();
        }
        private void SaveChangesBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackToEmployeePanel(object sender, RoutedEventArgs e)
        {
            var Window = new EmployeePanel(Employee);
            Window.Show();
            this.Close();
        }
    }
}
