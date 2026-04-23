
namespace ImaSteg.Views {
    partial class SetPasswordView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetPasswordView));
            this.generalBox = new System.Windows.Forms.GroupBox();
            this.TokenBox = new System.Windows.Forms.RichTextBox();
            this.WarningLbl = new System.Windows.Forms.Label();
            this.CreateTokenBtn = new System.Windows.Forms.Button();
            this.TokenLbl = new System.Windows.Forms.Label();
            this.PasswordLbl = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.AcceptBtn = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.generalBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // generalBox
            // 
            this.generalBox.Controls.Add(this.TokenBox);
            this.generalBox.Controls.Add(this.WarningLbl);
            this.generalBox.Controls.Add(this.CreateTokenBtn);
            this.generalBox.Controls.Add(this.TokenLbl);
            this.generalBox.Controls.Add(this.PasswordLbl);
            this.generalBox.Controls.Add(this.CancelBtn);
            this.generalBox.Controls.Add(this.AcceptBtn);
            this.generalBox.Controls.Add(this.PasswordTextBox);
            this.generalBox.Location = new System.Drawing.Point(12, 12);
            this.generalBox.Name = "generalBox";
            this.generalBox.Size = new System.Drawing.Size(495, 277);
            this.generalBox.TabIndex = 0;
            this.generalBox.TabStop = false;
            this.generalBox.Text = "Establezca una contraseña para realizar la acción";
            // 
            // TokenBox
            // 
            this.TokenBox.Location = new System.Drawing.Point(184, 101);
            this.TokenBox.Name = "TokenBox";
            this.TokenBox.Size = new System.Drawing.Size(249, 88);
            this.TokenBox.TabIndex = 9;
            this.TokenBox.Text = "";
            this.TokenBox.TextChanged += new System.EventHandler(this.TokenBox_TextChanged);
            // 
            // WarningLbl
            // 
            this.WarningLbl.AutoSize = true;
            this.WarningLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarningLbl.ForeColor = System.Drawing.Color.Black;
            this.WarningLbl.Location = new System.Drawing.Point(119, 197);
            this.WarningLbl.Name = "WarningLbl";
            this.WarningLbl.Size = new System.Drawing.Size(230, 20);
            this.WarningLbl.TabIndex = 8;
            this.WarningLbl.Text = "☺ GUARDE EL TOKEN ☺";
            // 
            // CreateTokenBtn
            // 
            this.CreateTokenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateTokenBtn.Location = new System.Drawing.Point(179, 225);
            this.CreateTokenBtn.Name = "CreateTokenBtn";
            this.CreateTokenBtn.Size = new System.Drawing.Size(138, 35);
            this.CreateTokenBtn.TabIndex = 7;
            this.CreateTokenBtn.Text = "NUEVO TOKEN";
            this.CreateTokenBtn.UseVisualStyleBackColor = true;
            this.CreateTokenBtn.Click += new System.EventHandler(this.CreateTokenBtn_Click);
            // 
            // TokenLbl
            // 
            this.TokenLbl.AutoSize = true;
            this.TokenLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TokenLbl.Location = new System.Drawing.Point(99, 101);
            this.TokenLbl.Name = "TokenLbl";
            this.TokenLbl.Size = new System.Drawing.Size(65, 20);
            this.TokenLbl.TabIndex = 6;
            this.TokenLbl.Text = "Token:";
            // 
            // PasswordLbl
            // 
            this.PasswordLbl.AutoSize = true;
            this.PasswordLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLbl.Location = new System.Drawing.Point(54, 49);
            this.PasswordLbl.Name = "PasswordLbl";
            this.PasswordLbl.Size = new System.Drawing.Size(111, 20);
            this.PasswordLbl.TabIndex = 5;
            this.PasswordLbl.Text = "Contraseña:";
            // 
            // CancelBtn
            // 
            this.CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.Location = new System.Drawing.Point(27, 225);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(146, 35);
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "CANCELAR";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // AcceptBtn
            // 
            this.AcceptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AcceptBtn.Location = new System.Drawing.Point(323, 225);
            this.AcceptBtn.Name = "AcceptBtn";
            this.AcceptBtn.Size = new System.Drawing.Size(146, 35);
            this.AcceptBtn.TabIndex = 2;
            this.AcceptBtn.Text = "ACEPTAR";
            this.AcceptBtn.UseVisualStyleBackColor = true;
            this.AcceptBtn.Click += new System.EventHandler(this.AcceptBtn_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.Location = new System.Drawing.Point(184, 46);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(249, 27);
            this.PasswordTextBox.TabIndex = 1;
            this.PasswordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBox_TextChanged);
            // 
            // SetPasswordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 301);
            this.Controls.Add(this.generalBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetPasswordView";
            this.Text = "Contraseña";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SetPasswordView_FormClosed);
            this.Load += new System.EventHandler(this.SetPasswordView_Load);
            this.generalBox.ResumeLayout(false);
            this.generalBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox generalBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button AcceptBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label PasswordLbl;
        private System.Windows.Forms.Label TokenLbl;
        private System.Windows.Forms.Button CreateTokenBtn;
        private System.Windows.Forms.Label WarningLbl;
        private System.Windows.Forms.RichTextBox TokenBox;
    }
}