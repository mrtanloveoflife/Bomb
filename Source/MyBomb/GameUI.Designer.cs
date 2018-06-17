namespace MyBomb
{
    partial class GameUI_Form
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.Back_Button = new System.Windows.Forms.Button();
            this.HiScore_Button = new System.Windows.Forms.Button();
            this.Play_Button = new System.Windows.Forms.Button();
            this.Guide_Button = new System.Windows.Forms.Button();
            this.Quit_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Back_Button
            // 
            this.Back_Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Back_Button.BackColor = System.Drawing.Color.Transparent;
            this.Back_Button.BackgroundImage = global::MyBomb.Properties.Resources.Button_Exit;
            this.Back_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Back_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Back_Button.FlatAppearance.BorderSize = 0;
            this.Back_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Back_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Back_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back_Button.Location = new System.Drawing.Point(0, 0);
            this.Back_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Back_Button.Name = "Back_Button";
            this.Back_Button.Size = new System.Drawing.Size(68, 60);
            this.Back_Button.TabIndex = 19;
            this.Back_Button.TabStop = false;
            this.Back_Button.UseVisualStyleBackColor = false;
            this.Back_Button.Click += new System.EventHandler(this.Back_Button_Click);
            // 
            // HiScore_Button
            // 
            this.HiScore_Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.HiScore_Button.BackColor = System.Drawing.Color.Transparent;
            this.HiScore_Button.BackgroundImage = global::MyBomb.Properties.Resources.Button;
            this.HiScore_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HiScore_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HiScore_Button.FlatAppearance.BorderSize = 0;
            this.HiScore_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.HiScore_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.HiScore_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HiScore_Button.Font = new System.Drawing.Font("Niagara Engraved", 24F, System.Drawing.FontStyle.Bold);
            this.HiScore_Button.Location = new System.Drawing.Point(73, 474);
            this.HiScore_Button.Margin = new System.Windows.Forms.Padding(2);
            this.HiScore_Button.Name = "HiScore_Button";
            this.HiScore_Button.Size = new System.Drawing.Size(193, 66);
            this.HiScore_Button.TabIndex = 16;
            this.HiScore_Button.TabStop = false;
            this.HiScore_Button.Text = "High Score";
            this.HiScore_Button.UseVisualStyleBackColor = false;
            this.HiScore_Button.Click += new System.EventHandler(this.HiScore_Button_Click);
            // 
            // Play_Button
            // 
            this.Play_Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Play_Button.BackColor = System.Drawing.Color.Transparent;
            this.Play_Button.BackgroundImage = global::MyBomb.Properties.Resources.Button;
            this.Play_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Play_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Play_Button.FlatAppearance.BorderSize = 0;
            this.Play_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Play_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Play_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Play_Button.Font = new System.Drawing.Font("Niagara Engraved", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Play_Button.ForeColor = System.Drawing.Color.Black;
            this.Play_Button.Location = new System.Drawing.Point(282, 474);
            this.Play_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Play_Button.Name = "Play_Button";
            this.Play_Button.Size = new System.Drawing.Size(193, 66);
            this.Play_Button.TabIndex = 16;
            this.Play_Button.TabStop = false;
            this.Play_Button.Text = "Play";
            this.Play_Button.UseVisualStyleBackColor = false;
            this.Play_Button.Click += new System.EventHandler(this.Play_Button_Click);
            // 
            // Guide_Button
            // 
            this.Guide_Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Guide_Button.BackColor = System.Drawing.Color.Transparent;
            this.Guide_Button.BackgroundImage = global::MyBomb.Properties.Resources.Button;
            this.Guide_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Guide_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Guide_Button.FlatAppearance.BorderSize = 0;
            this.Guide_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Guide_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Guide_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Guide_Button.Font = new System.Drawing.Font("Niagara Engraved", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Guide_Button.ForeColor = System.Drawing.Color.Black;
            this.Guide_Button.Location = new System.Drawing.Point(488, 474);
            this.Guide_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Guide_Button.Name = "Guide_Button";
            this.Guide_Button.Size = new System.Drawing.Size(193, 66);
            this.Guide_Button.TabIndex = 16;
            this.Guide_Button.TabStop = false;
            this.Guide_Button.Text = "Guide";
            this.Guide_Button.UseVisualStyleBackColor = false;
            this.Guide_Button.Click += new System.EventHandler(this.Guide_Button_Click);
            // 
            // Quit_Button
            // 
            this.Quit_Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Quit_Button.BackColor = System.Drawing.Color.Transparent;
            this.Quit_Button.BackgroundImage = global::MyBomb.Properties.Resources.Button;
            this.Quit_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Quit_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Quit_Button.FlatAppearance.BorderSize = 0;
            this.Quit_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Quit_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Quit_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Quit_Button.Font = new System.Drawing.Font("Niagara Engraved", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quit_Button.ForeColor = System.Drawing.Color.Black;
            this.Quit_Button.Location = new System.Drawing.Point(694, 474);
            this.Quit_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Quit_Button.Name = "Quit_Button";
            this.Quit_Button.Size = new System.Drawing.Size(193, 66);
            this.Quit_Button.TabIndex = 16;
            this.Quit_Button.TabStop = false;
            this.Quit_Button.Text = "Quit";
            this.Quit_Button.UseVisualStyleBackColor = false;
            this.Quit_Button.Click += new System.EventHandler(this.Quit_Button_Click);
            // 
            // GameUI_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackgroundImage = global::MyBomb.Properties.Resources.Menu_Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(960, 585);
            this.Controls.Add(this.Back_Button);
            this.Controls.Add(this.HiScore_Button);
            this.Controls.Add(this.Quit_Button);
            this.Controls.Add(this.Guide_Button);
            this.Controls.Add(this.Play_Button);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GameUI_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Play_Button;
        private System.Windows.Forms.Button HiScore_Button;
        private System.Windows.Forms.Button Back_Button;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button Guide_Button;
        private System.Windows.Forms.Button Quit_Button;
    }
}

