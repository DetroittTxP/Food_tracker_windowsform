namespace Food_tracker
{
    partial class EditFoodForm
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
            this.txtEditFoodName = new System.Windows.Forms.TextBox();
            this.txtEditFOodid = new System.Windows.Forms.TextBox();
            this.txtEditFoodCal = new System.Windows.Forms.TextBox();
            this.txtEditFoodPro = new System.Windows.Forms.TextBox();
            this.txtEditFoodCarb = new System.Windows.Forms.TextBox();
            this.txtEditFoodFat = new System.Windows.Forms.TextBox();
            this.btnOnEdit = new System.Windows.Forms.Button();
            this.lblTest = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtEditFoodName
            // 
            this.txtEditFoodName.Location = new System.Drawing.Point(309, 86);
            this.txtEditFoodName.Name = "txtEditFoodName";
            this.txtEditFoodName.Size = new System.Drawing.Size(135, 20);
            this.txtEditFoodName.TabIndex = 0;
            // 
            // txtEditFOodid
            // 
            this.txtEditFOodid.Location = new System.Drawing.Point(309, 49);
            this.txtEditFOodid.Name = "txtEditFOodid";
            this.txtEditFOodid.Size = new System.Drawing.Size(135, 20);
            this.txtEditFOodid.TabIndex = 1;
            // 
            // txtEditFoodCal
            // 
            this.txtEditFoodCal.Location = new System.Drawing.Point(309, 123);
            this.txtEditFoodCal.Name = "txtEditFoodCal";
            this.txtEditFoodCal.Size = new System.Drawing.Size(135, 20);
            this.txtEditFoodCal.TabIndex = 2;
            this.txtEditFoodCal.TextChanged += new System.EventHandler(this.txtEditFoodCal_TextChanged);
            // 
            // txtEditFoodPro
            // 
            this.txtEditFoodPro.Location = new System.Drawing.Point(309, 158);
            this.txtEditFoodPro.Name = "txtEditFoodPro";
            this.txtEditFoodPro.Size = new System.Drawing.Size(135, 20);
            this.txtEditFoodPro.TabIndex = 3;
            // 
            // txtEditFoodCarb
            // 
            this.txtEditFoodCarb.Location = new System.Drawing.Point(309, 193);
            this.txtEditFoodCarb.Name = "txtEditFoodCarb";
            this.txtEditFoodCarb.Size = new System.Drawing.Size(135, 20);
            this.txtEditFoodCarb.TabIndex = 4;
            // 
            // txtEditFoodFat
            // 
            this.txtEditFoodFat.Location = new System.Drawing.Point(309, 233);
            this.txtEditFoodFat.Name = "txtEditFoodFat";
            this.txtEditFoodFat.Size = new System.Drawing.Size(135, 20);
            this.txtEditFoodFat.TabIndex = 5;
            // 
            // btnOnEdit
            // 
            this.btnOnEdit.Location = new System.Drawing.Point(334, 273);
            this.btnOnEdit.Name = "btnOnEdit";
            this.btnOnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnOnEdit.TabIndex = 6;
            this.btnOnEdit.Text = "UPDATE";
            this.btnOnEdit.UseVisualStyleBackColor = true;
            this.btnOnEdit.Click += new System.EventHandler(this.btnOnEdit_Click);
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(572, 63);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(35, 13);
            this.lblTest.TabIndex = 7;
            this.lblTest.Text = "label1";
            // 
            // EditFoodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.btnOnEdit);
            this.Controls.Add(this.txtEditFoodFat);
            this.Controls.Add(this.txtEditFoodCarb);
            this.Controls.Add(this.txtEditFoodPro);
            this.Controls.Add(this.txtEditFoodCal);
            this.Controls.Add(this.txtEditFOodid);
            this.Controls.Add(this.txtEditFoodName);
            this.Name = "EditFoodForm";
            this.Text = "EditFoodForm";
            this.Load += new System.EventHandler(this.EditFoodForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEditFoodName;
        private System.Windows.Forms.TextBox txtEditFOodid;
        private System.Windows.Forms.TextBox txtEditFoodCal;
        private System.Windows.Forms.TextBox txtEditFoodPro;
        private System.Windows.Forms.TextBox txtEditFoodCarb;
        private System.Windows.Forms.TextBox txtEditFoodFat;
        private System.Windows.Forms.Button btnOnEdit;
        private System.Windows.Forms.Label lblTest;
    }
}