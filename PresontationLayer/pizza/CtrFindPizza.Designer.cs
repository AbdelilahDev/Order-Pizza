namespace PizzaProject.Pizza
{
    partial class CtrFindPizza
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbFilterPizza = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPizzaToppings = new System.Windows.Forms.ComboBox();
            this.ctrPizzaInformation1 = new PizzaProject.Pizza.CtrPizzaInformation();
            this.gbFilterPizza.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilterPizza
            // 
            this.gbFilterPizza.Controls.Add(this.label1);
            this.gbFilterPizza.Controls.Add(this.cmbPizzaToppings);
            this.gbFilterPizza.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilterPizza.Location = new System.Drawing.Point(17, 5);
            this.gbFilterPizza.Name = "gbFilterPizza";
            this.gbFilterPizza.Size = new System.Drawing.Size(524, 89);
            this.gbFilterPizza.TabIndex = 0;
            this.gbFilterPizza.TabStop = false;
            this.gbFilterPizza.Text = "Find Your Pizza";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Topping";
            // 
            // cmbPizzaToppings
            // 
            this.cmbPizzaToppings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPizzaToppings.FormattingEnabled = true;
            this.cmbPizzaToppings.Location = new System.Drawing.Point(174, 34);
            this.cmbPizzaToppings.Name = "cmbPizzaToppings";
            this.cmbPizzaToppings.Size = new System.Drawing.Size(222, 32);
            this.cmbPizzaToppings.TabIndex = 0;
            this.cmbPizzaToppings.SelectedIndexChanged += new System.EventHandler(this.cmbPizzaToppings_SelectedIndexChanged);
            // 
            // ctrPizzaInformation1
            // 
            this.ctrPizzaInformation1.BackColor = System.Drawing.Color.White;
            this.ctrPizzaInformation1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrPizzaInformation1.Location = new System.Drawing.Point(17, 100);
            this.ctrPizzaInformation1.Name = "ctrPizzaInformation1";
            this.ctrPizzaInformation1.Qauntity = 1;
            this.ctrPizzaInformation1.Size = new System.Drawing.Size(524, 292);
            this.ctrPizzaInformation1.TabIndex = 1;
            this.ctrPizzaInformation1.ToppingPrice = 0F;
            this.ctrPizzaInformation1.Load += new System.EventHandler(this.ctrPizzaInformation1_Load);
            // 
            // CtrFindPizza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ctrPizzaInformation1);
            this.Controls.Add(this.gbFilterPizza);
            this.Name = "CtrFindPizza";
            this.Size = new System.Drawing.Size(545, 403);
            this.gbFilterPizza.ResumeLayout(false);
            this.gbFilterPizza.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilterPizza;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPizzaToppings;
        private CtrPizzaInformation ctrPizzaInformation1;
    }
}
