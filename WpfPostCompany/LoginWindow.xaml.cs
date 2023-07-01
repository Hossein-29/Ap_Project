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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        PostCompanyEntities _db = new PostCompanyEntities();
        public LoginWindow()
        {
            InitializeComponent();

        }
        public string UserStatus(string name, string password)
        {
            var Customer = (from customer in _db.Customers
                            where customer.UserName == name && customer.Password == password
                            select customer).FirstOrDefault();
            if (Customer == null)
            {
                var Employee = (from employee in _db.Employees
                                where employee.UserName == name && employee.Password == password
                                select employee).FirstOrDefault();
                if (Employee == null)
                    return "none";
                else
                    return "employee";
            }
            else
                return "customer";
        }
        public void Login()
        {
            if (UserNameInput.Text == "")
                throw new Exception("please enter userName");

            else if (PasswordInput.Text == "")
                throw new Exception("please enter password");

            if (UserStatus(UserNameInput.Text, PasswordInput.Text) == "none")
            {
                UserNameInput.Text = "";
                PasswordInput.Text = "";
                throw new Exception("user not found");
            }
            else
            {
                var Window = new EmployeePanel();
                //    Window.Show();
                //     this.Close();

            }
        }
        private void LoginBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                Login();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SignUpEmployeesBtn(object sender, RoutedEventArgs e)
        {
            var Window = new SignUpEmployeesWindow();
            Window.Show();
            this.Close();
        }

        private void MouseEnterHandler(object sender, MouseEventArgs e)
        {
            SignUpBtn.Foreground = new SolidColorBrush(Colors.SkyBlue);
        }

        private void MouseLeaveHandler(object sender, MouseEventArgs e)
        {
            SignUpBtn.Foreground = new SolidColorBrush(Colors.Black);
        }
    }
}
