using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tiier
{
   public class clsTopping
    {

        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;
      
        public int ToppingID { get; set; }
        public int VegtableID { get; set; }
        public int FruitID { get; set; }
        public int MeatID { get; set; }
        public int SeaFishID { get; set; }

       public string GetToppingName
        {
            get 
            {
                if (VegtableID != -1)
                {
                    return clsVegetableTopping.GetVegetableInfoByVegetableID(VegtableID).Name;
                }

                if(FruitID !=-1)
                {
                    return clsFruitToppings.GetFruitInfoByFruitID(FruitID).Name;
                }

                if (MeatID != -1)
                {
                    return clsMeatTopping.GetMeatInfoByMeatID(MeatID).Name;
                }

                if (SeaFishID != -1)
                {
                    return clsSeaFish.GetMeatInfoByID(MeatID).Name;

                }

                else
                    return "Unownk";

            }
        
        }
 
        clsVegetableTopping ToppingVegetableInfo;
        clsFruitToppings    ToppingFruitInfo;
        clsMeatTopping      ToppingMeatInfo;
        clsSeaFish          ToppingSeaFishInfo;

        public clsTopping()
        {
            this.ToppingID =-1;
         
           
         
        }

        public clsTopping(int ToppingID,int VegetableID,int FruitID,int MeatID,int SeaFishID)
        {
            this.ToppingID = ToppingID;
            if (VegetableID != -1)
            {
                ToppingVegetableInfo = clsVegetableTopping.GetVegetableInfoByVegetableID(VegetableID);
            }

            if (FruitID != -1)
            {

                ToppingFruitInfo = clsFruitToppings.GetFruitInfoByFruitID(FruitID);
            }

            if (MeatID != -1)
            {
                ToppingMeatInfo = clsMeatTopping.GetMeatInfoByMeatID(MeatID);
            }

            if (SeaFishID != -1)
            {
                ToppingSeaFishInfo = clsSeaFish.GetMeatInfoByID(SeaFishID);
            }
            Mode = enMode.Update;
        
        }

        private bool _AddNewTopping()
        {
            this.ToppingID = clsToppingDataAccess.AddNewTopping(this.VegtableID,this.FruitID, this.MeatID,this.SeaFishID);
            return (this.ToppingID != -1);

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTopping())
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

        public static clsTopping GetToppingInfoByID(int ToppingID)
        {
             int VegetaID = -1,FruitID=-1,MeatID=-1,SeaFishID=-1;

            bool IsFound = clsToppingDataAccess.GetToppingInfoByID(ToppingID, ref VegetaID, ref FruitID, ref MeatID, ref SeaFishID); ;

            if (IsFound)
            {

                return new clsTopping(ToppingID, VegetaID, FruitID, MeatID, SeaFishID);
            }
            else
                return null;
        
        
        }


        public bool DeleteTopping()
        {
         return   clsToppingDataAccess.DeleteTopping(this.ToppingID);
        }

        public static bool DeleteTopping(int ToppingID)
        {
            return clsToppingDataAccess.DeleteTopping(ToppingID);
        }
    }
}
