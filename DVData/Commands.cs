using System;
using System.Windows;
using System.Windows.Input;

namespace DVData
{
    /// <summary>
    /// A simple command that displays the command parameter as
    /// a dialog message.
    /// </summary>
    public class ShowClient : ICommand
    {
        public void Execute(object parameter)
        {
            Application.Current.MainWindow.Activate();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}