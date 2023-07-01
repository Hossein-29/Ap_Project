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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            
            Customer customer = new Customer
            {
                FirstName = "hossein",
                LastName = "Babazadeh",
                SSN = "4890563261",
                Email = "hb3238816@gmail.com",
                Phone = "09385322639",
                UserName = "hossein29",
                Password = "1234",
                AccountBalance = 0
            };
            this.Hide();
            CustomerWindow customerWindow = new CustomerWindow(customer);
            customerWindow.ShowDialog();
            this.ShowDialog();
        }

    }
}
