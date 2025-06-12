using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public bool YesAnswer { get; set; } = false;
        public MessageWindow()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            YesAnswer = true;
            Close();
        }

        private void ntnNo_Click(object sender, RoutedEventArgs e)
        {
            YesAnswer = false;
            Close();
        }
    }
}
