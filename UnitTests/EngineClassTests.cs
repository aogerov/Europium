using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BalloonBoobsGame;

namespace UnitTests
{
    [TestClass]
    public class EngineClassTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestInputNull()
        {
            string userInput = null;
            Engine.ValidateUserInput(userInput);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestNegativeInput()
        {
            string userInput = "-1 0";
            Engine.ValidateUserInput(userInput);
        }

        [TestMethod]
        public void TestWithInputZero()
        {
            string userInput = "0 0";
            Assert.AreEqual(true,Engine.ValidateUserInput(userInput));
        }

        [TestMethod]
        public void TestWithIncorrectRows()
        {
            string userInput = "5 0";
            Assert.AreEqual(false, Engine.ValidateUserInput(userInput));
        }

        [TestMethod]
        public void TestWithIncorrectCols()
        {
            string userInput = "0 10";
            Assert.AreEqual(false, Engine.ValidateUserInput(userInput));
        }

        [TestMethod]
        public void TestCorrectInput()
        {
            string userInput = "4 9";
            Assert.AreEqual(true, Engine.ValidateUserInput(userInput));
        }

        [TestMethod]
        public void TestWithDotSeparator()
        {
            string userInput = "1.5";
            Assert.AreEqual(true, Engine.ValidateUserInput(userInput));
        }

        [TestMethod]
        public void TestWithComaSeparator()
        {
            string userInput = "2,6";
            Assert.AreEqual(true, Engine.ValidateUserInput(userInput));
        }

        [TestMethod]
        public void TestWithIncorrectSeparator()
        {
            string userInput = "3:6";
            Assert.AreEqual(false, Engine.ValidateUserInput(userInput));
        }
    }
}
