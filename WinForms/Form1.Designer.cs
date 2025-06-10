namespace WinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            rbFemale = new RadioButton();
            rbMale = new RadioButton();
            gbGender = new GroupBox();
            gbLanguage = new GroupBox();
            rbEnglish = new RadioButton();
            rbCroatian = new RadioButton();
            btnNext = new Button();
            gbGender.SuspendLayout();
            gbLanguage.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(124, 9);
            label1.Name = "label1";
            label1.Size = new Size(500, 37);
            label1.TabIndex = 0;
            label1.Text = "Settings";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // rbFemale
            // 
            rbFemale.AutoSize = true;
            rbFemale.Location = new Point(73, 22);
            rbFemale.Name = "rbFemale";
            rbFemale.Size = new Size(67, 19);
            rbFemale.TabIndex = 1;
            rbFemale.Text = "Women";
            rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            rbMale.AutoSize = true;
            rbMale.Checked = true;
            rbMale.Location = new Point(6, 22);
            rbMale.Name = "rbMale";
            rbMale.Size = new Size(49, 19);
            rbMale.TabIndex = 2;
            rbMale.TabStop = true;
            rbMale.Text = "Men";
            rbMale.UseVisualStyleBackColor = true;
            // 
            // gbGender
            // 
            gbGender.Controls.Add(rbFemale);
            gbGender.Controls.Add(rbMale);
            gbGender.Location = new Point(295, 93);
            gbGender.Name = "gbGender";
            gbGender.Size = new Size(163, 55);
            gbGender.TabIndex = 3;
            gbGender.TabStop = false;
            gbGender.Text = "Select cup";
            // 
            // gbLanguage
            // 
            gbLanguage.Controls.Add(rbEnglish);
            gbLanguage.Controls.Add(rbCroatian);
            gbLanguage.Location = new Point(295, 166);
            gbLanguage.Name = "gbLanguage";
            gbLanguage.Size = new Size(163, 55);
            gbLanguage.TabIndex = 4;
            gbLanguage.TabStop = false;
            gbLanguage.Text = "Select language";
            // 
            // rbEnglish
            // 
            rbEnglish.AutoSize = true;
            rbEnglish.Location = new Point(73, 22);
            rbEnglish.Name = "rbEnglish";
            rbEnglish.Size = new Size(63, 19);
            rbEnglish.TabIndex = 1;
            rbEnglish.Text = "English";
            rbEnglish.UseVisualStyleBackColor = true;
            // 
            // rbCroatian
            // 
            rbCroatian.AutoSize = true;
            rbCroatian.Checked = true;
            rbCroatian.Location = new Point(6, 22);
            rbCroatian.Name = "rbCroatian";
            rbCroatian.Size = new Size(70, 19);
            rbCroatian.TabIndex = 2;
            rbCroatian.TabStop = true;
            rbCroatian.Text = "Croatian";
            rbCroatian.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(318, 247);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(101, 35);
            btnNext.TabIndex = 5;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnNext);
            Controls.Add(gbLanguage);
            Controls.Add(gbGender);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            gbGender.ResumeLayout(false);
            gbGender.PerformLayout();
            gbLanguage.ResumeLayout(false);
            gbLanguage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private RadioButton rbFemale;
        private RadioButton rbMale;
        private GroupBox gbGender;
        private GroupBox gbLanguage;
        private RadioButton rbEnglish;
        private RadioButton rbCroatian;
        private Button btnNext;
    }
}
