using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Tiier
{
    public class clsGeneralTopping
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;
        public string Name { get; set; }

        public float Price { get; set; }

        public string Image { get; set; }


        public clsGeneralTopping()
        {
            this.Name = "";
            this.Price = -1;
            this.Image = "";
        
        }

        public clsGeneralTopping(string Name, float Price, string Image)
        {
            this.Name = Name;
            this.Price = Price;
            this.Image = Image;
        }
    }
}
