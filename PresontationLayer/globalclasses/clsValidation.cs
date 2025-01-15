using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PizzaProject.GlobalClasses
{
    internal class clsValidation
    {
        public static bool ValidatePhoneNumber(string PhoneNumber)
        {

           return  Regex.Match(PhoneNumber, @"^[0-9]{10}$").Success;
       
        }

        //public static bool IsNumber(int Number)
        //{ 
        
        
        //}
    }
}
