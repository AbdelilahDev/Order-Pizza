using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tiier
{
    public class clsPizza
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;

        public enum enSize { Small=1,Medium=2,Larg=3}

        public enSize Size;

       
        public int PizzaID { get; set; }
        public int ToppingID { get; set; }
        public int Quantity { get; set; }
        public clsTopping ToppingInfo;
        public float Price { get; set; }
        public string PizzaName { get; set; }

 

        public clsPizza()
        {
            this.PizzaID = -1;
            this.ToppingID = -1;
            this.Quantity = -1;
            this.Price = -1;
            this.PizzaName = "";
        
        }

        public clsPizza(int PizzaID, int ToppingID, int Qauntity, int Size, float Price,string PizzaName)
        {
            this.PizzaID = PizzaID;
            this.ToppingID = ToppingID;
            ToppingInfo = clsTopping.GetToppingInfoByID(ToppingID);
            this.Quantity = Qauntity;
            this.PizzaName = PizzaName;
            this.Size = (enSize)Size;
            this.Price = Price;
        }

        private bool _AddNewPizza()
        {
            this.PizzaID = clsPizzaDataAccess.AddNewPizza(this.ToppingID,this.Quantity,(int) this.Size,this.Price,this.PizzaName);
            return (this.PizzaID != -1);

        }

       public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPizza())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
              
            }
            return false;

        }

        public static clsPizza GetPizzInformation(int PizzaID)
        {
            int ToppiingID = -1, Qauntity = -1,Size=-1;
            float Price = -1;
            string PizzaName = "";
            bool IsFound = clsPizzaDataAccess.GetPizzaInformationByID(PizzaID, ref ToppiingID, ref Qauntity, ref Size, ref Price,ref PizzaName);
            if (IsFound)
            {
                return new clsPizza(PizzaID, ToppiingID, Qauntity, Size, Price,PizzaName);
            }
            else
                return null;

        
        }


        public bool DeletePizza()
        {
            return clsPizzaDataAccess.DeletePizza(this.PizzaID);
        }
        public static bool DeletePizza(int PizzaID)
        {
            return clsPizzaDataAccess.DeletePizza(PizzaID);
        }

    }
}
