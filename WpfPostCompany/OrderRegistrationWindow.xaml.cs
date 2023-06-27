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
    /// Interaction logic for OrderRegistrationWindow.xaml
    /// </summary>
    public partial class OrderRegistrationWindow : Window
    {
        public OrderRegistrationWindow()
        {
            InitializeComponent();
        }

        private void SearchSSnBtn(object sender, RoutedEventArgs e)
        {
            if (SSN.Text == "")
                MessageBox.Show("please enter SSN");
            else
            {
               var MainOrderRergistration = new MainOrderRegistrationWindow();
                MainOrderRergistration.Show();
                this.Close();
            }
        }
    }
}
