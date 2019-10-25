using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using IO = System.IO;

namespace MyImageProcessing.ViewModel.MainViewModel.Container {
    public class ImageContainer : TabItem {

        ImageCanvas canvas;
        public string ImagePath { get; set; }
        public ImageCanvas Image { get { return canvas; } }
        private double zoomLevel = 100;
        public int MinZoomLevel { get { return 5; } }
        public int MaxZoomLevel { get { return 250; } }

        public double ZoomLevel {
            get { return zoomLevel; }
            set {
                ScaleTransform transform = new ScaleTransform() {
                    ScaleX = value / 100,
                    ScaleY = value / 100
                };
                this.canvas.LayoutTransform = transform;
                this.zoomLevel = value;
            }
        }

        public ImageContainer(string path) {
            this.ImagePath = path;
            ScrollViewer viewer = new ScrollViewer() {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Visible,
                VerticalScrollBarVisibility = ScrollBarVisibility.Visible,
            };
            canvas = new ImageCanvas(path);
            this.Header = IO.Path.GetFileName(path);
            this.Content = viewer;
            this.Padding = new Thickness(5);
            this.Margin = new Thickness(0);
            viewer.Content = canvas;
        }
    }
}
