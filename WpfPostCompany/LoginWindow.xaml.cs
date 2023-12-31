﻿using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Threading;

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

        private void CurrentTime(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            string s = time.Second.ToString();
            string m = time.Minute.ToString();
            string h = time.Hour.ToString();

            if (time.Second < 10)
                s = $"0{time.Second}";
            if (time.Minute < 10)
                m = $"0{time.Minute}";
            if (time.Hour < 10)
                h = $"0{time.Hour}";

            CurrentTimeText.Content = $"{h} : {m} : {s}";
        }

        public dynamic UserStatus(string name, string password)
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
                    return null;
                else
                    return Employee;
            }
            else
                return Customer;
        }

        public void Login()
        {
            string UserName = UserNameInput.Text.ToString();
            string Password = PasswordInput.Text.ToString();
            dynamic Temp = UserStatus(UserName, Password);
            if (UserName == "")
                throw new Exception("please enter userName");

            else if (Password == "")
                throw new Exception("please enter password");

            else if (Temp == null)
            {
                UserNameInput.Text = "";
                PasswordInput.Text = "";
                throw new Exception("user not found");
            }
            else if (Temp is Employee)
            {
                var Window = new EmployeePanel(Temp);
                MessageBox.Show("welcome to your panel", "", MessageBoxButton.OK);
                Window.Show();
                this.Close();
            }
            else if (UserStatus(UserNameInput.Text.ToString(), PasswordInput.Text.ToString()) is Customer)
            {
                var Window = new CustomerWindow(Temp);
                MessageBox.Show("welcome to your panel", "", MessageBoxButton.OK);
                Window.Show();
                this.Close();
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

        private void LoginWindowLoaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += CurrentTime;
            Timer.Start();
        }

    }
}
