using Moves.Engine.Figures;

namespace Moves.Game.ViewModels
{
    public interface IFigureViewModel
    {
    }

    public class FigureViewModel : IFigureViewModel
    {
        private readonly IFigure _figure;

        public FigureViewModel(IFigure figure)
        {
            _figure = figure;
        }
    }
}