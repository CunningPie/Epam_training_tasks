using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountdownEvents
{
    /// <summary>
    /// Класс работника.
    /// </summary>
    public class Worker
    {
        private Countdown _countdown;

        /// <summary>
        /// Отсчетчик времени для начала работы.
        /// </summary>
        public Countdown Countdown
        {
            get { return _countdown; }
            set
            {
                Guard.Against.Null(value, nameof(value));
                _countdown = value;
            }
        }

        /// <summary>
        /// Конструктор класса Worker.
        /// </summary>
        public Worker(Countdown newCountdown)
        {
            _countdown = newCountdown;
            _countdown.TransmitMessageCountdown += (message) => { StartToWork(message); };
        }

        private void StartToWork(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine(@"{0} :Ok, i'll start to work.", this.ToString());
        }
    }
}
