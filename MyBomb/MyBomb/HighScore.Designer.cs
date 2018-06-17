namespace MyBomb
{
    partial class HighScore
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
            this.OK_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.HS_1 = new System.Windows.Forms.Label();
            this.HS_3 = new System.Windows.Forms.Label();
            this.HS_2 = new System.Windows.Forms.Label();
            this.Over_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OK_Button
            // 
            this.OK_Button.BackColor = System.Drawing.Color.Transparent;
            this.OK_Button.BackgroundImage = global::MyBomb.Properties.Resources.Button;
            this.OK_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OK_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OK_Button.FlatAppearance.BorderSize = 0;
            this.OK_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.OK_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.OK_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK_Button.Font = new System.Drawing.Font("Monotype Corsiva", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OK_Button.Location = new System.Drawing.Point(82, 379);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(135, 43);
            this.OK_Button.TabIndex = 0;
            this.OK_Button.TabStop = false;
            this.OK_Button.Text = "OK";
            this.OK_Button.UseVisualStyleBackColor = false;
            this.OK_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "High Score";
            // 
            // HS_1
            // 
            this.HS_1.BackColor = System.Drawing.Color.Transparent;
            this.HS_1.Font = new System.Drawing.Font("Minion Pro SmBd", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HS_1.Location = new System.Drawing.Point(120, 218);
            this.HS_1.Name = "HS_1";
            this.HS_1.Size = new System.Drawing.Size(65, 29);
            this.HS_1.TabIndex = 2;
            this.HS_1.Text = "label2";
            this.HS_1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // HS_3
            // 
            this.HS_3.BackColor = System.Drawing.Color.Transparent;
            this.HS_3.Font = new System.Drawing.Font("Minion Pro SmBd", 15.75F, System.Drawing.FontStyle.Bold);
            this.HS_3.Location = new System.Drawing.Point(120, 313);
            this.HS_3.Name = "HS_3";
            this.HS_3.Size = new System.Drawing.Size(65, 30);
            this.HS_3.TabIndex = 2;
            this.HS_3.Text = "label2";
            this.HS_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HS_2
            // 
            this.HS_2.BackColor = System.Drawing.Color.Transparent;
            this.HS_2.Font = new System.Drawing.Font("Minion Pro SmBd", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HS_2.Location = new System.Drawing.Point(120, 264);
            this.HS_2.Name = "HS_2";
            this.HS_2.Size = new System.Drawing.Size(65, 29);
            this.HS_2.TabIndex = 2;
            this.HS_2.Text = "label2";
            this.HS_2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Over_Label
            // 
            this.Over_Label.AutoSize = true;
            this.Over_Label.BackColor = System.Drawing.Color.Transparent;
            this.Over_Label.Font = new System.Drawing.Font("Mistral", 52F, System.Drawing.FontStyle.Bold);
            this.Over_Label.ForeColor = System.Drawing.Color.Red;
            this.Over_Label.Location = new System.Drawing.Point(-10, 9);
            this.Over_Label.Name = "Over_Label";
            this.Over_Label.Size = new System.Drawing.Size(328, 83);
            this.Over_Label.TabIndex = 3;
            this.Over_Label.Text = "GAME OVER";
            // 
            // HighScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::MyBomb.Properties.Resources.Win;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(305, 430);
            this.Controls.Add(this.Over_Label);
            this.Controls.Add(this.HS_3);
            this.Controls.Add(this.HS_2);
            this.Controls.Add(this.HS_1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OK_Button);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HighScore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HighScore";
            this.TransparencyKey = System.Drawing.Color.White;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Label HS_1;
        private System.Windows.Forms.Label HS_3;
        private System.Windows.Forms.Label HS_2;
        private System.Windows.Forms.Label Over_Label;
    }
}