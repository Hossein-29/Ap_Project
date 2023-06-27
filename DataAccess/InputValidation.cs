using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccess
{
    public class InputValidation
    {
        public static bool NameValidation(string name)
        {
            Regex regex = new Regex("^[a-zA-Z]{3,32}$");
            if (regex.IsMatch(name))
                return true;
            return false;
        }
        public static bool EmailValidation(string email)
        {
            Regex regex = new Regex("^([a-zA-Z]{3,32})@[a-z A-Z]{3,32}.([a-zA-z]){2,3}$");
            if (regex.IsMatch(email))
                return true;
            return false;
        }
        public static bool PhoneValidation(string phone)
        {
            Regex regex = new Regex("^09[0-9]{9}$");
            if (regex.IsMatch(phone))
                return true;
            return false;
        }
        public static bool EmployeePasswordValidation(string password)
        {
            Regex regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]){8,32}$");
            if (regex.IsMatch(password))
                return true;
            return false;
        }
        public static bool PersonIDValidation(string personID)
        {
            Regex regex = new Regex("^[0-9]{2}9[0-9]{2}$");
            if (regex.IsMatch(personID))
                return true;
            return false;
        }
        public static bool SSN_Validation(string ssn)
        {
            Regex regex = new Regex("^00[0-9]{8}$");
            if (regex.IsMatch(ssn))
                return true;
            return false;
        }
    }
}
