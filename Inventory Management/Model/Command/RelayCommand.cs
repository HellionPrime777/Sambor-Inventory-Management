using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Inventory_Management.Model
{
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Клас RelayCommand дозволяє створювати команди, які можуть бути прив'язані до подій і елементів керування у користувацькому інтерфейсі. 
        /// Використовуючи цей клас, можна визначити логіку виконання команди та перевірку її можливості виконання.
        /// </summary>
        #region Fields
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;
        #endregion
        // Fields
        #region  Constructors
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        { }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        { if (execute == null) throw new ArgumentNullException("execute"); _execute = execute; _canExecute = canExecute; }
        #endregion
        // Constructors
        #region ICommand Members
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        { return _canExecute == null ? true : _canExecute(parameter); }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        public void CheckAndExecute(object parameter)
        {
            if (CanExecute(parameter)) Execute(parameter);
        }
        #endregion
        // ICommand Members
    }
}
