﻿using System;
using NUnit.Framework;

namespace TDD_Katas_project.BowlingGame
{
    [TestFixture]
    [Category("TheBowlingGameKata")]
    public class TestGame
    {
        private Game _game;
        private int _frames;

        #region Setup/TearDown
        [TestFixtureSetUp]
        public void Setup()
        {
            _game = new Game();
            _frames = 10;
        }
        [TestFixtureTearDown]
        public void TearDown()
        {
            _game = null;
            _frames = 0;
        }
        #endregion

        #region TestMethods
        [Test]
        public void Can_Get_Calculate_Single_Scores()
        {
            _game.Roll(0);
            Console.WriteLine(string.Format("Roll Total - {0}, Result - {1}", 0, _game.Score()));
            Assert.That(0, Is.EqualTo(_game.Score()));
        }
        [Test]
        public void Can_Get_Calculate_Spare_Scores()
        {
            RollSpare();
            _game.Roll(3);
            FrameHits(0, 17);
            Console.WriteLine(string.Format("Roll Total - {0}, Result - {1}", 16, _game.Score()));
            Assert.That(16, Is.EqualTo(_game.Score()));
        }


        [Test]
        public void Can_Get_Calculate_Scores()
        {
            FrameHits(0, _frames);
            Assert.That(0, Is.EqualTo(_game.Score()));
        }
        #endregion

        #region Private Methods
        private void FrameHits(int pin, int count)
        {
            for (var i = 0; i < count; i++)
            {
                _game.Roll(pin);

            }
        }
        private void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }
        #endregion

    }
}
