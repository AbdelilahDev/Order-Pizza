using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tiier
{
 
   
    public class clsFruitToppings:clsGeneralTopping
    {
        public int FruitID { get; set; }

      public  clsFruitToppings()
        {
            FruitID = -1;
            
        }

        public clsFruitToppings(int FruitID, string Name, float Price, string Image) : base(Name, Price, Image)
        {
            this.FruitID = FruitID;
        }


        private bool _AddNewFruit()
        {
            this.FruitID = clsFruitToppingsDataAccess.AddNewFruitToppings(this.Name, this.Price,this.Image);
            return (FruitID != -1);
        }

        private bool _UpdateFruit()
        {
            return clsFruitToppingsDataAccess.UpdateFruit(this.FruitID, this.Name, this.Price, this.Image);
        }

        public bool Save()
        {
                  //Because of inheritance first we call the save method in the base class,
           //it will take care of adding all information to the application table.
            base.Mode = (clsFruitToppings.enMode) Mode;
      
            switch (Mode)
            {
                  case enMode.AddNew:
                    if (_AddNewFruit())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateFruit();

            }

            return false;
        
        }



        public float GetFruitPrice()
        {
         return   clsFruitToppingsDataAccess.GetFruitPrice(this.FruitID);
        }


        public static float GetFruitPrice(int FruitID)
        { 
         return   clsFruitToppingsDataAccess.GetFruitPrice(FruitID);
        }

        public  clsFruitToppings GetFruitInfo()
        {
            string Name = "", Image = "";
            float Price = 0;

            bool IsFruitFound = clsFruitToppingsDataAccess.GetFruitInformationByID(this.FruitID, ref Name, ref Price, ref Image);

            if (IsFruitFound)
            {
                return new clsFruitToppings(this.FruitID, Name, Price, Image);
            }
            else
                return null;


        }

        public static  clsFruitToppings GetFruitInfoByFruitID(int FruitID)
        {
            string Name = "", Image = "";
            float Price = 0;

            bool IsFruitFound = clsFruitToppingsDataAccess.GetFruitInformationByID(FruitID, ref Name, ref Price, ref Image);

            if (IsFruitFound)
            {
                return new clsFruitToppings(FruitID, Name, Price, Image);
            }
            else
                return null;


        }


        public static clsFruitToppings GetFruitInfoByFruitName(string Name)

        {
            string Image = "";
            int FruitID = -1;
            float Price = 0;

            bool IsFruitFound = clsFruitToppingsDataAccess.GetFruitInformationName(Name, ref FruitID, ref Price, ref Image);

            if (IsFruitFound)
            {
                return new clsFruitToppings(FruitID, Name, Price, Image);
            }
            else
                return null;

        }


        public static DataTable GetAllFruit()
        {

            return clsFruitToppingsDataAccess.GetAllFruit();
        }
    }
}
