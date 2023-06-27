using DataAccess;
using System;
using System.Collections.Generic;
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
        public SignUpEmployeesWindow()
        {
            InitializeComponent();
        }

        private void SignUpBtn(object sender, RoutedEventArgs e)
        {
            if (FirstName.Text == "")
                MessageBox.Show("please enter first name");
            else if (LastName.Text == "")
                MessageBox.Show("please enter last name");
            else if (PersonID.Text == "")
                MessageBox.Show("please enter personID");
            else if (UserName.Text == "")
                MessageBox.Show("please enter userName");
            else if (Email.Text == "")
                MessageBox.Show("please enter email");
            else if (Password.Text == "")
                MessageBox.Show("please enter password");
            else if (RePassword.Text == "")
                MessageBox.Show("please enter password repeat");
            else
            {
                if (!InputValidation.NameValidation(FirstName.Text.ToString()))
                    MessageBox.Show("invalid firstName");
                else if (!InputValidation.NameValidation(LastName.Text.ToString()))
                    MessageBox.Show("invalid lastName");
                else if (!InputValidation.PersonIDValidation(PersonID.Text.ToString()))
                    MessageBox.Show("invalid personID");
                else if (!InputValidation.EmailValidation(Email.Text.ToString()))
                    MessageBox.Show("invalid email");
                else if (!InputValidation.EmployeePasswordValidation(Password.Text.ToString()))
                    MessageBox.Show("invalid password");
                else if (Password.Text.ToString() != RePassword.Text.ToString())
                {
                    MessageBox.Show("password and repeated password are not aqual");
                    RePassword.Text = "";
                }

                else
                {
                    MessageBox.Show("Sign Up Successfully");
                    LoginWindow loginWindow = new LoginWindow();
                    Thread.Sleep(2000);
                
                    loginWindow.Show();
                    this.Close();
                }
            }
        }
    }
}
