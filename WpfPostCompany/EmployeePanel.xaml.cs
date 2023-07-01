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
    /// Interaction logic for EmployeePanel.xaml
    /// </summary>
    public partial class EmployeePanel : Window
    {
        Employee Employee { get; set; }
        public EmployeePanel(Employee employee)
        {
            InitializeComponent();
            Employee = employee;
        }

        private void OrderRegistrationBtn(object sender, RoutedEventArgs e)
        {
            var OrderRegistration = new OrderRegistrationWindow();
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
            var DisplayInfo = new DisplayPackageInformationWindow();
            DisplayInfo.Show();
            this.Close();
        }

        private void ViewCostumerCommentsBtn(object sender, RoutedEventArgs e)
        {

        }

        private void ReportingOfOrdersBtn(object sender, RoutedEventArgs e)
        {
            var ReportingOrders = new ReportingOfOrdersWindow();
            ReportingOrders.Show();
            this.Close();
        }
    }
}
