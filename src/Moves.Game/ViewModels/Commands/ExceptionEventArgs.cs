using System;

namespace Moves.Game.ViewModels.Commands
{
    public sealed class ExceptionEventArgs : EventArgs
    {
        public Exception Exception { get; private set; }

        public ExceptionEventArgs(Exception exception)
        {
            Exception = exception;
        }
    }
}