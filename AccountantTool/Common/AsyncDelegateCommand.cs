﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccountantTool.Common
{
    public class AsyncDelegateCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Func<object, Task> _asyncExecute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public AsyncDelegateCommand(Func<object, Task> asyncExecute, Predicate<object> canExecute = null)
        {
            _asyncExecute = asyncExecute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);
        public async void Execute(object parameter) => await ExecuteAsync(parameter);
        protected virtual async Task ExecuteAsync(object parameter) => await _asyncExecute(parameter);
    }
}