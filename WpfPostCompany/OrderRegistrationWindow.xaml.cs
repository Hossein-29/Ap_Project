using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfPostCompany
{
    /// <summary>
    /// Interaction logic for OrderRegistrationWindow.xaml
    /// </summary>
    public partial class OrderRegistrationWindow : Window
    {
        PostCompanyEntities _db = new PostCompanyEntities();
        Employee Employee { get; set; }
        public OrderRegistrationWindow(Employee employee)
        {
            InitializeComponent();
            Employee = employee;
        }

        public bool SeachCustomerBySSN(string ssn)
        {
            var Customer = _db.Customers.Where(customer => customer.SSN == ssn).FirstOrDefault();
            if (Customer == null)
                return false;
            return true;
        }
        public void SearchCustomer()
        {
            string CustomerSSN = SSN.Text.ToString();
            if (CustomerSSN == "")
                throw new Exception("please enter SSN");
            else if (!SeachCustomerBySSN(CustomerSSN))
            {
                SSN.Text = "";
                throw new Exception("customer not found");
            }

            var Window = new MainOrderRegistrationWindow(Employee, CustomerSSN);
            Window.Show();
            this.Close();
        }
        private void SearchSSnBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                SearchCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
