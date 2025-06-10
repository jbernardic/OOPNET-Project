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
            label4 = new Label();
            flMatchRankList = new FlowLayoutPanel();
            flPlayerRankList = new FlowLayoutPanel();
            tabSettings = new TabPage();
            label5 = new Label();
            tabControl1.SuspendLayout();
            tabPlayers.SuspendLayout();
            tabRankList.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 0;
            label1.Text = "Favourite team:";
            // 
            // cbFavTeam
            // 
            cbFavTeam.FormattingEnabled = true;
            cbFavTeam.Location = new Point(107, 6);
            cbFavTeam.Name = "cbFavTeam";
            cbFavTeam.Size = new Size(121, 23);
            cbFavTeam.TabIndex = 1;
            cbFavTeam.SelectedIndexChanged += cbFavTeam_SelectedIndexChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPlayers);
            tabControl1.Controls.Add(tabRankList);
            tabControl1.Controls.Add(tabSettings);
            tabControl1.Location = new Point(12, 35);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 403);
            tabControl1.TabIndex = 2;
            // 
            // tabPlayers
            // 
            tabPlayers.Controls.Add(btnToPlayers);
            tabPlayers.Controls.Add(btnToFav);
            tabPlayers.Controls.Add(label3);
            tabPlayers.Controls.Add(flFavourites);
            tabPlayers.Controls.Add(flPlayers);
            tabPlayers.Controls.Add(label2);
            tabPlayers.Location = new Point(4, 24);
            tabPlayers.Name = "tabPlayers";
            tabPlayers.Padding = new Padding(3);
            tabPlayers.Size = new Size(768, 375);
            tabPlayers.TabIndex = 0;
            tabPlayers.Text = "Players";
            tabPlayers.UseVisualStyleBackColor = true;
            // 
            // btnToPlayers
            // 
            btnToPlayers.Location = new Point(539, 314);
            btnToPlayers.Name = "btnToPlayers";
            btnToPlayers.Size = new Size(75, 23);
            btnToPlayers.TabIndex = 5;
            btnToPlayers.Text = "<-";
            btnToPlayers.UseVisualStyleBackColor = true;
            btnToPlayers.Click += btnToPlayers_Click;
            // 
            // btnToFav
            // 
            btnToFav.Location = new Point(137, 314);
            btnToFav.Name = "btnToFav";
            btnToFav.Size = new Size(75, 23);
            btnToFav.TabIndex = 4;
            btnToFav.Text = "->";
            btnToFav.UseVisualStyleBackColor = true;
            btnToFav.Click += btnToFav_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(375, 3);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 3;
            label3.Text = "Favourites";
            // 
            // flFavourites
            // 
            flFavourites.Location = new Point(375, 21);
            flFavourites.Name = "flFavourites";
            flFavourites.Size = new Size(387, 287);
            flFavourites.TabIndex = 2;
            // 
            // flPlayers
            // 
            flPlayers.Location = new Point(6, 21);
            flPlayers.Name = "flPlayers";
            flPlayers.Size = new Size(340, 287);
            flPlayers.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 3);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 0;
            label2.Text = "Players";
            // 
            // tabRankList
            // 
            tabRankList.Controls.Add(label5);
            tabRankList.Controls.Add(label4);
            tabRankList.Controls.Add(flMatchRankList);
            tabRankList.Controls.Add(flPlayerRankList);
            tabRankList.Location = new Point(4, 24);
            tabRankList.Name = "tabRankList";
            tabRankList.Padding = new Padding(3);
            tabRankList.Size = new Size(768, 375);
            tabRankList.TabIndex = 1;
            tabRankList.Text = "Rank List";
            tabRankList.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 9);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 2;
            label4.Text = "Player ranks";
            label4.Click += label4_Click;
            // 
            // flMatchRankList
            // 
            flMatchRankList.Location = new Point(406, 27);
            flMatchRankList.Name = "flMatchRankList";
            flMatchRankList.Size = new Size(356, 348);
            flMatchRankList.TabIndex = 1;
            // 
            // flPlayerRankList
            // 
            flPlayerRankList.Location = new Point(6, 27);
            flPlayerRankList.Name = "flPlayerRankList";
            flPlayerRankList.Size = new Size(356, 345);
            flPlayerRankList.TabIndex = 0;
            // 
            // tabSettings
            // 
            tabSettings.Location = new Point(4, 24);
            tabSettings.Name = "tabSettings";
            tabSettings.Size = new Size(768, 375);
            tabSettings.TabIndex = 2;
            tabSettings.Text = "Settings";
            tabSettings.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(406, 9);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 3;
            label5.Text = "Match ranks";
            // 
            // AppForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(cbFavTeam);
            Controls.Add(label1);
            Name = "AppForm";
            Text = "AppForm";
            tabControl1.ResumeLayout(false);
            tabPlayers.ResumeLayout(false);
            tabPlayers.PerformLayout();
            tabRankList.ResumeLayout(false);
            tabRankList.PerformLayout();
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
    }
}