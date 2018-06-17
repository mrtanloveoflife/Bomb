namespace MyBomb
{
    partial class GameEx
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Score_Label = new System.Windows.Forms.Label();
            this.Heart_Label = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.S_Label = new System.Windows.Forms.Label();
            this.M_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Score_Label
            // 
            this.Score_Label.AutoSize = true;
            this.Score_Label.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Score_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score_Label.ForeColor = System.Drawing.Color.White;
            this.Score_Label.Location = new System.Drawing.Point(964, 9);
            this.Score_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Score_Label.Name = "Score_Label";
            this.Score_Label.Size = new System.Drawing.Size(115, 39);
            this.Score_Label.TabIndex = 0;
            this.Score_Label.Text = "label1";
            // 
            // Heart_Label
            // 
            this.Heart_Label.AutoSize = true;
            this.Heart_Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Heart_Label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Heart_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Heart_Label.Location = new System.Drawing.Point(693, 10);
            this.Heart_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Heart_Label.Name = "Heart_Label";
            this.Heart_Label.Size = new System.Drawing.Size(132, 46);
            this.Heart_Label.TabIndex = 0;
            this.Heart_Label.Text = "label1";
            this.Heart_Label.Click += new System.EventHandler(this.Heart_Label_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(784, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = ":";
            // 
            // S_Label
            // 
            this.S_Label.AutoSize = true;
            this.S_Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.S_Label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.S_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.S_Label.Location = new System.Drawing.Point(813, 9);
            this.S_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.S_Label.Name = "S_Label";
            this.S_Label.Size = new System.Drawing.Size(66, 46);
            this.S_Label.TabIndex = 0;
            this.S_Label.Text = "00";
            // 
            // M_Label
            // 
            this.M_Label.AutoSize = true;
            this.M_Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.M_Label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.M_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.M_Label.Location = new System.Drawing.Point(745, 9);
            this.M_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.M_Label.Name = "M_Label";
            this.M_Label.Size = new System.Drawing.Size(43, 46);
            this.M_Label.TabIndex = 0;
            this.M_Label.Text = "3";
            // 
            // GameEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 601);
            this.Controls.Add(this.M_Label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.S_Label);
            this.Controls.Add(this.Heart_Label);
            this.Controls.Add(this.Score_Label);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameEx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameEx";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameEx_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Score_Label;
        private System.Windows.Forms.Label Heart_Label;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label S_Label;
        private System.Windows.Forms.Label M_Label;
    }
}