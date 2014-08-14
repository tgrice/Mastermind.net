using System.Collections.Generic;
using MasterMindGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestMasterMindGame
{
    [TestClass]
    public class TestCodeComparer
    {
        private CodeComparer _mind;

        [TestInitialize]
        public void Setup()
        {
            _mind = new CodeComparer();
        }

        [TestMethod]
        public void TestMasterMIndCreation()
        {
            Assert.IsNotNull(_mind);
        }

        [TestMethod]
        public void TestBlankResponse()
        {
            Assert.AreEqual("", _mind.CompareCode(
                new List<int> { 0, 0, 0, 0 }, new List<int> { 1, 1, 8, 9 }));
        }

        [TestMethod]
        public void TestOneWhiteResponse()
        {
            Assert.AreEqual("W", _mind.CompareCode(
                new List<int> { 0, 0, 1, 0 }, new List<int> { 1, 1, 8, 9 }));
        }

        [TestMethod]
        public void TestOneBlackResponse()
        {
            Assert.AreEqual("B", _mind.CompareCode(
                new List<int> { 0, 1, 0, 0 }, new List<int> { 1, 1, 8, 9 }));
        }

        [TestMethod]
        public void TestAllWhiteResponse()
        {
            Assert.AreEqual("WWWW", _mind.CompareCode(
                new List<int> { 8, 9, 1, 1 }, new List<int> { 1, 1, 8, 9 }));
        }
  
        [TestMethod]
        public void TestOneBlackOneWhiteResponse()
        {
            Assert.AreEqual("BW", _mind.CompareCode(
                new List<int> { 1, 8, 0, 0 }, new List<int> { 1, 1, 8, 9 }));
        }

        [TestMethod]
        public void TestTwoBlackTwoWhite()
        {
            Assert.AreEqual("BBWW", _mind.CompareCode(
                new List<int> { 1, 1, 9, 8 }, new List<int> { 1, 1, 8, 9 }));
        }

        [TestMethod]
        public void TestMultiples()
        {
            Assert.AreEqual("BB", _mind.CompareCode(
                new List<int> { 1, 1, 1, 1 }, new List<int> { 1, 1, 8, 9 }));
        }

        [TestMethod]
        public void TestCorrectResponse1()
        {
            Assert.AreEqual("B", _mind.CompareCode(
                new List<int> { 1, 1, 1, 1 }, new List<int> { 0, 9, 8, 1 }));
        }

    }
}
