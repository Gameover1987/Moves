using System.Linq;
using Moves.Engine.Figures;
using NUnit.Framework;

namespace Moves.Engine.Tests
{
    [TestFixture]
    public class RookTest : FigureTestBase
    {
        [TestCase("A1", "A2 A3 A4 A5 A6 A7 A8 B1 C1 D1 E1 F1 G1 H1")]
        [TestCase("E4", "E1 E2 E3 E5 E6 E7 E8 A4 B4 C4 D4 F4 G4 H4")]
        public void ShouldGetValidMoves(string position, string expectedMovesStr)
        {
            // Given
            var expectedMoves = expectedMovesStr.ToPositions();
            var rook = new Rook(position);

            // When
            var actualMoves = rook.GetMoves(Board);

            // Then
            Assert.IsTrue(actualMoves.SequenceEqual(expectedMoves));
        }
    }
}