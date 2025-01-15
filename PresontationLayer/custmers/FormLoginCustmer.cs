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

namespace PizzaProject.Custmers
{
    public partial class FormLoginCustmer : Form
    {
        clsCustmer custmer;
        public FormLoginCustmer()
        {
            InitializeComponent();
        }
        private bool _SaveNewCustmer()
        {
            string Name = txtName.Text.Trim();
            string Phone = txtPhone.Text.Trim();
            string Address = txtAddress.Text.Trim();
            custmer = new clsCustmer();
            custmer.Name = Name;
            custmer.PhoneNumber = Phone;
            custmer.Address = Address;

            return custmer.Save();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clsCustmer.IsCustmerExist(txtPhone.Text.Trim()))
            {
                clsCurrentCustmer.CurrentCustmer = clsCustmer.FindCustmer(txtPhone.Text.Trim());
                frmMain frm = new frmMain();
             
                frm.ShowDialog();
                this.Close();
            }

            else
            {
                if (_SaveNewCustmer())
                {
                    clsCurrentCustmer.CurrentCustmer =custmer;


                    frmMain frm = new frmMain();
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You have  a problem in custmer");
                }
            
            }
            
            
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
         

            if (string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhone, "You Should Enter Phone Number");
                return;
            }
            if (!clsValidation.ValidatePhoneNumber(txtPhone.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhone, "You Should Enter 10 Degetes");
                return;
            }

            else
            {
                errorProvider1.SetError(txtPhone, null);
            }

        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhone, "You Should Enter Phone Number");
                return;
            }
            else
            {
                errorProvider1.SetError(txtPhone, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormLoginCustmer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false; // it will close the form
           // e.Cancel = true; // it will not close the form     
        }
    }
}
