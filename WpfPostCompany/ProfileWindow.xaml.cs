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
using DataAccess;
using DataAccess.Models;

namespace WpfPostCompany
{
    /// <summary>
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        public Customer customer;
        public ProfileWindow(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            first_name_txtbox.Text = customer.FirstName;
            last_name_txtbox.Text = customer.LastName;
            snn_txtbox.Text = customer.SSN;
            email_txtbox.Text = customer.Email;
            phone_txtbox.Text = customer.Phone;
            username_txtbox.Text = customer.UserName;
            password_txtbox.Text = customer.Password;
            account_balance_txtbox.Text = customer.AccountBalance.ToString();
        }

        private void save_changes_btn_Click(object sender, RoutedEventArgs e)
        {
            PostCompanyEntities context = new PostCompanyEntities();


            var curCustomer = context.Customers.Where(c => c.UserName == customer.UserName).First();
            var tempCustomer = context.Customers.Where(c => c.UserName == username_txtbox.Text && c.UserName != customer.UserName).FirstOrDefault();
            var tempEmployee = context.Employees.Where(emp => emp.UserName == username_txtbox.Text && emp.UserName != customer.UserName).FirstOrDefault();
            if(tempCustomer != null || tempEmployee != null)
            {
                MessageBox.Show("Username already exists", "Profile", MessageBoxButton.OK);
            }
            else
            {
                if (password_txtbox.Text.Length != 8)
                {
                    MessageBox.Show("Password should be 8 charachter", "Profile", MessageBoxButton.OK);
                }
                else
                {
                    customer.UserName = username_txtbox.Text;
                    customer.Password = password_txtbox.Text;
                    context.Customers.Remove(curCustomer);
                    context.Customers.Add(customer);
                    context.SaveChanges();
                    MessageBox.Show("Username and password changed successfully", "Profile", MessageBoxButton.OK);
                }
            }
        }

        private void current_btn_Click(object sender, RoutedEventArgs e)
        {
            username_txtbox.Text = customer.UserName;
            password_txtbox.Text = customer.Password;
        }
    }
}
