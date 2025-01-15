using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace Business_Tiier
{
    public class clsEmployee
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;
        public int PersonID { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public short Gender { get; set; }
        public string NationalNumber { get; set; }
        public string Image    { get; set; }
        public DateTime DateofHired { get; set; }
        public bool IsFired { get; set; }
        public DateTime DateOfFired { get; set; }
        public string FiredCause { get; set; }


        public clsEmployee()
        {
            this.PersonID = -1;
            this.FullName = "";
            this.PhoneNumber = "";
            this.Address = "";
            this.Email = "";
            this.Gender = 0;
            this.NationalNumber = "";
            this.Image = "";
            this.DateofHired = DateTime.Now;
            this.IsFired = false;
            this.DateOfFired = DateTime.MaxValue;
            this.FiredCause = "";
            Mode = enMode.AddNew;
        
        }

        public clsEmployee(int PersonID, string FullName, string PhoneNumber, string Address, string Email, short Gendre, string NationalNumber, string ImagePath,DateTime DateOfHired,bool IsFired,DateTime DateOfFired,string CauseFired)
        {
            this.PersonID =PersonID;
            this.FullName =FullName;
            this.PhoneNumber =PhoneNumber;
            this.Address =Address;
            this.Email = Email;
            this.Gender = Gendre;
            this.NationalNumber =NationalNumber;
            this.Image =ImagePath;
            this.DateofHired = DateOfHired;
            this.IsFired = IsFired;
            this.DateOfFired = DateOfFired;
            this.FiredCause = CauseFired;
            Mode = enMode.Update;

        }

        private bool _AddNewEmployee()
        {
            this.PersonID = DataAccess.clsEmployee.AddNewEmployee(this.FullName, this.PhoneNumber, this.Address, this.Email, this.Gender, this.NationalNumber, this.Image,this.DateofHired,this.IsFired,this.DateOfFired,this.FiredCause);
            return (this.PersonID != -1);
        }

        private bool _UpdateEmployee()
        {
         return DataAccess.clsEmployee.UpdateEmployee(this.PersonID,this.FullName, this.PhoneNumber, this.Address, this.Email, this.Gender, this.NationalNumber, this.Image,this.DateofHired,this.IsFired,this.DateOfFired,this.FiredCause);

        }


        public static clsEmployee FindEmployee(int PersonID)
        {
            string FullName = "", PhoneNumber = "", Address = "", Email = "", NationalNumber = "", Image = "",FiredCause="";
            short Gender = 0;
            bool IsFired = false;
            DateTime HiredDate = DateTime.Now, FiredDate = DateTime.MaxValue;

            bool IsFound = DataAccess.clsEmployee.GetEmployeeInformationByID(PersonID, ref FullName, ref PhoneNumber,
                ref Address, ref Email,ref Gender, ref NationalNumber, ref Image,ref HiredDate,ref IsFired,ref FiredDate,ref FiredCause);
            if (IsFound)
            {
                return new clsEmployee(PersonID, FullName, PhoneNumber, Address, Email, Gender, NationalNumber, Image,HiredDate,IsFired,FiredDate,FiredCause);
            }
            else
                return null;


        }
        public static clsEmployee FindEmployee(string NationalNumber)
        {
            string FullName = "", PhoneNumber = "", Address = "", Email = "", Image = "", FiredCause = "";
            short Gender = 0;
            int PersonID = 0;
            bool IsFired = false;
            DateTime HiredDate = DateTime.Now, FiredDate = DateTime.MaxValue;

            bool IsFound = DataAccess.clsEmployee.GetEmployeeInformationByNationalNumber(NationalNumber, ref PersonID, ref FullName, ref PhoneNumber,
                ref Address, ref Email, ref Gender, ref Image, ref HiredDate, ref IsFired, ref FiredDate,ref FiredCause); ;
            if (IsFound)
            {
                return new clsEmployee(PersonID, FullName, PhoneNumber, Address, Email, Gender, NationalNumber, Image,HiredDate,IsFired,FiredDate,FiredCause);
            }
            else
                return null;


        }

        bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewEmployee())
                    {
                        Mode = enMode.Update;
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateEmployee();
            
            }
            return false;
        
        }

        public bool Delete()
        {
            return DataAccess.clsEmployee.DeleteEmployee(this.PersonID);
        }

        public static bool IsPersonExist(int PersonID)
        {

            return DataAccess.clsEmployee.IsEmployeeExist(PersonID);
        }

        public bool IsEmployeeFired()
        {
            return DataAccess.clsEmployee.IsEmployeeFired(this.PersonID);
        }

        public static bool IsEmployeeFired(int PersonID)
        {

            return DataAccess.clsEmployee.IsEmployeeFired(PersonID);
        }





    }
}
