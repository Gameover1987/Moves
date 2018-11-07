namespace Moves.UI.ViewModels
{
    public sealed class MovesViewModel : IMovesViewModel
    {
        public MovesViewModel()
        {
            
        }

        public IPlayerViewModel Player1 { get; }
        public IPlayerViewModel Player2 { get; }
        public IBoardViewModel Board { get; }
    }
}
