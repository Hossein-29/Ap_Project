using DataAccess;
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
    /// Interaction logic for RegisterCostumerWindow.xaml
    /// </summary>
    public partial class RegisterCostumerWindow : Window
    {
        public RegisterCostumerWindow()
        {
            InitializeComponent();
        }

        private void SignUpCostumerBtn(object sender, RoutedEventArgs e)
        {
            if (FirstName.Text == "")
                MessageBox.Show("please enter first name");
            else if (LastName.Text == "")
                MessageBox.Show("please enter last name");
            else if (SSN.Text == "")
                MessageBox.Show("please enter SSN");
            else if (PhoneNumber.Text == "")
                MessageBox.Show("please enter phone number");
            else if (Email.Text == "")
                MessageBox.Show("please enter email");
            else
            {
                if (!InputValidation.NameValidation(FirstName.Text.ToString()))
                    MessageBox.Show("invalid firstName");
                else if (!InputValidation.NameValidation(LastName.Text.ToString()))
                    MessageBox.Show("invalid lastName");
                else if (!InputValidation.SSN_Validation(SSN.Text.ToString()))
                    MessageBox.Show("invalid SSN");
                else if (!InputValidation.PhoneValidation(PhoneNumber.Text.ToString()))
                    MessageBox.Show("invalid phone number");
                else if (!InputValidation.EmailValidation(Email.Text.ToString()))
                    MessageBox.Show("invalid email format");

                else
                {
                    var EmployeePanel = new EmployeePanel();
                    EmployeePanel.Show();
                    this.Close();
                }
            }

        }
    }
}
