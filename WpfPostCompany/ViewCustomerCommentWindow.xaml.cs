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
    /// Interaction logic for ViewCustomerCommentWindow.xaml
    /// </summary>
    public partial class ViewCustomerCommentWindow : Window
    {
        PostCompanyEntities _db = new PostCompanyEntities();
        Employee Employee { get; set; }
        int OrderID { get; set; }
        public ViewCustomerCommentWindow(Employee employee)
        {
            InitializeComponent();
            Employee = employee;
            EmployeeUserNameLbl.Content += employee.UserName;
        }
        private void SearchOrder()
        {
            int Id = int.Parse(OrderIdText.Text);
            var Order = _db.Orders.Where(n => n.OrderID == Id).FirstOrDefault();
            if (OrderIdText.Text == "")
                throw new Exception("please enter orderID");
            else if (Order == null)
                throw new Exception("order not found");

            var Window = new OrderInformation(Employee, Id);
            Window.Show();
            this.Close();
        }
        private void SearchOrderBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                SearchOrder();
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
