namespace OrdemDeProducaoAmazon
{
    partial class Cliente
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
            this.label6 = new System.Windows.Forms.Label();
            this.telefoneTbx = new System.Windows.Forms.TextBox();
            this.clientesGrid = new System.Windows.Forms.DataGridView();
            this.adicionarBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cpfTbx = new System.Windows.Forms.TextBox();
            this.rgTbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sobrenomeTbx = new System.Windows.Forms.TextBox();
            this.nomeTbx = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.clientesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Telefone:";
            // 
            // telefoneTbx
            // 
            this.telefoneTbx.Location = new System.Drawing.Point(90, 186);
            this.telefoneTbx.Name = "telefoneTbx";
            this.telefoneTbx.Size = new System.Drawing.Size(217, 20);
            this.telefoneTbx.TabIndex = 11;
            // 
            // clientesGrid
            // 
            this.clientesGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.clientesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientesGrid.Location = new System.Drawing.Point(14, 226);
            this.clientesGrid.Name = "clientesGrid";
            this.clientesGrid.Size = new System.Drawing.Size(790, 284);
            this.clientesGrid.TabIndex = 12;
            // 
            // adicionarBtn
            // 
            this.adicionarBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.adicionarBtn.Location = new System.Drawing.Point(14, 12);
            this.adicionarBtn.Name = "adicionarBtn";
            this.adicionarBtn.Size = new System.Drawing.Size(70, 23);
            this.adicionarBtn.TabIndex = 0;
            this.adicionarBtn.Text = "Adicionar";
            this.adicionarBtn.UseVisualStyleBackColor = true;
            this.adicionarBtn.Click += new System.EventHandler(this.adicionarBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "CLIENTE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "CPF/CNPJ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "RG:";
            // 
            // cpfTbx
            // 
            this.cpfTbx.Location = new System.Drawing.Point(90, 160);
            this.cpfTbx.Name = "cpfTbx";
            this.cpfTbx.Size = new System.Drawing.Size(217, 20);
            this.cpfTbx.TabIndex = 9;
            // 
            // rgTbx
            // 
            this.rgTbx.Location = new System.Drawing.Point(90, 134);
            this.rgTbx.Name = "rgTbx";
            this.rgTbx.Size = new System.Drawing.Size(217, 20);
            this.rgTbx.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sobrenome:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nome:";
            // 
            // sobrenomeTbx
            // 
            this.sobrenomeTbx.Location = new System.Drawing.Point(90, 108);
            this.sobrenomeTbx.Name = "sobrenomeTbx";
            this.sobrenomeTbx.Size = new System.Drawing.Size(217, 20);
            this.sobrenomeTbx.TabIndex = 5;
            // 
            // nomeTbx
            // 
            this.nomeTbx.Location = new System.Drawing.Point(90, 82);
            this.nomeTbx.Name = "nomeTbx";
            this.nomeTbx.Size = new System.Drawing.Size(217, 20);
            this.nomeTbx.TabIndex = 3;
            // 
            // Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 522);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.telefoneTbx);
            this.Controls.Add(this.clientesGrid);
            this.Controls.Add(this.adicionarBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cpfTbx);
            this.Controls.Add(this.rgTbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sobrenomeTbx);
            this.Controls.Add(this.nomeTbx);
            this.Name = "Cliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produto";
            ((System.ComponentModel.ISupportInitialize)(this.clientesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox telefoneTbx;
        private System.Windows.Forms.DataGridView clientesGrid;
        private System.Windows.Forms.Button adicionarBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cpfTbx;
        private System.Windows.Forms.TextBox rgTbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sobrenomeTbx;
        private System.Windows.Forms.TextBox nomeTbx;

    }
}