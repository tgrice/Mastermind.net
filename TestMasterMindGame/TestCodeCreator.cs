using MasterMindGame;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestMasterMindGame
{
    [TestClass]
    public class TestCodeCreator
    {
        private CodeCreator _creator;

        private bool ValidateCodeDigits(List<int> code)
        {
            for (var i = 0; i < code.Count; i++)
            {
                if (code[i] > 9) return false; 
            }
            return true;
        }

        [TestInitialize]
        public void Setup()
        {
            _creator = new CodeCreator();
        }

        [TestMethod]
        public void TestCreation()
        {
            Assert.IsNotNull(_creator);
        }

        [TestMethod]
        public void TestCodeLength()
        {
            List<int> code = _creator.GenerateCode(4);
            Assert.AreEqual(4, code.Count);
        }

        [TestMethod]
        public void TestCodeContents()
        {
            List<int> code = _creator.GenerateCode(4);
            Assert.AreEqual(true, ValidateCodeDigits(code));
        }
    }
}
