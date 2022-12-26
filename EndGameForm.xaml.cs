using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LABA8
{
    /// <summary>
    /// Логика взаимодействия для EndGameForm.xaml
    /// </summary>
    public partial class EndGameForm : Window
    {
        public EndGameForm()
        {
            InitializeComponent();
        }

        public EndGameForm(string[] names)
        {
            InitializeComponent();
            Label[] labels = new Label[] {
                Player1, Player2, Player3, Player4
            };

            Image[] images = new Image[4] {
                Image1, Image2, Image3, Image4
            };

            for (int i = 0; i < labels.Length; i++)
                labels[i].Visibility = Visibility.Hidden;

            for (int i = 0; i < images.Length; i++)
                images[i].Visibility = Visibility.Hidden;

            for (int i = 0; i < names.Length; i++)
            {
                labels[i].Content = names[i];
                labels[i].Visibility = Visibility.Visible;
            }

            for (int i = 0; i < names.Length; i++)
            {
                images[i].Source = ImageInitialize(names[i]);
                images[i].Visibility = Visibility.Visible;
            }
        }

        private BitmapImage ImageInitialize(string name)
        {
            BitmapImage image = new BitmapImage(new Uri("C:\\Users\\arefe\\source\\repos\\LABA8\\Resources\\missing_texture.png"));
            switch (name)
            {
                case "Player1": return new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Resources\\Red.png"));
                case "Player2": return new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Resources\\Blue.png"));
                case "Player3": return new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Resources\\Green.png"));
                case "Player4": return new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Resources\\Yellow.png"));
            }

            return image;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.LoadGame = false;
            Properties.Settings.Default.Save();
        }
    }
}
