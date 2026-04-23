
namespace ImaSteg {
    partial class MainView {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.ImaStegStrip = new System.Windows.Forms.ToolStrip();
            this.OpenImageBtn = new System.Windows.Forms.ToolStripButton();
            this.Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.OnlyStegBtn = new System.Windows.Forms.ToolStripButton();
            this.Separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CryptoAndStegBtn = new System.Windows.Forms.ToolStripButton();
            this.Separator3 = new System.Windows.Forms.ToolStripSeparator();
            this.CancelBtn = new System.Windows.Forms.ToolStripButton();
            this.Separator4 = new System.Windows.Forms.ToolStripSeparator();
            this.AboutBtn = new System.Windows.Forms.ToolStripButton();
            this.Separator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ImaStegStripLbl = new System.Windows.Forms.ToolStripLabel();
            this.ImaStegOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ActionBtn = new System.Windows.Forms.Button();
            this.ImaStegSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ProgressIndicator = new System.Windows.Forms.PictureBox();
            this.ImaStegStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // ImaStegStrip
            // 
            this.ImaStegStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ImaStegStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenImageBtn,
            this.Separator1,
            this.OnlyStegBtn,
            this.Separator2,
            this.CryptoAndStegBtn,
            this.Separator3,
            this.CancelBtn,
            this.Separator4,
            this.AboutBtn,
            this.Separator5,
            this.ImaStegStripLbl});
            this.ImaStegStrip.Location = new System.Drawing.Point(0, 0);
            this.ImaStegStrip.Name = "ImaStegStrip";
            this.ImaStegStrip.Size = new System.Drawing.Size(494, 27);
            this.ImaStegStrip.TabIndex = 0;
            this.ImaStegStrip.Text = "Herramientas";
            // 
            // OpenImageBtn
            // 
            this.OpenImageBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OpenImageBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenImageBtn.Image = ((System.Drawing.Image)(resources.GetObject("OpenImageBtn.Image")));
            this.OpenImageBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenImageBtn.Name = "OpenImageBtn";
            this.OpenImageBtn.Size = new System.Drawing.Size(29, 24);
            this.OpenImageBtn.Text = "Abrir imagen";
            this.OpenImageBtn.Click += new System.EventHandler(this.OpenImageBtn_Click);
            // 
            // Separator1
            // 
            this.Separator1.Name = "Separator1";
            this.Separator1.Size = new System.Drawing.Size(6, 27);
            // 
            // OnlyStegBtn
            // 
            this.OnlyStegBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OnlyStegBtn.Image = ((System.Drawing.Image)(resources.GetObject("OnlyStegBtn.Image")));
            this.OnlyStegBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OnlyStegBtn.Name = "OnlyStegBtn";
            this.OnlyStegBtn.Size = new System.Drawing.Size(29, 24);
            this.OnlyStegBtn.Text = "Esteganografía";
            this.OnlyStegBtn.Click += new System.EventHandler(this.OnlyStegBtn_Click);
            // 
            // Separator2
            // 
            this.Separator2.Name = "Separator2";
            this.Separator2.Size = new System.Drawing.Size(6, 27);
            // 
            // CryptoAndStegBtn
            // 
            this.CryptoAndStegBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CryptoAndStegBtn.Image = ((System.Drawing.Image)(resources.GetObject("CryptoAndStegBtn.Image")));
            this.CryptoAndStegBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CryptoAndStegBtn.Name = "CryptoAndStegBtn";
            this.CryptoAndStegBtn.Size = new System.Drawing.Size(29, 24);
            this.CryptoAndStegBtn.Text = "Criptografía + Esteganografía";
            this.CryptoAndStegBtn.Click += new System.EventHandler(this.CryptoAndStegBtn_Click);
            // 
            // Separator3
            // 
            this.Separator3.Name = "Separator3";
            this.Separator3.Size = new System.Drawing.Size(6, 27);
            // 
            // CancelBtn
            // 
            this.CancelBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CancelBtn.Image = ((System.Drawing.Image)(resources.GetObject("CancelBtn.Image")));
            this.CancelBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(29, 24);
            this.CancelBtn.Text = "Cancelar Operación";
            this.CancelBtn.ToolTipText = "Cancelar operación";
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // Separator4
            // 
            this.Separator4.Name = "Separator4";
            this.Separator4.Size = new System.Drawing.Size(6, 27);
            // 
            // AboutBtn
            // 
            this.AboutBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AboutBtn.Image = global::ImaSteg.Properties.Resources.File_2;
            this.AboutBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AboutBtn.Name = "AboutBtn";
            this.AboutBtn.Size = new System.Drawing.Size(29, 24);
            this.AboutBtn.Text = "Acerca de";
            this.AboutBtn.Click += new System.EventHandler(this.AboutBtn_Click);
            // 
            // Separator5
            // 
            this.Separator5.Name = "Separator5";
            this.Separator5.Size = new System.Drawing.Size(6, 27);
            // 
            // ImaStegStripLbl
            // 
            this.ImaStegStripLbl.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImaStegStripLbl.Name = "ImaStegStripLbl";
            this.ImaStegStripLbl.Size = new System.Drawing.Size(0, 24);
            // 
            // ActionBtn
            // 
            this.ActionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActionBtn.Location = new System.Drawing.Point(150, 49);
            this.ActionBtn.Name = "ActionBtn";
            this.ActionBtn.Size = new System.Drawing.Size(203, 50);
            this.ActionBtn.TabIndex = 1;
            this.ActionBtn.UseVisualStyleBackColor = true;
            this.ActionBtn.Click += new System.EventHandler(this.ActionBtn_Click);
            // 
            // ProgressIndicator
            // 
            this.ProgressIndicator.Location = new System.Drawing.Point(463, 1);
            this.ProgressIndicator.Name = "ProgressIndicator";
            this.ProgressIndicator.Size = new System.Drawing.Size(27, 27);
            this.ProgressIndicator.TabIndex = 2;
            this.ProgressIndicator.TabStop = false;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 115);
            this.Controls.Add(this.ProgressIndicator);
            this.Controls.Add(this.ActionBtn);
            this.Controls.Add(this.ImaStegStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainView";
            this.Text = "ImaSteg";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainView_FormClosed);
            this.Load += new System.EventHandler(this.MainView_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainView_MouseDown);
            this.ImaStegStrip.ResumeLayout(false);
            this.ImaStegStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressIndicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ImaStegStrip;
        private System.Windows.Forms.ToolStripButton OpenImageBtn;
        private System.Windows.Forms.OpenFileDialog ImaStegOpenFileDialog;
        private System.Windows.Forms.ToolStripSeparator Separator1;
        private System.Windows.Forms.ToolStripButton OnlyStegBtn;
        private System.Windows.Forms.ToolStripSeparator Separator2;
        private System.Windows.Forms.ToolStripButton CryptoAndStegBtn;
        private System.Windows.Forms.Button ActionBtn;
        private System.Windows.Forms.ToolStripSeparator Separator3;
        private System.Windows.Forms.ToolStripLabel ImaStegStripLbl;
        private System.Windows.Forms.ToolStripButton CancelBtn;
        private System.Windows.Forms.ToolStripSeparator Separator4;
        private System.Windows.Forms.ToolStripButton AboutBtn;
        private System.Windows.Forms.ToolStripSeparator Separator5;
        private System.Windows.Forms.SaveFileDialog ImaStegSaveFileDialog;
        private System.Windows.Forms.PictureBox ProgressIndicator;
    }
}

