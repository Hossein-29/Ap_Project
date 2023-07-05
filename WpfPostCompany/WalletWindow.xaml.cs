﻿using System;
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
                MessageBox.Show("Charged Successfully", "Wallet", MessageBoxButton.OK);
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
    }
}
