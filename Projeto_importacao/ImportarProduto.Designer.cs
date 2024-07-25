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
            this.btnApresentar = new System.Windows.Forms.Button();
            this.lvDados = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImportar = new System.Windows.Forms.Button();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.cbTipoXml = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelecionar = new System.Windows.Forms.PictureBox();
            this.txtDiretorio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelecionar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnApresentar
            // 
            this.btnApresentar.BackColor = System.Drawing.Color.Indigo;
            this.btnApresentar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApresentar.FlatAppearance.BorderSize = 0;
            this.btnApresentar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApresentar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApresentar.ForeColor = System.Drawing.Color.White;
            this.btnApresentar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApresentar.Location = new System.Drawing.Point(290, 47);
            this.btnApresentar.Name = "btnApresentar";
            this.btnApresentar.Size = new System.Drawing.Size(107, 40);
            this.btnApresentar.TabIndex = 14;
            this.btnApresentar.Text = "Ler Dados";
            this.btnApresentar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApresentar.UseVisualStyleBackColor = false;
            this.btnApresentar.Click += new System.EventHandler(this.btnApresentar_Click);
            // 
            // lvDados
            // 
            this.lvDados.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // btnImportar
            // 
            this.btnImportar.BackColor = System.Drawing.Color.Indigo;
            this.btnImportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportar.FlatAppearance.BorderSize = 0;
            this.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportar.ForeColor = System.Drawing.Color.White;
            this.btnImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportar.Location = new System.Drawing.Point(677, 78);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(169, 40);
            this.btnImportar.TabIndex = 18;
            this.btnImportar.Text = "    Importar Dados";
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbEmpresa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(677, 47);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(169, 25);
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
            this.cbTipoXml.Location = new System.Drawing.Point(547, 47);
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
            this.label3.Location = new System.Drawing.Point(543, 24);
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
            this.label2.Location = new System.Drawing.Point(717, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 25;
            this.label2.Text = "Empresa";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(10)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtDiretorio);
            this.panel1.Controls.Add(this.btnSelecionar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbEmpresa);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lvDados);
            this.panel1.Controls.Add(this.cbTipoXml);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnImportar);
            this.panel1.Controls.Add(this.btnApresentar);
            this.panel1.Location = new System.Drawing.Point(0, -7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 644);
            this.panel1.TabIndex = 26;
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
            // txtDiretorio
            // 
            this.txtDiretorio.BackColor = System.Drawing.Color.Indigo;
            this.txtDiretorio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiretorio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiretorio.ForeColor = System.Drawing.SystemColors.Window;
            this.txtDiretorio.Location = new System.Drawing.Point(11, 47);
            this.txtDiretorio.Multiline = true;
            this.txtDiretorio.Name = "txtDiretorio";
            this.txtDiretorio.Size = new System.Drawing.Size(225, 39);
            this.txtDiretorio.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(33, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 21);
            this.label4.TabIndex = 28;
            this.label4.Text = "Diretório dos arquivos\r\n";
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
        private System.Windows.Forms.Button btnApresentar;
        private System.Windows.Forms.ListView lvDados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.ComboBox cbEmpresa;
        private System.Windows.Forms.ComboBox cbTipoXml;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnSelecionar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiretorio;
    }
}