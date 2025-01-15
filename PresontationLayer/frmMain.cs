using PizzaProject.GlobalClasses;
using PizzaProject.Orders.ActiveOrderForCustmer;
using PizzaProject.Pizza;
using PizzaProject.Riviews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaProject
{
    public partial class frmMain : Form
    {
      
        public frmMain()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string PizzaCategory = "Vegetables";
            FrmSendPizza frm = new FrmSendPizza(PizzaCategory);
            frm.ShowDialog();
            frmMain_Load(null, null);
        }

        private void fruitPizzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string PizzaCategory = "Fruits";
            FrmSendPizza frm = new FrmSendPizza(PizzaCategory);
            frm.ShowDialog();
            frmMain_Load(null, null);
        }

        private void meatPizzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string PizzaCategory = "Meats";
            FrmSendPizza frm = new FrmSendPizza(PizzaCategory);
            frm.ShowDialog();
            frmMain_Load(null, null);
        }
        
        private void seaFishPizzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            string PizzaCategory = "SeaFichs";
            FrmSendPizza frm = new FrmSendPizza(PizzaCategory);
            frm.ShowDialog();

            frmMain_Load(null, null);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblCountOrders.Text = clsCurrentCustmer.CurrentCustmer.GetNumberOfActiveOrders().ToString();
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsCurrentCustmer.CurrentCustmer == null)
            {
                MessageBox.Show("You Have A Problem In Current Custmer");
                return;
            }
            else
            {
                frmActiveOrderForACustmer fr = new frmActiveOrderForACustmer(clsCurrentCustmer.CurrentCustmer.CustmerID);
                fr.ShowDialog();
            }
        }

        private void reviewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustmerReviews fr = new frmCustmerReviews();
            fr.ShowDialog();
        }
    }
}
