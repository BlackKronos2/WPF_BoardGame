using System;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using Image = System.Windows.Controls.Image;


namespace LABA_8
{
    /// <summary>
    /// Класс игрок
    /// </summary>
    [DataContract]
    public class Player: Transform
    {
        public Image sprite { get; set; }

        [DataMember]
        int number;

        [DataMember]
        public string Name { get; set; } = "";

        [DataMember]
        public int point_number { get; set; } = 0;

        [DataMember]
        private Point shift;

        [DataMember]
        public bool Shift { get; set; } = true;

        [DataMember]
        private Point delta;

        [DataMember]
        string file_sprite;

        static string[] sprites = new string[4] {
            Environment.CurrentDirectory + "\\Resources\\Red.png",
            Environment.CurrentDirectory + "\\Resources\\Blue.png",
            Environment.CurrentDirectory + "\\Resources\\Green.png",
            Environment.CurrentDirectory + "\\Resources\\Yellow.png"
        };

        public Player(int newnumber, string newname, Point point)
        {
            number = newnumber;
            Position = point;
            Name = newname;

            file_sprite = sprites[number - 1];

            sprite = new Image()
            {
                Width = 60,
                Height = 70,
                Name = newname,
                Source = new BitmapImage(new Uri(file_sprite)),
            };

            point_number = 0;

            switch (newnumber)
            {
                case 1: shift = new Point(0, -10f); break;
                case 2: shift = new Point(-10f, 0); break;
                case 3: shift = new Point(0, 10f); break;
                case 4: shift = new Point(10f, 0); break;

                default: break;
            }

            delta = new Point(30, 45);
        }

        public void DrawSprite(Canvas canvas)
        {
            int renderx = (int)(Position.X - delta.X + ((Shift) ? (shift.X) : (0)));
            int rendery = (int)(Position.Y - delta.Y + ((Shift) ? (shift.Y) : (0)));

            try
            {
                if (sprite == null)
                    sprite = new Image()
                    {
                        Width = 60,
                        Height = 70,
                        Name = Name,
                        Source = new BitmapImage(new Uri(file_sprite)),
                    };
            }
            catch
            {
                sprite = new Image()
                {
                    Width = 60,
                    Height = 70,
                    Name = Name,
                    Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Resources\\missing_texture.png"))
                };
            }

            Canvas.SetTop(sprite, rendery);
            Canvas.SetLeft(sprite, renderx);

            canvas.Children.Add(sprite);
        }
    }
}
