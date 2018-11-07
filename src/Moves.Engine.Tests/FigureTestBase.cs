using Moves.Engine.Board;

namespace Moves.Engine.Tests
{
    public class FigureTestBase
    {
        public IBoard Board { get; } = Engine.Board.Board.CreateDefault();
    }
}
