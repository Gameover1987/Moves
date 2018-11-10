using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Moves.UI.ViewModels.Commands
{
    public class NotifyCommand : INotifyCommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;
        private readonly Action<Exception> _exceptionAction;
        private event EventHandler _canExecuteChanged;

        public NotifyCommand(Action action)
            : this(obj => action(), null)
        {
        }

        public NotifyCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public NotifyCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                _canExecuteChanged += value;
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                _canExecuteChanged -= value;
                CommandManager.RequerySuggested -= value;
            }
        }

        public event EventHandler Executed;

        public bool TryExecute()
        {
            return TryExecute(null);
        }

        public bool TryExecute(object obj)
        {
            if (CanExecute(obj))
            {
                Execute(obj);
                return true;
            }

            return false;
        }

        public bool CanExecute()
        {
            return CanExecute(null);
        }

        public void Execute()
        {
            Execute(null);
        }

        public bool CanExecute(object parameter)
        {
            try
            {
                return _canExecute == null || _canExecute(parameter);
            }
            catch (Exception e)
            {
                _exceptionAction(e);
                return false;
            }
        }

        public void Execute(object parameter)
        {
            try
            {
                _execute(parameter);

                if (Executed != null)
                    Executed(this, new EventArgs());
            }
            catch (Exception e)
            {
                _exceptionAction(e);
            }
        }

        public void NotifyCanExecuteChanged()
        {
            if (_canExecuteChanged != null)
            {
                if (Application.Current?.Dispatcher.CheckAccess() == true)
                    _canExecuteChanged(this, EventArgs.Empty);
                else
                    Application.Current?.Dispatcher.InvokeAsync(() => _canExecuteChanged(this, EventArgs.Empty), DispatcherPriority.Normal);
            }
        }

        public static void NotifyCanExecuteChangedForAll()
        {
            if (Application.Current?.Dispatcher.CheckAccess() == true)
                CommandManager.InvalidateRequerySuggested();
            else
                Application.Current?.Dispatcher.InvokeAsync(CommandManager.InvalidateRequerySuggested, DispatcherPriority.Normal);
        }
    }
}
