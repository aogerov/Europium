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
    }
}
