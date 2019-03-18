using NUnit.Framework;

namespace Moves.Engine.Tests
{
    [TestFixture]
    public class FigureExtensionsTest
    {
        /// <summary>
        /// Должен создать фигуру по заданному типу и заданной позиции
        /// </summary>
        [TestCase(FigureType.Pawn, "a2", "Pa2")]
        [TestCase(FigureType.Rook, "a1", "Ra1")]
        [TestCase(FigureType.Knight, "a2", "Na2")]
        [TestCase(FigureType.Bishop, "c1", "Bc1")]
        [TestCase(FigureType.King, "e1", "Ke1")]
        [TestCase(FigureType.Queen, "d1", "Qd1")]
        public void ShouldCreateFigureByTypeAndPosition(FigureType figureType, string position, string expectedFigureStr)
        {
            // Given
            var expectedFigure = expectedFigureStr.ToFigure(FigureColor.White);

            // When
            var actualFigure = figureType.CreateFigure(FigureColor.White, position);

            // Then
            Assert.AreEqual(expectedFigure, actualFigure);
        }
    }
}
