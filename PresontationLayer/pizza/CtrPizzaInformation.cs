

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using PizzaProject.GlobalClasses;
using Business_Tiier;
using PizzaOrders.Properties;

namespace PizzaProject.Pizza
{
    public partial class CtrPizzaInformation : UserControl
    {
        clsTopping ToppingInfo=new clsTopping();
        clsVegetableTopping VegetableToppingInfo;
       

        clsFruitToppings FruitToppingInfo;
       
        clsMeatTopping MeatToppingInfo;

        clsSeaFish SeaFishToppingInfo;
        int ToppingID = -1;
        string PizzaName = "";
        float TotalPrice = 0;

        public int Qauntity
        {
            get {
                return (int)nudQauntity.Value;
               }

            set
            {
                nudQauntity.Value = value;
            }
        }

        public float ToppingPrice { get; set; }

        public int GetSize
        {
            get 
            {
                if (rdbSmall.Checked)
                {
                    return 1;

                }
                else if (rdbMeduim.Checked)
                {
                    return 2;
                }
                else
                    return 3;

            
            }
        
        }

        public float Price
        {
           
            get 
            {
               
                return ToppingPrice;
            
            }
        
        }


        public CtrPizzaInformation()
        {
            InitializeComponent();
        }
        private void _DefualtInfo()
        {
            lblType.Text = "???";
            lblPrice.Text = "???";
            nudQauntity.Value = 1;
            pictureBox1.Image = Resources.LogoPizza;
            rdbSmall.Checked = true;

        
        
        }
      

        public void ChangePrice()
        {



            if (rdbSmall.Checked)
            {
                TotalPrice = (ToppingPrice * (float)nudQauntity.Value);
                lblPrice.Text = (ToppingPrice * (float)nudQauntity.Value).ToString();

            }

            if (rdbMeduim.Checked)
            {
                TotalPrice =(float) (ToppingPrice * 1.5 * (float)nudQauntity.Value);
                lblPrice.Text = (ToppingPrice*1.5*(float)nudQauntity.Value).ToString();
            }

            if (rdbLarg.Checked)
            {
                TotalPrice = (ToppingPrice * 2 * (float)nudQauntity.Value);

                lblPrice.Text = (ToppingPrice *2*(float)nudQauntity.Value).ToString();
            }


        }

        private void _LoadFruitPizza()
        {
            PizzaName = FruitToppingInfo.Name;
            lblType.Text = FruitToppingInfo.Name;
            ToppingPrice = FruitToppingInfo.Price;
            lblPrice.Text = ToppingPrice.ToString();
            string ImagePath = FruitToppingInfo.Image;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                 pictureBox1.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ToppingInfo.FruitID = ToppingID;
            ToppingInfo.MeatID = -1;
            ToppingInfo.VegtableID = -1;
            ToppingInfo.SeaFishID = -1;
            

        }
        private void _LoadVegetablePizza()
        {
            PizzaName = VegetableToppingInfo.Name;
            lblType.Text = VegetableToppingInfo.Name;
            ToppingPrice = VegetableToppingInfo.Price;
            lblPrice.Text =ToppingPrice.ToString();
            string ImagePath = VegetableToppingInfo.Image;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pictureBox1.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            ToppingInfo.VegtableID = ToppingID;
            ToppingInfo.FruitID = -1;
            ToppingInfo.MeatID = -1;
            ToppingInfo.SeaFishID = -1;
        }


        private void _LoadMeatPizza()
        {
            PizzaName = MeatToppingInfo.Name;
            lblType.Text = MeatToppingInfo.Name;
            ToppingPrice = MeatToppingInfo.Price;
            lblPrice.Text =ToppingPrice.ToString();
            string ImagePath = MeatToppingInfo.Image;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pictureBox1.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            ToppingInfo.MeatID = ToppingID;
            ToppingInfo.FruitID = -1;
            ToppingInfo.SeaFishID = -1;
            ToppingInfo.VegtableID = -1;
        }

        private void _LoadSeaFoodPizza()
        {
            PizzaName = SeaFishToppingInfo.Name;
            lblType.Text = SeaFishToppingInfo.Name;
            ToppingPrice= SeaFishToppingInfo.Price;
            lblPrice.Text = ToppingPrice.ToString();
            string ImagePath = SeaFishToppingInfo.Image;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pictureBox1.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            ToppingInfo.SeaFishID = ToppingID;
            ToppingInfo.MeatID = -1;
            ToppingInfo.FruitID = -1;
            ToppingInfo.VegtableID = -1;

        }




        public void FindPizza(string ToppingName,int ToppingID)
        {
            this.ToppingID = ToppingID;
            switch (ToppingName.Trim())
            {
                      case "Fruits":
                
                        FruitToppingInfo = clsFruitToppings.GetFruitInfoByFruitID(ToppingID);
                        _LoadFruitPizza();
                       break;
                case "Vegetables":
               
                    VegetableToppingInfo = clsVegetableTopping.GetVegetableInfoByVegetableID(ToppingID);
                    _LoadVegetablePizza();
                    break;

                case "Meats":
                    
                    MeatToppingInfo = clsMeatTopping.GetMeatInfoByMeatID(ToppingID);
                    _LoadMeatPizza();
                    break;

                case "SeaFichs":
               
                    SeaFishToppingInfo = clsSeaFish.GetMeatInfoByID(ToppingID);
                    _LoadSeaFoodPizza();
                    break;

                default:
                    _DefualtInfo();
                    break;




            }

        }

        private void btnSendOrder_Click(object sender, EventArgs e)
        {

            ChangePrice();
          if (! ToppingInfo.Save())
           {
                MessageBox.Show("Topping Information Not Saved Seccufuully");
                return;
            
           }
            clsPizza Pizza = new clsPizza();
            Pizza.Size =(clsPizza.enSize) GetSize;
            Pizza.Quantity = Qauntity;
            Pizza.ToppingID = ToppingInfo.ToppingID;
            Pizza.PizzaName = PizzaName;
            Pizza.Price = TotalPrice;

           

             if (!Pizza.Save())
            {
                MessageBox.Show("the Pizza Not Saved Seccffully");
                if (!ToppingInfo.DeleteTopping())
                {
                    MessageBox.Show("The Topping Created Before And Not Deleted"); ;

                }
                return;
            }
            clsOrder order = new clsOrder();
            order.CustmerID = clsCurrentCustmer.CurrentCustmer.CustmerID;
            order.Status = 1;
            order.TotalPrice = Pizza.Price;
            order.PizzaID = Pizza.PizzaID;
            
          


            if (order.Save())
            { 

                lblOrderNumber.Text = order.OrderID.ToString();
                MessageBox.Show("Your Order Send Seccuffully Number Order IS: " + order.OrderID.ToString());
            }
            else
            { 

                MessageBox.Show("Your Order Not Send Seccuffully Number ");
                if (!Pizza.DeletePizza())
                {
                    MessageBox.Show("Pizza Created Before You Not Deleted ");

                }
            }




        }

        private void CtrPizzaInformation_Load(object sender, EventArgs e)
        {

        }

        private void rdbMeduim_CheckedChanged(object sender, EventArgs e)
        {
            ChangePrice();
        }

        private void rdbLarg_CheckedChanged(object sender, EventArgs e)
        {
            ChangePrice();
        }

        private void rdbSmall_CheckedChanged(object sender, EventArgs e)
        {

            ChangePrice();
        }

        private void nudQauntity_ValueChanged(object sender, EventArgs e)
        {
           if(rdbSmall.Checked)
            lblPrice.Text = ((float)(nudQauntity.Value)*ToppingPrice ).ToString();
            if (rdbMeduim.Checked)
                lblPrice.Text = ((float)(nudQauntity.Value) * (ToppingPrice*1.5)).ToString();
            if (rdbLarg.Checked)
                lblPrice.Text = ((float)(nudQauntity.Value) * (ToppingPrice * 2)).ToString();

        }
    }
}
