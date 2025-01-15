using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tiier
{
    public class clsManDelivery
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;
        public int ManDeliveryID { get; set; }
        public int PersonID { get; set; }
        public string Note { get; set; }
        public int OrderDelivery { get; set; }
        public clsEmployee EmployeeInfo { get; set; }

        public clsManDelivery()
        {
            this.ManDeliveryID = -1;
            this.PersonID = -1;
            this.Note = "";
            this.OrderDelivery = 0;
            Mode = enMode.AddNew;
        
        }

        public clsManDelivery(int ManDelivery, int PersonID, string Note, int OrderDelivery)
        {
            this.ManDeliveryID = ManDelivery;
            this.PersonID = PersonID;
            this.Note = Note;
            this.OrderDelivery = OrderDelivery;
            this.EmployeeInfo = clsEmployee.FindEmployee(PersonID);
            Mode = enMode.Update;
        
        }

        private bool _AddNewManDelivry()
        {
            this.ManDeliveryID = DataAccess.clsManDelivery.AddNewManDelivery(this.PersonID, this.Note, this.OrderDelivery);
            return (this.ManDeliveryID != -1);
        
        }
        private bool _UpdateManDelivery()
        {
            return DataAccess.clsManDelivery.UpdateManDelivery(this.ManDeliveryID, this.PersonID, this.Note, this.OrderDelivery);
        
        }

        public bool AddOrderDelviry()
        {
            return DataAccess.clsManDelivery.AddAnOrderToManDelivery(this.ManDeliveryID);
        }

        public static bool AddOrderToDeliveryMan(int DeliveryManID)
        {
            return DataAccess.clsManDelivery.AddAnOrderToManDelivery(DeliveryManID);

        }

        public bool Delete()
        {
            return DataAccess.clsManDelivery.DeleteDeliveryMan(this.ManDeliveryID);
        }

        public static bool DeleteManDelivery(int ManDelivery)
        {
            return DataAccess.clsManDelivery.DeleteDeliveryMan(ManDelivery);
        }

        public static clsManDelivery FindDeliveryManByID(int DeliveryManID)
        {
            int PersonID = -1, DeliveryOrders = 0;
            string Note = "";

            bool IsFound = DataAccess.clsManDelivery.GetManDeliveryInfoBYID(DeliveryManID, ref PersonID, ref Note, ref DeliveryOrders);
            if (IsFound)
            {
                return new clsManDelivery(DeliveryManID, PersonID, Note, DeliveryOrders);

            }

            else
                return null;
        
        }

        public static clsManDelivery FindDeliveryManByPersonID(int PerosnID)
        {
            int DelivryManID = -1, DeliveryOrders = 0;
            string Note = "";

            bool IsFound = DataAccess.clsManDelivery.GetManDeliveryInfoPersonID(PerosnID, ref DelivryManID, ref Note, ref DeliveryOrders);
            if (IsFound)
            {
                return new clsManDelivery(DelivryManID, PerosnID, Note, DeliveryOrders);

            }

            else
                return null;

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewManDelivry())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    else
                        return false;

                case enMode.Update:

                    return _UpdateManDelivery();
            
            }

            return false;
        
        }
    
   
    
    }
}
