using NUnit.Framework;
using System;

namespace CountdownEvents.Tests
{
    public class CountdownEventsTests
    {
        Countdown _countdown = new Countdown();

        [SetUp]
        public void Setup()
        {
            _countdown = new Countdown();
        }

        [TestCase(3)]
        [TestCase(0)]
        public void Countdown_RaiseEvent_ShouldReturnTrue(int time)
        {
            var raised = false;

            _countdown.TransmitMessageCountdown += (x) => { raised = true; };
            _countdown.StartCountdown(time);

            Assert.IsTrue(raised);
        }

        [Test]
        public void Countdown_RaiseEventWithNegative_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => { _countdown.StartCountdown(-3); });
        }
    }
}