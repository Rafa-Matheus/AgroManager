namespace OrdemDeProducaoAmazon
{
    partial class MateriaPrima
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">verdade se for necessário descartar os recursos gerenciados; caso contrário, falso.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte do Designer - não modifique
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.materiasGrid = new System.Windows.Forms.DataGridView();
            this.msgLbl = new System.Windows.Forms.Label();
            this.adicionarBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.materiasGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // materiasGrid
            // 
            this.materiasGrid.AllowDrop = true;
            this.materiasGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.materiasGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.materiasGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.materiasGrid.Location = new System.Drawing.Point(12, 41);
            this.materiasGrid.Name = "materiasGrid";
            this.materiasGrid.Size = new System.Drawing.Size(760, 430);
            this.materiasGrid.TabIndex = 0;
            // 
            // msgLbl
            // 
            this.msgLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.msgLbl.AutoSize = true;
            this.msgLbl.Location = new System.Drawing.Point(12, 480);
            this.msgLbl.Name = "msgLbl";
            this.msgLbl.Size = new System.Drawing.Size(0, 13);
            this.msgLbl.TabIndex = 7;
            // 
            // adicionarBtn
            // 
            this.adicionarBtn.Location = new System.Drawing.Point(12, 12);
            this.adicionarBtn.Name = "adicionarBtn";
            this.adicionarBtn.Size = new System.Drawing.Size(78, 23);
            this.adicionarBtn.TabIndex = 8;
            this.adicionarBtn.Text = "Adicionar";
            this.adicionarBtn.UseVisualStyleBackColor = true;
            this.adicionarBtn.Click += new System.EventHandler(this.adicionarBtn_Click);
            // 
            // MateriaPrima
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 502);
            this.Controls.Add(this.adicionarBtn);
            this.Controls.Add(this.msgLbl);
            this.Controls.Add(this.materiasGrid);
            this.Name = "MateriaPrima";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matéria Prima";
            ((System.ComponentModel.ISupportInitialize)(this.materiasGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView materiasGrid;
        private System.Windows.Forms.Label msgLbl;
        private System.Windows.Forms.Button adicionarBtn;
    }
}

