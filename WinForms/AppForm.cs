using DataLayer;
using DataLayer.Models;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static DataLayer.UserSettings;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WinForms
{
    public partial class AppForm : Form
    {


        private Control? _draggedPanel;

        public AppForm()
        {
            InitializeComponent();

            flPlayers.AutoScroll = true;
            flFavourites.AutoScroll = true;
            flPlayerRankList.AutoScroll = true;

            flPlayers.AllowDrop = true;
            flFavourites.AllowDrop = true;

            flPlayers.DragEnter += PanelDragEnter;
            flFavourites.DragEnter += PanelDragEnter;

            flPlayers.DragDrop += PanelDragDrop;
            flFavourites.DragDrop += PanelDragDrop;

            FillTeams();

            flFavourites.ControlAdded += FavouriteAdded;


            var settings = UserSettings.GetInstance();
            if (settings.SelectedCategory == Category.Men)
            {
                rbMale.Checked = true;
            }
            else rbFemale.Checked = true;

            if (settings.SelectedLanguage == Language.English)
            {
                rbEnglish.Checked = true;
            }
            else rbCroatian.Checked = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            var msgForm = new MessageForm();
            msgForm.ShowDialog();
            if (msgForm.YesAnswer)
            {
                UserSettings.GetInstance().Save();
            }
            else e.Cancel = true;

        }

        void FavouriteAdded(object? sender, ControlEventArgs e)
        {
            if (e.Control is Panel panel)
            {
                if (panel.Tag is string tag)
                    UserSettings.GetInstance().FavouritePlayers.Add(tag);
            }
        }


        void FavouriteRemovedByUser(Control? control)
        {
            if (control is Panel panel)
            {
                if (panel.Tag is string tag)
                    UserSettings.GetInstance().FavouritePlayers.Remove(tag);
            }
        }

        private async void FillTeams()
        {
            var category = UserSettings.GetInstance().SelectedCategory;
            var favTeam = UserSettings.GetInstance().FavouriteTeam;

            var teams = await Repository.Get(category).GetTeams();

            cbFavTeam.DataSource = teams;
            cbFavTeam.SelectedIndex = teams.FindIndex(0, teams.Count, (x)=> x==favTeam);
        }

        private async void CreatePanels()
        {
            flPlayers.Controls.Clear();
            flFavourites.Controls.Clear();

            var category = UserSettings.GetInstance().SelectedCategory;
            var team = UserSettings.GetInstance().FavouriteTeam;
            if (team == null) return;

            var players = await Repository.Get(category).GetPlayers(team);

            foreach (var player in players)
            {
                if (!UserSettings.GetInstance().FavouritePlayers.Contains(player.Name))
                {
                    flPlayers.Controls.Add(CreatePlayerPanel(player.Name));
                }
                else
                {
                    flFavourites.Controls.Add(CreatePlayerPanel(player.Name));
                }
            }

            var playerRanks = await Repository.Get(category).GetPlayerRanks(team);
            foreach (var rank in playerRanks)
            {
                flPlayerRankList.Controls.Add(CreatePlayerRankListPanel(rank));
            }

            var matchRanks = await Repository.Get(category).GetMatchRanks(team);
            foreach (var rank in matchRanks)
            {
                flMatchRankList.Controls.Add(CreateMatchRankListPanel(rank));
            }
        }

        private TableLayoutPanel CreateMatchRankListPanel(MatchRank rank)
        {
            TableLayoutPanel panel = new()
            {
                BorderStyle = BorderStyle.FixedSingle,
                Width = 180,
                Height = 50,
                Margin = new Padding(5),
                BackColor = Color.LightBlue
            };

            Label nameLabel = new()
            {
                Text = $"{rank.HomeTeamCountry} | {rank.AwayTeamCountry}",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
            };

            Label infoLabel = new()
            {
                Text = $"Visits: {rank.Attendance}, Location: {rank.Location}",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
            };

            panel.Controls.Add(nameLabel);
            panel.Controls.Add(infoLabel);

            return panel;
        }

        private Control CreatePlayerPanel(string name)
        {
            PlayerControl control = new(name);

            control.MouseDown += ItemMouseDown;
            control.GetLabel().MouseDown += ItemMouseDown;
            

            return control;
        }

        private TableLayoutPanel CreatePlayerRankListPanel(PlayerRank player)
        {
            TableLayoutPanel panel = new()
            {
                BorderStyle = BorderStyle.FixedSingle,
                Width = 180,
                Height = 50,
                Margin = new Padding(5),
                BackColor = Color.LightBlue
            };

            Label nameLabel = new()
            {
                Text = player.PlayerName,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
            };

            Label infoLabel = new()
            {
                Text = $"Plays: {player.AppearanceCount}, Goals: {player.GoalCount}, Yellow cards: {player.YellowCardCount}",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
            };

            panel.Controls.Add(nameLabel);
            panel.Controls.Add(infoLabel);

            return panel;
        }

        private void ItemMouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || sender == null)
                return;

            PlayerControl? panelToDrag = sender as PlayerControl;
            panelToDrag ??= (sender as Control)?.Parent as PlayerControl;

            if (panelToDrag != null)
            {
                _draggedPanel = panelToDrag;
                if (panelToDrag.Tag != null)
                {
                    panelToDrag.DoDragDrop(panelToDrag.Tag, DragDropEffects.Move);
                }

            }
        }

        private void PanelDragEnter(object? sender, DragEventArgs e)
        {
            if (_draggedPanel != null)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void PanelDragDrop(object? sender, DragEventArgs e)
        {
            if (_draggedPanel == null || sender == null)
                return;

            Panel targetPanel = (Panel)sender;

            if (_draggedPanel.Parent != targetPanel)
            {
                targetPanel.Controls.Add(_draggedPanel);

                if (targetPanel == flPlayers)
                {
                    FavouriteRemovedByUser(_draggedPanel);
                }
            }

            _draggedPanel = null;
        }

        private void cbFavTeam_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (sender is ComboBox cb)
            {
                if (cb.SelectedItem != null)
                {
                    UserSettings.GetInstance().FavouriteTeam = cb.SelectedItem.ToString();
                    CreatePanels();
                }
            }

        }

        private void btnToFav_Click(object sender, EventArgs e)
        {
            List<PlayerControl> panelsToRemove = [];
            foreach (var obj in flPlayers.Controls)
            {
                if (obj is PlayerControl panel)
                {
                    if (panel.IsChecked && panel.Tag is string tag)
                    {
                        flFavourites.Controls.Add(CreatePlayerPanel(tag));
                        panelsToRemove.Add(panel);
                    }
                }
            }

            foreach (var panel in panelsToRemove)
            {
                flPlayers.Controls.Remove(panel);
            }
        }

        private void btnToPlayers_Click(object sender, EventArgs e)
        {
            List<PlayerControl> panelsToRemove = [];
            foreach (var obj in flFavourites.Controls)
            {
                if (obj is PlayerControl panel)
                {
                    if (panel.IsChecked && panel.Tag is string tag)
                    {
                        flPlayers.Controls.Add(CreatePlayerPanel(tag));
                        panelsToRemove.Add(panel);
                    }
                }
            }

            foreach (var panel in panelsToRemove)
            {
                flFavourites.Controls.Remove(panel);
                FavouriteRemovedByUser(panel);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            var msgForm = new MessageForm();
            msgForm.ShowDialog();
            if (msgForm.YesAnswer)
            {
                UserSettings settings = UserSettings.GetInstance();
                settings.SelectedCategory = rbFemale.Checked ? Category.Women : Category.Men;
                settings.SelectedLanguage = rbCroatian.Checked ? Language.Croatian : Language.English;
                settings.FavouriteTeam = null;
                settings.Save();

                cbFavTeam.Items.Clear();
                FillTeams();
            }
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintPageHandler;

            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printDoc
            };

            previewDialog.ShowDialog();
        }

        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(tabRankList.Width, tabRankList.Height);
            tabRankList.DrawToBitmap(bmp, new Rectangle(0, 0, tabRankList.Width, tabRankList.Height));

            float scale = Math.Min(
                (float)e.MarginBounds.Width / bmp.Width,
                (float)e.MarginBounds.Height / bmp.Height);

            int printWidth = (int)(bmp.Width * scale);
            int printHeight = (int)(bmp.Height * scale);

            e.Graphics?.DrawImage(bmp, e.MarginBounds.Left, e.MarginBounds.Top, printWidth, printHeight);
        }
    }
}
