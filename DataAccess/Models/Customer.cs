using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Customer : IPerson
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string phoneNumber { get; set; }
        public static ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

        public Customer(string id, string firstName, string lastName, string email, string userName, string password, string phoneNumber)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.userName = userName;
            this.password = password;
            this.phoneNumber = phoneNumber;
            customers.Add(this);
        }
    }
}
