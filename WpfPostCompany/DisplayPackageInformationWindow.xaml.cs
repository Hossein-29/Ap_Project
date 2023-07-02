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
    /// Interaction logic for DisplayPackageInformationWindow.xaml
    /// </summary>
    public partial class DisplayPackageInformationWindow : Window
    {
        PostCompanyEntities _db = new PostCompanyEntities();
        int Id { get; set; }
        Employee Employee { get; set; }
        public DisplayPackageInformationWindow(Employee employee)
        {
            InitializeComponent();
            Employee = employee;
            EmployeeUserName.Content += Employee.UserName;
        }
        public bool SearchOrderByID(int id)
        {
            var Order = (from order in _db.Orders
                         where order.OrderID == id
                         select order).FirstOrDefault();
            if (Order == null)
                return false;
            return true;
        }
        public void DisplayOrderInfo()
        {
            Id = int.Parse(OrderIDText.Text);
            if (OrderIDText.Text == "")
                throw new Exception("please enter orderID");
            else if (!SearchOrderByID(Id))
                throw new Exception("order not found");

            var Window = new OrderInformation(Employee, Id);
            Window.Show();
            this.Close();
        }
        private void DisplayOrderInfoBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                DisplayOrderInfo();
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