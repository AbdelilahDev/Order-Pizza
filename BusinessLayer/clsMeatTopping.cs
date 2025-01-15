using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tiier
{
    public class clsMeatTopping:clsGeneralTopping
    {

        public int MeatID { get; set; }

        public clsMeatTopping()
        {
            MeatID = -1;

        }

        public clsMeatTopping(int MeatID, string Name, float Price, string Image) : base(Name, Price, Image)
        {
            this.MeatID = MeatID;
        }


        private bool _AddNewMeat()
        {
            this.MeatID = clsMeatToppingsDataAccess.AddMeatToppings(this.Name, this.Price, this.Image);
            return (MeatID != -1);
        }

        private bool _UpdateMeat()
        {
            return clsMeatToppingsDataAccess.UpdateMeat(this.MeatID, this.Name, this.Price, this.Image);
        }

        public bool Save()
        {
            //Because of inheritance first we call the save method in the base class,
            //it will take care of adding all information to the application table.
            base.Mode = (clsFruitToppings.enMode)Mode;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewMeat())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateMeat();

            }

            return false;

        }



        public float GetMeatPrice()
        {
            return clsMeatToppingsDataAccess.GetMeatPrice(this.MeatID);
        }


        public static float GetMeatPrice(int MeatID)
        {
            return clsMeatToppingsDataAccess.GetMeatPrice(MeatID);
        }

        public clsMeatTopping GetMeatInfo()
        {
            string Name = "", Image = "";
            float Price = 0;

            bool IsVegetableFound = clsMeatToppingsDataAccess.GetMeatInformationByID(this.MeatID, ref Name, ref Price, ref Image);

            if (IsVegetableFound)
            {
                return new clsMeatTopping(this.MeatID, Name, Price, Image);
            }
            else
                return null;


        }

        public static clsMeatTopping GetMeatInfoByMeatID(int MeatID)
        {
            string Name = "", Image = "";
            float Price = 0;

            bool IsFruitFound =clsMeatToppingsDataAccess.GetMeatInformationByID(MeatID, ref Name, ref Price, ref Image);

            if (IsFruitFound)
            {
                return new clsMeatTopping(MeatID, Name, Price, Image);
            }
            else
                return null;


        }


        public static clsMeatTopping GetVegetableInfoByMeatName(string Name)

        {
            string Image = "";
            int MeatID = -1;
            float Price = 0;

            bool IsVegetableFound = clsMeatToppingsDataAccess.GetMeatInformationByName(Name, ref MeatID, ref Price, ref Image);

            if (IsVegetableFound)
            {
                return new clsMeatTopping(MeatID, Name, Price, Image);
            }
            else
                return null;

        }

        public static DataTable GetAllMeats()
        {
            return clsMeatToppingsDataAccess.GetAllMeats();
        }


    }
}
