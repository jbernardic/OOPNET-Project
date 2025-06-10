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
            tabRangList = new TabPage();
            tabSettings = new TabPage();
            tabControl1.SuspendLayout();
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
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPlayers);
            tabControl1.Controls.Add(tabRangList);
            tabControl1.Controls.Add(tabSettings);
            tabControl1.Location = new Point(12, 35);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 403);
            tabControl1.TabIndex = 2;
            // 
            // tabPlayers
            // 
            tabPlayers.Location = new Point(4, 24);
            tabPlayers.Name = "tabPlayers";
            tabPlayers.Padding = new Padding(3);
            tabPlayers.Size = new Size(768, 375);
            tabPlayers.TabIndex = 0;
            tabPlayers.Text = "Players";
            tabPlayers.UseVisualStyleBackColor = true;
            // 
            // tabRangList
            // 
            tabRangList.Location = new Point(4, 24);
            tabRangList.Name = "tabRangList";
            tabRangList.Padding = new Padding(3);
            tabRangList.Size = new Size(768, 375);
            tabRangList.TabIndex = 1;
            tabRangList.Text = "Rang List";
            tabRangList.UseVisualStyleBackColor = true;
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbFavTeam;
        private TabControl tabControl1;
        private TabPage tabPlayers;
        private TabPage tabRangList;
        private TabPage tabSettings;
    }
}