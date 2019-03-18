using System.Linq;
using NUnit.Framework;

namespace Moves.Engine.Tests
{
    [TestFixture]
    public class BoardTest
    {
        // Тесты учитывающие перекрытия

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

        // Тесты для ферзя
        [TestCase(null, null, "Qa1", null, null)]
        [TestCase(null, "Ra2 Rb1", "Qa1", "Ra2 Rb1", "Ra2 Rb1")]
        [TestCase(null, "Ra2 Ra3", "Qa1", "Ra2", "Ra2")]
        public void BoardHitTest(string sourceWhiteFiguresStr, string sourceBlackFiguresStr, string addingFigureStr, string expectedAttackingStr, string expectedAttackedStr)
        {
            // Given
            var board = Board.CreateDefault();
            var sourceWhiteFigures = sourceWhiteFiguresStr.ToFigures(FigureColor.White);
            var sourceBlackFigures = sourceBlackFiguresStr.ToFigures(FigureColor.Black);
            var expectedAttackingFigures = expectedAttackingStr.ToFigures(FigureColor.Black);
            var expectedAttackedFigures = expectedAttackedStr.ToFigures(FigureColor.Black);
            var addingFigure = addingFigureStr.ToFigure(FigureColor.White);
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
        
        // Ходы фигур
        [TestCase(FigureType.Rook, "a1", "a2 a3 a4 a5 a6 a7 a8 b1 c1 d1 e1 f1 g1 h1")]
        [TestCase(FigureType.Rook, "e4", "e1 e2 e3 e5 e6 e7 e8 a4 b4 c4 d4 f4 g4 h4")]

        [TestCase(FigureType.Knight, "a1", "b3 c2")]
        [TestCase(FigureType.Knight, "a8", "b6 c7")]
        [TestCase(FigureType.Knight, "h1", "f2 g3")]
        [TestCase(FigureType.Knight, "h8", "f7 g6")]
        [TestCase(FigureType.Knight, "b1", "a3 c3 d2")]
        [TestCase(FigureType.Knight, "g1", "e2 f3 h3")]
        [TestCase(FigureType.Knight, "b8", "a6 c6 d7")]
        [TestCase(FigureType.Knight, "g8", "e7 f6 h6")]
        [TestCase(FigureType.Knight, "d1", "b2 c3 e3 f2")]
        [TestCase(FigureType.Knight, "a4", "b6 c3 c5 b2")]
        [TestCase(FigureType.Knight, "d8", "f7 e6 c6 b7")]
        [TestCase(FigureType.Knight, "h5", "g7 f6 f4 g3")]
        [TestCase(FigureType.Knight, "e2", "c1 c3 d4 f4 g3 g1")]
        [TestCase(FigureType.Knight, "c3", "a2 b1 d1 e2 e4 d5 b5 a4")]

        [TestCase(FigureType.Bishop, "a1", "b2 c3 d4 e5 f6 g7 h8")]
        [TestCase(FigureType.Bishop, "a8", "b7 c6 d5 e4 f3 g2 h1")]
        [TestCase(FigureType.Bishop, "h8", "g7 f6 e5 d4 c3 b2 a1")]
        [TestCase(FigureType.Bishop, "h1", "g2 f3 e4 d5 c6 b7 a8")]
        [TestCase(FigureType.Bishop, "c1", "a3 b2 d2 e3 f4 g5 h6")]
        [TestCase(FigureType.Bishop, "d4", "c3 b2 a1 c5 b6 a7 e5 f6 g7 h8 e3 f2 g1")]

        [TestCase(FigureType.Queen, "a1", "b2 c3 d4 e5 f6 g7 h8 a2 a3 a4 a5 a6 a7 a8 b1 c1 d1 e1 f1 g1 h1")]
        [TestCase(FigureType.Queen, "d5", "a5 b5 c5 e5 f5 g5 h5 d1 d2 d3 d4 d6 d7 d8 a8 b7 c6 e4 f3 g2 h1 a2 b3 c4 e6 f7 g8")]

        [TestCase(FigureType.King, "a1", "a2 b2 b1")]
        [TestCase(FigureType.King, "d1", "c1 c2 d2 e2 e1")]
        [TestCase(FigureType.King, "e5", "d6 e6 f6 d5 f5 d4 e4 f4")]
        public void ShouldGetMoves(FigureType type, string positionStr, string expectedMovesStr)
        {
            // Given
            var expectedMoves = expectedMovesStr.ToPositions();
            var figure = new Figure(type, FigureColor.White, positionStr);
            var board = new Board(GlobalConstants.DefaultWidth, GlobalConstants.DefaultHeight);

            // When
            var actualMoves = board.GetMoves(figure).OrderBy(x => x.PositionStr).ToArray();

            // Then
            Assert.IsTrue(actualMoves.SequenceEqual(expectedMoves));
        }
    }
}
