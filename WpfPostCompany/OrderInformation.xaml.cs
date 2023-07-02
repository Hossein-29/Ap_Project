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
            OrderID.Content += Id.ToString();
            SenderAddress.Content += Order.SenderAddress;
            ReceiverAddress.Content += Order.ReceiverAddress;
            Weight.Content += Order.Weight.ToString();
            PackageType.Content += DataCreater.PackageType(Order.PackageType);
            PostType.Content += DataCreater.PostType(Order.PostType);
            HasExpensiveContent.Content += DataCreater.HasExpensiveContent(Order.HasExpensiveContent);
            Phone.Content += Order.Phone;
            Price.Content += Order.FinalPrice.ToString();
            Comment.Content += Order.Comment;
        }
        public void SaveChanges()
        {
            Order Order = ReturnOrder(Id);
            Order.ShippingStatus = ShippingStatus.SelectedIndex;
            
            _db.SaveChanges();
            var Window = new EmployeePanel(Employee);
            Window.Show();
            this.Close();
        }
        private void SaveChangesBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ShippingStatus.SelectedIndex == 3)
                    ShippingStatus.IsEnabled = false;
                SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
