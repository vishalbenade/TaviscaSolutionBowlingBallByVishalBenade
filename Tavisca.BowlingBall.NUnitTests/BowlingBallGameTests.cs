using NUnit.Framework;
using Tavisca.BowlingBall.ClassLibrary;

namespace Tavisca.BowlingBall.NUnitTests
{
    [TestFixture]
    public class BowlingBallGameTests
    {
        private BowlingBallGame game;
        [SetUp]
        public void Setup()
        {
            game = new BowlingBallGame();
        }

        [Test]
        public void CanRollTheGameTest()
        {
            RollSameNumberOfPins(0, 20);
            Assert.AreEqual(0, game.Score);
        }
        [Test]
        public void CanRollAllOnesTest()
        {
            RollSameNumberOfPins(1,20);
            Assert.AreEqual(20, game.Score);
        }
        [Test]
        public void CanRollSpareTest()
        {
            game.Roll(5);
            game.Roll(5);
            game.Roll(3);
            RollSameNumberOfPins(0, 18);
            Assert.AreEqual(16, game.Score);
        }
        [Test]
        public void CanRollStrikeTest()
        {
            game.Roll(10);
            game.Roll(3);
            game.Roll(4);
            RollSameNumberOfPins(0, 17);
            Assert.AreEqual(24, game.Score);
        }
        [Test]
        public void CanRollPerfectGameTest()
        {            
            RollSameNumberOfPins(10, 12);
            Assert.AreEqual(300, game.Score);
        }

        private void RollSameNumberOfPins(int pins, int rolls)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }
    }
}