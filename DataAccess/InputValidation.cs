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
            Regex regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,32}$");
            if (regex.IsMatch(password))
                return true;
            return false;
        }
        public static bool PersonalIDValidation(string personalID)
        {
            Regex regex = new Regex("^[0-9]{2}9[0-9]{2}$");
            if (regex.IsMatch(personalID))
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
        public static bool CreditCarNumberValidation(string creditCarNumber)
        {
            int Sum = 0;
            for (int i = 1; i < creditCarNumber.Length + 1; i++)
            {
                int temp = int.Parse(creditCarNumber[i - 1].ToString());
                if (i % 2 == 0)
                {
                    temp *= 2;
                    if (temp > 9)
                        temp -= 9;
                }
                Sum += temp;
            }
            return Sum % 10 == 0;
        }

        public static bool CVVNumberValidation(string CVVNumber)
        {
            if(CVVNumber.Length != 3 && CVVNumber.Length != 4)
            {
                return false;
            }
            int res;
            bool isInt = int.TryParse(CVVNumber, out res);
            if (!isInt)
            {
                return false;
            }
            else if(res < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
