using MyImageProcessing.Commands;
using Forms = System.Windows.Forms;
using MyImageProcessing.ViewModel.MainViewModel.Container;
using MyImageProcessing.Windows;
using System.Windows.Documents;
using System.Windows.Controls;
using System.IO;
using System.Windows.Xps.Packaging;
using System.Windows.Xps;
using System.Windows.Xps.Serialization;

namespace MyImageProcessing.ViewModel.MainViewModel {
    public partial class MainViewModel {

        private RelayCommand fileOpenCommand = null;
        private RelayCommand fileSaveCommand = null;
        private RelayCommand fileSaveAsCommand = null;
        private RelayCommand fileCloseCommand = null;
        private RelayCommand filePrintCommand = null;

        public RelayCommand FilePrintCommand {
            get {
                return filePrintCommand == null ? filePrintCommand = new RelayCommand(OnExecuteFilePrintCommand, ContainerNotNull) : filePrintCommand;
            }
        }

        public RelayCommand FileCloseCommand {
            get {
                return fileCloseCommand == null ? fileCloseCommand = new RelayCommand(OnExecuteFileCloseCommand) : fileCloseCommand;
            }
        }

        public RelayCommand FileSaveAsCommand {
            get {
                return fileSaveAsCommand == null ? fileSaveAsCommand = new RelayCommand(OnExecuteFileSaveAsCommand, ContainerNotNull) : fileSaveAsCommand;
            }
        }
        public RelayCommand FileSaveCommand {
            get {
                return fileSaveCommand == null ? fileSaveCommand = new RelayCommand(OnExecuteFileSaveCommand, CanSaveFileCommandExecute) : fileSaveCommand;
            }
        }

        public RelayCommand FileOpenCommand {
            get {
                return ((fileOpenCommand == null) ? (fileOpenCommand = new RelayCommand(OnExecuteFileOpenCommand)) : fileOpenCommand);
            }
        }

        private bool CanSaveFileCommandExecute() {
            return ContainerNotNull() && CurrentImageContainer.Image.IsNotSaved;
        }

        private void OnExecuteFilePrintCommand() {
            FlowDocument flowDocument = new FlowDocument();
            Image image = new Image() {
                Source = CurrentImageContainer.Image.GetBitmapImage()
            };
            flowDocument.Blocks.Add(new BlockUIContainer(image));

            if (File.Exists("printPreview.xps")) {
                File.Delete("printPreview.xps");
            }
            var xpsDocument = new XpsDocument("printPreview.xps", FileAccess.ReadWrite);
            XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(xpsDocument);
            writer.Write(((IDocumentPaginatorSource)flowDocument).DocumentPaginator);
            FixedDocumentSequence document = xpsDocument.GetFixedDocumentSequence();
            xpsDocument.Close();
            PrintWindow printWindow = new PrintWindow(document);
            printWindow.Show();
        }
        private void OnExecuteFileSaveCommand() {
            CurrentImageContainer.Image.GetBitmap().Save(CurrentImageContainer.ImagePath);
            CurrentImageContainer.Image.IsNotSaved = false;
        }

        private void OnExecuteFileCloseCommand() {
            System.Environment.Exit(0);
        }

        private void OnExecuteFileOpenCommand() {
            Forms.OpenFileDialog openFileDialog = new Forms.OpenFileDialog {
                Filter = "JPEG Images(*.jpg, *.jpeg) | *.jpg; *.jpeg | Bitmap Images (*.bmp) | *.bmp | PNG Images (*.png)| *.png"
            };
            if (openFileDialog.ShowDialog() == Forms.DialogResult.OK) {
                CreateNewContainer(openFileDialog.FileName);
            }
        }

        private void OnExecuteFileSaveAsCommand() {
            Forms.SaveFileDialog saveFileDialog = new Forms.SaveFileDialog {
                Filter = "JPEG Images(*.jpg, *.jpeg) | *.jpg; *.jpeg | Bitmap Images (*.bmp) | *.bmp | PNG Images (*.png)| *.png"
            };
            if (saveFileDialog.ShowDialog() == Forms.DialogResult.OK) {
                CurrentImageContainer.Image.GetBitmap().Save(saveFileDialog.FileName);
            }
        }


        private void CreateNewContainer(string initFileName) {
            ImageContainer container = new ImageContainer(initFileName);
            ImageContainers.Add(container);
            container.Focus();
            CurrentImageContainer = container;
            CurrentImageContainer.Image.ApplyOperation(ImageOperations.OperationList.Original, null);
        }

        private MultiRelayCommand operationCommand = null;
        public MultiRelayCommand OperationCommand {
            get {
                return operationCommand == null ?
                    operationCommand = new MultiRelayCommand((operation, args) => CurrentImageContainer.Image.ApplyOperation(operation, args) , ContainerNotNull) : operationCommand;
            }
        }

        private bool ContainerNotNull() {
            return IsContainerNotNull;
        }
    }
}
