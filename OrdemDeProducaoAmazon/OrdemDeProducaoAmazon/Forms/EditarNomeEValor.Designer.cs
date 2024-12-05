namespace OrdemDeProducaoAmazon
{
    partial class EditarNomeEValor
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
            this.nameLbl = new System.Windows.Forms.Label();
            this.nomeTbx = new System.Windows.Forms.TextBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.valorTbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tipoCbx = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(12, 9);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(38, 13);
            this.nameLbl.TabIndex = 0;
            this.nameLbl.Text = "Nome:";
            // 
            // nomeTbx
            // 
            this.nomeTbx.Location = new System.Drawing.Point(12, 25);
            this.nomeTbx.Name = "nomeTbx";
            this.nomeTbx.Size = new System.Drawing.Size(222, 20);
            this.nomeTbx.TabIndex = 1;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(157, 131);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // valorTbx
            // 
            this.valorTbx.Location = new System.Drawing.Point(12, 64);
            this.valorTbx.Name = "valorTbx";
            this.valorTbx.Size = new System.Drawing.Size(222, 20);
            this.valorTbx.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Valor (FOB):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tipo:";
            // 
            // tipoCbx
            // 
            this.tipoCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoCbx.FormattingEnabled = true;
            this.tipoCbx.Items.AddRange(new object[] {
            "Sólido",
            "Líquido"});
            this.tipoCbx.Location = new System.Drawing.Point(12, 103);
            this.tipoCbx.Name = "tipoCbx";
            this.tipoCbx.Size = new System.Drawing.Size(220, 21);
            this.tipoCbx.TabIndex = 6;
            // 
            // EditarNomeEValor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 166);
            this.Controls.Add(this.tipoCbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.valorTbx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.nomeTbx);
            this.Controls.Add(this.nameLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditarNomeEValor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditarNome";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.TextBox nomeTbx;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.TextBox valorTbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tipoCbx;
    }
}