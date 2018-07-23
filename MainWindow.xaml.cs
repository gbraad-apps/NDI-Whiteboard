using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Brushes = System.Windows.Media.Brushes;

namespace Whiteboard
{
    public partial class MainWindow : MetroWindow
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Z:
                    if ((System.Windows.Forms.Control.ModifierKeys & System.Windows.Forms.Keys.Control) == System.Windows.Forms.Keys.Control)
                        theWhiteboard.Undo();
                    break;
            }
        }

        private void Btn_White_Click(object sender, RoutedEventArgs e)
        {
            theWhiteboard.Background = Brushes.White;
        }
        private void Btn_Chroma_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            theWhiteboard.Background = btn.Foreground;
        }
        private void Btn_Transparent_Click(object sender, RoutedEventArgs e)
        {
            theWhiteboard.Background = Brushes.Transparent;
        }

        private void Btn_Pen_Click(object sender, RoutedEventArgs e)
        {
            /*
            foreach (UIElement control in DrawSettings.Children)
            {
                if (control is Border)
                {
                    Border border = control as Border;
                    border.BorderBrush = Brushes.Transparent;
                }
            }
            */

            Button btn = (Button)sender;
            //btn.BorderBrush = Brushes.Red;

            theWhiteboard.SetPenColor(btn.Foreground);
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            theWhiteboard.Clear();
        }
        private void Btn_Size1_Click(object sender, RoutedEventArgs e)
        {
            theWhiteboard.BrushThickness = 1.0;
        }

        private void Btn_Size2_Click(object sender, RoutedEventArgs e)
        {
            theWhiteboard.BrushThickness = 2.0;
        }

        private void Btn_Size3_Click(object sender, RoutedEventArgs e)
        {
            theWhiteboard.BrushThickness = 3.0;
        }

        private void Btn_Size4_Click(object sender, RoutedEventArgs e)
        {
            theWhiteboard.BrushThickness = 4.0;
        }

        private void Btn_Size5_Click(object sender, RoutedEventArgs e)
        {
            theWhiteboard.BrushThickness = 5.0;
        }
    }
}