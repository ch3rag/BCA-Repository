using System;

namespace MyImageProcessing.Commands {

    public class RelayCommand : CommandBase {
        Action execute;
        Func<bool> canExecute;

        public override bool CanExecute(object parameter) {
            return canExecute == null || canExecute();
        }

        public override void Execute(object parameter) {
            execute();
        }

        public RelayCommand(Action execute) : this(execute, null ) { }
        public RelayCommand(Action execute, Func<bool> canExecute) {
            this.execute = execute;
            this.canExecute = canExecute;
        }
    }
}
