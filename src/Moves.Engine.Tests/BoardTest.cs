using System.Linq;
using Moves.Engine.Figures;
using NUnit.Framework;

namespace Moves.Engine.Tests
{
    [TestFixture]
    public class BoardTest
    {
        [TestCase("NA1 NA3 NC1 NC3", null, "PB2", null, "NA3 NC3")]
        [TestCase("RA1 NB1", null, "PC1", null, null)]
        public void BoardHitTest(string sourceWhiteFiguresStr, string sourceBlackFiguresStr, string addingFigureStr, string expectedAttackingStr, string expectedAttackedStr)
        {
            // Given
            var board = Board.Board.CreateDefault();
            var sourceWhiteFigures = sourceWhiteFiguresStr.ToFigures();
            var sourceBlackFigures = sourceBlackFiguresStr.ToFigures();
            var expectedAttackingFigures = expectedAttackingStr.ToFigures();
            var expectedAttackedFigures = expectedAttackedStr.ToFigures();
            var addingFigure = addingFigureStr.ToFigure();
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
