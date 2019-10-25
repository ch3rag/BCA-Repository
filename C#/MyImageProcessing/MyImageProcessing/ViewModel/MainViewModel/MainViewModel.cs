using MyImageProcessing.ViewModel.MainViewModel.Container;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Emgu.CV.UI;

namespace MyImageProcessing.ViewModel.MainViewModel {
    public partial class MainViewModel : INotifyPropertyChanged {

        ObservableCollection<ImageContainer> imageContainers = new ObservableCollection<ImageContainer>();
        private ImageContainer currentImageContainer;
        
        public ObservableCollection<ImageContainer> ImageContainers { get { return imageContainers; } }

        public ImageContainer CurrentImageContainer {
            get { return currentImageContainer;  }
            set { currentImageContainer = value; }
        }

        public bool IsContainerNotNull { get { return CurrentImageContainer != null; } }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
