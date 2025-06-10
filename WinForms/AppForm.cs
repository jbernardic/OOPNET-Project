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
            flFavourites.ControlRemoved += FavouriteRemoved;

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SettingsManager.GetSettings().Save();
        }

        void FavouriteAdded(object? sender, ControlEventArgs e)
        {
            if (e.Control is Panel panel)
            {
                if (panel.Tag is string tag)
                    SettingsManager.GetSettings().FavouritePlayers.Add(tag);
            }
        }


        void FavouriteRemoved(object? sender, ControlEventArgs e)
        {
            if (e.Control is Panel panel)
            {
                if (panel.Tag is string tag)
                    SettingsManager.GetSettings().FavouritePlayers.Remove(tag);
            }
        }

        private async void FillTeams()
        {
            var category = SettingsManager.GetSettings().SelectedCategory;

            var teams = await Repository.Get(category).GetTeams();

            var index = 0;
            foreach (var team in teams)
            {
                cbFavTeam.Items.Add(team);

                if (team == SettingsManager.GetSettings().FavouriteTeam)
                {
                    cbFavTeam.SelectedIndex = index;
                }
                index++;

            }
        }

        private async void CreatePanels()
        {
            flPlayers.Controls.Clear();

            var category = SettingsManager.GetSettings().SelectedCategory;
            var team = SettingsManager.GetSettings().FavouriteTeam;
            if (team == null) return;

            var players = await Repository.Get(category).GetPlayers(team);

            foreach (var player in players)
            {
                if (!SettingsManager.GetSettings().FavouritePlayers.Contains(player.Name))
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

        private TableLayoutPanel CreatePlayerPanel(string name)
        {
            Label playerLabel = new Label
            {
                Text = name,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
            };


            TableLayoutPanel playerPanel = new TableLayoutPanel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Width = 180,
                Height = 50,
                Margin = new Padding(5),
                Tag = name,
                BackColor = Color.LightBlue
            };

            playerPanel.Controls.Add(playerLabel);
            playerPanel.Controls.Add(new CheckBox());

            playerPanel.MouseDown += ItemMouseDown;
            playerLabel.MouseDown += ItemMouseDown;

            return playerPanel;
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

            Control? panelToDrag = (sender as Control)?.Parent;

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

            FlowLayoutPanel targetPanel = (FlowLayoutPanel)sender;

            if (_draggedPanel.Parent != targetPanel)
            {
                targetPanel.Controls.Add(_draggedPanel);
            }

            _draggedPanel = null;
        }

        private void cbFavTeam_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (sender is ComboBox cb)
            {
                if (cb.SelectedItem != null)
                {
                    SettingsManager.GetSettings().FavouriteTeam = cb.SelectedItem.ToString();
                    CreatePanels();
                }
            }

        }

        private void btnToFav_Click(object sender, EventArgs e)
        {
            List<Panel> panelsToRemove = [];
            foreach (var obj in flPlayers.Controls)
            {
                if (obj is Panel panel)
                {
                    foreach (var pObj in panel.Controls)
                    {
                        if (pObj is CheckBox checkbox)
                        {
                            if (checkbox.Checked && panel.Tag is string tag)
                            {
                                flFavourites.Controls.Add(CreatePlayerPanel(tag));
                                panelsToRemove.Add(panel);
                            }
                            break;
                        }
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
            List<Panel> panelsToRemove = [];
            foreach (var obj in flFavourites.Controls)
            {
                if (obj is Panel panel)
                {
                    foreach (var pObj in panel.Controls)
                    {
                        if (pObj is CheckBox checkbox)
                        {
                            if (checkbox.Checked && panel.Tag is string tag)
                            {
                                flPlayers.Controls.Add(CreatePlayerPanel(tag));
                                panelsToRemove.Add(panel);
                            }
                            break;
                        }
                    }
                }
            }

            foreach (var panel in panelsToRemove)
            {
                flFavourites.Controls.Remove(panel);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
