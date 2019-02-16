using System.Linq;
using Moves.Engine.Figures;
using NUnit.Framework;

namespace Moves.Engine.Tests
{
    [TestFixture]
    public class BoardTest
    {
        [TestCase("NA1 NA3 NC1 NC3", "PB2", null, "NA3 NC3")]
        public void BoardHitTest(string sourceFiguresStr, string addingFigureStr, string expectedAttackingStr, string expectedAttackedStr)
        {
            // Given
            var board = Board.Board.CreateDefault();
            var expectedAttackingFigures = expectedAttackingStr.ToFigures();
            var expectedAttackedFigures = expectedAttackedStr.ToFigures();
            var sourceFigures = sourceFiguresStr.ToFigures();
            var addingFigure = addingFigureStr.ToFigure();
            addingFigure.Color = FigureColor.White;
            foreach (var figure in sourceFigures)
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
