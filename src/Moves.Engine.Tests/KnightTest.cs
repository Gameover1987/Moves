using System.Linq;
using Moves.Engine.Figures;
using NUnit.Framework;

namespace Moves.Engine.Tests
{
    [TestFixture]
    public class KnightTest : FigureTestBase
    {
        [TestCase("A1", "B3 C2")]
        [TestCase("A8", "B6 C7")]
        [TestCase("H1", "F2 G3")]
        [TestCase("H8", "F7 G6")]

        [TestCase("B1", "A3 C3 D2")]
        [TestCase("G1", "E2 F3 H3")]
        [TestCase("B8", "A6 C6 D7")]
        [TestCase("G8", "E7 F6 H6")]

        [TestCase("D1", "B2 C3 E3 F2")]
        [TestCase("A4", "B6 C3 C5 B2")]
        [TestCase("D8", "F7 E6 C6 B7")]
        [TestCase("H5", "G7 F6 F4 G3")]

        [TestCase("E2", "C1 C3 D4 F4 G3 G1")]

        [TestCase("C3", "A2 B1 D1 E2 E4 D5 B5 A4")]
        public void ShouldGetValidMoves(string position, string expectedMovesStr)
        {
            // Given
            var expectedMoves = expectedMovesStr.ToPositions();
            var knight = new Knight(position);

            // When
            var actualMoves = knight.GetMoves(Board);

            // Then
            Assert.IsTrue(actualMoves.SequenceEqual(expectedMoves));
        }
    }
}
