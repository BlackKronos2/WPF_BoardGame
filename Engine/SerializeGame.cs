using System.Runtime.Serialization;


namespace LABA_8
{
    [DataContract]
    public class SerializeGame
    {
        /// <summary>
        /// Сериализация
        /// </summary>
        [DataMember]
        internal Dices dices { get; set; }
        [DataMember]
        public int timer { get; set; }
        [DataMember]
        internal GameManager gameManager { get; set; }

        internal SerializeGame(Dices _dices, int _timer, GameManager _gameManager)
        {
            dices = _dices;
            timer = _timer;
            gameManager = _gameManager;
        }
    }
}



