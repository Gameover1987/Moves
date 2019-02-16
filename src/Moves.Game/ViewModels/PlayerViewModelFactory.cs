using Moves.Engine.Figures;

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
