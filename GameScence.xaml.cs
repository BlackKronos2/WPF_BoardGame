using System;
using System.Windows;
using System.IO;
using System.Windows.Documents;
using System.Runtime.Serialization;
using System.Windows.Threading;
using LABA_8;

namespace LABA8
{
    /// <summary>
    /// Логика взаимодействия для GameScence.xaml
    /// </summary>
    public partial class GameScence : Window
    {
        [DataMember]
        Dices _dices;

        Point[] points;
        [DataMember]
        int timer_value;
        [DataMember]
        GameManager gameManager;

        DispatcherTimer timer = new DispatcherTimer();


        public GameScence(int player_count)
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += new EventHandler(Update);
            timer.Start();

            _dices = new Dices(Dice1, Dice2, timer.Interval.Milliseconds);
            _dices.Animation = true;

            points = new Point[] {
                new Point(110, 82),
                new Point(183, 45),
                new Point(242, 47),
                new Point(301, 65),
                new Point(348, 98),
                new Point(369, 148),
                new Point(347, 205),
                new Point(295, 238),
                new Point(238, 255),
                new Point(175, 262),
                new Point(113, 276),
                new Point(65, 308),
                new Point(37, 356),
                new Point(29, 419),
                new Point(57, 463),
                new Point(103, 484),
                new Point(155, 493),
                new Point(209, 490),
                new Point(264, 480),
                new Point(316, 461),
                new Point(368, 439),
                new Point(414, 416),
                new Point(467, 408),
                new Point(512, 433),
                new Point(513, 491),
                new Point(485, 536),
                new Point(438, 568),
                new Point(386, 591),
                new Point(329, 603),
                new Point(278, 593),
                new Point(226, 570),
                new Point(169, 549),
                new Point(106, 543),
                new Point(56, 569),
                new Point(35, 624),
                new Point(64, 681),
                new Point(111, 719),
                new Point(173, 754),
                new Point(242, 766),
                new Point(308, 759),
                new Point(365, 742),
                new Point(421, 714),
                new Point(471, 680),
                new Point(510, 638),
                new Point(539, 588),
                new Point(560, 532),
                new Point(567, 475),
                new Point(560, 415),
                new Point(544, 363),
                new Point(517, 310),
                new Point(485, 264),
                new Point(462, 205),
                new Point(457, 150),
                new Point(475, 94),
                new Point(519, 50),
                new Point(573, 33),
                new Point(633, 31),
                new Point(690, 47),
                new Point(743, 72),
                new Point(795, 80),
                new Point(854, 67),
                new Point(906, 43),
                new Point(970, 46),
                new Point(1015, 84),
                new Point(1037, 142),
                new Point(1018, 198),
                new Point(963, 221),
                new Point(909, 221),
                new Point(855, 203),
                new Point(801, 181),
                new Point(744, 159),
                new Point(693, 146),
                new Point(638, 157),
                new Point(593, 191),
                new Point(577, 250),
                new Point(587, 308),
                new Point(622, 354),
                new Point(670, 387),
                new Point(721, 406),
                new Point(781, 412),
                new Point(839, 400),
                new Point(893, 392),
                new Point(949, 403),
                new Point(993, 435),
                new Point(1001, 499),
                new Point(952, 539),
                new Point(892, 533),
                new Point(831, 520),
                new Point(768, 512),
                new Point(711, 515),
                new Point(654, 534),
                new Point(609, 570),
                new Point(589, 633),
                new Point(608, 694),
                new Point(655, 739),
                new Point(716, 757),
                new Point(776, 761),
                new Point(834, 759),
                new Point(892, 741),
                new Point(942, 705),
                new Point(985, 668),
                new Point(1032, 601)

            };

            gameManager = new GameManager(points, player_count);

            timer_value = 0;
            button2.IsEnabled = Properties.Settings.Default.DevelopMode;
        }

        public GameScence(SerializeGame loadgame)
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += new EventHandler(Update);
            timer.Start();

            _dices = loadgame.dices;
            _dices.DicesInit(Dice1, Dice2);

            points = new Point[] {
                new Point(110, 82),
                new Point(183, 45),
                new Point(242, 47),
                new Point(301, 65),
                new Point(348, 98),
                new Point(369, 148),
                new Point(347, 205),
                new Point(295, 238),
                new Point(238, 255),
                new Point(175, 262),
                new Point(113, 276),
                new Point(65, 308),
                new Point(37, 356),
                new Point(29, 419),
                new Point(57, 463),
                new Point(103, 484),
                new Point(155, 493),
                new Point(209, 490),
                new Point(264, 480),
                new Point(316, 461),
                new Point(368, 439),
                new Point(414, 416),
                new Point(467, 408),
                new Point(512, 433),
                new Point(513, 491),
                new Point(485, 536),
                new Point(438, 568),
                new Point(386, 591),
                new Point(329, 603),
                new Point(278, 593),
                new Point(226, 570),
                new Point(169, 549),
                new Point(106, 543),
                new Point(56, 569),
                new Point(35, 624),
                new Point(64, 681),
                new Point(111, 719),
                new Point(173, 754),
                new Point(242, 766),
                new Point(308, 759),
                new Point(365, 742),
                new Point(421, 714),
                new Point(471, 680),
                new Point(510, 638),
                new Point(539, 588),
                new Point(560, 532),
                new Point(567, 475),
                new Point(560, 415),
                new Point(544, 363),
                new Point(517, 310),
                new Point(485, 264),
                new Point(462, 205),
                new Point(457, 150),
                new Point(475, 94),
                new Point(519, 50),
                new Point(573, 33),
                new Point(633, 31),
                new Point(690, 47),
                new Point(743, 72),
                new Point(795, 80),
                new Point(854, 67),
                new Point(906, 43),
                new Point(970, 46),
                new Point(1015, 84),
                new Point(1037, 142),
                new Point(1018, 198),
                new Point(963, 221),
                new Point(909, 221),
                new Point(855, 203),
                new Point(801, 181),
                new Point(744, 159),
                new Point(693, 146),
                new Point(638, 157),
                new Point(593, 191),
                new Point(577, 250),
                new Point(587, 308),
                new Point(622, 354),
                new Point(670, 387),
                new Point(721, 406),
                new Point(781, 412),
                new Point(839, 400),
                new Point(893, 392),
                new Point(949, 403),
                new Point(993, 435),
                new Point(1001, 499),
                new Point(952, 539),
                new Point(892, 533),
                new Point(831, 520),
                new Point(768, 512),
                new Point(711, 515),
                new Point(654, 534),
                new Point(609, 570),
                new Point(589, 633),
                new Point(608, 694),
                new Point(655, 739),
                new Point(716, 757),
                new Point(776, 761),
                new Point(834, 759),
                new Point(892, 741),
                new Point(942, 705),
                new Point(985, 668),
                new Point(1032, 601)

            };

            gameManager = loadgame.gameManager;

            timer_value = loadgame.timer;
        }


        private void Update(object sender, EventArgs e) {
            button1.IsEnabled = !_dices.Button;

            _dices.Dice_Update();
            gameManager.GameTic();

            if (_dices.Button)
                if (timer_value > 0)
                    timer_value -= timer.Interval.Milliseconds;
                else
                {
                   gameManager.Move_steps += _dices.Values / 10 + _dices.Values % 10;
                   gameManager.TriggerCheking();
                }

            mapCanvas.Children.Clear();
            gameManager.Draw(mapCanvas);
            Statistic();
        }
        private void Statistic()
        {
            richTextBox1.Document.Blocks.Clear();
            richTextBox1.Document.Blocks.Add(new Paragraph(new Run(gameManager.PlayersStatistics())));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataContractSerializer jsonF = new DataContractSerializer(typeof(SerializeGame));

            using (FileStream fileStream = new FileStream("GameSave.json", FileMode.Create))
            {
                SerializeGame serializeGame = new SerializeGame(_dices, timer_value, gameManager);
                jsonF.WriteObject(fileStream, serializeGame);
            }

            Properties.Settings.Default.LoadGame = true;
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            _dices.Button = true;


            if (_dices.Animation)
                timer_value = 1000;
            else
                timer_value = 50;

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            _dices.Animation = !(bool)(animationChechBox.IsChecked);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            gameManager.Move_steps++;
        }
    }
}
