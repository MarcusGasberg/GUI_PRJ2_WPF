using System;
using System.Windows.Input;
namespace GUI_PRJ2_Library
{
    public class RelayCommand<T> : ICommand
    {
        #region Fields
        /// <summary>
        /// The action to run
        /// </summary>
        readonly Action<T> execute_ = null;

        readonly Predicate<T> canExecute_ = null;
        #endregion 
        #region Public Events
        /// <summary>
        /// The event thats fired when the <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of <see cref="DelegateCommand{T}"/>
        /// </summary>
        /// <param name="execute"></param>
        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            execute_ = execute ?? throw new ArgumentNullException("execute");
            canExecute_ = canExecute;
        }
        #endregion
        #region Command Methods
        /// <summary>
        /// A relay command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return canExecute_ == null ? true : canExecute_((T)parameter);
        }
        /// <summary>
        /// Execture the commands Action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            action_();
        }
        #endregion
    }
}
