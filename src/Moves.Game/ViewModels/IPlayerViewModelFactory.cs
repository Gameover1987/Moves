using Moves.Engine;

namespace Moves.Game.ViewModels
{
    public interface IPlayerViewModelFactory
    {
        IPlayerViewModel CreatePlayer(FigureColor color);
    }
}
