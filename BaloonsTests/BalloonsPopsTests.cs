using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Balloons;
using System.Collections.Generic;
using System.Text;

namespace BalloonsTests
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
            int[,] matrix = new int[5, 10];
            BalloonsPops.ValidateInput(userInput,matrix);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStringEmpty()
        {
            string userInput = string.Empty;
            int[,] matrix = new int[5, 10];
            BalloonsPops.ValidateInput(userInput, matrix);
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
            string userInput = "3/5";
            int[,] matrix = new int[5, 10];
            BalloonsPops.ValidateInput(userInput, matrix);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestUserInputRows()
        {
            string userInput = "5 5";
            int[,] matrix = new int[5, 10];
            BalloonsPops.ValidateInput(userInput, matrix);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestUserInputCols()
        {
            string userInput = "2 5";
            int[,] matrix = new int[5, 5];
            BalloonsPops.ValidateInput(userInput, matrix);
        }

        //CheckForBalloon Method Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUserInputNull()
        {
            string userInput = null;
            int[,] matrix = new int[5, 10];
            BalloonsPops.CheckForBaloon(userInput, matrix);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUserInputStringEmpty()
        {
            string userInput = string.Empty;
            int[,] matrix = new int[5, 10];
            BalloonsPops.CheckForBaloon(userInput, matrix);
        }

        [TestMethod]
        public void TestIsTrue()
        {
            string userInput = "1 1";
            int[,] matrix = new int[2, 2]{{2,2},
                                          {2,2}};
            Assert.IsTrue(BalloonsPops.CheckForBaloon(userInput, matrix));
        }

        [TestMethod]
        public void TestIsFalse()
        {
            string userInput = "0 0";
            int[,] matrix = new int[5, 10];
            Assert.IsFalse(BalloonsPops.CheckForBaloon(userInput, matrix));
        }

        //PopBalloons Method Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInputNull()
        {
            string userInput = null;
            int[,] matrix = new int[5, 10];
            BalloonsPops.PopBaloons(userInput,ref matrix);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInputStringEmpty()
        {
            string userInput = string.Empty;
            int[,] matrix = new int[5, 10];
            BalloonsPops.PopBaloons(userInput,ref matrix);
        }

        [TestMethod]
        public void CheckPopBalloons()
        {
            string input = "1 1";
            int[,] actual = new int[,]   {{1,3,5},
                                          {3,3,4},
                                          {2,3,8}};

            int[,] excepted = new int[,]  {{0,0,5},
                                           {1,0,4},
                                           {2,0,8}};

            BalloonsPops.PopBaloons(input,ref actual);

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Assert.AreEqual(excepted[row,col], actual[row,col]);
                }
            }
        }

        //CheckForGameOver Method Test
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MatrixNull()
        {
            int[,] matrix = null;
            BalloonsPops.CheckForGameOver(matrix);
        }

        [TestMethod]
        public void GameOverIsTrue()
        {
            int[,] matrix = new int[,]{{0,0},{0,0}};
            Assert.IsTrue(BalloonsPops.CheckForGameOver(matrix));
        }

        [TestMethod]
        public void GameOverIsFalse()
        {
            int[,] matrix = new int[, ]{{2,2},{2,2}};
            Assert.IsFalse(BalloonsPops.CheckForGameOver(matrix));
        }

        //PrintBoard
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void PrintBoardNullMatrix()
        {
            int[,] matrix = null;
            BalloonsPops.PrintBoard(matrix);
        }

        //ProccessGame
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ProccessGameValidation()
        {
            string userInput = null;
            int[,] matrix = null;
            IChart chart = null;
            int userMoves = 2;
            BalloonsPops.ProcessGame(userInput, ref matrix, chart, ref userMoves);
        }

        [TestMethod]
        public void ProccessGameDeleteUserMoves()
        {
            string userInput = "RESTART";
            int[,] matrix = new int[5,10];
            IChart chart = new Chart();
            int userMoves = 2;
            BalloonsPops.ProcessGame(userInput, ref matrix, chart, ref userMoves);
            Assert.AreEqual(0, userMoves);
        }

        [TestMethod]
        public void ProccessGameRestartRows()
        {
            string userInput = "RESTART";
            int[,] matrix = new int[5,10];
            IChart chart = new Chart();
            int userMoves = 2;
            BalloonsPops.ProcessGame(userInput, ref matrix, chart, ref userMoves);
            Assert.AreEqual(5, matrix.GetLength(0));
        }

        [TestMethod]
        public void ProccessGameRestartCols()
        {
            string userInput = "RESTART";
            int[,] matrix = new int[5,10];
            IChart chart = new Chart();
            int userMoves = 2;
            BalloonsPops.ProcessGame(userInput, ref matrix, chart, ref userMoves);
            Assert.AreEqual(10, matrix.GetLength(1));
        }
        
        //Case Exit
        [TestMethod]
        public void ProccessGameExit()
        {
            string userInput = "EXIT";
            int[,] matrix = new int[5, 10];
            IChart chart = new Chart();
            int userMoves = 2;
            BalloonsPops.ProcessGame(userInput, ref matrix, chart, ref userMoves);
        }

        //Case Exit
        [TestMethod]
        public void ProccessGameTop()
        {
            string userInput = "TOP";
            int[,] matrix = new int[5, 10];
            IChart chart = new Chart();
            int userMoves = 2;
            BalloonsPops.ProcessGame(userInput, ref matrix, chart, ref userMoves);
        }

        //Default
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ProccessGameTestDefaultIncorrectUserInput()
        {
            string userInput = "1234";
            int[,] matrix = new int[5, 10];
            IChart chart = new Chart();
            int userMoves = 2;
            BalloonsPops.ProcessGame(userInput, ref matrix, chart, ref userMoves);
        }
    }
}
