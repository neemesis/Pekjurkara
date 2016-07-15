namespace Pekjurkara {
    partial class Form1 {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.novBerachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prikazhiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.denToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mesecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.godinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vkupnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.berachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novDenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zatvoriDenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smeniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imeNaBerachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.denToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.berachDenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novBerachToolStripMenuItem,
            this.prikazhiToolStripMenuItem,
            this.novDenToolStripMenuItem,
            this.zatvoriDenToolStripMenuItem,
            this.smeniToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(954, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // novBerachToolStripMenuItem
            // 
            this.novBerachToolStripMenuItem.Name = "novBerachToolStripMenuItem";
            this.novBerachToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.novBerachToolStripMenuItem.Text = "Nov Vlez";
            this.novBerachToolStripMenuItem.Click += new System.EventHandler(this.novBerachToolStripMenuItem_Click);
            // 
            // prikazhiToolStripMenuItem
            // 
            this.prikazhiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.denToolStripMenuItem,
            this.mesecToolStripMenuItem,
            this.godinaToolStripMenuItem,
            this.vkupnoToolStripMenuItem,
            this.berachToolStripMenuItem});
            this.prikazhiToolStripMenuItem.Name = "prikazhiToolStripMenuItem";
            this.prikazhiToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.prikazhiToolStripMenuItem.Text = "Prikazhi";
            // 
            // denToolStripMenuItem
            // 
            this.denToolStripMenuItem.Name = "denToolStripMenuItem";
            this.denToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.denToolStripMenuItem.Text = "Den";
            this.denToolStripMenuItem.Click += new System.EventHandler(this.denToolStripMenuItem_Click);
            // 
            // mesecToolStripMenuItem
            // 
            this.mesecToolStripMenuItem.Name = "mesecToolStripMenuItem";
            this.mesecToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mesecToolStripMenuItem.Text = "Mesec";
            this.mesecToolStripMenuItem.Click += new System.EventHandler(this.mesecToolStripMenuItem_Click);
            // 
            // godinaToolStripMenuItem
            // 
            this.godinaToolStripMenuItem.Name = "godinaToolStripMenuItem";
            this.godinaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.godinaToolStripMenuItem.Text = "Godina";
            // 
            // vkupnoToolStripMenuItem
            // 
            this.vkupnoToolStripMenuItem.Name = "vkupnoToolStripMenuItem";
            this.vkupnoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.vkupnoToolStripMenuItem.Text = "Vkupno";
            // 
            // berachToolStripMenuItem
            // 
            this.berachToolStripMenuItem.Name = "berachToolStripMenuItem";
            this.berachToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.berachToolStripMenuItem.Text = "Berach";
            this.berachToolStripMenuItem.Click += new System.EventHandler(this.berachToolStripMenuItem_Click);
            // 
            // novDenToolStripMenuItem
            // 
            this.novDenToolStripMenuItem.Name = "novDenToolStripMenuItem";
            this.novDenToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.novDenToolStripMenuItem.Text = "Nov Den";
            this.novDenToolStripMenuItem.Click += new System.EventHandler(this.novDenToolStripMenuItem_Click);
            // 
            // zatvoriDenToolStripMenuItem
            // 
            this.zatvoriDenToolStripMenuItem.Name = "zatvoriDenToolStripMenuItem";
            this.zatvoriDenToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.zatvoriDenToolStripMenuItem.Text = "Zatvori Den";
            this.zatvoriDenToolStripMenuItem.Click += new System.EventHandler(this.zatvoriDenToolStripMenuItem_Click);
            // 
            // smeniToolStripMenuItem
            // 
            this.smeniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imeNaBerachToolStripMenuItem,
            this.denToolStripMenuItem1,
            this.berachDenToolStripMenuItem});
            this.smeniToolStripMenuItem.Name = "smeniToolStripMenuItem";
            this.smeniToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.smeniToolStripMenuItem.Text = "Smeni";
            // 
            // imeNaBerachToolStripMenuItem
            // 
            this.imeNaBerachToolStripMenuItem.Name = "imeNaBerachToolStripMenuItem";
            this.imeNaBerachToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.imeNaBerachToolStripMenuItem.Text = "Ime na Berach";
            this.imeNaBerachToolStripMenuItem.Click += new System.EventHandler(this.imeNaBerachToolStripMenuItem_Click);
            // 
            // denToolStripMenuItem1
            // 
            this.denToolStripMenuItem1.Name = "denToolStripMenuItem1";
            this.denToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.denToolStripMenuItem1.Text = "Den";
            // 
            // berachDenToolStripMenuItem
            // 
            this.berachDenToolStripMenuItem.Name = "berachDenToolStripMenuItem";
            this.berachDenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.berachDenToolStripMenuItem.Text = "Berach - Den";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.toolStripSplitButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 486);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(954, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(13, 28);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(929, 455);
            this.dataGrid.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 20);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            this.toolStripSplitButton1.ButtonClick += new System.EventHandler(this.toolStripSplitButton1_ButtonClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 508);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Otkup na Pekjurki";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem novBerachToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prikazhiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem denToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mesecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem godinaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vkupnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem berachToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novDenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zatvoriDenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smeniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imeNaBerachToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem denToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem berachDenToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
    }
}

