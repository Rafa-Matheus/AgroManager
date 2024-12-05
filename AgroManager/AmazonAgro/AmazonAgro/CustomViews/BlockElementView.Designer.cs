namespace AmazonAgro
{
    partial class BlockElementView
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

        #region código gerado pelo Component Designer

        /// <summary> 
        /// Método necessário para o suporte do Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlockElementView));
            this.fieldsPnl = new System.Windows.Forms.Panel();
            this.disposeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fieldsPnl
            // 
            this.fieldsPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldsPnl.Location = new System.Drawing.Point(3, 47);
            this.fieldsPnl.Name = "fieldsPnl";
            this.fieldsPnl.Size = new System.Drawing.Size(142, 98);
            this.fieldsPnl.TabIndex = 0;
            // 
            // disposeBtn
            // 
            this.disposeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.disposeBtn.BackColor = System.Drawing.Color.Transparent;
            this.disposeBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("disposeBtn.BackgroundImage")));
            this.disposeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.disposeBtn.FlatAppearance.BorderSize = 0;
            this.disposeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disposeBtn.Location = new System.Drawing.Point(129, 1);
            this.disposeBtn.Name = "disposeBtn";
            this.disposeBtn.Size = new System.Drawing.Size(16, 16);
            this.disposeBtn.TabIndex = 1;
            this.disposeBtn.UseVisualStyleBackColor = false;
            this.disposeBtn.Click += new System.EventHandler(this.disposeBtn_Click);
            // 
            // BlockElementView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.disposeBtn);
            this.Controls.Add(this.fieldsPnl);
            this.Name = "BlockElementView";
            this.Size = new System.Drawing.Size(148, 148);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel fieldsPnl;
        private System.Windows.Forms.Button disposeBtn;

    }
}
