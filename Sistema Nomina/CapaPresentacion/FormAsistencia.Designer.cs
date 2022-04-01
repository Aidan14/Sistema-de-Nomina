
namespace CapaPresentacion
{
    partial class FormAsistencia
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
            this.components = new System.ComponentModel.Container();
            this.panel13 = new System.Windows.Forms.Panel();
            this.btnPonche = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cbID = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.lbFecha = new System.Windows.Forms.Label();
            this.lbHora = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.White;
            this.panel13.Controls.Add(this.btnPonche);
            this.panel13.Controls.Add(this.label1);
            this.panel13.Controls.Add(this.cbID);
            this.panel13.Controls.Add(this.pictureBox2);
            this.panel13.Controls.Add(this.pictureBox1);
            this.panel13.Location = new System.Drawing.Point(332, 286);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(379, 195);
            this.panel13.TabIndex = 6;
            // 
            // btnPonche
            // 
            this.btnPonche.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(146)))), ((int)(((byte)(213)))));
            this.btnPonche.FlatAppearance.BorderSize = 0;
            this.btnPonche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPonche.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPonche.ForeColor = System.Drawing.Color.White;
            this.btnPonche.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnPonche.IconColor = System.Drawing.Color.Black;
            this.btnPonche.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPonche.Location = new System.Drawing.Point(21, 113);
            this.btnPonche.Name = "btnPonche";
            this.btnPonche.Size = new System.Drawing.Size(336, 56);
            this.btnPonche.TabIndex = 75;
            this.btnPonche.Tag = "";
            this.btnPonche.Text = "Ingresar";
            this.btnPonche.UseVisualStyleBackColor = false;
            this.btnPonche.Click += new System.EventHandler(this.btnPonche_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(19, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 19);
            this.label1.TabIndex = 74;
            this.label1.Text = "ID Usuario";
            // 
            // cbID
            // 
            this.cbID.BackColor = System.Drawing.Color.White;
            this.cbID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbID.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbID.ForeColor = System.Drawing.Color.DimGray;
            this.cbID.FormattingEnabled = true;
            this.cbID.Location = new System.Drawing.Point(33, 57);
            this.cbID.Name = "cbID";
            this.cbID.Size = new System.Drawing.Size(310, 27);
            this.cbID.TabIndex = 71;
            this.cbID.TextChanged += new System.EventHandler(this.cbID_TextChanged);
            this.cbID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbID_KeyPress);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(23, 50);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(332, 40);
            this.pictureBox2.TabIndex = 72;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox1.Location = new System.Drawing.Point(21, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(336, 44);
            this.pictureBox1.TabIndex = 73;
            this.pictureBox1.TabStop = false;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Gainsboro;
            this.panel12.Location = new System.Drawing.Point(335, 289);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(376, 196);
            this.panel12.TabIndex = 7;
            // 
            // lbFecha
            // 
            this.lbFecha.Font = new System.Drawing.Font("Calibri Light", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFecha.ForeColor = System.Drawing.Color.DimGray;
            this.lbFecha.Location = new System.Drawing.Point(282, 135);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(483, 50);
            this.lbFecha.TabIndex = 8;
            this.lbFecha.Text = "label2";
            this.lbFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbHora
            // 
            this.lbHora.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHora.ForeColor = System.Drawing.Color.DimGray;
            this.lbHora.Location = new System.Drawing.Point(282, 201);
            this.lbHora.Name = "lbHora";
            this.lbHora.Size = new System.Drawing.Size(483, 50);
            this.lbHora.TabIndex = 8;
            this.lbHora.Text = "00:00:00";
            this.lbHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1058, 672);
            this.Controls.Add(this.lbHora);
            this.Controls.Add(this.lbFecha);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAsistencia";
            this.Text = "FormAsistencia";
            this.Load += new System.EventHandler(this.FormAsistencia_Load);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbID;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btnPonche;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.Label lbHora;
        private System.Windows.Forms.Timer timer1;
    }
}