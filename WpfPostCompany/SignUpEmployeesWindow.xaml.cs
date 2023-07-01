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
    /// Interaction logic for SignUpEmployeesWindow.xaml
    /// </summary>
    public partial class SignUpEmployeesWindow : Window
    {
        PostCompanyEntities _db = new PostCompanyEntities();
        private Employee _employee = new Employee();
        public SignUpEmployeesWindow()
        {
            InitializeComponent();
            this.DataContext = _employee;
        }

        public void SignUpEmployee()
        {

            if (FirstName.Text == "")
                throw new Exception("please enter firstName");
            else if (LastName.Text == "")
                throw new Exception("please enter lastName");
            else if (PersonalID.Text == "")
                throw new Exception("please enter personalID");
            else if (UserName.Text == "")
                throw new Exception("please enter userName");
            else if (Email.Text == "")
                throw new Exception("please enter email");
            else if (Password.Text == "")
                throw new Exception("please enter password");
            else if (RePassword.Text == "")
                throw new Exception("please enter repeat password");


            if (!InputValidation.NameValidation(FirstName.Text.ToString()))
                throw new Exception("invalid firstName");
            else if (!InputValidation.NameValidation(LastName.Text.ToString()))
                throw new Exception("invalid lastName");
            else if (!InputValidation.PersonalIDValidation(PersonalID.Text.ToString()))
                throw new Exception("invalid personal ID");
            else if (!InputValidation.EmailValidation(Email.Text.ToString()))
                throw new Exception("invalid  email");
            else if (!InputValidation.EmployeePasswordValidation(Password.Text.ToString()))
                throw new Exception("invalid  password");

            else if (Password.Text.ToString() != RePassword.Text.ToString())
            {
                RePassword.Text = "";
                throw new Exception("password and repeated passowrd are not equal");
            }

            _db.Employees.Add(_employee);
            _db.SaveChanges();

            LoginWindow Window = new LoginWindow();
            MessageBox.Show("employee registered successfully");
            Thread.Sleep(1000);
            Window.Show();
            this.Close();
        }
        private void SignUpBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                SignUpEmployee();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}