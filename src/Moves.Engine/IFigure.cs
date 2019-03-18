namespace Moves.Engine
{
    public enum FigureColor
    {
        Black,
        White
    }

    public interface IFigure
    {
        FigureColor Color { get; }

        Position Position { get; }

        FigureType Type { get; }
    }
}