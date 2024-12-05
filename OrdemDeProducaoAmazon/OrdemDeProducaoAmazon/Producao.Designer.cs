namespace OrdemDeProducaoAmazon
{
    partial class Producao
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.qdteLitrosTbx = new System.Windows.Forms.TextBox();
            this.densidadeTbx = new System.Windows.Forms.TextBox();
            this.calculosGrid = new System.Windows.Forms.DataGridView();
            this.materiasGrid = new System.Windows.Forms.DataGridView();
            this.msgLbl = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.clienteTbx = new System.Windows.Forms.TextBox();
            this.pesquisarBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.calculosGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiasGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "QTDE (L):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Densidade:";
            // 
            // qdteLitrosTbx
            // 
            this.qdteLitrosTbx.Location = new System.Drawing.Point(260, 40);
            this.qdteLitrosTbx.Name = "qdteLitrosTbx";
            this.qdteLitrosTbx.Size = new System.Drawing.Size(102, 20);
            this.qdteLitrosTbx.TabIndex = 6;
            this.qdteLitrosTbx.Text = "0";
            this.qdteLitrosTbx.TextChanged += new System.EventHandler(this.Main_TextChanged);
            // 
            // densidadeTbx
            // 
            this.densidadeTbx.Location = new System.Drawing.Point(79, 40);
            this.densidadeTbx.Name = "densidadeTbx";
            this.densidadeTbx.Size = new System.Drawing.Size(102, 20);
            this.densidadeTbx.TabIndex = 4;
            this.densidadeTbx.Text = "0";
            this.densidadeTbx.TextChanged += new System.EventHandler(this.Main_TextChanged);
            // 
            // calculosGrid
            // 
            this.calculosGrid.AllowDrop = true;
            this.calculosGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calculosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.calculosGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.calculosGrid.Location = new System.Drawing.Point(368, 66);
            this.calculosGrid.Name = "calculosGrid";
            this.calculosGrid.Size = new System.Drawing.Size(404, 397);
            this.calculosGrid.TabIndex = 8;
            this.calculosGrid.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            this.calculosGrid.DragOver += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragOver);
            // 
            // materiasGrid
            // 
            this.materiasGrid.AllowDrop = true;
            this.materiasGrid.AllowUserToAddRows = false;
            this.materiasGrid.AllowUserToDeleteRows = false;
            this.materiasGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.materiasGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.materiasGrid.Location = new System.Drawing.Point(12, 66);
            this.materiasGrid.Name = "materiasGrid";
            this.materiasGrid.Size = new System.Drawing.Size(350, 397);
            this.materiasGrid.TabIndex = 7;
            this.materiasGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            this.materiasGrid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseMove);
            // 
            // msgLbl
            // 
            this.msgLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.msgLbl.AutoSize = true;
            this.msgLbl.Location = new System.Drawing.Point(12, 470);
            this.msgLbl.Name = "msgLbl";
            this.msgLbl.Size = new System.Drawing.Size(0, 13);
            this.msgLbl.TabIndex = 9;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem3});
            this.menuItem1.Text = "Arquivo";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "Abrir...";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "Salvar";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cliente:";
            // 
            // clienteTbx
            // 
            this.clienteTbx.Location = new System.Drawing.Point(79, 12);
            this.clienteTbx.Name = "clienteTbx";
            this.clienteTbx.Size = new System.Drawing.Size(102, 20);
            this.clienteTbx.TabIndex = 1;
            // 
            // pesquisarBtn
            // 
            this.pesquisarBtn.Location = new System.Drawing.Point(187, 10);
            this.pesquisarBtn.Name = "pesquisarBtn";
            this.pesquisarBtn.Size = new System.Drawing.Size(67, 23);
            this.pesquisarBtn.TabIndex = 2;
            this.pesquisarBtn.Text = "Pesquisar";
            this.pesquisarBtn.UseVisualStyleBackColor = true;
            this.pesquisarBtn.Click += new System.EventHandler(this.pesquisarBtn_Click);
            // 
            // Producao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 492);
            this.Controls.Add(this.pesquisarBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.clienteTbx);
            this.Controls.Add(this.msgLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.qdteLitrosTbx);
            this.Controls.Add(this.densidadeTbx);
            this.Controls.Add(this.calculosGrid);
            this.Controls.Add(this.materiasGrid);
            this.Menu = this.mainMenu1;
            this.Name = "Producao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Producao";
            ((System.ComponentModel.ISupportInitialize)(this.calculosGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiasGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox qdteLitrosTbx;
        private System.Windows.Forms.TextBox densidadeTbx;
        private System.Windows.Forms.DataGridView calculosGrid;
        private System.Windows.Forms.DataGridView materiasGrid;
        private System.Windows.Forms.Label msgLbl;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox clienteTbx;
        private System.Windows.Forms.Button pesquisarBtn;
    }
}