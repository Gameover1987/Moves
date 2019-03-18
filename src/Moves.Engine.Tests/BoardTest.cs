using System.Linq;
using Moves.Engine.Figures;
using NUnit.Framework;

namespace Moves.Engine.Tests
{
    [TestFixture]
    public class BoardTest
    {
        // Тесты для ладьи
        [TestCase(null, null, "Ra1", null, null)]
        [TestCase(null, "Ra8", "Ra1", "Ra8", "Ra8")]
        [TestCase(null, "Pa7", "Ra1", null, "Pa7")]
        [TestCase(null, "Pa7 Ra8", "Ra1", null, "Pa7")]

        // Тесты для слона
        [TestCase(null, null, "Bf1", null, null)]
        [TestCase(null, "Bc3", "Bf1", null, null)]
        [TestCase(null, "Bc4", "Bf1", "Bc4", "Bc4")]
        [TestCase(null, "Bc4 Pd3", "Bf1", null, "Pd3")]
        public void BoardHitTest(string sourceWhiteFiguresStr, string sourceBlackFiguresStr, string addingFigureStr, string expectedAttackingStr, string expectedAttackedStr)
        {
            // Given
            var board = Board.Board.CreateDefault();
            var sourceWhiteFigures = sourceWhiteFiguresStr.ToFigures(FigureColor.White);
            var sourceBlackFigures = sourceBlackFiguresStr.ToFigures(FigureColor.Black);
            var expectedAttackingFigures = expectedAttackingStr.ToFigures(FigureColor.Black);
            var expectedAttackedFigures = expectedAttackedStr.ToFigures(FigureColor.Black);
            var addingFigure = addingFigureStr.ToFigure(FigureColor.White);
            addingFigure.Color = FigureColor.White;
            foreach (var figure in sourceWhiteFigures.Concat(sourceBlackFigures))
            {
                board.AddFigure(figure);
            }

            // When
            var result = board.HitTest(addingFigure);

            // Then
            Assert.IsTrue(result.AttackingFigures.SequenceEqual(expectedAttackingFigures));
            Assert.IsTrue(result.AttackedFigures.SequenceEqual(expectedAttackedFigures));
        }
    }
}
