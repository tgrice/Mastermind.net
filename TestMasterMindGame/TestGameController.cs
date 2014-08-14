using System.Collections.Generic;
using MasterMindGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestMasterMindGame
{
    [TestClass]
    public class TestGameController
    {
        private GameController _gameCon;

        private void CreateGameController(List<int> fakeCode)
        {
            _gameCon = new GameController(
                new FakeCodeCreator(fakeCode),
                new CodeComparer(),
                new GuessTranslator(),
                new FakeGameIO());
        }

        [TestInitialize]
        public void Setup()
        {
            CreateGameController(new List<int>{1,1,8,9});
        }

        [TestMethod]
        public void TestControllerCreation()
        {
            Assert.IsNotNull(_gameCon);
        }

        [TestMethod]
        public void CanGetUserGuess()
        {
            _gameCon.Run();
            CollectionAssert.AreEqual(new List<int>{1,1,1,1}, _gameCon.Guess);
        }

        [TestMethod]
        public void CanWin()
        {
            CreateGameController(new List<int>{1,1,1,1});
            _gameCon.Run();
            Assert.AreEqual("VICTORY!!", _gameCon.Feedback);
        }

        [TestMethod]
        public void TestLose()
        {
            _gameCon.Run();
            Assert.AreEqual("Game Over, Turn Limit Reached.", _gameCon.Feedback);
        }
    }
}
