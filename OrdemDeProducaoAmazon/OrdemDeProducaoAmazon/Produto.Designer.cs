namespace OrdemDeProducaoAmazon
{
    partial class Produto
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clienteTbx = new System.Windows.Forms.TextBox();
            this.nomeTbx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.culturaTbx = new System.Windows.Forms.TextBox();
            this.dataTbx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.adicionarBtn = new System.Windows.Forms.Button();
            this.produtosGrid = new System.Windows.Forms.DataGridView();
            this.pesquisarBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.produtosGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Cliente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nome:";
            // 
            // clienteTbx
            // 
            this.clienteTbx.Location = new System.Drawing.Point(88, 108);
            this.clienteTbx.Name = "clienteTbx";
            this.clienteTbx.Size = new System.Drawing.Size(217, 20);
            this.clienteTbx.TabIndex = 7;
            // 
            // nomeTbx
            // 
            this.nomeTbx.Location = new System.Drawing.Point(88, 82);
            this.nomeTbx.Name = "nomeTbx";
            this.nomeTbx.Size = new System.Drawing.Size(217, 20);
            this.nomeTbx.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Cultura:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Data:";
            // 
            // culturaTbx
            // 
            this.culturaTbx.Location = new System.Drawing.Point(88, 160);
            this.culturaTbx.Name = "culturaTbx";
            this.culturaTbx.Size = new System.Drawing.Size(217, 20);
            this.culturaTbx.TabIndex = 11;
            // 
            // dataTbx
            // 
            this.dataTbx.Location = new System.Drawing.Point(88, 134);
            this.dataTbx.Name = "dataTbx";
            this.dataTbx.Size = new System.Drawing.Size(217, 20);
            this.dataTbx.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "PRODUTO";
            // 
            // adicionarBtn
            // 
            this.adicionarBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.adicionarBtn.Location = new System.Drawing.Point(12, 12);
            this.adicionarBtn.Name = "adicionarBtn";
            this.adicionarBtn.Size = new System.Drawing.Size(70, 23);
            this.adicionarBtn.TabIndex = 18;
            this.adicionarBtn.Text = "Adicionar";
            this.adicionarBtn.UseVisualStyleBackColor = true;
            this.adicionarBtn.Click += new System.EventHandler(this.adicionarBtn_Click);
            // 
            // produtosGrid
            // 
            this.produtosGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.produtosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.produtosGrid.Location = new System.Drawing.Point(12, 199);
            this.produtosGrid.Name = "produtosGrid";
            this.produtosGrid.Size = new System.Drawing.Size(790, 311);
            this.produtosGrid.TabIndex = 20;
            // 
            // pesquisarBtn
            // 
            this.pesquisarBtn.Location = new System.Drawing.Point(311, 106);
            this.pesquisarBtn.Name = "pesquisarBtn";
            this.pesquisarBtn.Size = new System.Drawing.Size(67, 23);
            this.pesquisarBtn.TabIndex = 21;
            this.pesquisarBtn.Text = "Pesquisar";
            this.pesquisarBtn.UseVisualStyleBackColor = true;
            this.pesquisarBtn.Click += new System.EventHandler(this.pesquisarBtn_Click);
            // 
            // Produto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 522);
            this.Controls.Add(this.pesquisarBtn);
            this.Controls.Add(this.produtosGrid);
            this.Controls.Add(this.adicionarBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.culturaTbx);
            this.Controls.Add(this.dataTbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clienteTbx);
            this.Controls.Add(this.nomeTbx);
            this.Name = "Produto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produto";
            ((System.ComponentModel.ISupportInitialize)(this.produtosGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox clienteTbx;
        private System.Windows.Forms.TextBox nomeTbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox culturaTbx;
        private System.Windows.Forms.TextBox dataTbx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button adicionarBtn;
        private System.Windows.Forms.DataGridView produtosGrid;
        private System.Windows.Forms.Button pesquisarBtn;
    }
}