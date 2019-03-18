using Moves.Engine.Figures;
using NUnit.Framework;

namespace Moves.Engine.Tests
{
    [TestFixture]
    public class FigureExtensionsTest
    {
        /// <summary>
        /// Должен создать фигуру по заданному типу и заданной позиции
        /// </summary>
        [TestCase(ChessFigureType.Pawn, "A2", "PA2")]
        [TestCase(ChessFigureType.Rook, "A1", "RA1")]
        [TestCase(ChessFigureType.Knight, "A2", "NA2")]
        [TestCase(ChessFigureType.Bishop, "C1", "BC1")]
        [TestCase(ChessFigureType.King, "E1", "KE1")]
        [TestCase(ChessFigureType.Queen, "D1", "QD1")]
        public void ShouldCreateFigureByTypeAndPosition(ChessFigureType figureType, string position, string expectedFigureStr)
        {
            // Given
            var expectedFigure = expectedFigureStr.ToFigure(FigureColor.White);

            // When
            var actualFigure = figureType.CreateFigure(position);
            actualFigure.Color = FigureColor.White;

            // Then
            Assert.AreEqual(expectedFigure, actualFigure);
        }
    }
}
