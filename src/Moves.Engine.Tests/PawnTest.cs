using System.Linq;
using Moves.Engine.Figures;
using NUnit.Framework;

namespace Moves.Engine.Tests
{
    [TestFixture]
    public sealed class PawnTest : FigureTestBase
    {
        [TestCase("A2", "B3", FigureColor.White)]
        [TestCase("B2", "A3 C3", FigureColor.White)]

        [TestCase("A7", "B6", FigureColor.Black)]
        [TestCase("B7", "A6 C6", FigureColor.Black)]
        public void ShouldGetValidMoves(string position, string expectedMovesStr, FigureColor color)
        {
            // Given
            var expectedMoves = expectedMovesStr.ToPositions();
            var pawn = new Pawn(position);
            pawn.Color = color;

            // When
            var actualMoves = pawn.GetMoves(Board);

            // Then
            Assert.IsTrue(actualMoves.SequenceEqual(expectedMoves));
        }
    }
}
