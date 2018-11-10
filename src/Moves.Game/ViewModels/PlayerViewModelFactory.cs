namespace Moves.Game.ViewModels
{
    public sealed class PlayerViewModelFactory : IPlayerViewModelFactory
    {
        public IPlayerViewModel CreatePlayer()
        {
            return new PlayerViewModel();
        }
    }
}
