using System.Windows;
using System.Windows.Controls;
using System.Runtime.Serialization;
using System.IO;
using LABA_8;

namespace LABA8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            slider1.Minimum = 1;
            slider1.Maximum = 4;

            slider2.Minimum = 2;
            slider2.Maximum = 20;
            slider2.Value = Properties.Settings.Default.MoveSpeed;

            button2.IsEnabled = Properties.Settings.Default.LoadGame;
            checkBox1.IsChecked = Properties.Settings.Default.DevelopMode;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.MoveSpeed = (int)slider2.Value;
            Properties.Settings.Default.DevelopMode = (bool)checkBox1.IsChecked;
            Properties.Settings.Default.Save();

            GameScence gameScence = new GameScence((int)slider1.Value);
            gameScence.Show();
            this.Hide();
        }

        private void Settings_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.DevelopMode = (bool)checkBox1.IsChecked;
            Properties.Settings.Default.MoveSpeed = (int)slider2.Value;

            Properties.Settings.Default.Save();
            Application.Current.Shutdown();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            PlayerCountBox.Text = slider1.Value.ToString();
        }

        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GameSpeedBox.Text = slider2.Value.ToString();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void GameSpeedBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            DataContractSerializer jsonF = new DataContractSerializer(typeof(SerializeGame));

            using (FileStream fileStream = new FileStream("GameSave.json", FileMode.Open))
            {
                SerializeGame loadgame = (SerializeGame)jsonF.ReadObject(fileStream);
                GameScence gameScence = new GameScence(loadgame);
                gameScence.Show();
                this.Hide();
            }
        }
    }
}
