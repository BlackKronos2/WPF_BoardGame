using System;
using System.Runtime.Serialization;
using System.Windows;

namespace LABA_8
{
    /// <summary>
    /// Обрабатывает все события на карте
    /// </summary>
    [DataContract]
    public class TriggersManager : GameStatistics
    {
        [DataMember]
        /// <summary> Номер игрока, который сейчас ходит </summary>
        private int activeplayernumber;
        [DataMember]
        /// <summary> Желтые точки карты (Игрок на них пропускает ход) </summary>
        private int[] yellow_points = new int[]{
            6,
            48,
            64,
            84,
            89
        };
        [DataMember]
        /// <summary> Зеленые точки карты (Игрок на них получает доп. ход) </summary>
        private int[] green_points = new int[] {
            10,
            52,
            71,
            76
        };

        [DataMember]
        /// <summary> Получает ли текущий игрок доп. ход </summary>
        bool green_flag;
        [DataMember]
        /// <summary> Номер игрока, который пропустит ход </summary>
        private int skip_number = -5;

        //Пути вынужденного перемещения игроков
        [DataMember]
        Way blue_way_1 = new Way(
            new Point[] {
            new Point(396, 477),
            new Point(428, 516),
            new Point(438, 568)
            }, 27);

        [DataMember]
        Way blue_way_2 = new Way(
            new Point[] {
            new Point(381, 636),
            new Point(404, 673),
            new Point(471, 680)
            }, 43);

        [DataMember]
        Way blue_way_3 = new Way(
            new Point[] {
            new Point(860, 112),
            new Point(921, 163),
            new Point(963, 221)
            }, 67);

        [DataMember]
        Way blue_way_4 = new Way(
            new Point[] {
            new Point(820, 711),
            new Point(898, 656),
            new Point(964, 619)
            }, 101);

        [DataMember]
        Way red_way_1 = new Way(
            new Point[] {
            new Point(381, 289),
            new Point(197, 365),
            new Point(29, 419)
            }, 14);

        [DataMember]
        Way red_way_2 = new Way(
            new Point[] {
            new Point(253, 731),
            new Point(317, 674),
            new Point(329, 603)
            }, 29);

        [DataMember]
        Way red_way_3 = new Way(
            new Point[] {
            new Point(680, 325),
            new Point(636, 249),
            new Point(593, 191)
            }, 74);

        [DataMember]
        /// <summary> Нуждается ли игрок в вынужденном перемещении </summary>
        protected Way active_way;

        public int ActivePlayerNumber
        {
            get { return activeplayernumber; }
            set
            {
                activeplayernumber = value % _players.Count;
            }
        }

        /// <summary> Проверка на события </summary>
        public void TriggerCheking()
        {
            CheckingGreenAndYellowPoints();
        }

        /// <summary> Проверка на события </summary>
        public void CheckingGreenAndYellowPoints()
        {
            green_flag = false;

            for (int i = 0; i < green_points.Length; i++)
                if (_players[(activeplayernumber == -1) ? (0) : (activeplayernumber)].point_number == green_points[i])
                {
                    green_flag = true;
                    break;
                }

            for (int i = 0; i < yellow_points.Length; i++)
                if (_players[(activeplayernumber == -1) ? (0) : (activeplayernumber)].point_number == yellow_points[i])
                {
                    skip_number = ActivePlayerNumber;
                    break;
                }


            if (!green_flag)
                if ((ActivePlayerNumber + 1) % _players.Count == skip_number)
                {
                    ActivePlayerNumber += 2;
                    skip_number = -5;
                }
                else
                {
                    ActivePlayerNumber += 1;
                    while (players_finish.Contains(_players[ActivePlayerNumber]) && players_finish.Count != _players.Count)
                        ActivePlayerNumber += 1;
                }
            else
                green_flag = false;
        }

        /// <summary> Проверка на события </summary>
        public void CheckingBlueAndRedPoints()
        {
            switch (_players[(activeplayernumber == -1) ? (0) : (activeplayernumber)].point_number)
            {
                case 20: active_way = blue_way_1; break;
                case 28: active_way = blue_way_2; break;
                case 60: active_way = blue_way_3; break;
                case 97: active_way = blue_way_4; break;
                case 51: active_way = red_way_1; break;
                case 38: active_way = red_way_2; break;
                case 79: active_way = red_way_3; break;
            }
        }
    }

    [DataContract]
    public struct Way
    {
        [DataMember]
        private Point[] points;
        [DataMember]
        private int finish_point_number;
        [DataMember]
        private int player_on_way_number;

        public Way(Point[] new_points, int finish)
        {
            this.player_on_way_number = 0;
            this.points = new_points;
            this.finish_point_number = finish;
            this.Active = true;
        }

        public Point[] GetPoints()
        {
            return points;
        }

        public int GetFinish()
        {
            return finish_point_number;
        }

        public int ActivePlayerPoint
        {
            get { return player_on_way_number; }
            set
            {
                player_on_way_number = value;
            }
        }

        public bool Active
        {
            get { return !(finish_point_number == 0); }
            set
            {
                if (value == false)
                    finish_point_number = 0;
            }
        }
    }
}
