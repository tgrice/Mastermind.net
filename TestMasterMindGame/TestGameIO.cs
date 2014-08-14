using MasterMindConsole;
using MasterMindGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestMasterMindGame
{
    [TestClass]
    public class TestGameIO
    {
        private IGameIO _cIO;

        [TestInitialize]
        public void Setup()
        {
            _cIO = new ConsoleIO();
        }

        [TestMethod]
        public void CanGetUserGuess()
        {
            Assert.AreEqual("1111", _cIO.GetUserGuess());
        }
    }
}
