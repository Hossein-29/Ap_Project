using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using MessageBox = System.Windows.Forms.MessageBox;

namespace WpfPostCompany
{
    /// <summary>
    /// Interaction logic for MainOrderRegistrationWindow.xaml
    /// </summary>
    public partial class MainOrderRegistrationWindow : Window
    {
        PostCompanyEntities _db = new PostCompanyEntities();
        Order _order = new Order();
        Employee Employee { get; set; }
        string SSN { get; set; }
        public MainOrderRegistrationWindow(Employee employee, string ssn)
        {
            InitializeComponent();
            Employee = employee;
            SSN = ssn;
            this.DataContext = _order;
            EmployeeUserName.Content += Employee.UserName;
        }
        private double FinalPrice()
        {
            double Price = 10000;
            double Weight = double.Parse(PackageWeight.Text.ToString());
            if (PackageType.SelectedIndex == 1)
                Price *= 1.5;
            else if (PackageType.SelectedIndex == 2)
                Price *= 2;

            if (PostType.SelectedIndex == 1)
                Price *= 1.5;

            if (HasExpensiveContent.IsChecked == true)
                Price *= 2;

            if (Weight > 0.5)
            {
                Weight -= 0.5;
                int Coefficient = 0;
                Coefficient += (int)Math.Ceiling(Weight / 0.5);
                if (Coefficient != 0)
                    Price *= Math.Pow(1.2, Coefficient);
            }
            return Price;
        }
        private void CalculateFinalPrice()
        {
            if (SenderAddress.Text == "")
                throw new Exception("please enter sender address");
            else if (RecieverAddress.Text == "")
                throw new Exception("please enter receiver address");
            else if (PackageType.SelectedItem == null)
                throw new Exception("please select package type");
            else if (PostType.SelectedItem == null)
                throw new Exception("please enter post type");
            else if (PackageWeight.Text == "")
                throw new Exception("please enter weight");
            else if (double.IsNaN(double.Parse(PackageWeight.Text.ToString())))
                throw new Exception("invalid weight");
            else if (PhoneNumber.Text != "" && !InputValidation.PhoneValidation(PhoneNumber.Text.ToString()))
                throw new Exception("invalid phone number");

            var Result = WPFCustomMessageBox.CustomMessageBox.ShowOKCancel($"Final Price : {FinalPrice()}", "", "Register", "Cancel");


            if (Result == MessageBoxResult.OK)
            {
                _order.OrderID = _db.Orders.Count() + 1;
                _order.CustomerSSN = SSN;
                _order.PackageType = PackageType.SelectedIndex;
                _order.PostType = PostType.SelectedIndex;
                _order.CreatedAt = DateTime.Now;
                if (HasExpensiveContent.IsChecked == false)
                    _order.HasExpensiveContent = 0;
                else
                    _order.HasExpensiveContent = 1;

                _order.FinalPrice = int.Parse(FinalPrice().ToString());

                _db.Orders.Add(_order);
                _db.SaveChanges();
                MessageBox.Show("order registerd successfully");
                var Window = new EmployeePanel(Employee);
                Thread.Sleep(500);
                Window.Show();
                this.Close();
            }
            //else
            //{
            //    var Window = new EmployeePanel(Employee);
            //    Window.Show();
            //    this.Close();
            //}
        }
        private void CalculateFinalPriceBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                CalculateFinalPrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
