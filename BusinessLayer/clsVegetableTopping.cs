
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tiier
{
    public class clsVegetableTopping:clsGeneralTopping
    {

        public int VegetableID { get; set; }

        public clsVegetableTopping()
        {
            VegetableID = -1;

        }

        public clsVegetableTopping(int VegetableID, string Name, float Price, string Image) : base(Name, Price, Image)
        {
            this.VegetableID = VegetableID;
        }


        private bool _AddNewVegetable()
        {
            this.VegetableID =clsVegetablesToppingsDataAccess.AddNewVegetablesToppings(this.Name, this.Price, this.Image);
            return (VegetableID != -1);
        }

        private bool _UpdateVegetable()
        {
            return clsVegetablesToppingsDataAccess.UpdateVegetables(this.VegetableID, this.Name, this.Price, this.Image);
        }

        public bool Save()
        {
            //Because of inheritance first we call the save method in the base class,
            //it will take care of adding all information to the application table.
            base.Mode = (clsFruitToppings.enMode)Mode;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewVegetable())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateVegetable();

            }

            return false;

        }



        public float GetVegetablePrice()
        {
            return clsVegetablesToppingsDataAccess.GetVegetablePrice(this.VegetableID);
        }


        public static float GetVegetablePrice(int VegetableID)
        {
            return clsVegetablesToppingsDataAccess.GetVegetablePrice(VegetableID);
        }

        public clsVegetableTopping GetVegtableInfo()
        {
            string Name = "", Image = "";
            float Price = 0;

            bool IsVegetableFound = clsVegetablesToppingsDataAccess.GetVegetablesInformationByID(this.VegetableID, ref Name, ref Price, ref Image);

            if (IsVegetableFound)
            {
                return new clsVegetableTopping(this.VegetableID, Name, Price, Image);
            }
            else
                return null;


        }

        public static clsVegetableTopping GetVegetableInfoByVegetableID(int VegetableID)
        {
            string Name = "", Image = "";
            float Price = 0;

            bool IsFruitFound =clsVegetablesToppingsDataAccess.GetVegetablesInformationByID(VegetableID, ref Name, ref Price, ref Image);

            if (IsFruitFound)
            {
                return new clsVegetableTopping(VegetableID, Name, Price, Image);
            }
            else
                return null;


        }


        public static clsVegetableTopping GetVegetableInfoByFruitName(string Name)

        {
            string Image = "";
            int VegetableID = -1;
            float Price = 0;

            bool IsVegetableFound =clsVegetablesToppingsDataAccess.GetVegetablesInformationByName(Name, ref VegetableID, ref Price, ref Image);

            if (IsVegetableFound)
            {
                return new clsVegetableTopping(VegetableID, Name, Price, Image);
            }
            else
                return null;

        }

        public static DataTable GetAllVegetable()
        {
            return clsVegetablesToppingsDataAccess.GetAllVegetable();
        }
    }
}
