namespace OrdemDeProducaoAmazon
{
    partial class EditarElementos
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
            this.label3 = new System.Windows.Forms.Label();
            this.simboloTbx = new System.Windows.Forms.TextBox();
            this.porcentagemTbx = new System.Windows.Forms.TextBox();
            this.elementosLbx = new System.Windows.Forms.ListBox();
            this.addElementBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Símbolo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Porcentagem:";
            // 
            // simboloTbx
            // 
            this.simboloTbx.Location = new System.Drawing.Point(70, 12);
            this.simboloTbx.Name = "simboloTbx";
            this.simboloTbx.Size = new System.Drawing.Size(100, 20);
            this.simboloTbx.TabIndex = 4;
            // 
            // porcentagemTbx
            // 
            this.porcentagemTbx.Location = new System.Drawing.Point(255, 12);
            this.porcentagemTbx.Name = "porcentagemTbx";
            this.porcentagemTbx.Size = new System.Drawing.Size(100, 20);
            this.porcentagemTbx.TabIndex = 5;
            // 
            // elementosLbx
            // 
            this.elementosLbx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementosLbx.FormattingEnabled = true;
            this.elementosLbx.Location = new System.Drawing.Point(70, 36);
            this.elementosLbx.Name = "elementosLbx";
            this.elementosLbx.Size = new System.Drawing.Size(612, 264);
            this.elementosLbx.TabIndex = 6;
            this.elementosLbx.DoubleClick += new System.EventHandler(this.double_click);
            // 
            // addElementBtn
            // 
            this.addElementBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addElementBtn.Location = new System.Drawing.Point(607, 10);
            this.addElementBtn.Name = "addElementBtn";
            this.addElementBtn.Size = new System.Drawing.Size(75, 23);
            this.addElementBtn.TabIndex = 7;
            this.addElementBtn.Text = "Adicionar";
            this.addElementBtn.UseVisualStyleBackColor = true;
            this.addElementBtn.Click += new System.EventHandler(this.addElementBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(607, 317);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 8;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // EditarElementos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 352);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.addElementBtn);
            this.Controls.Add(this.elementosLbx);
            this.Controls.Add(this.porcentagemTbx);
            this.Controls.Add(this.simboloTbx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.MinimumSize = new System.Drawing.Size(710, 390);
            this.Name = "EditarElementos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditarElementos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox simboloTbx;
        private System.Windows.Forms.TextBox porcentagemTbx;
        private System.Windows.Forms.ListBox elementosLbx;
        private System.Windows.Forms.Button addElementBtn;
        private System.Windows.Forms.Button okBtn;
    }
}