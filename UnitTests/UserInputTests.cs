using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BalloonBoobsGame;

namespace UnitTests
{
    [TestClass]
    public class UserInputTests
    {
        [TestMethod]
        public void TestNull()
        {
            string userInput = "-1 -1";
            Assert.AreEqual(false, Engine.ValidateUserInput(userInput));
        }
    }
}
