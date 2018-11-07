using System.Linq;
using Moves.Engine.Figures;
using NUnit.Framework;

namespace Moves.Engine.Tests
{
    [TestFixture]
    public class QueenTest : FigureTestBase
    {
        [TestCase("A1", "B2 C3 D4 E5 F6 G7 H8 A2 A3 A4 A5 A6 A7 A8 B1 C1 D1 E1 F1 G1 H1")]
        [TestCase("D5", "A5 B5 C5 E5 F5 G5 H5 D1 D2 D3 D4 D6 D7 D8 A8 B7 C6 E4 F3 G2 H1 A2 B3 C4 E6 F7 G8")]
        public void ShouldGetValidMoves(string position, string expectedMovesStr)
        {
            // Given
            var expectedMoves = expectedMovesStr.ToPositions();
            var queen = new Queen(position);

            // When
            var actualMoves = queen.GetMoves(Board);

            // Then
            Assert.IsTrue(actualMoves.SequenceEqual(expectedMoves));
        }
    }
}
