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
        bool cheatMode = false;
        bool easyMode = false;
        double r, g, b = 0;
        
        public MainWindow()
        {
            InitializeComponent();
            canvas.Background = new SolidColorBrush(Color.FromRgb((byte)(255 * random.NextDouble()), (byte)(255 * random.NextDouble()), (byte)(255 * random.NextDouble())));
        }


        private void submitButton_Click(object sender, RoutedEventArgs e)
        { 

            MessageBox.Show($"Hello {firstNameText.Text}");

        }



        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {

            Point Point = e.GetPosition(this);
            
            double height = mainWindow.ActualHeight;
            double width = mainWindow.ActualWidth;

            //MessageBox.Show($"Height = {height} Width = {width}");

            //r = 255 - (((Point.Y / height)*128) + (Point.X /width)*128);
            r = 255-((Point.X/width)*255);
            g = ((Point.Y/height)*255);
            //g = ((Point.Y / height) * 128) + ((Point.X / width) * 128);
            //b = (Point.Y/height) * 255;



            //List<FontFamily> fontFamilies = new List<FontFamily>() {
            //    new FontFamily("Old English Text MT"),
            //    new FontFamily("Comic Sans"),
            //    new FontFamily("Papyrus")
            //};

            //rgbinfo.FontFamily = fontFamilies[(int)((r%255/255)*3)];
            //rgbinfo.FontSize = g;
            updateWindow();

           

            if (( 
                ((SolidColorBrush)mainWindow.Background).Color.R == ((SolidColorBrush)canvas.Background).Color.R && 
                ((SolidColorBrush)mainWindow.Background).Color.G == ((SolidColorBrush)canvas.Background).Color.G && 
                ((SolidColorBrush)mainWindow.Background).Color.B == ((SolidColorBrush)canvas.Background).Color.B) 
                ||
                (easyMode &&
               ((((SolidColorBrush)mainWindow.Background).Color.R + 10 >= ((SolidColorBrush)canvas.Background).Color.R) &&
               (((SolidColorBrush)mainWindow.Background).Color.R - 10 <= ((SolidColorBrush)canvas.Background).Color.R) &&
               (((SolidColorBrush)mainWindow.Background).Color.G + 10 >= ((SolidColorBrush)canvas.Background).Color.G) &&
               (((SolidColorBrush)mainWindow.Background).Color.G - 10 <= ((SolidColorBrush)canvas.Background).Color.G) &&
               (((SolidColorBrush)mainWindow.Background).Color.B + 10 >= ((SolidColorBrush)canvas.Background).Color.B) &&
               (((SolidColorBrush)mainWindow.Background).Color.B - 10 <= ((SolidColorBrush)canvas.Background).Color.B))))


            {
                MessageBox.Show("You WIN!");
            }

        }

        private void colorButton_Click(object sender, RoutedEventArgs e)
        {
            buttonClicked = true;
            canvas.Background = new SolidColorBrush(Color.FromRgb((byte)(255 * random.NextDouble()), (byte)(255 * random.NextDouble()), (byte)(255 * random.NextDouble())));
        }

        private void easyButton_Click(object sender, RoutedEventArgs e)
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
            updateWindow();

        }

        private void cheatButton_Click(object sender, RoutedEventArgs e)
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
            updateWindow();
        }

        private void mainWindow_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            double delta = (double)e.Delta;
            if (delta > 0)
            {
                b++;
            }
            else if (delta < 0)
            {
                b--;
            }
            updateWindow();


        }

        private void updateWindow()
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
        }
    }
}
