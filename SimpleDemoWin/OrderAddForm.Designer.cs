namespace SimpleDemoWin
{
    partial class OrderAddForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.priceBox = new System.Windows.Forms.NumericUpDown();
            this.countBox = new System.Windows.Forms.NumericUpDown();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.priceBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Имя";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Цена";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Количество";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(102, 24);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(335, 20);
            this.nameBox.TabIndex = 23;
            // 
            // priceBox
            // 
            this.priceBox.DecimalPlaces = 2;
            this.priceBox.Location = new System.Drawing.Point(102, 49);
            this.priceBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.priceBox.Name = "priceBox";
            this.priceBox.Size = new System.Drawing.Size(335, 20);
            this.priceBox.TabIndex = 29;
            this.priceBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // countBox
            // 
            this.countBox.Location = new System.Drawing.Point(102, 75);
            this.countBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.countBox.Name = "countBox";
            this.countBox.Size = new System.Drawing.Size(335, 20);
            this.countBox.TabIndex = 30;
            this.countBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(144, 123);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(91, 23);
            this.cancelButton.TabIndex = 32;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(252, 122);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(89, 23);
            this.addBtn.TabIndex = 31;
            this.addBtn.Text = "ОК";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // OrderAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 169);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.countBox);
            this.Controls.Add(this.priceBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameBox);
            this.Name = "OrderAddForm";
            this.Text = "OrderAddForm";
            this.Load += new System.EventHandler(this.OrderAddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.priceBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.NumericUpDown priceBox;
        private System.Windows.Forms.NumericUpDown countBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button addBtn;
    }
}