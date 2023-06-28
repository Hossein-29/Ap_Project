using DataAccess;
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
    /// Interaction logic for MainOrderRegistrationWindow.xaml
    /// </summary>
    public partial class MainOrderRegistrationWindow : Window
    {
        public MainOrderRegistrationWindow()
        {
            InitializeComponent();
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
                if(Coefficient != 0)
                Price *= Coefficient * 1.2;
            }
            return Price;
        }

        private void CalculateFinalPrice(object sender, RoutedEventArgs e)
        {
            if (SenderAddress.Text == "")
                MessageBox.Show("please enter sender address");
            else if (RecieverAddress.Text == "")
                MessageBox.Show("please enter reciever address");
            else if (PackageType.SelectedItem == null)
                MessageBox.Show("please select type of package");
            else if (PostType.SelectedItem == null)
                MessageBox.Show("please select type of post");
            else if (PackageWeight.Text == "")
                MessageBox.Show("please enter weight");
            else if (double.IsNaN(double.Parse(PackageWeight.Text.ToString())))
                MessageBox.Show("invalid weight value");
            else if (PhoneNumber.Text != "" && !InputValidation.PhoneValidation(PhoneNumber.Text.ToString()))
                MessageBox.Show("invalid phone number");
            else
            {
                MessageBox.Show($"Final Price : {FinalPrice()}", "", MessageBoxButton.OKCancel);
            }
        }
    }
}
