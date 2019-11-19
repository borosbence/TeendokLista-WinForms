namespace TeendokLista.Views
{
    partial class Login
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
            this.labelFelhasznaloNev = new System.Windows.Forms.Label();
            this.textBoxJelszo = new System.Windows.Forms.TextBox();
            this.textBoxFelhasznaloNev = new System.Windows.Forms.TextBox();
            this.labelJelszo = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.errorProviderFNev = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFNev)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFelhasznaloNev
            // 
            this.labelFelhasznaloNev.AutoSize = true;
            this.labelFelhasznaloNev.Location = new System.Drawing.Point(89, 69);
            this.labelFelhasznaloNev.Name = "labelFelhasznaloNev";
            this.labelFelhasznaloNev.Size = new System.Drawing.Size(81, 13);
            this.labelFelhasznaloNev.TabIndex = 0;
            this.labelFelhasznaloNev.Text = "Felhasználónév";
            // 
            // textBoxJelszo
            // 
            this.textBoxJelszo.Location = new System.Drawing.Point(92, 125);
            this.textBoxJelszo.Name = "textBoxJelszo";
            this.textBoxJelszo.Size = new System.Drawing.Size(200, 20);
            this.textBoxJelszo.TabIndex = 1;
            // 
            // textBoxFelhasznaloNev
            // 
            this.textBoxFelhasznaloNev.Location = new System.Drawing.Point(92, 86);
            this.textBoxFelhasznaloNev.Name = "textBoxFelhasznaloNev";
            this.textBoxFelhasznaloNev.Size = new System.Drawing.Size(200, 20);
            this.textBoxFelhasznaloNev.TabIndex = 1;
            // 
            // labelJelszo
            // 
            this.labelJelszo.AutoSize = true;
            this.labelJelszo.Location = new System.Drawing.Point(89, 109);
            this.labelJelszo.Name = "labelJelszo";
            this.labelJelszo.Size = new System.Drawing.Size(36, 13);
            this.labelJelszo.TabIndex = 0;
            this.labelJelszo.Text = "Jelszó";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(145, 169);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(100, 23);
            this.buttonLogin.TabIndex = 2;
            this.buttonLogin.Text = "Bejelentkezés";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // errorProviderFNev
            // 
            this.errorProviderFNev.ContainerControl = this;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.textBoxFelhasznaloNev);
            this.Controls.Add(this.textBoxJelszo);
            this.Controls.Add(this.labelJelszo);
            this.Controls.Add(this.labelFelhasznaloNev);
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderFNev)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFelhasznaloNev;
        private System.Windows.Forms.TextBox textBoxJelszo;
        private System.Windows.Forms.TextBox textBoxFelhasznaloNev;
        private System.Windows.Forms.Label labelJelszo;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.ErrorProvider errorProviderFNev;
    }
}