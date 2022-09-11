namespace Ex5_MemoryGame
{
    partial class MemoryGameSettings
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
            this.buttonChoiceWhoToPlayAgaints = new System.Windows.Forms.Button();
            this.buttonSize = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelFirstPlayerName = new System.Windows.Forms.Label();
            this.textBoxFirstPlayerName = new System.Windows.Forms.TextBox();
            this.textBoxSecondPlayerName = new System.Windows.Forms.TextBox();
            this.labelSecondPlayerName = new System.Windows.Forms.Label();
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonChoiceWhoToPlayAgaints
            // 
            this.buttonChoiceWhoToPlayAgaints.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChoiceWhoToPlayAgaints.Location = new System.Drawing.Point(345, 68);
            this.buttonChoiceWhoToPlayAgaints.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonChoiceWhoToPlayAgaints.Name = "buttonChoiceWhoToPlayAgaints";
            this.buttonChoiceWhoToPlayAgaints.Size = new System.Drawing.Size(182, 31);
            this.buttonChoiceWhoToPlayAgaints.TabIndex = 2;
            this.buttonChoiceWhoToPlayAgaints.Text = "Against a Friend";
            this.buttonChoiceWhoToPlayAgaints.UseVisualStyleBackColor = true;
            this.buttonChoiceWhoToPlayAgaints.Click += new System.EventHandler(this.buttonChoiceWhoToPlayAgaints_Click);
            // 
            // buttonSize
            // 
            this.buttonSize.BackColor = System.Drawing.Color.Thistle;
            this.buttonSize.Location = new System.Drawing.Point(23, 144);
            this.buttonSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSize.Name = "buttonSize";
            this.buttonSize.Size = new System.Drawing.Size(136, 100);
            this.buttonSize.TabIndex = 3;
            this.buttonSize.Text = "4 x 4";
            this.buttonSize.UseVisualStyleBackColor = false;
            this.buttonSize.Click += new System.EventHandler(this.buttonSize_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonStart.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonStart.Location = new System.Drawing.Point(389, 200);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(138, 44);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start!";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelFirstPlayerName
            // 
            this.labelFirstPlayerName.AutoSize = true;
            this.labelFirstPlayerName.Location = new System.Drawing.Point(22, 34);
            this.labelFirstPlayerName.Name = "labelFirstPlayerName";
            this.labelFirstPlayerName.Size = new System.Drawing.Size(137, 20);
            this.labelFirstPlayerName.TabIndex = 5;
            this.labelFirstPlayerName.Text = "First Player Name:";
            // 
            // textBoxFirstPlayerName
            // 
            this.textBoxFirstPlayerName.Location = new System.Drawing.Point(189, 34);
            this.textBoxFirstPlayerName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxFirstPlayerName.Name = "textBoxFirstPlayerName";
            this.textBoxFirstPlayerName.Size = new System.Drawing.Size(130, 26);
            this.textBoxFirstPlayerName.TabIndex = 6;
            // 
            // textBoxSecondPlayerName
            // 
            this.textBoxSecondPlayerName.Enabled = false;
            this.textBoxSecondPlayerName.Location = new System.Drawing.Point(189, 68);
            this.textBoxSecondPlayerName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSecondPlayerName.Name = "textBoxSecondPlayerName";
            this.textBoxSecondPlayerName.Size = new System.Drawing.Size(130, 26);
            this.textBoxSecondPlayerName.TabIndex = 7;
            this.textBoxSecondPlayerName.Text = "- computer -";
            // 
            // labelSecondPlayerName
            // 
            this.labelSecondPlayerName.AutoSize = true;
            this.labelSecondPlayerName.Location = new System.Drawing.Point(22, 68);
            this.labelSecondPlayerName.Name = "labelSecondPlayerName";
            this.labelSecondPlayerName.Size = new System.Drawing.Size(158, 20);
            this.labelSecondPlayerName.TabIndex = 8;
            this.labelSecondPlayerName.Text = "Second player name:";
            // 
            // labelBoardSize
            // 
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.BackColor = System.Drawing.Color.Azure;
            this.labelBoardSize.Location = new System.Drawing.Point(22, 110);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(91, 20);
            this.labelBoardSize.TabIndex = 9;
            this.labelBoardSize.Text = "Board Size:";
            // 
            // MemoryGameSettings
            // 
            this.AcceptButton = this.buttonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(543, 272);
            this.Controls.Add(this.labelBoardSize);
            this.Controls.Add(this.labelSecondPlayerName);
            this.Controls.Add(this.textBoxSecondPlayerName);
            this.Controls.Add(this.textBoxFirstPlayerName);
            this.Controls.Add(this.labelFirstPlayerName);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonSize);
            this.Controls.Add(this.buttonChoiceWhoToPlayAgaints);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(782, 455);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(561, 317);
            this.Name = "MemoryGameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game - Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonChoiceWhoToPlayAgaints;
        private System.Windows.Forms.Button buttonSize;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelFirstPlayerName;
        private System.Windows.Forms.TextBox textBoxFirstPlayerName;
        private System.Windows.Forms.TextBox textBoxSecondPlayerName;
        private System.Windows.Forms.Label labelSecondPlayerName;
        private System.Windows.Forms.Label labelBoardSize;
    }
}