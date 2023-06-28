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
    /// Interaction logic for DisplayPackageInformationWindow.xaml
    /// </summary>
    public partial class DisplayPackageInformationWindow : Window
    {
        public DisplayPackageInformationWindow()
        {
            InitializeComponent();
        }

        private void DisplayOrderInfoBtn(object sender, RoutedEventArgs e)
        {
            var OrderInfo = new OrderInformation();
            OrderInfo.Show();
            this.Close();
        }
    }
}
