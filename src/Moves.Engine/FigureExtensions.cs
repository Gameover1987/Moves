namespace Moves.Engine
{
    public static class FigureExtensions
    {
        public static IFigure CreateFigure(this FigureType figure, FigureColor color, Position position)
        {
            return figure.CreateFigure(color, position.ToString());
        }

        public static IFigure CreateFigure(this FigureType figure, FigureColor color, string positionStr)
        {
           return new Figure(figure, color, positionStr);
        }
    }
}
