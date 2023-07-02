using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for RegisterCostumerWindow.xaml
    /// </summary>
    public partial class RegisterCostumerWindow : Window
    {
        PostCompanyEntities _db = new PostCompanyEntities();
        Customer _customer = new Customer();
        Employee Employee;
        public RegisterCostumerWindow(Employee employee)
        {
            InitializeComponent();
            this.DataContext = _customer;
            Employee = employee;
            EmployeeUserName.Content += Employee.UserName;
        }
        private void SignUpCustomer()
        {
            if (FirstName.Text == "")
                throw new Exception("please enter firstName");
            else if (LastName.Text == "")
                throw new Exception("please enter lastName");
            else if (SSN.Text == "")
                throw new Exception("please enter SSN");
            else if (PhoneNumber.Text == "")
                throw new Exception("please enter phone");
            else if (Email.Text == "")
                throw new Exception("please enter email");
            else if (!InputValidation.NameValidation(FirstName.Text.ToString()))
                throw new Exception("invalid firstName");
            else if (!InputValidation.NameValidation(LastName.Text.ToString()))
                throw new Exception("invalid lastName");
            else if (!InputValidation.SSN_Validation(SSN.Text.ToString()))
                throw new Exception("invalid SSN");
            else if (!InputValidation.PhoneValidation(PhoneNumber.Text.ToString()))
                throw new Exception("invalid phone number");
            else if (!InputValidation.EmailValidation(Email.Text.ToString()))
                throw new Exception("invalid email format");

            _db.Customers.Add(_customer);
            _customer.UserName = DataCreater.CreateCustomerUserName();
            _customer.Password = DataCreater.CreateCustomerPassword();
            _db.SaveChanges();
            var Window = new EmployeePanel(Employee);
            MessageBox.Show("customer registered successfully");
            Thread.Sleep(1000);
            Window.Show();
            this.Close();
        }
        private void SignUpCostumerBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                SignUpCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
