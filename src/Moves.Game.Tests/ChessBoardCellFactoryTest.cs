using Moves.Engine.Figures;
using Moves.Game.ViewModels.Board;
using NUnit.Framework;

namespace Moves.Game.Tests
{
    [TestFixture]
    public class ChessBoardCellFactoryTest
    {
        /// <summary>
        /// Должен создать клетку правильного цвета
        /// </summary>
        [TestCase(0, 0, FigureColor.Black)]
        [TestCase(0, 1, FigureColor.White)]
        [TestCase(1, 1, FigureColor.Black)]
        public void ShouldcreateCellWithcorrectColor(int row, int column, FigureColor expectedColor)
        {
            // Given
            var factory = new ChessBoardCellFactory();

            // When
            var cell = factory.CreateCell(row, column);

            // Then
            Assert.AreEqual(cell.Row, row);
            Assert.AreEqual(cell.Column, column);
            Assert.AreEqual(cell.Color, expectedColor);
        }
    }
}
