using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountdownEvents
{
    /// <summary>
    /// Класс ленивого работника.
    /// </summary>
    public class LazyWorker
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
        /// Конструктор класса LazyWorker.
        /// </summary>
        public LazyWorker(Countdown newCountdown)
        {
            _countdown = newCountdown;
            _countdown.TransmitMessageCountdown += (message) => { BeLazy(message); };
        }

        private void BeLazy(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine(@"{0} :Nah, i'm too lazy to do something..", this.ToString());
        }
    }
}
