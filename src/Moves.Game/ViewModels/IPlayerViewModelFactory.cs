using System.Windows.Media;
using Moves.Engine.Figures;

namespace Moves.Game.ViewModels
{
    public interface IPlayerViewModelFactory
    {
        IPlayerViewModel CreatePlayer(FigureColor color);
    }
}
