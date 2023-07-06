using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataCreator
    {
        static PostCompanyEntities _db = new PostCompanyEntities();
        static public bool IsUserNameExist(string userName)
        {
            var UserName = (from user in _db.Customers
                            where user.UserName == userName
                            select user).FirstOrDefault();
            if (UserName == null)
                return true;
            return false;
        }
        static public bool IsPasswordExist(string password)
        {
            var Password = (from user in _db.Customers
                            where user.Password == password
                            select user).FirstOrDefault();
            if (Password == null)
                return true;
            return false;
        }
        static public string CreateCustomerUserName()
        {
            string UserName = "user";
            string digits = "0123456789";
            do
            {
                Random random = new Random();
                for (int i = 0; i < 4; i++)
                {
                    int help = random.Next(0, digits.Length);
                    UserName += digits[help];
                }
            } while (!IsUserNameExist(UserName));
            return UserName;
        }
        static public string CreateCustomerPassword()
        {
            string Password = "";
            do
            {
                string digits = "0123456789";
                Random random = new Random();
                for (int i = 0; i < 8; i++)
                {
                    int help = random.Next(0, digits.Length);
                    Password += digits[help];
                }
            } while (!IsPasswordExist(Password));
            return Password;
        }
        static public Employee ReturnEmployee(string username)
        {
            var Employee = (from emp in _db.Employees
                            where emp.UserName == username
                            select emp).FirstOrDefault();
            return Employee;
        }
        static public Customer ReturnCustomer(string username)
        {
            var Customer = (from customer in _db.Customers
                            where customer.UserName == username
                            select customer).FirstOrDefault();
            return Customer;
        }
        public static Order ReturnOrder(int id)
        {
            var Order = (from order in _db.Orders
                         where order.OrderID == id
                         select order).FirstOrDefault();
            return Order;
        }
        static public string PostType(int index)
        {
            switch (index)
            {
                case 0:
                    return "Ordinary";
                case 1:
                    return "Leading";
                default:
                    return "";
            }
        }
        static public string PackageType(int index)
        {
            switch (index)
            {
                case 0:
                    return "Object";
                case 1:
                    return "Document";
                case 2:
                    return "Breakable";
                default:
                    return "";
            }
        }
        static public string HasExpensiveContent(int state)
        {
            switch (state)
            {
                case 0:
                    return "No";
                case 1:
                    return "Yes";
                default:
                    return "";
            }
        }
    }
}
