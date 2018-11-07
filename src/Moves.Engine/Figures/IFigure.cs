using Moves.Engine.Board;

namespace Moves.Engine.Figures
{
    public enum FigureColor
    {
        Black,
        White
    }

    public interface IFigure
    {
        FigureColor Color { get; set; }

        Position Position { get; set; }

        Position[] GetMoves(IBoard board);
    }
}