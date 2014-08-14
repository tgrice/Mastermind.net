using System.Collections.Generic;
using MasterMindGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestMasterMindGame
{
    [TestClass]
    public class TestGuessTranslator
    {
        private GuessTranslator trans;

        [TestInitialize]
        public void Setup()
        {
            trans = new GuessTranslator();
        }

        [TestMethod]
        public void TestGuessTranslatorCreation()
        {
            Assert.IsNotNull(trans);
        }

        [TestMethod]
        public void TestOneTranslation()
        {
            CollectionAssert.AreEqual( new List<int>{1}, trans.Translate("1"));
        }

        [TestMethod]
        public void TestTwoTranslations()
        {
            CollectionAssert.AreEqual(new List<int>{1, 2}, trans.Translate("12"));
        }

        [TestMethod]
        public void TestFullTranslation()
        {
            CollectionAssert.AreEqual(new List<int>{1, 2, 3, 4}, trans.Translate("1234"));
        }
    }
}
