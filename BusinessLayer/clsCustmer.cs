using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tiier
{
    public class clsCustmer
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;
        public int CustmerID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Note{ get; set; }
        public clsCustmer()
        {
            this.CustmerID = -1;
            this.Name = "";
            this.PhoneNumber = "";
            this.Address = "";
            this.Note = "";
            Mode = enMode.AddNew;
        
        }

        public clsCustmer(int CustmerID, string Name, string PhoneNumber, string Address, string Note)
        {
            this.CustmerID = CustmerID;
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;
            this.Note = Note;
            Mode = enMode.Update;
        
        
        }

        private bool _AddNewCustmer()
        {
            this.CustmerID = clsCustmerDatAcess.AddCustmer(this.Name, this.PhoneNumber, this.Address, this.Note);
            return (this.CustmerID != -1);
        
        }
        private bool _UpdateCustmer()
        {

            return clsCustmerDatAcess.UpdateCustmer(this.CustmerID, this.Name, this.PhoneNumber, this.Address, this.Note);
        
        }

        public static clsCustmer FindCustmer(string Phone)
        {
            string Name = "", Address = "", Note = "";
            int CustmerID = 0;
        
            bool IsFound = clsCustmerDatAcess.GetCusmtmerInformationByPhoneNumber(Phone, ref Name, ref CustmerID, ref Address, ref Note);

            if (IsFound)
            {
                return new clsCustmer(CustmerID, Name, Phone, Address, Note);

            }
            else
                return null;
        }

        public static clsCustmer FindCustmer(int CustmerID)
        {
            string Name = "", Address = "", Note = "",Phone="";
          

            bool IsFound = clsCustmerDatAcess.GetCusmtmerInformationByID(CustmerID, ref Name, ref Phone, ref Address, ref Note);

            if (IsFound)
            {
                return new clsCustmer(CustmerID, Name, Phone, Address, Note);

            }
            else
                return null;
        }

      public  bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCustmer())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateCustmer();
            }
            return false;
        
        }

        public static bool IsCustmerExist(string Phone)
        {
            return clsCustmerDatAcess.IsCustmerExist(Phone);
        }

        public static int GetNumberOfActiveOrders(int CustmerID)
        {
            return clsCustmerDatAcess.CountActiveOrdersForCustmer(CustmerID);
        }
        public  int GetNumberOfActiveOrders()
        {
            return clsCustmerDatAcess.CountActiveOrdersForCustmer(this.CustmerID);
        }

        public static DataTable GetAllActiveOrders(int CustmerID)
        {
            return clsCustmerDatAcess.GetActiveOrderForCustmer(CustmerID);
        
        }

        public  DataTable GetAllActiveOrders()
        {
            return clsCustmerDatAcess.GetActiveOrderForCustmer(this.CustmerID);

        }



    }
}
