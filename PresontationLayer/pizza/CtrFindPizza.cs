using Business_Tiier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaProject.Pizza
{
    public partial class CtrFindPizza : UserControl
    {
        int ToppingID = 0;
        string Category = "";
        public CtrFindPizza()
        {
            InitializeComponent();
        }
       

        private void _FillcmbToppings()
        {
           
            DataTable dt = new DataTable();

            switch (Category)
            {
               
                case "Vegetables":
                    dt = clsVegetableTopping.GetAllVegetable();
                    foreach (DataRow row in dt.Rows)
                    {
                       cmbPizzaToppings.Items.Add(row["Name".Trim()]);
                    }
                
                    break;
                case "Fruits":
                    dt = clsFruitToppings.GetAllFruit();
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbPizzaToppings.Items.Add(row["Name".Trim()]);
                    }
                    break;

                case "Meats":
                    dt = clsMeatTopping.GetAllMeats();
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbPizzaToppings.Items.Add(row["Name".Trim()]);
                    }
                    break;
                case "SeaFichs":
                    dt = clsSeaFish.GetAllSeaFish();
                    foreach (DataRow row in dt.Rows)
                    {
                        cmbPizzaToppings.Items.Add(row["Name".Trim()]);
                    }
                    break;





            }
            cmbPizzaToppings.SelectedIndex = 0;

        }

        public void FindPizza(string Category)
        {
          
            this.Category = Category;
            _FillcmbToppings();
            ToppingID = cmbPizzaToppings.SelectedIndex+1;
            ctrPizzaInformation1.FindPizza(Category, ToppingID);
        
        }

        private void cmbPizzaToppings_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToppingID = cmbPizzaToppings.SelectedIndex+1;
            ctrPizzaInformation1.FindPizza(Category, ToppingID);
            ctrPizzaInformation1.ChangePrice();
        }

        private void ctrPizzaInformation1_Load(object sender, EventArgs e)
        {

        }
    }
}
