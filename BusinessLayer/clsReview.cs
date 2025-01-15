using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tiier
{
    public class clsReview
    {

        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;

        public int ReviewID { get; set; }
        public int CustmerID { get; set; }
        public int OrderID { get; set; }
        public string Delevry { get; set; }
        public string Pizza { get; set; }
        public DateTime date { get; set; }
        public clsReview()
        {
            this.ReviewID = -1;
            this.CustmerID = -1;
            this.OrderID = -1;
            this.Delevry = "";
            this.Pizza = "";
            this.date = DateTime.Now;
            Mode = enMode.AddNew;
        
        
        }


        public clsReview(int ReviewID, int CustmerID, int OrderID, string Delevry, string Pizza)
        {
            this.ReviewID = ReviewID;
            this.CustmerID = CustmerID;
            this.OrderID = OrderID;
            this.Delevry = Delevry;
            this.Pizza = Pizza;
            this.date = DateTime.Now;
            Mode = enMode.Update;
        
        
        }

        private bool _AddNewReview()
        {
            this.ReviewID = clsReviewsDataAccess.AddNewReview(this.CustmerID, this.OrderID, this.Delevry, this.Pizza,this.date);
            return (this.ReviewID != -1);
        
        }


        private bool _UpdateReview()
        {
            return clsReviewsDataAccess.UpdateReview(this.ReviewID, this.OrderID, this.Delevry, this.Pizza);
        
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
              if (_AddNewReview())
            {
                Mode = enMode.Update;
                return true;
            }
            else
            {
                return false;
            }
                case enMode.Update:
                    return _UpdateReview();

            
            }
            return false;
        
        
        }
    
    }
}
