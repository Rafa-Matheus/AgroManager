namespace OrdemDeProducaoAmazon
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ordemBtn = new System.Windows.Forms.Button();
            this.produtosBtn = new System.Windows.Forms.Button();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materiasBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.clientesBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ordemBtn
            // 
            this.ordemBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ordemBtn.FlatAppearance.BorderSize = 0;
            this.ordemBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ordemBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ordemBtn.ForeColor = System.Drawing.Color.White;
            this.ordemBtn.Image = ((System.Drawing.Image)(resources.GetObject("ordemBtn.Image")));
            this.ordemBtn.Location = new System.Drawing.Point(3, 3);
            this.ordemBtn.Name = "ordemBtn";
            this.ordemBtn.Size = new System.Drawing.Size(160, 160);
            this.ordemBtn.TabIndex = 0;
            this.ordemBtn.Text = "Ordem de Produção";
            this.ordemBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ordemBtn.UseVisualStyleBackColor = false;
            this.ordemBtn.Click += new System.EventHandler(this.ordemBtn_Click);
            // 
            // produtosBtn
            // 
            this.produtosBtn.BackColor = System.Drawing.Color.ForestGreen;
            this.produtosBtn.FlatAppearance.BorderSize = 0;
            this.produtosBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.produtosBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produtosBtn.ForeColor = System.Drawing.Color.White;
            this.produtosBtn.Image = ((System.Drawing.Image)(resources.GetObject("produtosBtn.Image")));
            this.produtosBtn.Location = new System.Drawing.Point(3, 169);
            this.produtosBtn.Name = "produtosBtn";
            this.produtosBtn.Size = new System.Drawing.Size(160, 160);
            this.produtosBtn.TabIndex = 1;
            this.produtosBtn.Text = "Produtos";
            this.produtosBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.produtosBtn.UseVisualStyleBackColor = false;
            this.produtosBtn.Click += new System.EventHandler(this.produtosBtn_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "Arquivo";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "Dados";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Início";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(387, 449);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 99);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // materiasBtn
            // 
            this.materiasBtn.BackColor = System.Drawing.Color.Blue;
            this.materiasBtn.FlatAppearance.BorderSize = 0;
            this.materiasBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materiasBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materiasBtn.ForeColor = System.Drawing.Color.White;
            this.materiasBtn.Image = ((System.Drawing.Image)(resources.GetObject("materiasBtn.Image")));
            this.materiasBtn.Location = new System.Drawing.Point(335, 3);
            this.materiasBtn.Name = "materiasBtn";
            this.materiasBtn.Size = new System.Drawing.Size(160, 160);
            this.materiasBtn.TabIndex = 4;
            this.materiasBtn.Text = "Matérias Primas";
            this.materiasBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.materiasBtn.UseVisualStyleBackColor = false;
            this.materiasBtn.Click += new System.EventHandler(this.materiasBtn_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.ordemBtn);
            this.flowLayoutPanel1.Controls.Add(this.clientesBtn);
            this.flowLayoutPanel1.Controls.Add(this.materiasBtn);
            this.flowLayoutPanel1.Controls.Add(this.produtosBtn);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(18, 74);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(544, 369);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // clientesBtn
            // 
            this.clientesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.clientesBtn.FlatAppearance.BorderSize = 0;
            this.clientesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clientesBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientesBtn.ForeColor = System.Drawing.Color.White;
            this.clientesBtn.Image = ((System.Drawing.Image)(resources.GetObject("clientesBtn.Image")));
            this.clientesBtn.Location = new System.Drawing.Point(169, 3);
            this.clientesBtn.Name = "clientesBtn";
            this.clientesBtn.Size = new System.Drawing.Size(160, 160);
            this.clientesBtn.TabIndex = 5;
            this.clientesBtn.Text = "Clientes";
            this.clientesBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.clientesBtn.UseVisualStyleBackColor = false;
            this.clientesBtn.Click += new System.EventHandler(this.clientesBtn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(574, 560);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(590, 470);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ordemBtn;
        private System.Windows.Forms.Button produtosBtn;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button materiasBtn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button clientesBtn;
    }
}