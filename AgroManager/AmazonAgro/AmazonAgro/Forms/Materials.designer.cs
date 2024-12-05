namespace AmazonAgro
{
    partial class Materials
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Materials));
            this.msgLbl = new System.Windows.Forms.Label();
            this.editBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.insertBtn = new System.Windows.Forms.Button();
            this.itemsLvw = new System.Windows.Forms.ListView();
            this.composeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // msgLbl
            // 
            this.msgLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.msgLbl.AutoSize = true;
            this.msgLbl.Location = new System.Drawing.Point(12, 550);
            this.msgLbl.Name = "msgLbl";
            this.msgLbl.Size = new System.Drawing.Size(0, 13);
            this.msgLbl.TabIndex = 7;
            // 
            // editBtn
            // 
            this.editBtn.BackColor = System.Drawing.Color.Black;
            this.editBtn.FlatAppearance.BorderSize = 0;
            this.editBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.editBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editBtn.ForeColor = System.Drawing.Color.White;
            this.editBtn.Image = global::AmazonAgro.Properties.Resources.edit;
            this.editBtn.Location = new System.Drawing.Point(89, 104);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(75, 76);
            this.editBtn.TabIndex = 1;
            this.editBtn.Text = "Editar";
            this.editBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.editBtn.UseVisualStyleBackColor = false;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.Black;
            this.deleteBtn.FlatAppearance.BorderSize = 0;
            this.deleteBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteBtn.ForeColor = System.Drawing.Color.White;
            this.deleteBtn.Image = global::AmazonAgro.Properties.Resources.remove_all;
            this.deleteBtn.Location = new System.Drawing.Point(170, 104);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 76);
            this.deleteBtn.TabIndex = 2;
            this.deleteBtn.Text = "Apagar";
            this.deleteBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // insertBtn
            // 
            this.insertBtn.BackColor = System.Drawing.Color.Black;
            this.insertBtn.FlatAppearance.BorderSize = 0;
            this.insertBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.insertBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.insertBtn.ForeColor = System.Drawing.Color.White;
            this.insertBtn.Image = global::AmazonAgro.Properties.Resources.add;
            this.insertBtn.Location = new System.Drawing.Point(8, 104);
            this.insertBtn.Name = "insertBtn";
            this.insertBtn.Size = new System.Drawing.Size(75, 76);
            this.insertBtn.TabIndex = 0;
            this.insertBtn.Text = "Adicionar";
            this.insertBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.insertBtn.UseVisualStyleBackColor = false;
            this.insertBtn.Click += new System.EventHandler(this.insertBtn_Click);
            // 
            // itemsLvw
            // 
            this.itemsLvw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsLvw.Location = new System.Drawing.Point(9, 186);
            this.itemsLvw.Name = "itemsLvw";
            this.itemsLvw.Size = new System.Drawing.Size(953, 374);
            this.itemsLvw.TabIndex = 4;
            this.itemsLvw.UseCompatibleStateImageBehavior = false;
            // 
            // composeBtn
            // 
            this.composeBtn.BackColor = System.Drawing.Color.Black;
            this.composeBtn.FlatAppearance.BorderSize = 0;
            this.composeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.composeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.composeBtn.ForeColor = System.Drawing.Color.White;
            this.composeBtn.Image = ((System.Drawing.Image)(resources.GetObject("composeBtn.Image")));
            this.composeBtn.Location = new System.Drawing.Point(251, 104);
            this.composeBtn.Name = "composeBtn";
            this.composeBtn.Size = new System.Drawing.Size(75, 76);
            this.composeBtn.TabIndex = 3;
            this.composeBtn.Text = "Compostos";
            this.composeBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.composeBtn.UseVisualStyleBackColor = false;
            this.composeBtn.Click += new System.EventHandler(this.composeBtn_Click);
            // 
            // Materials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(974, 572);
            this.Controls.Add(this.composeBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.itemsLvw);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.insertBtn);
            this.Controls.Add(this.msgLbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(570, 530);
            this.Name = "Materials";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Matéria Prima";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.paint);
            this.Resize += new System.EventHandler(this.resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label msgLbl;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button insertBtn;
        private System.Windows.Forms.ListView itemsLvw;
        private System.Windows.Forms.Button composeBtn;
    }
}

