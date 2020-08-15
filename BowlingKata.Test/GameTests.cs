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
        public void TestGame()
        { }

        [Test]
        public void TestScore()
        {
            RollMany(20, 0);
            AssertScoreIs(0);
        }

        [Test]
        public void TestAllOne()
        {
            RollMany(20, 1);
            AssertScoreIs(20);
        }

        [Test]
        public void TestSpare()
        {
            _sut.Roll(4);
            _sut.Roll(6);
            _sut.Roll(1);
            RollMany(17, 0);

            AssertScoreIs(12);
        }

        [Test]
        public void TestStrike()
        {
            _sut.Roll(10);
            _sut.Roll(1);
            _sut.Roll(2);
            RollMany(16, 0);

            AssertScoreIs(16);
        }

        [Test]
        public void TestSpareLastFrame()
        {
            RollMany(18, 0);
            _sut.Roll(4);
            _sut.Roll(6);
            _sut.Roll(1);

            AssertScoreIs(11);
        }

        [Test]
        public void TestStrikeLastFrame()
        {
            RollMany(16, 0);
            _sut.Roll(10);
            _sut.Roll(1);
            _sut.Roll(2);

            AssertScoreIs(14);
        }

        private void RollMany(int rolls, int pins)
        {
            for (var i = 0; i < rolls; i++)
            {
                _sut.Roll(pins);
            }
        }

        private void AssertScoreIs(int expectedScore)
        {
            Assert.That(_sut.Score(), Is.EqualTo(expectedScore));
        }
    }
}
