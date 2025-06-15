using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinForms
{
    public partial class PlayerControl : UserControl
    {
        public PlayerControl(string name)
        {
            InitializeComponent();
            lbName.Text = name;
            Tag = name;
            InitImage();


        }

        private void InitImage()
        {
            var imagePath = ImageHelper.GetPlayerImagePath(lbName.Text);
            if (imagePath != null)
            {
                SetPlayerImage(imagePath);
            }
        }

        private void SetPlayerImage(string path)
        {
            if (File.Exists(path))
            {
                // Load image without locking the file
                using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                pictureBox.Image = new Bitmap(fs); // Safe way to load without locking file
            }
        }

        public Label GetLabel()
        {
            return lbName;
        }

        public bool IsChecked { get; private set; } = false;

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            IsChecked = checkBox.Checked;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select Player Image",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = openFileDialog.FileName;

                ImageHelper.UploadPlayerImage(lbName.Text, selectedPath);

                InitImage();
            }
        }
    }
}
