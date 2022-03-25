
namespace CapaPresentacion
{
    partial class FormRecuperacion
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
            this.iconUser = new FontAwesome.Sharp.IconButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtAdmin = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.txtClaveAdmin = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.txtClaveUsuario = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.txtConfirmacion = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
            this.btnEfectuar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iconUser
            // 
            this.iconUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.iconUser.BackColor = System.Drawing.Color.Transparent;
            this.iconUser.FlatAppearance.BorderSize = 0;
            this.iconUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconUser.IconChar = FontAwesome.Sharp.IconChar.Toolbox;
            this.iconUser.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.iconUser.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconUser.IconSize = 20;
            this.iconUser.Location = new System.Drawing.Point(38, 98);
            this.iconUser.Name = "iconUser";
            this.iconUser.Size = new System.Drawing.Size(27, 26);
            this.iconUser.TabIndex = 10;
            this.iconUser.TabStop = false;
            this.iconUser.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(38, 125);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(220, 3);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // txtAdmin
            // 
            this.txtAdmin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            this.txtAdmin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAdmin.Font = new System.Drawing.Font("Calibri", 14F);
            this.txtAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.txtAdmin.Location = new System.Drawing.Point(71, 98);
            this.txtAdmin.Name = "txtAdmin";
            this.txtAdmin.Size = new System.Drawing.Size(155, 23);
            this.txtAdmin.TabIndex = 0;
            this.txtAdmin.Text = "Admin";
            this.txtAdmin.Enter += new System.EventHandler(this.txt_Enter);
            this.txtAdmin.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 26);
            this.panel1.TabIndex = 11;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnClose.IconColor = System.Drawing.Color.Silver;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 24;
            this.btnClose.Location = new System.Drawing.Point(278, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(22, 22);
            this.btnClose.TabIndex = 11;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbTitulo
            // 
            this.lbTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTitulo.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.lbTitulo.Location = new System.Drawing.Point(16, 39);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(268, 34);
            this.lbTitulo.TabIndex = 12;
            this.lbTitulo.Text = "Recuperar Contraseña";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtClaveAdmin
            // 
            this.txtClaveAdmin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtClaveAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            this.txtClaveAdmin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClaveAdmin.Font = new System.Drawing.Font("Calibri", 14F);
            this.txtClaveAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.txtClaveAdmin.Location = new System.Drawing.Point(71, 152);
            this.txtClaveAdmin.Name = "txtClaveAdmin";
            this.txtClaveAdmin.Size = new System.Drawing.Size(155, 23);
            this.txtClaveAdmin.TabIndex = 1;
            this.txtClaveAdmin.Text = "Contraseña";
            this.txtClaveAdmin.Enter += new System.EventHandler(this.txt_Enter);
            this.txtClaveAdmin.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.flowLayoutPanel2.Location = new System.Drawing.Point(38, 179);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(220, 3);
            this.flowLayoutPanel2.TabIndex = 9;
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.iconButton1.BackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.iconButton1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButton1.IconSize = 20;
            this.iconButton1.Location = new System.Drawing.Point(38, 152);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(27, 26);
            this.iconButton1.TabIndex = 10;
            this.iconButton1.TabStop = false;
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Font = new System.Drawing.Font("Calibri", 14F);
            this.txtUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.txtUsuario.Location = new System.Drawing.Point(71, 228);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(155, 23);
            this.txtUsuario.TabIndex = 2;
            this.txtUsuario.Text = "Usuario";
            this.txtUsuario.Enter += new System.EventHandler(this.txt_Enter);
            this.txtUsuario.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.flowLayoutPanel3.Location = new System.Drawing.Point(38, 255);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(220, 3);
            this.flowLayoutPanel3.TabIndex = 9;
            // 
            // iconButton2
            // 
            this.iconButton2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.iconButton2.BackColor = System.Drawing.Color.Transparent;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.User;
            this.iconButton2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButton2.IconSize = 20;
            this.iconButton2.Location = new System.Drawing.Point(38, 228);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(27, 26);
            this.iconButton2.TabIndex = 10;
            this.iconButton2.TabStop = false;
            this.iconButton2.UseVisualStyleBackColor = false;
            // 
            // txtClaveUsuario
            // 
            this.txtClaveUsuario.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtClaveUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            this.txtClaveUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClaveUsuario.Font = new System.Drawing.Font("Calibri", 14F);
            this.txtClaveUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.txtClaveUsuario.Location = new System.Drawing.Point(71, 284);
            this.txtClaveUsuario.Name = "txtClaveUsuario";
            this.txtClaveUsuario.Size = new System.Drawing.Size(155, 23);
            this.txtClaveUsuario.TabIndex = 3;
            this.txtClaveUsuario.Text = "Contraseña Nueva";
            this.txtClaveUsuario.Enter += new System.EventHandler(this.txt_Enter);
            this.txtClaveUsuario.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.flowLayoutPanel4.Location = new System.Drawing.Point(38, 311);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(220, 3);
            this.flowLayoutPanel4.TabIndex = 9;
            // 
            // iconButton3
            // 
            this.iconButton3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.iconButton3.BackColor = System.Drawing.Color.Transparent;
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.iconButton3.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButton3.IconSize = 20;
            this.iconButton3.Location = new System.Drawing.Point(38, 284);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(27, 26);
            this.iconButton3.TabIndex = 10;
            this.iconButton3.TabStop = false;
            this.iconButton3.UseVisualStyleBackColor = false;
            // 
            // txtConfirmacion
            // 
            this.txtConfirmacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtConfirmacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            this.txtConfirmacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfirmacion.Font = new System.Drawing.Font("Calibri", 14F);
            this.txtConfirmacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.txtConfirmacion.Location = new System.Drawing.Point(71, 343);
            this.txtConfirmacion.Name = "txtConfirmacion";
            this.txtConfirmacion.Size = new System.Drawing.Size(155, 23);
            this.txtConfirmacion.TabIndex = 4;
            this.txtConfirmacion.Text = "Confirmar Clave";
            this.txtConfirmacion.Enter += new System.EventHandler(this.txt_Enter);
            this.txtConfirmacion.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.flowLayoutPanel5.Location = new System.Drawing.Point(38, 370);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(220, 3);
            this.flowLayoutPanel5.TabIndex = 9;
            // 
            // iconButton4
            // 
            this.iconButton4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.iconButton4.BackColor = System.Drawing.Color.Transparent;
            this.iconButton4.FlatAppearance.BorderSize = 0;
            this.iconButton4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton4.IconChar = FontAwesome.Sharp.IconChar.LockOpen;
            this.iconButton4.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.iconButton4.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButton4.IconSize = 20;
            this.iconButton4.Location = new System.Drawing.Point(38, 343);
            this.iconButton4.Name = "iconButton4";
            this.iconButton4.Size = new System.Drawing.Size(27, 26);
            this.iconButton4.TabIndex = 10;
            this.iconButton4.TabStop = false;
            this.iconButton4.UseVisualStyleBackColor = false;
            // 
            // btnEfectuar
            // 
            this.btnEfectuar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEfectuar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.btnEfectuar.FlatAppearance.BorderSize = 0;
            this.btnEfectuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEfectuar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEfectuar.ForeColor = System.Drawing.Color.White;
            this.btnEfectuar.Location = new System.Drawing.Point(38, 408);
            this.btnEfectuar.Name = "btnEfectuar";
            this.btnEfectuar.Size = new System.Drawing.Size(220, 42);
            this.btnEfectuar.TabIndex = 5;
            this.btnEfectuar.Text = "Efectuar Cambios";
            this.btnEfectuar.UseVisualStyleBackColor = false;
            this.btnEfectuar.Click += new System.EventHandler(this.btnEfectuar_Click);
            // 
            // FormRecuperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 473);
            this.Controls.Add(this.btnEfectuar);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.iconButton4);
            this.Controls.Add(this.iconButton3);
            this.Controls.Add(this.iconButton2);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.iconUser);
            this.Controls.Add(this.flowLayoutPanel5);
            this.Controls.Add(this.flowLayoutPanel4);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.txtConfirmacion);
            this.Controls.Add(this.txtClaveUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtClaveAdmin);
            this.Controls.Add(this.txtAdmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRecuperacion";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormRecuperacion";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton iconUser;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtAdmin;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnClose;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.TextBox txtClaveAdmin;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.TextBox txtClaveUsuario;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private FontAwesome.Sharp.IconButton iconButton3;
        private System.Windows.Forms.TextBox txtConfirmacion;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private FontAwesome.Sharp.IconButton iconButton4;
        private System.Windows.Forms.Button btnEfectuar;
    }
}