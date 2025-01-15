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

namespace PizzaProject.Orders.ActiveOrderForCustmer
{
    public partial class frmActiveOrderForACustmer : Form
    {
        private int CustmerID = -1;
        DataTable ActiveOrderForOneCustmer = null;
        public frmActiveOrderForACustmer(int CustmersID)
        {
            InitializeComponent();
            this.CustmerID = CustmersID;
            ActiveOrderForOneCustmer = clsCustmer.GetAllActiveOrders(this.CustmerID);

        }

        private void frmActiveOrderForACustmer_Load(object sender, EventArgs e)
        {
            dgvOrdreListForOneCustmer.DataSource = ActiveOrderForOneCustmer;
           lblTotalOrders.Text = dgvOrdreListForOneCustmer.Rows.Count.ToString();
            if (dgvOrdreListForOneCustmer.Rows.Count > 0)
            {

                dgvOrdreListForOneCustmer.Columns[0].HeaderText = "Order Number";
                dgvOrdreListForOneCustmer.Columns[0].Width = 130;

                dgvOrdreListForOneCustmer.Columns[1].HeaderText = "Order Status";
                dgvOrdreListForOneCustmer.Columns[1].Width = 130;

                dgvOrdreListForOneCustmer.Columns[2].HeaderText = "Pizza Name";
                dgvOrdreListForOneCustmer.Columns[2].Width = 130;

                dgvOrdreListForOneCustmer.Columns[3].HeaderText = "Qty";
                dgvOrdreListForOneCustmer.Columns[3].Width = 50;

                dgvOrdreListForOneCustmer.Columns[4].HeaderText = "Size";
                dgvOrdreListForOneCustmer.Columns[4].Width = 100;

                dgvOrdreListForOneCustmer.Columns[5].HeaderText = "Price";
                dgvOrdreListForOneCustmer.Columns[5].Width = 100;


                dgvOrdreListForOneCustmer.Columns[6].HeaderText = "Custmer Name";
                dgvOrdreListForOneCustmer.Columns[6].Width = 130;


                dgvOrdreListForOneCustmer.Columns[7].HeaderText = "Phone";
                dgvOrdreListForOneCustmer.Columns[7].Width = 100;

                dgvOrdreListForOneCustmer.Columns[8].HeaderText = "Address";
                dgvOrdreListForOneCustmer.Columns[8].Width = 100;


            }

     
        }
    }
}
