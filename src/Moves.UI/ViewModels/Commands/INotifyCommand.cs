﻿using System;
using System.Windows.Input;

namespace Moves.UI.ViewModels.Commands
{
    public interface INotifyCommand : ICommand
    {
        void NotifyCanExecuteChanged();
        event EventHandler Executed;

        bool TryExecute();

        bool TryExecute(object obj);

        bool CanExecute();

        void Execute();
    }
}
