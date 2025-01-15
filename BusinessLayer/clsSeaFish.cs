using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tiier
{
    public class clsSeaFish:clsGeneralTopping
    {

        public int SeaFishID { get; set; }

        public clsSeaFish()
        {
            SeaFishID = -1;

        }

        public clsSeaFish(int SeaFishID, string Name, float Price, string Image) : base(Name, Price, Image)
        {
            this.SeaFishID = SeaFishID;
        }


        private bool _AddNewSeaFish()
        {
            this.SeaFishID = clsSeaFichDataAccess.AddNewSeaFishToppings(this.Name, this.Price, this.Image);
            return (SeaFishID != -1);
        }

        private bool _UpdateSeaFish()
        {
            return clsSeaFichDataAccess.UpdateSeaFish(this.SeaFishID, this.Name, this.Price, this.Image);
        }

        public bool Save()
        {
            //Because of inheritance first we call the save method in the base class,
            //it will take care of adding all information to the application table.
            base.Mode = (clsFruitToppings.enMode)Mode;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewSeaFish())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateSeaFish();

            }

            return false;

        }



        public float GetSeaFishPrice()
        {
            return clsSeaFichDataAccess.GetSeaFishIDPrice(this.SeaFishID);
        }


        public static float GetSeaFishPrice(int SeaFishID)
        {
            return clsSeaFichDataAccess.GetSeaFishIDPrice(SeaFishID);
        }

        public clsSeaFish GetSeaFishInfo()
        {
            string Name = "", Image = "";
            float Price = 0;

            bool IsSeaFishFound = clsSeaFichDataAccess.GetSeaFichsInformationByID(this.SeaFishID, ref Name, ref Price, ref Image);

            if (IsSeaFishFound)
            {
                return new clsSeaFish(this.SeaFishID, Name, Price, Image);
            }
            else
                return null;


        }

        public static clsSeaFish GetMeatInfoByID(int SeaFishID)
        {
            string Name = "", Image = "";
            float Price = 0;

            bool IsSeaFishFound = clsSeaFichDataAccess.GetSeaFichsInformationByID(SeaFishID, ref Name, ref Price, ref Image);

            if (IsSeaFishFound)
            {
                return new clsSeaFish(SeaFishID, Name, Price, Image);
            }
            else
                return null;


        }


        public static clsSeaFish GetSeaFishInfoByName(string Name)

        {
            string Image = "";
            int MeatID = -1;
            float Price = 0;

            bool IsSeaFishFound = clsSeaFichDataAccess.GetSeaFichsInformationByNmae(Name, ref MeatID, ref Price, ref Image);

            if (IsSeaFishFound)
            {
                return new clsSeaFish(MeatID, Name, Price, Image);
            }
            else
                return null;

        }

        public static DataTable GetAllSeaFish()
        {
            return clsSeaFichDataAccess.GetAllSeaFish();
        
        }
    
    }
}
