using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tiier
{
      public class clsOrder
    {

        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;

        public enum enStatus { New=1,Canceled=2,Complete=3};
        public enStatus OrderStatus;

        public enStatus enOrderStatus { get; set; }

        public string StatusText
        {
            get
            {

                switch (enOrderStatus)
                {
                    case enStatus.New:
                        return "New";
                    case enStatus.Canceled:
                        return "Cancelled";
                    case enStatus.Complete:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }

        }

        public int OrderID { get; set; }
        public int CustmerID { get; set; }
        public DateTime OrderDate { get; set; }
        public int Status { get; set; }
 
        public int PizzaID { get; set; }
 
        public float TotalPrice { get; set; }

        public clsCustmer CustmerInfo { get; set; }

          public clsPizza PizzaInfo { get; set; }




        public clsOrder()
        {
            this.OrderID = -1;
            this.CustmerID = -1;
            this.OrderDate = DateTime.Now;
            this.Status = 0;

            this.PizzaID = -1;
       
            this.TotalPrice = 0;
            Mode = enMode.AddNew;
            OrderStatus = enStatus.New;
      
        
        
        
        }


        public clsOrder(int OrderID, int CustmerID, DateTime OrderDate,
            int Status,int PizzaID ,float TotalPrice)
        {

            this.OrderID = OrderID;
            this.CustmerID =CustmerID;
            this.OrderDate = DateTime.Now;
            this.Status = Status;
      
            this.PizzaID = PizzaID;
         
            this.TotalPrice =TotalPrice;
          
            this.CustmerInfo = clsCustmer.FindCustmer(CustmerID);
          
            OrderStatus = enStatus.New;
            Mode = enMode.Update;
        }


        private bool _AddNewOrder()
        {
            this.OrderID = clsOrderDataAccess.AddNewOrder(this.CustmerID, this.OrderDate, this.Status,
                this.PizzaID, this.TotalPrice);
            return (this.OrderID != -1);
        }

        private bool _UpdateOrder()
        {
            return clsOrderDataAccess.UpdateOrder(this.OrderID, this.CustmerID,this.OrderDate, this.Status
                , this.PizzaID, this.TotalPrice); ;
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewOrder())
                    {
                        Mode = enMode.Update;
                       
                        return true;
                    }
                    else
                    {

                        return false;
                    }
                case enMode.Update:
                    return _UpdateOrder();
            
            }

            return false;
        
        }


        public static bool UpdateOrderStatus(int OrdreID, short NewStatus)
        {

            return clsOrderDataAccess.UpdateOrderStatus(OrdreID, NewStatus);
        
        }

        public static clsOrder FindOrder(int OrderID)
        {
            int PizzaID = -1, CustmerID=-1;
            int Status = -1;
             DateTime Date=DateTime.Now;
           float TotalPrice = -1;

            bool IsFound = clsOrderDataAccess.FindOrder(OrderID, ref CustmerID, ref PizzaID, ref Date, ref Status, ref TotalPrice);
            if (IsFound)
            {
                return new clsOrder(OrderID, CustmerID, Date, Status, PizzaID, TotalPrice);
            }
            else
                return null;


        }



    }
}
