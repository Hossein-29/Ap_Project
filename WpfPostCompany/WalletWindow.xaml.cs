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
using DataAccess;
using DataAccess.Models;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;

namespace WpfPostCompany
{
    /// <summary>
    /// Interaction logic for WalletWindow.xaml
    /// </summary>
    public partial class WalletWindow : Window
    {
        public Customer customer;
        public WalletWindow(Customer customer)
        {
            this.customer = customer;
            InitializeComponent();
            account_balance_lbl.Content = customer.AccountBalance;
        }

        private void submit_payment_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (card_number_txtbox.Text == "" || cvv_number_txtbox.Text == "" || year_txtbox.Text == "" || month_txtbox.Text == "" || total_pay_txtbox.Text == "")
                    throw new Exception("Insert all fields");
                int year = int.Parse(year_txtbox.Text);
                int month = int.Parse(month_txtbox.Text);
                int totalPay = int.Parse(total_pay_txtbox.Text);
                if (!InputValidation.CreditCarNumberValidation(card_number_txtbox.Text))
                {
                    throw new Exception("Invalid Card Number");
                }
                else if (!InputValidation.CVVNumberValidation(cvv_number_txtbox.Text))
                {
                    throw new Exception("Invalid CCV Number");
                }
                else if(year < 0 || month <= 0 || month > 12)
                {
                    throw new Exception("Invalid Date");
                }
                else if(totalPay < 0)
                {
                    throw new Exception("Invalid Total Pay");
                }
                customer.AccountBalance += totalPay;
                account_balance_lbl.Content = customer.AccountBalance.ToString();
                var beSaved = MessageBox.Show("Charged Successfully\nDo want it to save as PDF?", "Wallet", MessageBoxButton.YesNo);
                if(beSaved == MessageBoxResult.Yes)
                {
                    PdfDocument document = new PdfDocument();
                    PdfPage page = document.AddPage();
                    
                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    XFont font = new XFont("Segoe UI", 20, XFontStyle.Bold);
                    XTextFormatter xTextFormatter = new XTextFormatter(gfx);
                    var paymentString = $" {DateTime.Now} \n Card Number : {card_number_txtbox.Text} \n Total Pay : {total_pay_txtbox.Text} \n Account Balance : {customer.AccountBalance}";
                    xTextFormatter.DrawString(paymentString, font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormat.TopLeft);
                    string fileName = @"..\..\..\DataAccess\Payments.pdf";

                    document.Save(fileName);
                    Process.Start(fileName);
                }
                card_number_txtbox.Text = cvv_number_txtbox.Text = year_txtbox.Text = month_txtbox.Text = total_pay_txtbox.Text = "";
                
                PostCompanyEntities context = new PostCompanyEntities();
                var curCustomer = context.Customers.Where(c => c.SSN == customer.SSN).First();
                context.Customers.Remove(curCustomer);
                context.Customers.Add(customer);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Wallet", MessageBoxButton.OK);
            }
        }

        private void charge_account_btn_Click(object sender, RoutedEventArgs e)
        {
            payment_border.Visibility = Visibility.Visible;
        }

        private void BackToLoginPanel(object sender, RoutedEventArgs e)
        {
            var Window = new CustomerWindow(customer);
            Window.Show();
            this.Close();
        }
    }
}
