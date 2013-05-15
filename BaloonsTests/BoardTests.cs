using System;
using Balloons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaloonsTests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void GenerateTest()
        {
            int[,] expected = new int[,]{
                { 4, 6},
                { 3, 2 }
            };
            int[,] actual = Board.Generate(2, 2, 1, 9);
            Assert.AreEqual(expected.GetLength(0), actual.GetLength(0));
            Assert.AreEqual(expected.GetLength(1), actual.GetLength(1));
        }
    }
}
