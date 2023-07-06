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
    /// Interaction logic for EmployeePanel.xaml
    /// </summary>
    public partial class EmployeePanel : Window
    {
        PostCompanyEntities _db = new PostCompanyEntities();
        Employee Employee { get; set; }
        public EmployeePanel(Employee employee)
        {
            InitializeComponent();
            Employee = employee;
            EmployeeUserName.Content += Employee.UserName;
        }



        private void OrderRegistrationBtn(object sender, RoutedEventArgs e)
        {
            var OrderRegistration = new OrderRegistrationWindow(Employee);
            OrderRegistration.Show();
            this.Close();
        }

        private void SendDeliveryEmail(object sender, RoutedEventArgs e)
        {

        }

        private void RegisterCostumerBtn(object sender, RoutedEventArgs e)
        {
            var Window = new RegisterCostumerWindow(Employee);
            Window.Show();
            this.Close();
        }

        private void DisplayPackageInfoBtn(object sender, RoutedEventArgs e)
        {
            var DisplayInfo = new DisplayPackageInformationWindow(Employee);
            DisplayInfo.Show();
            this.Close();
        }

        private void ViewCostumerCommentsBtn(object sender, RoutedEventArgs e)
        {
            var Window = new ViewCustomerCommentWindow(Employee);
            Window.Show();
            this.Close();
        }

        private void ReportingOfOrdersBtn(object sender, RoutedEventArgs e)
        {
            var ReportingOrders = new ReportingOfOrdersWindow(Employee);
            ReportingOrders.Show();
            this.Close();
        }

        private void BackToLoginPanel(object sender, RoutedEventArgs e)
        {
            var Window = new LoginWindow();
            Window.Show();
            this.Close();
        }
    }
}
