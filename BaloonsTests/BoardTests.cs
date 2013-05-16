using System;
using Balloons;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

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

        [TestMethod]
        public void DropDownBalloonTest()
        {
            int[,] testMatrix = new int[,]{
                { 4, 2, 7},
                { 3, 3, 4},
                { 6, 0, 4}
            };

            int[,] expected = new int[,]{
                { 4, 0, 7},
                { 3, 2, 4},
                { 6, 3, 4}
            };

            int[,] actual = Board.DropDownBaloons(testMatrix);
            for (int i = 0; i < testMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < testMatrix.GetLength(1); j++)
                {
                    Assert.AreEqual(expected[i, j], actual[i, j]);
                   
                }
            }
        }

        [TestMethod]
        public void AsStringTest()
        {
            int[,] testMatrix = new int[,]{
                { 1, 0, 3},
                { 1, 3, 3}
            };

            StringBuilder sb = new StringBuilder();
            sb.Append("    ");
            sb.Append("0 1 2 ");
            sb.Append("\r\n   ");
            sb.Append("-------");
            sb.Append("\r\n");
            sb.Append("0 | 1   3 | ");
            sb.Append("\r\n");
            sb.Append("1 | 1 3 3 | ");
            sb.Append("\r\n");
            sb.Append("   -------\r\n");
            string expected = sb.ToString();

            string actual = Board.AsString(testMatrix);
            
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AsStringNullTest()
        {
            Board.AsString(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DropDownBaloonsNullTest()
        {
            Board.DropDownBaloons(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GenerateWithNegativeValuesTest()
        {
            Board.Generate(-1, 2, 1, 2);
        }
    }
}
