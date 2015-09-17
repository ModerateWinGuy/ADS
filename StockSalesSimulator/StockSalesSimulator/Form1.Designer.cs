namespace StockSalesSimulator
{
    partial class Form1
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
            this.lstbxBuyOrders = new System.Windows.Forms.ListBox();
            this.lstboxSellOrders = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbxSellOrder = new System.Windows.Forms.TextBox();
            this.txtbxBuyOrder = new System.Windows.Forms.TextBox();
            this.btnAddBuy = new System.Windows.Forms.Button();
            this.btnAddSell = new System.Windows.Forms.Button();
            this.btnSell = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstbxBuyOrders
            // 
            this.lstbxBuyOrders.FormattingEnabled = true;
            this.lstbxBuyOrders.Location = new System.Drawing.Point(164, 22);
            this.lstbxBuyOrders.Name = "lstbxBuyOrders";
            this.lstbxBuyOrders.Size = new System.Drawing.Size(140, 459);
            this.lstbxBuyOrders.TabIndex = 0;
            // 
            // lstboxSellOrders
            // 
            this.lstboxSellOrders.FormattingEnabled = true;
            this.lstboxSellOrders.Location = new System.Drawing.Point(310, 22);
            this.lstboxSellOrders.Name = "lstboxSellOrders";
            this.lstboxSellOrders.Size = new System.Drawing.Size(146, 459);
            this.lstboxSellOrders.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buy Orders";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sell Orders";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Add Buy Order";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(495, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Add Sell Order";
            // 
            // txtbxSellOrder
            // 
            this.txtbxSellOrder.Location = new System.Drawing.Point(483, 89);
            this.txtbxSellOrder.Name = "txtbxSellOrder";
            this.txtbxSellOrder.Size = new System.Drawing.Size(100, 20);
            this.txtbxSellOrder.TabIndex = 6;
            // 
            // txtbxBuyOrder
            // 
            this.txtbxBuyOrder.Location = new System.Drawing.Point(28, 89);
            this.txtbxBuyOrder.Name = "txtbxBuyOrder";
            this.txtbxBuyOrder.Size = new System.Drawing.Size(100, 20);
            this.txtbxBuyOrder.TabIndex = 7;
            // 
            // btnAddBuy
            // 
            this.btnAddBuy.Location = new System.Drawing.Point(41, 115);
            this.btnAddBuy.Name = "btnAddBuy";
            this.btnAddBuy.Size = new System.Drawing.Size(75, 23);
            this.btnAddBuy.TabIndex = 8;
            this.btnAddBuy.Text = "Add";
            this.btnAddBuy.UseVisualStyleBackColor = true;
            this.btnAddBuy.Click += new System.EventHandler(this.btnAddBuy_Click);
            // 
            // btnAddSell
            // 
            this.btnAddSell.Location = new System.Drawing.Point(498, 115);
            this.btnAddSell.Name = "btnAddSell";
            this.btnAddSell.Size = new System.Drawing.Size(75, 23);
            this.btnAddSell.TabIndex = 9;
            this.btnAddSell.Text = "Add";
            this.btnAddSell.UseVisualStyleBackColor = true;
            this.btnAddSell.Click += new System.EventHandler(this.btnAddSell_Click);
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(164, 488);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(292, 31);
            this.btnSell.TabIndex = 10;
            this.btnSell.Text = "Sell!";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 523);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.btnAddSell);
            this.Controls.Add(this.btnAddBuy);
            this.Controls.Add(this.txtbxBuyOrder);
            this.Controls.Add(this.txtbxSellOrder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstboxSellOrders);
            this.Controls.Add(this.lstbxBuyOrders);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstbxBuyOrders;
        private System.Windows.Forms.ListBox lstboxSellOrders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbxSellOrder;
        private System.Windows.Forms.TextBox txtbxBuyOrder;
        private System.Windows.Forms.Button btnAddBuy;
        private System.Windows.Forms.Button btnAddSell;
        private System.Windows.Forms.Button btnSell;
    }
}

