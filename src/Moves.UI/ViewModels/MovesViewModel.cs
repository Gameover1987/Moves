﻿using Moves.UI.Interaction;
using Moves.UI.ViewModels.Commands;

namespace Moves.UI.ViewModels
{
    public sealed class MovesViewModel : IMovesViewModel
    {
        private readonly IViewManager _viewManager;

        public MovesViewModel(IViewManager viewManager)
        {
            _viewManager = viewManager;

            NewGameCommand = new NotifyCommand(NewGameCommandHandler);            
        }

        public IPlayerViewModel Player1 { get; }
        public IPlayerViewModel Player2 { get; }
        public IBoardViewModel Board { get; }

        public INotifyCommand NewGameCommand { get; private set; }

        private void NewGameCommandHandler()
        {
            var newGameViewModel = _viewManager.NewGame();
        }
    }
}
