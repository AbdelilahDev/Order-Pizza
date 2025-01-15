namespace PizzaProject.Riviews
{
    partial class frmCustmerReviews
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
            this.ctrCustmerReview1 = new PizzaProject.Riviews.CtrCustmerReview();
            this.SuspendLayout();
            // 
            // ctrCustmerReview1
            // 
            this.ctrCustmerReview1.BackColor = System.Drawing.Color.White;
            this.ctrCustmerReview1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrCustmerReview1.Location = new System.Drawing.Point(10, 14);
            this.ctrCustmerReview1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrCustmerReview1.Name = "ctrCustmerReview1";
            this.ctrCustmerReview1.Size = new System.Drawing.Size(317, 358);
            this.ctrCustmerReview1.TabIndex = 0;
            // 
            // frmCustmerReviews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 386);
            this.Controls.Add(this.ctrCustmerReview1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmCustmerReviews";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reviews";
            this.ResumeLayout(false);

        }

        #endregion

        private CtrCustmerReview ctrCustmerReview1;
    }
}