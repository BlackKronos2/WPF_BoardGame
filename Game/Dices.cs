using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Threading;
using System.IO;
using LABA8;
using System.Windows.Media.Imaging;
using Image = System.Windows.Controls.Image;

namespace LABA_8
{
    [DataContract]
    /// <summary>
    /// Класс описывающий работу кубиков
    /// </summary>
    public class Dices
    {
        [DataMember]
        int tics;
        [DataMember]
        private int timer_interval;
        [DataMember]
        private int value1;
        [DataMember]
        private int value2;

        [DataMember]
        public bool Button { get; set; }
        [DataMember]
        public bool Animation { get; set; }

        static Random random1 = new Random((int)DateTime.Now.Ticks + 600);
        static Random random2 = new Random((int)DateTime.Now.Ticks);

        private Image _dice1;
        private Image _dice2;


        BitmapImage[] Images = new BitmapImage[6] {
                new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Resources\\Dice_1.png")),
                new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Resources\\Dice_2.png")),
                new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Resources\\Dice_3.png")),
                new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Resources\\Dice_4.png")),
                new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Resources\\Dice_5.png")),
                new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Resources\\Dice_6.png"))
        };

        public Dices(Image dice1, Image dice2, int update_Interval)
        {
            _dice1 = dice1;
            _dice2 = dice2;

            _dice1.Source = Images[0];
            _dice2.Source = Images[0];

            timer_interval = update_Interval;

            value1 = value2 = 1;

            Button = false;
            Animation = true;

            tics = 0;

        }

        public void DicesInit(Image dice1, Image dice2) {
            _dice1 = dice1;
            _dice2 = dice2;

            Images = new BitmapImage[6] {
                new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Resources\\Dice_1.png")),
                new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Resources\\Dice_2.png")),
                new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Resources\\Dice_3.png")),
                new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Resources\\Dice_4.png")),
                new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Resources\\Dice_5.png")),
                new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Resources\\Dice_6.png"))
            };

            _dice1.Source = Images[value1 - 1];
            _dice2.Source = Images[value2 - 1];

            random1 = new Random((int)DateTime.Now.Ticks + 600);
            random2 = new Random((int)DateTime.Now.Ticks);
        }

        private void Mixing()
        {
            value1 = random1.Next(1, 7); //получение случайного числа от 1 до 6 
            value2 = random2.Next(1, 7); //получение случайного числа от 1 до 6 

            _dice1.Source = Images[value1 - 1];
            _dice2.Source = Images[value2 - 1];
        }

        public void Dice_Update()
        {
            if (Button)
                if (Animation)
                {
                    if (tics <= 1000)
                    {
                        tics += timer_interval;
                        Mixing();
                    }
                    else
                    {
                        tics = 0;
                        Button = false;
                    }
                }
                else
                {
                    if (tics == 0)
                        Mixing();

                    if (tics <= 50)
                    {
                        tics += timer_interval;
                    }
                    else
                    {
                        Button = false;
                        tics = 0;
                    }
                }
        }

        public int Values
        {
            get { return value1 * 10 + value2; }
        }

        public void DrawDices(Graphics graphics)
        {
            if (_dice1.Source == null || _dice2.Source == null)
            {
                _dice1.Source = Images[value1 - 1];
                _dice2.Source = Images[value2 - 1];
            }

            //render1.DrawSprite(graphics);
            //render2.DrawSprite(graphics);
        }
    }
}
