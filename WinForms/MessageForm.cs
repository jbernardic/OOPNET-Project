using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class MessageForm : Form
    {
        public bool YesAnswer { get; set; } = false;
        public MessageForm()
        {
            InitializeComponent();
        }

        //YES
        private void button1_Click(object sender, EventArgs e)
        {
            YesAnswer = true;
            Close();
        }

        //NO
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
