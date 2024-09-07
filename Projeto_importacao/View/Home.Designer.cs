namespace PortaFacil
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.pnMenu = new System.Windows.Forms.Panel();
            this.pbLinx = new FontAwesome.Sharp.IconPictureBox();
            this.btnCliente = new FontAwesome.Sharp.IconButton();
            this.btnProduto = new FontAwesome.Sharp.IconButton();
            this.btnBanco = new FontAwesome.Sharp.IconButton();
            this.btnSobre = new FontAwesome.Sharp.IconButton();
            this.PnMexer = new System.Windows.Forms.Panel();
            this.btnMinimizar = new FontAwesome.Sharp.IconButton();
            this.btnSair = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pnMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLinx)).BeginInit();
            this.PnMexer.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnMenu
            // 
            this.pnMenu.BackColor = System.Drawing.Color.Indigo;
            this.pnMenu.Controls.Add(this.pbLinx);
            this.pnMenu.Controls.Add(this.btnCliente);
            this.pnMenu.Controls.Add(this.btnProduto);
            this.pnMenu.Controls.Add(this.btnBanco);
            this.pnMenu.Controls.Add(this.btnSobre);
            this.pnMenu.Location = new System.Drawing.Point(0, 189);
            this.pnMenu.Name = "pnMenu";
            this.pnMenu.Size = new System.Drawing.Size(211, 512);
            this.pnMenu.TabIndex = 0;
            this.pnMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnMenu_MouseDown);
            // 
            // pbLinx
            // 
            this.pbLinx.BackColor = System.Drawing.Color.Indigo;
            this.pbLinx.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pbLinx.IconChar = FontAwesome.Sharp.IconChar.None;
            this.pbLinx.IconColor = System.Drawing.SystemColors.ControlText;
            this.pbLinx.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pbLinx.IconSize = 117;
            this.pbLinx.Location = new System.Drawing.Point(0, 392);
            this.pbLinx.Name = "pbLinx";
            this.pbLinx.Size = new System.Drawing.Size(211, 117);
            this.pbLinx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbLinx.TabIndex = 7;
            this.pbLinx.TabStop = false;
            // 
            // btnCliente
            // 
            this.btnCliente.BackColor = System.Drawing.Color.Indigo;
            this.btnCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCliente.FlatAppearance.BorderSize = 0;
            this.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCliente.ForeColor = System.Drawing.Color.White;
            this.btnCliente.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnCliente.IconColor = System.Drawing.Color.White;
            this.btnCliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCliente.IconSize = 60;
            this.btnCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCliente.Location = new System.Drawing.Point(0, 0);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(211, 88);
            this.btnCliente.TabIndex = 6;
            this.btnCliente.Text = "Importar cliente";
            this.btnCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCliente.UseVisualStyleBackColor = false;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click_1);
            // 
            // btnProduto
            // 
            this.btnProduto.BackColor = System.Drawing.Color.Indigo;
            this.btnProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProduto.FlatAppearance.BorderSize = 0;
            this.btnProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnProduto.ForeColor = System.Drawing.Color.White;
            this.btnProduto.IconChar = FontAwesome.Sharp.IconChar.OilCan;
            this.btnProduto.IconColor = System.Drawing.Color.White;
            this.btnProduto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProduto.IconSize = 60;
            this.btnProduto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduto.Location = new System.Drawing.Point(0, 86);
            this.btnProduto.Name = "btnProduto";
            this.btnProduto.Size = new System.Drawing.Size(211, 88);
            this.btnProduto.TabIndex = 5;
            this.btnProduto.Text = "Importar produto";
            this.btnProduto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProduto.UseVisualStyleBackColor = false;
            this.btnProduto.Click += new System.EventHandler(this.btnProduto_Click_1);
            // 
            // btnBanco
            // 
            this.btnBanco.BackColor = System.Drawing.Color.Indigo;
            this.btnBanco.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBanco.FlatAppearance.BorderSize = 0;
            this.btnBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanco.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnBanco.ForeColor = System.Drawing.Color.White;
            this.btnBanco.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.btnBanco.IconColor = System.Drawing.Color.White;
            this.btnBanco.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBanco.IconSize = 60;
            this.btnBanco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBanco.Location = new System.Drawing.Point(0, 180);
            this.btnBanco.Name = "btnBanco";
            this.btnBanco.Size = new System.Drawing.Size(211, 88);
            this.btnBanco.TabIndex = 4;
            this.btnBanco.Text = "Banco de dados";
            this.btnBanco.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBanco.UseVisualStyleBackColor = false;
            this.btnBanco.Click += new System.EventHandler(this.btnBanco_Click_1);
            // 
            // btnSobre
            // 
            this.btnSobre.BackColor = System.Drawing.Color.Indigo;
            this.btnSobre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSobre.FlatAppearance.BorderSize = 0;
            this.btnSobre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSobre.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSobre.ForeColor = System.Drawing.Color.White;
            this.btnSobre.IconChar = FontAwesome.Sharp.IconChar.Info;
            this.btnSobre.IconColor = System.Drawing.Color.White;
            this.btnSobre.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSobre.IconSize = 60;
            this.btnSobre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSobre.Location = new System.Drawing.Point(0, 274);
            this.btnSobre.Name = "btnSobre";
            this.btnSobre.Size = new System.Drawing.Size(211, 88);
            this.btnSobre.TabIndex = 0;
            this.btnSobre.Text = "     Sobre";
            this.btnSobre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSobre.UseVisualStyleBackColor = false;
            this.btnSobre.Click += new System.EventHandler(this.btnSobre_Click_1);
            // 
            // PnMexer
            // 
            this.PnMexer.BackColor = System.Drawing.Color.Indigo;
            this.PnMexer.Controls.Add(this.btnMinimizar);
            this.PnMexer.Controls.Add(this.btnSair);
            this.PnMexer.Controls.Add(this.label1);
            this.PnMexer.Location = new System.Drawing.Point(0, 0);
            this.PnMexer.Name = "PnMexer";
            this.PnMexer.Size = new System.Drawing.Size(1068, 36);
            this.PnMexer.TabIndex = 1;
            this.PnMexer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnMexer_MouseDown);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.BackColor = System.Drawing.Color.Indigo;
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btnMinimizar.IconColor = System.Drawing.Color.White;
            this.btnMinimizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMinimizar.IconSize = 40;
            this.btnMinimizar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMinimizar.Location = new System.Drawing.Point(998, 3);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(31, 27);
            this.btnMinimizar.TabIndex = 3;
            this.btnMinimizar.UseVisualStyleBackColor = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click_1);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.Indigo;
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btnSair.IconColor = System.Drawing.Color.White;
            this.btnSair.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSair.IconSize = 28;
            this.btnSair.Location = new System.Drawing.Point(1035, 3);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(30, 27);
            this.btnSair.TabIndex = 0;
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Porta Fácil V 1.0.1";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(210, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(858, 680);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(10)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pbLogo);
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(211, 158);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(10)))), ((int)(((byte)(60)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(36, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Porta Fácil </>";
            // 
            // pbLogo
            // 
            this.pbLogo.Location = new System.Drawing.Point(0, 3);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(211, 152);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            this.pbLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbLogo_MouseDown);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 700);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PnMexer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.pnMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLinx)).EndInit();
            this.PnMexer.ResumeLayout(false);
            this.PnMexer.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMenu;
        private System.Windows.Forms.Panel PnMexer;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnMinimizar;
        private FontAwesome.Sharp.IconButton btnSair;
        private FontAwesome.Sharp.IconButton btnSobre;
        private FontAwesome.Sharp.IconButton btnBanco;
        private FontAwesome.Sharp.IconButton btnProduto;
        private FontAwesome.Sharp.IconButton btnCliente;
        private FontAwesome.Sharp.IconPictureBox pbLinx;
    }
}