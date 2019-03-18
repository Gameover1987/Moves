using Moves.Engine;

namespace Moves.Game.ViewModels
{
    public sealed class PlayerViewModelFactory : IPlayerViewModelFactory
    {
        public IPlayerViewModel CreatePlayer(FigureColor color)
        {
            return new PlayerViewModel() {Color = color};
        }
    }
}
