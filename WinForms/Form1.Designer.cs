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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            rbFemale = new RadioButton();
            rbMale = new RadioButton();
            gbGender = new GroupBox();
            gbLanguage = new GroupBox();
            rbEnglish = new RadioButton();
            rbCroatian = new RadioButton();
            btnSave = new Button();
            gbGender.SuspendLayout();
            gbLanguage.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // rbFemale
            // 
            resources.ApplyResources(rbFemale, "rbFemale");
            rbFemale.Name = "rbFemale";
            rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            resources.ApplyResources(rbMale, "rbMale");
            rbMale.Checked = true;
            rbMale.Name = "rbMale";
            rbMale.TabStop = true;
            rbMale.UseVisualStyleBackColor = true;
            // 
            // gbGender
            // 
            gbGender.Controls.Add(rbFemale);
            gbGender.Controls.Add(rbMale);
            resources.ApplyResources(gbGender, "gbGender");
            gbGender.Name = "gbGender";
            gbGender.TabStop = false;
            // 
            // gbLanguage
            // 
            gbLanguage.Controls.Add(rbEnglish);
            gbLanguage.Controls.Add(rbCroatian);
            resources.ApplyResources(gbLanguage, "gbLanguage");
            gbLanguage.Name = "gbLanguage";
            gbLanguage.TabStop = false;
            // 
            // rbEnglish
            // 
            resources.ApplyResources(rbEnglish, "rbEnglish");
            rbEnglish.Name = "rbEnglish";
            rbEnglish.UseVisualStyleBackColor = true;
            // 
            // rbCroatian
            // 
            resources.ApplyResources(rbCroatian, "rbCroatian");
            rbCroatian.Checked = true;
            rbCroatian.Name = "rbCroatian";
            rbCroatian.TabStop = true;
            rbCroatian.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            resources.ApplyResources(btnSave, "btnSave");
            btnSave.Name = "btnSave";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnNext_Click;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnSave);
            Controls.Add(gbLanguage);
            Controls.Add(gbGender);
            Controls.Add(label1);
            Name = "Form1";
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
        private Button btnSave;
    }
}
