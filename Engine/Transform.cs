using System;
using System.Windows;
using System.Runtime.Serialization;

namespace LABA_8
{
    /// <summary>
    /// Отвечает за всё, что связано с перемещениями объектов
    /// </summary>
    [DataContract]
    public class Transform
    {
        [DataMember]
        private Point position;

        public virtual void MoveToward(Point target, float speed)
        {
            if (target != position)
            {
                double x = Math.Abs(position.X - target.X);
                double y = Math.Abs(position.Y - target.Y);


                double c = Math.Sqrt((x * x) + (y * y));

                double k = speed / c;

                int delta_x = (int)(x * k);
                int delta_y = (int)(y * k);

                position.X += (target.X > position.X) ? (delta_x) : (-delta_x);
                position.Y += (target.Y > position.Y) ? (delta_y) : (-delta_y);

                if (c < speed)
                {
                    position.X = target.X;
                    position.Y = target.Y;
                }
            }
        }

        public Point Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}


