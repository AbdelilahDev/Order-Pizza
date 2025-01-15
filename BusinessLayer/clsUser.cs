using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tiier
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;
        public int PersonID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; } 
        public int Permosions { get; set; }
        public clsEmployee EmployeeInfo { get; set; }


        public clsUser()
        {
            this.PersonID = -1;
            this.UserID = -1;
            this.UserName = "";
            this.Password = "";
            this.Permosions = 0;
            Mode = enMode.AddNew;
        
        }

        public clsUser(int UserID,int PersonID,string UserName,string Password,int Permisions)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.Permosions = Permisions;
            this.EmployeeInfo = clsEmployee.FindEmployee(PersonID);
            Mode = enMode.Update;


        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserDataAcces.AddNewUser(this.UserName, this.Password, this.PersonID, this.Permosions);
            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUserDataAcces.UpdateUser(this.UserID, this.UserName, this.Password, this.PersonID, this.Permosions);
        }

        public static clsUser FindUserByUserID(int UserID)
        {
            string UserName = "", Password = "";
            int PersonID = -1, Permison = -1;

            bool IsUserFound = clsUserDataAcces.GetUserInformationByUserID(UserID, ref UserName, ref Password, ref PersonID, ref Permison);

            if (IsUserFound)
            {
                return new clsUser(UserID, PersonID, UserName, Password, Permison);
            }

            else
                return null;
        
        
        }

        public static clsUser FindUserByPersonID(int PersonID)
        {
            string UserName = "", Password = "";
            int UserID = -1, Permison = -1;

            bool IsUserFound = clsUserDataAcces.GetUserInformationByPersonID(PersonID,ref UserID, ref UserName, ref Password, ref Permison);

            if (IsUserFound)
            {
                return new clsUser(UserID, PersonID, UserName, Password, Permison);
            }

            else
                return null;


        }

        public bool DeleteUser()
        {
            return clsUserDataAcces.DeleteUser(this.UserID);
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserDataAcces.DeleteUser(UserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateUser();
            
            }

            return false;
        
        
        }
    }
}
