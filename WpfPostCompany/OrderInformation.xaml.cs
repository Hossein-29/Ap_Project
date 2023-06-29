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
    /// Interaction logic for OrderInformation.xaml
    /// </summary>
    public partial class OrderInformation : Window
    {
        public OrderInformation()
        {
            InitializeComponent();
        }

        private void SelectionChangedHandler(object sender, SelectionChangedEventArgs e)
        {
            if (ShippingStatus.SelectedIndex == 3)
                ShippingStatus.IsEnabled = false;
        }

        private void DiscardChangesBtn(object sender, RoutedEventArgs e)
        {
            if (ShippingStatus.SelectedItem == null)
                MessageBox.Show("please select status");
        }
    }
}
