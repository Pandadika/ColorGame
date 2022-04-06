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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new();
        bool cheatMode = false;
        bool easyMode = false;
        bool hardMode = false;
        double r, g, b = 0;

        public MainWindow()
        {
            InitializeComponent();
            canvas.Background = new SolidColorBrush(Color.FromRgb((byte)(255 * random.NextDouble()), (byte)(255 * random.NextDouble()), (byte)(255 * random.NextDouble())));
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {

            Point Point = e.GetPosition(this);

            double height = mainWindow.ActualHeight;
            double width = mainWindow.ActualWidth;


            if (easyMode)
            {
                if ((int)((Point.X / width) * 255) % 5.0 == 0)
                {
                    r = 255 - ((Point.X / width) * 255) + 1;
                }
                if ((int)((Point.Y / height) * 255) % 5.0 == 0)
                {
                    g = ((Point.Y / height) * 255);
                }

            }
            else
            {
                r = 255 - ((Point.X / width) * 255);
                g = ((Point.Y / height) * 255);
            }

            UpdateWindow();

        }

        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            byte red, green, blue;
            red = (byte)random.Next(0, 255);
            green = (byte)random.Next(0, 255);
            blue = (byte)random.Next(0, 255);
            if (easyMode)
            {

                while (red % 5.0 != 0)
                {
                    red++;
                }
                while (green % 5.0 != 0)
                {
                    green++;
                }
                while (blue % 5.0 != 0)
                {
                    blue++;
                }
            }

            canvas.Background = new SolidColorBrush(Color.FromRgb(red, green, blue));

        }

        private void EasyButton_Click(object sender, RoutedEventArgs e)
        {
            easyMode = !easyMode;
            if (easyMode)
            {
                easyButton.Content = "Easy Mode On";
            }
            else
            {
                easyButton.Content = "Easy Mode Off";
            }
            UpdateWindow();

        }

        private void CheatButton_Click(object sender, RoutedEventArgs e)
        {
            cheatMode = !cheatMode;
            if (cheatMode)
            {
                cheatButton.Content = "Cheat Mode Activated!";
            }
            else
            {
                cheatButton.Content = "Activate Cheat";
            }
            UpdateWindow();
        }

        private void MainWindow_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            double delta = (double)e.Delta;
            if (delta > 0)
            {
                if (easyMode)
                {
                    if ((byte)b % 5.0 == 0)
                    {
                        b += 5;
                    }
                    else
                    {
                        b++;
                    }
                }
                else
                {
                    b++;
                }
            }
            else if (delta < 0)
            {
                if (easyMode)
                {
                    if ((byte)b % 5.0 == 0)
                    {
                        b -= 5;
                    }
                    else
                    {
                        b--;
                    }
                }
                else
                {
                    b--;
                }
            }
            UpdateWindow();
        }

        private void hardButton_Click(object sender, RoutedEventArgs e)
        {
            hardMode = !hardMode;
            if (hardMode)
            {
                hardButton.Content = "HARDMODE ON!!!";
                BlackCanvas.Visibility = Visibility.Visible;
            }
            else
            {
                BlackCanvas.Visibility = Visibility.Hidden;
                hardButton.Content = "hardMode ?";
            }
        }

        private void UpdateWindow()
        {
            if (cheatMode)
            {
                SolidColorBrush brush = (SolidColorBrush)canvas.Background;
                rgbinfo.Text = $"R={(byte)r} G = {(byte)g} B = {(byte)b} Target: R={(int)brush.Color.R} G = {(int)brush.Color.G} B = {(int)brush.Color.B} ";
            }
            else
            {
                rgbinfo.Text = $"R={(byte)r} G = {(byte)g} B = {(byte)b}";
            }

            mainWindow.Background = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
            CheckWin();
        }

        private void CheckWin()
        {
            int difficultyCoeficient = 15;
            if ((
                ((SolidColorBrush)mainWindow.Background).Color.R == ((SolidColorBrush)canvas.Background).Color.R &&
                ((SolidColorBrush)mainWindow.Background).Color.G == ((SolidColorBrush)canvas.Background).Color.G &&
                ((SolidColorBrush)mainWindow.Background).Color.B == ((SolidColorBrush)canvas.Background).Color.B)
                ||
                (easyMode &&
               (((SolidColorBrush)mainWindow.Background).Color.R + difficultyCoeficient >= ((SolidColorBrush)canvas.Background).Color.R) &&
               (((SolidColorBrush)mainWindow.Background).Color.R - difficultyCoeficient <= ((SolidColorBrush)canvas.Background).Color.R) &&
               (((SolidColorBrush)mainWindow.Background).Color.G + difficultyCoeficient >= ((SolidColorBrush)canvas.Background).Color.G) &&
               (((SolidColorBrush)mainWindow.Background).Color.G - difficultyCoeficient <= ((SolidColorBrush)canvas.Background).Color.G) &&
               (((SolidColorBrush)mainWindow.Background).Color.B + difficultyCoeficient >= ((SolidColorBrush)canvas.Background).Color.B) &&
               (((SolidColorBrush)mainWindow.Background).Color.B - difficultyCoeficient <= ((SolidColorBrush)canvas.Background).Color.B)))

            {
                MessageBox.Show("You WIN!");
                canvas.Background = new SolidColorBrush(Color.FromRgb((byte)(255 * random.NextDouble()), (byte)(255 * random.NextDouble()), (byte)(255 * random.NextDouble())));
                UpdateWindow();
            }
        }
    }
}
