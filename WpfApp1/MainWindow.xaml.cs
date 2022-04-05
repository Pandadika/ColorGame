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
        Random random = new Random();
        bool buttonClicked = false;
        
        public MainWindow()
        {
            InitializeComponent();
        }


        private void submitButton_Click(object sender, RoutedEventArgs e)
        { 

            MessageBox.Show($"Hello {firstNameText.Text}");

        }



        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {

            Point Point = e.GetPosition(this);
            double r, g, b;
            
            double height = mainWindow.ActualHeight;
            double width = mainWindow.ActualWidth;

            //MessageBox.Show($"Height = {height} Width = {width}");

            r = 255 - (((Point.Y / height)*128) + (Point.X /width)*128);
            g = 255;
            b = 255;
            //g = ((Point.Y / height) * 128) + ((Point.X / width) * 128);
            //b = (Point.Y/height) * 255;

            rgbinfo.Text = $"R={(int)r} G = {(int)g} B = {(int)b}";

            List<FontFamily> fontFamilies = new List<FontFamily>() {
                new FontFamily("Old English Text MT"),
                new FontFamily("Comic Sans"),
                new FontFamily("Papyrus")
            };

            rgbinfo.FontFamily = fontFamilies[(int)((r%255/255)*3)];
            //rgbinfo.FontSize = g;
            mainWindow.Background = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));

           

            if (buttonClicked && ((SolidColorBrush)mainWindow.Background).Color.R == ((SolidColorBrush)canvas.Background).Color.R && ((SolidColorBrush)mainWindow.Background).Color.G == ((SolidColorBrush)canvas.Background).Color.G && ((SolidColorBrush)mainWindow.Background).Color.B == ((SolidColorBrush)canvas.Background).Color.B)
            {
                MessageBox.Show("You WIN!");
            }

        }

        private void colorButton_Click(object sender, RoutedEventArgs e)
        {
            buttonClicked = true;
            canvas.Background = new SolidColorBrush(Color.FromRgb((byte)(255 * random.NextDouble()), 255, 255));
        }

        private void cheatButton_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush brush = (SolidColorBrush)canvas.Background;
            if (brush != null)
            {
                rgbinfo.Text = $"Target: R={(int)brush.Color.R} G = {(int)brush.Color.G} B = {(int)brush.Color.B} ";
            }
        }
    }
}
