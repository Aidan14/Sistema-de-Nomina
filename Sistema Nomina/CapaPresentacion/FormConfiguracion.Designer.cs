
namespace CapaPresentacion
{
    partial class FormConfiguracion
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
            this.panelArriba = new System.Windows.Forms.Panel();
            this.sombraArriba = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAFP = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lbHT = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtARS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panelArriba.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelArriba
            // 
            this.panelArriba.BackColor = System.Drawing.Color.White;
            this.panelArriba.Controls.Add(this.btnGuardar);
            this.panelArriba.Controls.Add(this.label4);
            this.panelArriba.Controls.Add(this.lbHT);
            this.panelArriba.Controls.Add(this.label1);
            this.panelArriba.Controls.Add(this.txtARS);
            this.panelArriba.Controls.Add(this.label2);
            this.panelArriba.Controls.Add(this.pictureBox2);
            this.panelArriba.Controls.Add(this.txtAFP);
            this.panelArriba.Controls.Add(this.pictureBox1);
            this.panelArriba.Controls.Add(this.pictureBox3);
            this.panelArriba.Controls.Add(this.pictureBox4);
            this.panelArriba.Location = new System.Drawing.Point(37, 83);
            this.panelArriba.Name = "panelArriba";
            this.panelArriba.Size = new System.Drawing.Size(983, 94);
            this.panelArriba.TabIndex = 18;
            // 
            // sombraArriba
            // 
            this.sombraArriba.BackColor = System.Drawing.Color.Gainsboro;
            this.sombraArriba.Location = new System.Drawing.Point(40, 86);
            this.sombraArriba.Name = "sombraArriba";
            this.sombraArriba.Size = new System.Drawing.Size(980, 95);
            this.sombraArriba.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(32, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 26);
            this.label3.TabIndex = 16;
            this.label3.Text = "Configuracion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(16, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 19);
            this.label2.TabIndex = 69;
            this.label2.Text = "Porcentaje de AFP";
            // 
            // txtAFP
            // 
            this.txtAFP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAFP.BackColor = System.Drawing.Color.White;
            this.txtAFP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAFP.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAFP.ForeColor = System.Drawing.Color.DimGray;
            this.txtAFP.Location = new System.Drawing.Point(28, 46);
            this.txtAFP.Name = "txtAFP";
            this.txtAFP.Size = new System.Drawing.Size(163, 20);
            this.txtAFP.TabIndex = 68;
            this.txtAFP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numTxt_KeyPress);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(20, 36);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(203, 40);
            this.pictureBox3.TabIndex = 70;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox4.Location = new System.Drawing.Point(18, 34);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(207, 44);
            this.pictureBox4.TabIndex = 71;
            this.pictureBox4.TabStop = false;
            // 
            // lbHT
            // 
            this.lbHT.Font = new System.Drawing.Font("Calibri", 14F);
            this.lbHT.ForeColor = System.Drawing.Color.DimGray;
            this.lbHT.Location = new System.Drawing.Point(197, 45);
            this.lbHT.Name = "lbHT";
            this.lbHT.Size = new System.Drawing.Size(20, 23);
            this.lbHT.TabIndex = 72;
            this.lbHT.Text = "%";
            this.lbHT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox1.Location = new System.Drawing.Point(259, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 44);
            this.pictureBox1.TabIndex = 71;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(261, 36);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(203, 40);
            this.pictureBox2.TabIndex = 70;
            this.pictureBox2.TabStop = false;
            // 
            // txtARS
            // 
            this.txtARS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtARS.BackColor = System.Drawing.Color.White;
            this.txtARS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtARS.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtARS.ForeColor = System.Drawing.Color.DimGray;
            this.txtARS.Location = new System.Drawing.Point(269, 46);
            this.txtARS.Name = "txtARS";
            this.txtARS.Size = new System.Drawing.Size(163, 20);
            this.txtARS.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(257, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 19);
            this.label1.TabIndex = 69;
            this.label1.Text = "Porcentaje de ARS";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Calibri", 14F);
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(438, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 23);
            this.label4.TabIndex = 72;
            this.label4.Text = "%";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(146)))), ((int)(((byte)(213)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(750, 34);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(207, 44);
            this.btnGuardar.TabIndex = 73;
            this.btnGuardar.Text = "Aplicar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FormConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 672);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelArriba);
            this.Controls.Add(this.sombraArriba);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormConfiguracion";
            this.Text = "FormConfiguracion";
            this.Load += new System.EventHandler(this.FormConfiguracion_Load);
            this.panelArriba.ResumeLayout(false);
            this.panelArriba.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelArriba;
        private System.Windows.Forms.Panel sombraArriba;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAFP;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbHT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtARS;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnGuardar;
    }
}