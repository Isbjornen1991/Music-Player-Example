namespace WinFormsPractice
{
    partial class Library_Selection_Form
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
            libraryListBox = new ListBox();
            SelectButton = new Button();
            SuspendLayout();
            // 
            // libraryListBox
            // 
            libraryListBox.FormattingEnabled = true;
            libraryListBox.Location = new Point(12, 10);
            libraryListBox.Name = "libraryListBox";
            libraryListBox.Size = new Size(776, 394);
            libraryListBox.TabIndex = 0;
            libraryListBox.DoubleClick += libraryListBox_DoubleClick;
            // 
            // SelectButton
            // 
            SelectButton.Location = new Point(355, 415);
            SelectButton.Name = "SelectButton";
            SelectButton.Size = new Size(104, 23);
            SelectButton.TabIndex = 1;
            SelectButton.Text = "Add to Playlist...";
            SelectButton.UseVisualStyleBackColor = true;
            SelectButton.Click += SelectButton_Click;
            // 
            // Library_Selection_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SelectButton);
            Controls.Add(libraryListBox);
            Name = "Library_Selection_Form";
            Text = "Library_Selection_Form";
            ResumeLayout(false);
        }

        #endregion

        private ListBox libraryListBox;
        private Button SelectButton;
    }
}