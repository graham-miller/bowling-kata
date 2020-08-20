using NUnit.Framework;

namespace BowlingKata.Test
{
    [TestFixture]
    public class GameTests
    {
        private Game _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new Game();
        }

        [Test]
        public void TestGutterGame()
        {
            RollMany(20, 0);
            Assert.That(_sut.Score(), Is.EqualTo(0));
        }

        [Test]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.That(_sut.Score(), Is.EqualTo(20));
        }

        [Test]
        public void TestOneSpare()
        {
            RollSpare();
            _sut.Roll(3);
            RollMany(17, 0);
            Assert.That(_sut.Score(), Is.EqualTo(16));
        }

        [Test]
        public void TestOneStrike()
        {
            RollStrike();
            _sut.Roll(3);
            _sut.Roll(4);
            RollMany(16, 0);
            Assert.That(_sut.Score(), Is.EqualTo(24));
        }

        [Test]
        public void TestPerfectGame()
        {
            RollMany(12, 10);
            Assert.That(_sut.Score(), Is.EqualTo(300));
        }

        private void RollMany(int rolls, int pins)
        {
            for (var i = 0; i < rolls; i++)
            {
                _sut.Roll(pins);
            }
        }

        private void RollSpare()
        {
            _sut.Roll(5);
            _sut.Roll(5);
        }

        private void RollStrike()
        {
            _sut.Roll(10);
        }
    }
}
