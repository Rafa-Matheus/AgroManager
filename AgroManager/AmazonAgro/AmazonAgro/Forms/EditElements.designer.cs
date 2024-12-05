using System.Windows.Forms;
namespace AmazonAgro
{
    partial class EditElements
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditElements));
            this.periodicPnl = new System.Windows.Forms.Panel();
            this.itemsPnl = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.composePnl = new System.Windows.Forms.FlowLayoutPanel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.okBtn = new AmazonAgro.CustomButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // periodicPnl
            // 
            this.periodicPnl.AutoScroll = true;
            this.periodicPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.periodicPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.periodicPnl.Location = new System.Drawing.Point(0, 0);
            this.periodicPnl.Name = "periodicPnl";
            this.periodicPnl.Size = new System.Drawing.Size(1200, 378);
            this.periodicPnl.TabIndex = 9;
            // 
            // itemsPnl
            // 
            this.itemsPnl.AutoScroll = true;
            this.itemsPnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemsPnl.Dock = System.Windows.Forms.DockStyle.Right;
            this.itemsPnl.ForeColor = System.Drawing.Color.White;
            this.itemsPnl.Location = new System.Drawing.Point(1203, 0);
            this.itemsPnl.Name = "itemsPnl";
            this.itemsPnl.Size = new System.Drawing.Size(174, 495);
            this.itemsPnl.TabIndex = 10;
            this.itemsPnl.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.added);
            this.itemsPnl.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.removed);
            this.itemsPnl.Paint += new System.Windows.Forms.PaintEventHandler(this.items_paint);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.periodicPnl);
            this.panel1.Controls.Add(this.splitter2);
            this.panel1.Controls.Add(this.composePnl);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.itemsPnl);
            this.panel1.Location = new System.Drawing.Point(12, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1377, 495);
            this.panel1.TabIndex = 11;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 378);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1200, 3);
            this.splitter2.TabIndex = 13;
            this.splitter2.TabStop = false;
            // 
            // composePnl
            // 
            this.composePnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.composePnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.composePnl.Location = new System.Drawing.Point(0, 381);
            this.composePnl.Name = "composePnl";
            this.composePnl.Size = new System.Drawing.Size(1200, 114);
            this.composePnl.TabIndex = 12;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(1200, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 495);
            this.splitter1.TabIndex = 11;
            this.splitter1.TabStop = false;
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(168)))), ((int)(((byte)(59)))));
            this.okBtn.FlatAppearance.BorderSize = 0;
            this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.okBtn.ForeColor = System.Drawing.Color.White;
            this.okBtn.Location = new System.Drawing.Point(1314, 604);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 12;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = false;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // EditElements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1401, 639);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(710, 390);
            this.Name = "EditElements";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nutrientes";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.paint);
            this.Resize += new System.EventHandler(this.resize);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel periodicPnl;
        private FlowLayoutPanel itemsPnl;
        private Panel panel1;
        private Splitter splitter1;
        private CustomButton okBtn;
        private Splitter splitter2;
        private FlowLayoutPanel composePnl;
    }
}