namespace PizzaProject.Orders.ActiveOrderForCustmer
{
    partial class frmActiveOrderForACustmer
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvOrdreListForOneCustmer = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.la = new System.Windows.Forms.Label();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdreListForOneCustmer)).BeginInit();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(162, 3);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(143, 29);
            this.label.TabIndex = 1;
            this.label.Text = "Pizza Shop";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PizzaOrders.Properties.Resources.PizzaLogaf;
            this.pictureBox1.Location = new System.Drawing.Point(163, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dgvOrdreListForOneCustmer
            // 
            this.dgvOrdreListForOneCustmer.AllowUserToAddRows = false;
            this.dgvOrdreListForOneCustmer.AllowUserToDeleteRows = false;
            this.dgvOrdreListForOneCustmer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvOrdreListForOneCustmer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdreListForOneCustmer.GridColor = System.Drawing.Color.White;
            this.dgvOrdreListForOneCustmer.Location = new System.Drawing.Point(0, 174);
            this.dgvOrdreListForOneCustmer.MultiSelect = false;
            this.dgvOrdreListForOneCustmer.Name = "dgvOrdreListForOneCustmer";
            this.dgvOrdreListForOneCustmer.ReadOnly = true;
            this.dgvOrdreListForOneCustmer.Size = new System.Drawing.Size(468, 133);
            this.dgvOrdreListForOneCustmer.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Orders";
            // 
            // la
            // 
            this.la.AutoSize = true;
            this.la.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.la.Location = new System.Drawing.Point(2, 309);
            this.la.Name = "la";
            this.la.Size = new System.Drawing.Size(175, 29);
            this.la.TabIndex = 4;
            this.la.Text = "Total Orders: ";
            // 
            // lblTotalOrders
            // 
            this.lblTotalOrders.AutoSize = true;
            this.lblTotalOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalOrders.Location = new System.Drawing.Point(167, 310);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(65, 29);
            this.lblTotalOrders.TabIndex = 5;
            this.lblTotalOrders.Text = "????";
            // 
            // frmActiveOrderForACustmer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(468, 343);
            this.Controls.Add(this.lblTotalOrders);
            this.Controls.Add(this.la);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvOrdreListForOneCustmer);
            this.Controls.Add(this.label);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmActiveOrderForACustmer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Your Active Orders";
            this.Load += new System.EventHandler(this.frmActiveOrderForACustmer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdreListForOneCustmer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.DataGridView dgvOrdreListForOneCustmer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label la;
        private System.Windows.Forms.Label lblTotalOrders;
    }
}