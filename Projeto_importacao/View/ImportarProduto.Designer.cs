namespace PortaFacil
{
    partial class ImportarProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportarProduto));
            this.lvDados = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.cbTipoXml = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtEncontrado = new System.Windows.Forms.Label();
            this.txtProduto = new System.Windows.Forms.Label();
            this.txtDiretorio = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnApresentar = new FontAwesome.Sharp.IconButton();
            this.btnImportar = new FontAwesome.Sharp.IconButton();
            this.btnSelecionar = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelecionar)).BeginInit();
            this.SuspendLayout();
            // 
            // lvDados
            // 
            this.lvDados.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvDados.HideSelection = false;
            this.lvDados.Location = new System.Drawing.Point(11, 151);
            this.lvDados.Name = "lvDados";
            this.lvDados.Size = new System.Drawing.Size(835, 493);
            this.lvDados.TabIndex = 17;
            this.lvDados.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(237, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 21);
            this.label1.TabIndex = 21;
            this.label1.Text = "DADOS DE PRODUTOS A SEREM IMPORTADOS";
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbEmpresa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(538, 44);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(308, 25);
            this.cbEmpresa.TabIndex = 22;
            // 
            // cbTipoXml
            // 
            this.cbTipoXml.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTipoXml.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoXml.FormattingEnabled = true;
            this.cbTipoXml.Items.AddRange(new object[] {
            "NFC-e",
            "CF-e",
            "NF-e"});
            this.cbTipoXml.Location = new System.Drawing.Point(538, 97);
            this.cbTipoXml.Name = "cbTipoXml";
            this.cbTipoXml.Size = new System.Drawing.Size(124, 25);
            this.cbTipoXml.TabIndex = 23;
            this.cbTipoXml.Text = "CF-e";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(534, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Modelo de XML";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(643, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 25;
            this.label2.Text = "Empresa";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(10)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.txtEncontrado);
            this.panel1.Controls.Add(this.txtProduto);
            this.panel1.Controls.Add(this.txtDiretorio);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnApresentar);
            this.panel1.Controls.Add(this.btnImportar);
            this.panel1.Controls.Add(this.btnSelecionar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbEmpresa);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lvDados);
            this.panel1.Controls.Add(this.cbTipoXml);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 644);
            this.panel1.TabIndex = 26;
            // 
            // txtEncontrado
            // 
            this.txtEncontrado.AutoSize = true;
            this.txtEncontrado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEncontrado.ForeColor = System.Drawing.Color.White;
            this.txtEncontrado.Location = new System.Drawing.Point(153, 97);
            this.txtEncontrado.Name = "txtEncontrado";
            this.txtEncontrado.Size = new System.Drawing.Size(0, 21);
            this.txtEncontrado.TabIndex = 47;
            // 
            // txtProduto
            // 
            this.txtProduto.AutoSize = true;
            this.txtProduto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduto.ForeColor = System.Drawing.Color.White;
            this.txtProduto.Location = new System.Drawing.Point(146, 118);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(0, 21);
            this.txtProduto.TabIndex = 46;
            // 
            // txtDiretorio
            // 
            this.txtDiretorio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiretorio.ForeColor = System.Drawing.Color.White;
            this.txtDiretorio.Location = new System.Drawing.Point(8, 47);
            this.txtDiretorio.Name = "txtDiretorio";
            this.txtDiretorio.Size = new System.Drawing.Size(221, 40);
            this.txtDiretorio.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(7, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 21);
            this.label7.TabIndex = 44;
            this.label7.Text = "Total de produtos:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(7, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 21);
            this.label5.TabIndex = 43;
            this.label5.Text = "Total de arquivos:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(7, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 21);
            this.label6.TabIndex = 42;
            this.label6.Text = "Diretório dos arquivos:";
            // 
            // btnApresentar
            // 
            this.btnApresentar.BackColor = System.Drawing.Color.Indigo;
            this.btnApresentar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApresentar.FlatAppearance.BorderSize = 0;
            this.btnApresentar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApresentar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnApresentar.ForeColor = System.Drawing.Color.White;
            this.btnApresentar.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            this.btnApresentar.IconColor = System.Drawing.Color.White;
            this.btnApresentar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnApresentar.IconSize = 30;
            this.btnApresentar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApresentar.Location = new System.Drawing.Point(290, 47);
            this.btnApresentar.Name = "btnApresentar";
            this.btnApresentar.Size = new System.Drawing.Size(113, 40);
            this.btnApresentar.TabIndex = 41;
            this.btnApresentar.Text = "Ler Dados";
            this.btnApresentar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnApresentar.UseVisualStyleBackColor = false;
            this.btnApresentar.Click += new System.EventHandler(this.btnApresentar_Click_1);
            // 
            // btnImportar
            // 
            this.btnImportar.BackColor = System.Drawing.Color.Indigo;
            this.btnImportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportar.FlatAppearance.BorderSize = 0;
            this.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnImportar.ForeColor = System.Drawing.Color.White;
            this.btnImportar.IconChar = FontAwesome.Sharp.IconChar.FileImport;
            this.btnImportar.IconColor = System.Drawing.Color.White;
            this.btnImportar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImportar.IconSize = 40;
            this.btnImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportar.Location = new System.Drawing.Point(677, 78);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(169, 53);
            this.btnImportar.TabIndex = 40;
            this.btnImportar.Text = "Importar Dados";
            this.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click_1);
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecionar.Location = new System.Drawing.Point(241, 47);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(43, 40);
            this.btnSelecionar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnSelecionar.TabIndex = 26;
            this.btnSelecionar.TabStop = false;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click_1);
            // 
            // ImportarProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(10)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(858, 662);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportarProduto";
            this.Text = "ImportarProduto";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelecionar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView lvDados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbEmpresa;
        private System.Windows.Forms.ComboBox cbTipoXml;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnSelecionar;
        private FontAwesome.Sharp.IconButton btnApresentar;
        private FontAwesome.Sharp.IconButton btnImportar;
        private System.Windows.Forms.Label txtDiretorio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtEncontrado;
        private System.Windows.Forms.Label txtProduto;
    }
}