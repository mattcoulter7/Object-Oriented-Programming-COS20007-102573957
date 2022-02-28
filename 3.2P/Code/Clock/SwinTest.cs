using NUnit.Framework;

namespace Clock
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void Initialisation()
        {
            Clock _clock = new Clock();
            Assert.IsTrue(Equals(_clock.ReturnTime(), "00:00:00"));
        }
        [Test]
        public void Increment()
        {
            Clock _clock = new Clock();
            _clock.Tick();
            Assert.IsTrue(Equals(_clock.ReturnTime(), "00:00:01"));
        }
        [Test]
        public void IncrementMultipleTimes()
        {
            Clock _clock = new Clock();
            _clock.Tick();
            _clock.Tick();
            _clock.Tick();
            Assert.IsTrue(Equals(_clock.ReturnTime(), "00:00:03"));
        }
        [Test]
        public void Reset()
        {
            Clock _clock = new Clock();
            _clock.Secs.Count = 34;
            _clock.Mins.Count = 18;
            _clock.Hours.Count = 7;
            _clock.Secs.Reset();
            _clock.Mins.Reset();
            _clock.Hours.Reset();
            Assert.IsTrue(Equals(_clock.ReturnTime(), "00:00:00"));
        }
    }
}