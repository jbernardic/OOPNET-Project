namespace WinForms
{
    partial class AppForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppForm));
            label1 = new Label();
            cbFavTeam = new ComboBox();
            tabControl1 = new TabControl();
            tabPlayers = new TabPage();
            btnToPlayers = new Button();
            btnToFav = new Button();
            label3 = new Label();
            flFavourites = new FlowLayoutPanel();
            flPlayers = new FlowLayoutPanel();
            label2 = new Label();
            tabRankList = new TabPage();
            btnPrint = new Button();
            label5 = new Label();
            label4 = new Label();
            flMatchRankList = new FlowLayoutPanel();
            flPlayerRankList = new FlowLayoutPanel();
            tabSettings = new TabPage();
            btnSave = new Button();
            gbLanguage = new GroupBox();
            rbEnglish = new RadioButton();
            rbCroatian = new RadioButton();
            gbGender = new GroupBox();
            rbFemale = new RadioButton();
            rbMale = new RadioButton();
            label6 = new Label();
            tabControl1.SuspendLayout();
            tabPlayers.SuspendLayout();
            tabRankList.SuspendLayout();
            tabSettings.SuspendLayout();
            gbLanguage.SuspendLayout();
            gbGender.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // cbFavTeam
            // 
            cbFavTeam.FormattingEnabled = true;
            resources.ApplyResources(cbFavTeam, "cbFavTeam");
            cbFavTeam.Name = "cbFavTeam";
            cbFavTeam.SelectedIndexChanged += cbFavTeam_SelectedIndexChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPlayers);
            tabControl1.Controls.Add(tabRankList);
            tabControl1.Controls.Add(tabSettings);
            resources.ApplyResources(tabControl1, "tabControl1");
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            // 
            // tabPlayers
            // 
            tabPlayers.Controls.Add(btnToPlayers);
            tabPlayers.Controls.Add(btnToFav);
            tabPlayers.Controls.Add(label3);
            tabPlayers.Controls.Add(flFavourites);
            tabPlayers.Controls.Add(flPlayers);
            tabPlayers.Controls.Add(label2);
            resources.ApplyResources(tabPlayers, "tabPlayers");
            tabPlayers.Name = "tabPlayers";
            tabPlayers.UseVisualStyleBackColor = true;
            // 
            // btnToPlayers
            // 
            resources.ApplyResources(btnToPlayers, "btnToPlayers");
            btnToPlayers.Name = "btnToPlayers";
            btnToPlayers.UseVisualStyleBackColor = true;
            btnToPlayers.Click += btnToPlayers_Click;
            // 
            // btnToFav
            // 
            resources.ApplyResources(btnToFav, "btnToFav");
            btnToFav.Name = "btnToFav";
            btnToFav.UseVisualStyleBackColor = true;
            btnToFav.Click += btnToFav_Click;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // flFavourites
            // 
            resources.ApplyResources(flFavourites, "flFavourites");
            flFavourites.Name = "flFavourites";
            // 
            // flPlayers
            // 
            resources.ApplyResources(flPlayers, "flPlayers");
            flPlayers.Name = "flPlayers";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // tabRankList
            // 
            tabRankList.Controls.Add(btnPrint);
            tabRankList.Controls.Add(label5);
            tabRankList.Controls.Add(label4);
            tabRankList.Controls.Add(flMatchRankList);
            tabRankList.Controls.Add(flPlayerRankList);
            resources.ApplyResources(tabRankList, "tabRankList");
            tabRankList.Name = "tabRankList";
            tabRankList.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            resources.ApplyResources(btnPrint, "btnPrint");
            btnPrint.Name = "btnPrint";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            label4.Click += label4_Click;
            // 
            // flMatchRankList
            // 
            resources.ApplyResources(flMatchRankList, "flMatchRankList");
            flMatchRankList.Name = "flMatchRankList";
            // 
            // flPlayerRankList
            // 
            resources.ApplyResources(flPlayerRankList, "flPlayerRankList");
            flPlayerRankList.Name = "flPlayerRankList";
            // 
            // tabSettings
            // 
            tabSettings.Controls.Add(btnSave);
            tabSettings.Controls.Add(gbLanguage);
            tabSettings.Controls.Add(gbGender);
            tabSettings.Controls.Add(label6);
            resources.ApplyResources(tabSettings, "tabSettings");
            tabSettings.Name = "tabSettings";
            tabSettings.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            resources.ApplyResources(btnSave, "btnSave");
            btnSave.Name = "btnSave";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
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
            // gbGender
            // 
            gbGender.Controls.Add(rbFemale);
            gbGender.Controls.Add(rbMale);
            resources.ApplyResources(gbGender, "gbGender");
            gbGender.Name = "gbGender";
            gbGender.TabStop = false;
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
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // AppForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Controls.Add(cbFavTeam);
            Controls.Add(label1);
            Name = "AppForm";
            tabControl1.ResumeLayout(false);
            tabPlayers.ResumeLayout(false);
            tabPlayers.PerformLayout();
            tabRankList.ResumeLayout(false);
            tabRankList.PerformLayout();
            tabSettings.ResumeLayout(false);
            gbLanguage.ResumeLayout(false);
            gbLanguage.PerformLayout();
            gbGender.ResumeLayout(false);
            gbGender.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbFavTeam;
        private TabControl tabControl1;
        private TabPage tabPlayers;
        private TabPage tabRankList;
        private TabPage tabSettings;
        private FlowLayoutPanel flPlayers;
        private Label label2;
        private Label label3;
        private FlowLayoutPanel flFavourites;
        private Button btnToPlayers;
        private Button btnToFav;
        private FlowLayoutPanel flPlayerRankList;
        private Label label4;
        private FlowLayoutPanel flMatchRankList;
        private Label label5;
        private Button btnSave;
        private GroupBox gbLanguage;
        private RadioButton rbEnglish;
        private RadioButton rbCroatian;
        private GroupBox gbGender;
        private RadioButton rbFemale;
        private RadioButton rbMale;
        private Label label6;
        private Button btnPrint;
    }
}