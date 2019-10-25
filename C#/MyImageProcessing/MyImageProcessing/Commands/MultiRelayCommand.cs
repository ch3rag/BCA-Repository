using System;
using MyImageProcessing.ImageOperations;

namespace MyImageProcessing.Commands {
    public class MultiRelayCommand : CommandBase {

        private Action<OperationList, dynamic[]> execute;
        private Func<bool> canExecute;

        public override bool CanExecute(object parameter) {
            return canExecute();
        }

        public override void Execute(object parameter) {
            object[] values = (object[])parameter;
            OperationList operation = (OperationList)values[0];
            dynamic[] args = new dynamic[values.Length - 1];
            Array.Copy(values, 1, args, 0, args.Length);
            execute(operation, args);
        }

        public MultiRelayCommand(Action<OperationList, dynamic[]> execute, Func<bool> canExecute) {
            this.execute = execute;
            this.canExecute = canExecute;
        }
    }
}
