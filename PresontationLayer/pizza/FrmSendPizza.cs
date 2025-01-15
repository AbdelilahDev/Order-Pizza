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
    public partial class FrmSendPizza : Form
    {
        string PizzaCategory = "";
        public FrmSendPizza(string PizzaCategory)
        {
            InitializeComponent();
            this.PizzaCategory = PizzaCategory;
            
        }

        private void FrmSendPizza_Load(object sender, EventArgs e)
        {
            ctrFindPizza1.FindPizza(PizzaCategory);
        }
    }
}
