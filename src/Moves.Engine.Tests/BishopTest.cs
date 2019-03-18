using System.Linq;
using Moves.Engine.Figures;
using NUnit.Framework;

namespace Moves.Engine.Tests
{
    [TestFixture]
    public class BishopTest : FigureTestBase
    {
        [TestCase("a1", "b2 c3 d4 e5 f6 g7 h8")]
        [TestCase("b8", "a7 c7 d6 e5 f4 g3 h2")]
        [TestCase("d5", "a8 b7 c6 e4 f3 g2 h1 a2 b3 c4 e6 f7 g8")]

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
