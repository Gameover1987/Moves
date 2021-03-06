﻿using Moves.Engine.Figures;
using Moves.UI.ViewModels;
using Moves.UI.ViewModels.Commands;
using System.Collections.ObjectModel;

namespace Moves.UI.Windows.DesignTime
{
    internal sealed class DesignTimeNewGameViewModel : INewGameViewModel
    {
        public DesignTimeNewGameViewModel()
        {
            Player1 = new DesignTimePlayerViewModel { Nick = "Вячеслав" };
            Player2 = new DesignTimePlayerViewModel { Nick = "Петр" };

            Figures = new ObservableCollection<ChessFigureType>
            {
                ChessFigureType.Pawn,
                ChessFigureType.Rook,
                ChessFigureType.Knight,
                ChessFigureType.Bishop,
                ChessFigureType.Queen,
                ChessFigureType.King,
            };
        }

        public IPlayerViewModel Player1 { get; private set; }

        public IPlayerViewModel Player2 { get; private set; }

        public ObservableCollection<ChessFigureType> Figures { get; private set; }

        public INotifyCommand GiveFigureToPlayer1Command { get; private set; }

        public INotifyCommand GiveFigureToPlayer2Command { get; private set; }

        public INotifyCommand GiveDefaultFigureSetCommand { get; private set; }

        public INotifyCommand OkCommand { get; private set; }
    }
}
