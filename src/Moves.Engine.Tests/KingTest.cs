using System.Linq;
using Moves.Engine.Figures;
using NUnit.Framework;

namespace Moves.Engine.Tests
{
    [TestFixture]
    public class KingTest : FigureTestBase
    {
        [TestCase("A1", "A2 B2 B1")]
        [TestCase("D1", "C1 C2 D2 E2 E1")]
        [TestCase("E5", "D6 E6 F6 D5 F5 D4 E4 F4")]
        public void ShouldGetValidMoves(string position, string expectedMovesStr)
        {
            // Given
            var expectedMoves = expectedMovesStr.ToPositions();
            var king = new King(position);

            // When
            var actualMoves = king.GetMoves(Board);

            // Then
            Assert.IsTrue(actualMoves.SequenceEqual(expectedMoves));
        }
    }
}
