using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountdownEvents
{
    /// <summary>
    /// Класс подписчика на событие отсчета.
    /// </summary>
    public class EventClassSubscriber
    {
        private Countdown _countdown;

        /// <summary>
        /// Отсчетчик времени для начала работы.
        /// </summary>
        public Countdown Countdown {
            get { return _countdown; }
            set {
                Guard.Against.Null(value, nameof(value));
                _countdown = value;
            }
        }

        /// <summary>
        /// Конструктор класса EventClassSubscriber.
        /// </summary>
        public EventClassSubscriber(Countdown newCountdown)
        {
            _countdown = newCountdown;
            _countdown.TransmitMessageCountdown += (message) => { WaitingForMessage(message); };
        }

        private void WaitingForMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine(@"{0} : I got it!", this.ToString());
        }

    }
}
