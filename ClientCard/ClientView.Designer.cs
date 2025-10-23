namespace ClientCard
{
    partial class ClientView
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TitleLabel = new System.Windows.Forms.Label();
            this.AvatarBox = new System.Windows.Forms.PictureBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.MailLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(75)))), ((int)(((byte)(161)))));
            this.TitleLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.TitleLabel.Location = new System.Drawing.Point(255, 104);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(272, 32);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "label1";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AvatarBox
            // 
            this.AvatarBox.Location = new System.Drawing.Point(0, 0);
            this.AvatarBox.Name = "AvatarBox";
            this.AvatarBox.Size = new System.Drawing.Size(250, 250);
            this.AvatarBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AvatarBox.TabIndex = 1;
            this.AvatarBox.TabStop = false;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(75)))), ((int)(((byte)(161)))));
            this.DescriptionLabel.Location = new System.Drawing.Point(257, 132);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(268, 25);
            this.DescriptionLabel.TabIndex = 2;
            this.DescriptionLabel.Text = "label1";
            this.DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PhoneLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(75)))), ((int)(((byte)(161)))));
            this.PhoneLabel.Location = new System.Drawing.Point(257, 214);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(38, 14);
            this.PhoneLabel.TabIndex = 3;
            this.PhoneLabel.Text = "label1";
            // 
            // MailLabel
            // 
            this.MailLabel.AutoSize = true;
            this.MailLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(75)))), ((int)(((byte)(161)))));
            this.MailLabel.Location = new System.Drawing.Point(257, 228);
            this.MailLabel.Name = "MailLabel";
            this.MailLabel.Size = new System.Drawing.Size(38, 14);
            this.MailLabel.TabIndex = 4;
            this.MailLabel.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(75)))), ((int)(((byte)(161)))));
            this.label1.Location = new System.Drawing.Point(360, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Клиент";
            // 
            // ClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MailLabel);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.AvatarBox);
            this.Controls.Add(this.TitleLabel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ClientView";
            this.Size = new System.Drawing.Size(532, 250);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClientView_MouseClick);
            this.MouseEnter += new System.EventHandler(this.ClientView_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ClientView_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.AvatarBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.PictureBox AvatarBox;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.Label MailLabel;
        private System.Windows.Forms.Label label1;
    }
}
