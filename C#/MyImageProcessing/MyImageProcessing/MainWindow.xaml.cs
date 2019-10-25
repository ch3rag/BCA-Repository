using System.Windows;
using MyImageProcessing.ViewModel.MainViewModel;
namespace MyImageProcessing {
    
    public partial class MainWindow : Window {
        public MainViewModel ViewModel { get; set; } = new MainViewModel();
        public MainWindow() {
            InitializeComponent();
        }
    }
}
