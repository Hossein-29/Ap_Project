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
        public LoginWindow()
        {
            InitializeComponent();
           
        }

        private void LoginBtn(object sender, RoutedEventArgs e)
        {
            if (UserNameInput.Text == "")
                MessageBox.Show("Invalid UserName");
            
            else if (PasswordInput.Text == "")
                MessageBox.Show("Invalid Password");
            var Panel = new EmployeePanel();
            Panel.Show();
            this.Close();
        }

        private void SignUpEmployeesBtn(object sender, RoutedEventArgs e)
        {
            var SignUpWindow = new SignUpEmployeesWindow();
            SignUpWindow.Show();
            this.Close();
        }

        private void MouseEnterHandler(object sender, MouseEventArgs e)
        {
            SignUpBtn.Foreground  = new SolidColorBrush(Colors.SkyBlue);
        }

        private void MouseLeaveHandler(object sender, MouseEventArgs e)
        {
            SignUpBtn.Foreground = new SolidColorBrush(Colors.Black);
        }
    }
}
