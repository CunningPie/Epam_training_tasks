using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CountdownEvents
{
    /// <summary>
    /// Класс события отсчета времени.
    /// </summary>
    public class Countdown
    {
        /// <summary>
        /// Делегат передачи сообщения.
        /// </summary>
        /// <param name="message">Передаваемое сообщение.</param>
        public delegate void TransmitMessage(string message);

        /// <summary>
        /// Событие передачи сообщения после конца отсчета.
        /// </summary>
        public event TransmitMessage TransmitMessageCountdown;

        /// <summary>
        /// Запускает отсчет, после которого всем подписчикам будет передано сообщение.
        /// </summary>
        /// <param name="time">Время до начала работы.</param>
        public void StartCountdown(int time)
        {
            Guard.Against.Negative(time, nameof(time));
            Guard.Against.Null(TransmitMessageCountdown, nameof(TransmitMessageCountdown));

            Console.WriteLine("Start countdown..");

            for (int i = 0; i < time; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(@"{0} second left", time - i);
                Console.WriteLine("...");
            }

            foreach (TransmitMessage transmit in TransmitMessageCountdown.GetInvocationList())
            {
                transmit(String.Format(@"Send message to {0}.", transmit.Target.ToString()));
            }
        }
    }
}
