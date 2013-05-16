using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Balloons;

namespace BaloonsTests
{
    [TestClass]
    public class PopperTests
    {
        [TestMethod]
        public void TryPopLeftTest()
        {
            int[,] matrixTest = new int[,]{
                { 4, 6, 5},
                { 3, 4, 4}
            };

            Popper.TryPopLeft(matrixTest, 1, 2, 4);

            int[,] expected = new int[,]{
                { 4, 6, 5},
                { 3, 0, 4}
            };

            for (int i = 0; i < matrixTest.GetLength(0); i++)
            {
                for (int j = 0; j < matrixTest.GetLength(1); j++)
                {
                    Assert.AreEqual(expected[i, j], matrixTest[i, j]);
                }
            }
        }

        [TestMethod]
        public void TryPopRightTest()
        {
            int[,] matrixTest = new int[,]{
                { 4, 6, 5},
                { 3, 4, 4}
            };

            Popper.TryPopRight(matrixTest, 1, 1, 4);

            int[,] expected = new int[,]{
                { 4, 6, 5},
                { 3, 4, 0}
            };

            for (int i = 0; i < matrixTest.GetLength(0); i++)
            {
                for (int j = 0; j < matrixTest.GetLength(1); j++)
                {
                    Assert.AreEqual(expected[i, j], matrixTest[i, j]);
                }
            }
        }

        [TestMethod]
        public void TryPopUpTest()
        {
            int[,] matrixTest = new int[,]{
                { 4, 6, 5},
                { 3, 4, 4}
            };

            Popper.TryPopUp(matrixTest, 1, 1, 6);

            int[,] expected = new int[,]{
                { 4, 0, 5},
                { 3, 4, 4}
            };

            for (int i = 0; i < matrixTest.GetLength(0); i++)
            {
                for (int j = 0; j < matrixTest.GetLength(1); j++)
                {
                    Assert.AreEqual(expected[i, j], matrixTest[i, j]);
                }
            }
        }

        [TestMethod]
        public void TryPopDownTest()
        {
            int[,] matrixTest = new int[,]{
                { 4, 6, 5},
                { 3, 4, 4}
            };

            Popper.TryPopDown(matrixTest, 0, 1, 4);

            int[,] expected = new int[,]{
                { 4, 6, 5},
                { 3, 0, 4}
            };

            for (int i = 0; i < matrixTest.GetLength(0); i++)
            {
                for (int j = 0; j < matrixTest.GetLength(1); j++)
                {
                    Assert.AreEqual(expected[i, j], matrixTest[i, j]);
                }
            }
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TryArgumentTest()
        {
            int[,] matrixTest = null;

            Popper.TryPopDown(matrixTest, 1, 1, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TryPopOutOfRangeTest()
        {
            int[,] matrixTest = new int[,]{
                { 4, 6, 5},
                { 3, 4, 4}
            };

            Popper.TryPopDown(matrixTest, -2, -3, 4);
        }
    }
}
