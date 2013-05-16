using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Balloons;

namespace BaloonsTests
{
    [TestClass]
    public class BalloonsPopsTests
    {
        // GenerateBoard Method Tests
        [TestMethod]
        public void TestRows()
        {
            int[,] matrix = new int[5,10];
            var actual = BalloonsPops.GenerateBoard();
            Assert.AreEqual(matrix.GetLength(0), actual.GetLength(0));
        }

        [TestMethod]
        public void TestCols()
        {
            int[,] matrix = new int[5, 10];
            var actual = BalloonsPops.GenerateBoard();
            Assert.AreEqual(matrix.GetLength(1), actual.GetLength(1));
        }

        [TestMethod]
        public void TestLenght()
        {
            var actual = BalloonsPops.GenerateBoard();
            Assert.IsFalse(actual.Length <= 0);
        }

        //ValidateInput Method Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIfNull()
        {
            string userInput = null;
            int[,] matrix = new int[5,10];
            BalloonsPops.ValidateInput(userInput,matrix);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInputLenght()
        {
            string userInput = "1234";
            int[,] matrix = new int[5, 10];
            BalloonsPops.ValidateInput(userInput, matrix);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestNegativeInput()
        {
            string userInput = "-65";
            int[,] matrix = new int[5, 10];
            BalloonsPops.ValidateInput(userInput, matrix);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSerarators()
        {
            string userInput = "3|5";
            int[,] matrix = new int[5, 10];
            BalloonsPops.ValidateInput(userInput, matrix);
        }
    
    }
}
