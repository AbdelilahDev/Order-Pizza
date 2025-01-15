using Business_Tiier;
using PizzaProject.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaProject.Riviews
{
    public partial class CtrCustmerReview : UserControl
    {
 
        public clsOrder OrderInfo;
        public clsReview ReveiwInfo=new clsReview();
        public string GetDeliveryReview
        {
            get
             {
                return cmbDelivery.SelectedItem.ToString();
             }
        }

        public string GetPizzaRiview
        {
            get
            {
                return cmbPizza.SelectedItem.ToString();
            }

        }
        public CtrCustmerReview()
        {
            InitializeComponent();
        }
        private bool _FindOrder(int orderID)
        {
            if (clsOrder.FindOrder(orderID) != null)
            {

                OrderInfo = clsOrder.FindOrder(orderID);
                return true;
            }
            else
            
                return false;
        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }
            int OrderID = int.Parse(txtOrderNumber.Text.Trim());
            if (_FindOrder(OrderID))
            {
                grbReviewItems.Enabled = true;
                cmbDelivery.SelectedIndex = 0;
                cmbPizza.SelectedIndex = 0;
                btnSave.Enabled = true;
            }
            else
            {
                MessageBox.Show("This Order Not Found");
                txtOrderNumber.Clear();
                grbReviewItems.Enabled = false;
                btnSave.Enabled = false;

            }
        }

        private void txtOrderNumber_KeyPress(object sender, KeyPressEventArgs e) 
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                button1.PerformClick();
            }

            //this will allow only digits if person id is selected
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ReveiwInfo.CustmerID = clsCurrentCustmer.CurrentCustmer.CustmerID;
            ReveiwInfo.OrderID = OrderInfo.OrderID;
            ReveiwInfo.Delevry = GetDeliveryReview;
            ReveiwInfo.Pizza = GetPizzaRiview;
            if (ReveiwInfo.Save())
            {
                MessageBox.Show("Your Reveiw Send Seccuffuly We Will Respond You as Possible soon time");


            }
            else
            {
                MessageBox.Show("Your Reveiw Not Send Seccuffuly ");



            }

        }

        private void txtOrderNumber_Validating(object sender, CancelEventArgs e)
        {
            if (txtOrderNumber.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtOrderNumber, "You Need To Enter Number Of Order");

            }

            else
            {
                errorProvider1.SetError(txtOrderNumber,null);

            }
        }
    }
}
