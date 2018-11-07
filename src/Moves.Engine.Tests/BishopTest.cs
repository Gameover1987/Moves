using System.Linq;
using Moves.Engine.Figures;
using NUnit.Framework;

namespace Moves.Engine.Tests
{
    [TestFixture]
    public class BishopTest : FigureTestBase
    {
        [TestCase("A1", "B2 C3 D4 E5 F6 G7 H8")]
        [TestCase("B8", "A7 C7 D6 E5 F4 G3 H2")]
        [TestCase("D5", "A8 B7 C6 E4 F3 G2 H1 A2 B3 C4 E6 F7 G8")]

        public void ShouldGetValidMoves(string position, string expectedMovesStr)
        {
            // Given
            var expectedMoves = expectedMovesStr.ToPositions();
            var bishop = new Bishop(position);

            // When
            var actualMoves = bishop.GetMoves(Board);

            // Then
            Assert.IsTrue(actualMoves.SequenceEqual(expectedMoves));
        }
    }
}
