namespace PizzaProject.Pizza
{
    partial class CtrPizzaInformation
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.nudQauntity = new System.Windows.Forms.NumericUpDown();
            this.rdbSmall = new System.Windows.Forms.RadioButton();
            this.rdbMeduim = new System.Windows.Forms.RadioButton();
            this.rdbLarg = new System.Windows.Forms.RadioButton();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSendOrder = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudQauntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Size: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Price: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Qauntity: ";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(96, 55);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(32, 18);
            this.lblType.TabIndex = 5;
            this.lblType.Text = "???";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(96, 204);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(16, 18);
            this.lblPrice.TabIndex = 8;
            this.lblPrice.Text = "0";
            // 
            // nudQauntity
            // 
            this.nudQauntity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudQauntity.Location = new System.Drawing.Point(97, 147);
            this.nudQauntity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQauntity.Name = "nudQauntity";
            this.nudQauntity.Size = new System.Drawing.Size(43, 24);
            this.nudQauntity.TabIndex = 9;
            this.nudQauntity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudQauntity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQauntity.ValueChanged += new System.EventHandler(this.nudQauntity_ValueChanged);
            // 
            // rdbSmall
            // 
            this.rdbSmall.AutoSize = true;
            this.rdbSmall.Checked = true;
            this.rdbSmall.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSmall.Location = new System.Drawing.Point(92, 98);
            this.rdbSmall.Name = "rdbSmall";
            this.rdbSmall.Size = new System.Drawing.Size(63, 22);
            this.rdbSmall.TabIndex = 10;
            this.rdbSmall.TabStop = true;
            this.rdbSmall.Text = "Small";
            this.rdbSmall.UseVisualStyleBackColor = true;
            this.rdbSmall.CheckedChanged += new System.EventHandler(this.rdbSmall_CheckedChanged);
            // 
            // rdbMeduim
            // 
            this.rdbMeduim.AutoSize = true;
            this.rdbMeduim.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMeduim.Location = new System.Drawing.Point(166, 98);
            this.rdbMeduim.Name = "rdbMeduim";
            this.rdbMeduim.Size = new System.Drawing.Size(55, 22);
            this.rdbMeduim.TabIndex = 11;
            this.rdbMeduim.Text = "Med";
            this.rdbMeduim.UseVisualStyleBackColor = true;
            this.rdbMeduim.CheckedChanged += new System.EventHandler(this.rdbMeduim_CheckedChanged);
            // 
            // rdbLarg
            // 
            this.rdbLarg.AutoSize = true;
            this.rdbLarg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbLarg.Location = new System.Drawing.Point(241, 98);
            this.rdbLarg.Name = "rdbLarg";
            this.rdbLarg.Size = new System.Drawing.Size(55, 22);
            this.rdbLarg.TabIndex = 12;
            this.rdbLarg.Text = "Larg";
            this.rdbLarg.UseVisualStyleBackColor = true;
            this.rdbLarg.CheckedChanged += new System.EventHandler(this.rdbLarg_CheckedChanged);
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNumber.Location = new System.Drawing.Point(145, 7);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(32, 18);
            this.lblOrderNumber.TabIndex = 14;
            this.lblOrderNumber.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(2, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 24);
            this.label6.TabIndex = 13;
            this.label6.Text = "OrderNumber: ";
            // 
            // btnSendOrder
            // 
            this.btnSendOrder.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSendOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendOrder.ForeColor = System.Drawing.Color.Black;
            this.btnSendOrder.Location = new System.Drawing.Point(148, 241);
            this.btnSendOrder.Name = "btnSendOrder";
            this.btnSendOrder.Size = new System.Drawing.Size(166, 48);
            this.btnSendOrder.TabIndex = 15;
            this.btnSendOrder.Text = "Send Order";
            this.btnSendOrder.UseVisualStyleBackColor = false;
            this.btnSendOrder.Click += new System.EventHandler(this.btnSendOrder_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(328, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 179);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // CtrPizzaInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnSendOrder);
            this.Controls.Add(this.lblOrderNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rdbLarg);
            this.Controls.Add(this.rdbMeduim);
            this.Controls.Add(this.rdbSmall);
            this.Controls.Add(this.nudQauntity);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CtrPizzaInformation";
            this.Size = new System.Drawing.Size(497, 290);
            this.Load += new System.EventHandler(this.CtrPizzaInformation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudQauntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown nudQauntity;
        private System.Windows.Forms.RadioButton rdbSmall;
        private System.Windows.Forms.RadioButton rdbMeduim;
        private System.Windows.Forms.RadioButton rdbLarg;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSendOrder;
    }
}
