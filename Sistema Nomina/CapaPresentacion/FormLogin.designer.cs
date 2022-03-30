
namespace CapaPresentacion 
{
    partial class FormLogin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbRecuperar = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.cbMostrarContraseña = new FontAwesome.Sharp.IconButton();
            this.iconUser = new FontAwesome.Sharp.IconButton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.iconUserCircle = new FontAwesome.Sharp.IconButton();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lbRecuperar);
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.cbMostrarContraseña);
            this.panel1.Controls.Add(this.iconUser);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.txtClave);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.iconUserCircle);
            this.panel1.Controls.Add(this.txtUsuario);
            this.panel1.Location = new System.Drawing.Point(108, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 437);
            this.panel1.TabIndex = 0;
            // 
            // lbRecuperar
            // 
            this.lbRecuperar.Font = new System.Drawing.Font("Calibri Light", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecuperar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.lbRecuperar.Location = new System.Drawing.Point(30, 300);
            this.lbRecuperar.Name = "lbRecuperar";
            this.lbRecuperar.Size = new System.Drawing.Size(219, 23);
            this.lbRecuperar.TabIndex = 10;
            this.lbRecuperar.Text = "Olvidó su contraseña?";
            this.lbRecuperar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbRecuperar.Click += new System.EventHandler(this.lbRecuperar_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.iconButton1.IconColor = System.Drawing.Color.Silver;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 20;
            this.iconButton1.Location = new System.Drawing.Point(29, 243);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(27, 26);
            this.iconButton1.TabIndex = 8;
            this.iconButton1.TabStop = false;
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // cbMostrarContraseña
            // 
            this.cbMostrarContraseña.FlatAppearance.BorderSize = 0;
            this.cbMostrarContraseña.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.cbMostrarContraseña.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.cbMostrarContraseña.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMostrarContraseña.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.cbMostrarContraseña.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.cbMostrarContraseña.IconColor = System.Drawing.Color.Silver;
            this.cbMostrarContraseña.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.cbMostrarContraseña.IconSize = 24;
            this.cbMostrarContraseña.Location = new System.Drawing.Point(223, 240);
            this.cbMostrarContraseña.Name = "cbMostrarContraseña";
            this.cbMostrarContraseña.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.cbMostrarContraseña.Size = new System.Drawing.Size(25, 25);
            this.cbMostrarContraseña.TabIndex = 9;
            this.cbMostrarContraseña.TabStop = false;
            this.cbMostrarContraseña.UseVisualStyleBackColor = true;
            this.cbMostrarContraseña.Click += new System.EventHandler(this.cbMostrarContraseña_Click);
            // 
            // iconUser
            // 
            this.iconUser.BackColor = System.Drawing.Color.Transparent;
            this.iconUser.FlatAppearance.BorderSize = 0;
            this.iconUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconUser.IconChar = FontAwesome.Sharp.IconChar.User;
            this.iconUser.IconColor = System.Drawing.Color.Silver;
            this.iconUser.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconUser.IconSize = 20;
            this.iconUser.Location = new System.Drawing.Point(29, 181);
            this.iconUser.Name = "iconUser";
            this.iconUser.Size = new System.Drawing.Size(27, 26);
            this.iconUser.TabIndex = 7;
            this.iconUser.TabStop = false;
            this.iconUser.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.DarkGray;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(29, 271);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(220, 2);
            this.flowLayoutPanel2.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.DarkGray;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(29, 208);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(220, 2);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // txtClave
            // 
            this.txtClave.BackColor = System.Drawing.Color.White;
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClave.Font = new System.Drawing.Font("Calibri", 14F);
            this.txtClave.ForeColor = System.Drawing.Color.DimGray;
            this.txtClave.Location = new System.Drawing.Point(62, 243);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(155, 23);
            this.txtClave.TabIndex = 1;
            this.txtClave.Text = "Contraseña";
            this.txtClave.Enter += new System.EventHandler(this.txtContraseña_Enter);
            this.txtClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txtClave.Leave += new System.EventHandler(this.txtContraseña_Leave);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(146)))), ((int)(((byte)(213)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(33, 364);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(220, 42);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Iniciar Sesión";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // iconUserCircle
            // 
            this.iconUserCircle.BackColor = System.Drawing.Color.Transparent;
            this.iconUserCircle.FlatAppearance.BorderSize = 0;
            this.iconUserCircle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconUserCircle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconUserCircle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconUserCircle.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.iconUserCircle.IconColor = System.Drawing.Color.Silver;
            this.iconUserCircle.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconUserCircle.IconSize = 126;
            this.iconUserCircle.Location = new System.Drawing.Point(86, 24);
            this.iconUserCircle.Name = "iconUserCircle";
            this.iconUserCircle.Size = new System.Drawing.Size(110, 129);
            this.iconUserCircle.TabIndex = 1;
            this.iconUserCircle.TabStop = false;
            this.iconUserCircle.UseVisualStyleBackColor = false;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Font = new System.Drawing.Font("Calibri", 14F);
            this.txtUsuario.ForeColor = System.Drawing.Color.DimGray;
            this.txtUsuario.Location = new System.Drawing.Point(62, 181);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(155, 23);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.Text = "Usuario";
            this.txtUsuario.Enter += new System.EventHandler(this.txt_Enter);
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            this.txtUsuario.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnClose.IconColor = System.Drawing.Color.Silver;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 24;
            this.btnClose.Location = new System.Drawing.Point(459, -1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(1, 3, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(39, 28);
            this.btnClose.TabIndex = 11;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(497, 506);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormLogin_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton iconUserCircle;
        private FontAwesome.Sharp.IconButton cbMostrarContraseña;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Button btnLogin;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconUser;
        private System.Windows.Forms.Label lbRecuperar;
        private FontAwesome.Sharp.IconButton btnClose;
    }
}