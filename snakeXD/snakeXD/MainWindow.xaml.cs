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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace snakeXD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Canvas_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Right)
            {
                double currentRight = Canvas.GetRight(Jens);
                double newRight = currentRight + 20;
                Canvas.SetRight(Jens, newRight);
            }

            if (e.Key == Key.Left)
            {
                double currentLeft = Canvas.GetLeft(Jens);
                double newLeft = currentLeft + 20;
                Canvas.SetLeft(Jens, newLeft);
            }

            if (e.Key == Key.Up)
            {
                double currentUp = Canvas.GetTop(Jens);
                double newUp = currentUp + 20;
                Canvas.SetTop(Jens, newUp);
            }

            if(e.Key == Key.Down)
            {
                double currentDown = Canvas.GetBottom(Jens);
                double newBottom = currentDown + 20;
                Canvas.SetBottom(Jens, newBottom);
            }
        }
    }
}
