namespace ISYS325_A4_ThomasVecellio
{
    partial class DeckForm
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
            cardListBox = new ListBox();
            cardPictureBox = new PictureBox();
            downButton = new Button();
            upButton = new Button();
            ((System.ComponentModel.ISupportInitialize)cardPictureBox).BeginInit();
            SuspendLayout();
            // 
            // cardListBox
            // 
            cardListBox.FormattingEnabled = true;
            cardListBox.Location = new Point(33, 68);
            cardListBox.Name = "cardListBox";
            cardListBox.Size = new Size(150, 104);
            cardListBox.TabIndex = 0;
            cardListBox.SelectedIndexChanged += cardListBox_SelectedIndexChanged;
            // 
            // cardPictureBox
            // 
            cardPictureBox.Location = new Point(309, 88);
            cardPictureBox.Name = "cardPictureBox";
            cardPictureBox.Size = new Size(125, 200);
            cardPictureBox.TabIndex = 1;
            cardPictureBox.TabStop = false;
            // 
            // downButton
            // 
            downButton.Location = new Point(189, 103);
            downButton.Name = "downButton";
            downButton.Size = new Size(94, 29);
            downButton.TabIndex = 2;
            downButton.Text = "&Down";
            downButton.UseVisualStyleBackColor = true;
            downButton.Click += downButton_Click;
            // 
            // upButton
            // 
            upButton.Location = new Point(189, 68);
            upButton.Name = "upButton";
            upButton.Size = new Size(94, 29);
            upButton.TabIndex = 3;
            upButton.Text = "&Up";
            upButton.UseVisualStyleBackColor = true;
            upButton.Click += upButton_Click;
            // 
            // DeckForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(upButton);
            Controls.Add(downButton);
            Controls.Add(cardPictureBox);
            Controls.Add(cardListBox);
            Name = "DeckForm";
            Text = "DeckForm";
            ((System.ComponentModel.ISupportInitialize)cardPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox cardListBox;
        private PictureBox cardPictureBox;
        private Button downButton;
        private Button upButton;
    }
}