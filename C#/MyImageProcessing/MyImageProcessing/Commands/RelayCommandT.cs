using System;

namespace MyImageProcessing.Commands {

    public class RelayCommand<T> : CommandBase {
        Action<T> execute;
        Func<T, bool> canExecute;

        public override bool CanExecute(object parameter) {
            return canExecute == null || canExecute((T)parameter);
        }

        public override void Execute(object parameter) {
            execute((T)parameter);
        }

        public RelayCommand(Action<T> execute) : this(execute, null) { }
        public RelayCommand(Action<T> execute, Func<T, bool> canExecute) {
            this.execute = execute;
            this.canExecute = canExecute;
        }
    }
}
