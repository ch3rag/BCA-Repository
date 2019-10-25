using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Emgu.CV;
using Emgu.CV.Structure;
using MyImageProcessing.ImageOperations;
using Drawing = System.Drawing;
using Media = System.Windows.Media;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;
using System.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Shapes;
using System.Windows.Input;

namespace MyImageProcessing.ViewModel.MainViewModel.Container {


    public class ImageCanvas : Canvas, INotifyPropertyChanged, IDataErrorInfo {
        private enum Tool {
            Select,
            Text,
            Line,
            Circle,
            Rectangle,
            Paint,
            None,
            Dropper
        };

        public bool IsNotSaved { get; set; }
        private Tool currentTool = Tool.None;


        public bool IsDropperToolEnabled {
            get { return currentTool == Tool.Dropper; }
            set { SetTool(Tool.Dropper, value); }
        }

        public bool IsSelectToolEnabled {
            get { return currentTool == Tool.Select; }
            set { SetTool(Tool.Select, value); }
        }

        public bool IsLineToolEnabled {
            get { return currentTool == Tool.Line; }
            set { SetTool(Tool.Line, value); }
        }

        public bool IsRectangleToolEnabled {
            get { return currentTool == Tool.Rectangle; }
            set { SetTool(Tool.Rectangle, value); }
        }

        public bool IsCircleToolEnabled {
            get { return currentTool == Tool.Circle; }
            set { SetTool(Tool.Circle, value); }
        }

        public bool IsTextToolEnabled {
            get { return currentTool == Tool.Text; }
            set { SetTool(Tool.Text, value); }
        }

        public bool IsPaintToolEnabled {
            get { return currentTool == Tool.Paint; }
            set { SetTool(Tool.Paint, value); }
        }

        private void SetTool(Tool tool, bool state) {
            DisableAllTools();
            if (state) {
                switch(tool) {
                    case Tool.Select:
                        selectionRect.Visibility = Visibility.Visible;
                        break;
                    case Tool.Paint:
                        ink.Visibility = Visibility.Visible;

                        break;
                }
                currentTool = tool;
            }
        }

        private void DisableAllTools() {
            currentTool = Tool.None;
            ink.Visibility = Visibility.Collapsed;
            ink.Strokes.Clear();
            selectionRect.Height = selectionRect.Width = 0;
        }

        public void OnPropertyChanged(string columnName) {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }

        private void Dissolve() {
            if (this.ActualHeight > 0 || this.ActualWidth > 0) {
                selectionRect.Visibility = Visibility.Collapsed;
                DisplayImage(new Image<Bgr, byte>(BitmapFromWriteableBitmap(SaveAsWriteableBitmap(this))));
            }
            ClearChilds();
        }

        

        // BINDING VARS
        public int ResizeWidth { get; set; }
        public int ResizeHeight { get; set; }
        public int ResizeScale { get; set; }
        public string FontFamily { get; set; } = "Arial";
        public int FontSize { get; set; } = 8;
        public bool FontBold { get; set; } = false;
        public bool FontUnderline { get; set; } = false;
        public bool FontItalic { get; set; } = false;
        private Color stroke = Media.Colors.Black;
        public Color Stroke {
            get { return stroke; }
            set { stroke = value; ink.DefaultDrawingAttributes.Color = value; }
        }
        public Color Fill { get; set; } = Media.Colors.Transparent;
        private int strokeWidth = 1;
        public int StrokeWidth {
            get { return strokeWidth; }
            set { strokeWidth = value; ink.DefaultDrawingAttributes.Width = value; ink.DefaultDrawingAttributes.Height = value; }
        }
        public Image<Bgr, byte> image;
        Rectangle selectionRect = new Rectangle();
        Line currentLine;
        Rectangle currentRectangle;
        System.Windows.Shapes.Ellipse currentCircle;
        private int historyIndex;
        Point mouse, mousePressed;
        InkCanvas ink = new InkCanvas();

        private List<Image<Bgr, byte>> operationHistory = new List<Image<Bgr, byte>>();
        public List<Image<Bgr, byte>> OperationHistory { get { return operationHistory; } }

        public ObservableCollection<string> history = new ObservableCollection<string>();
        public ObservableCollection<string> History { get { return history; } }

        // HANDLER FOR INOTIFYPROPERTYCHANGED
        public event PropertyChangedEventHandler PropertyChanged;

        // IDATAERRORINFO
        public string Error { get { return string.Empty; } }
        public string this[string columnName] {
            get {
                switch (columnName) {
                    case "ResizeWidth":
                        if (ResizeWidth < 1 || ResizeWidth > 2048)
                            return "Width Out Of Bounds";
                        break;
                    case "ResizeHeight":
                        if (ResizeHeight < 1 || ResizeHeight > 2048)
                            return "Height Out Of Bounds";
                        break;
                    case "ResizeScale":
                        if (ResizeScale < 1 || ResizeScale > 1000)
                            return "Scale Out Of Bounds";
                        break;

                }
                return string.Empty;
            }
        }

        public int HistoryIndex {
            get { return historyIndex; }
            set {
                if (value >= OperationHistory.Count || value < 0)
                    throw new ArgumentException("Invalid History Index");
                historyIndex = value;
                DisplayImage(OperationHistory[value]);
            }
        }

        
        private void DisplayImage(Image<Bgr, byte> image) {
            this.image = image;
            ink.Width = this.Width = image.Width;
            ink.Height = this.Height = image.Height;
            this.InvalidateVisual();
        }
        
        public ImageCanvas(string imageURI) {
            image = new Image<Bgr, byte>(imageURI);
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Top;
            this.Height = image.Height;
            this.Width = image.Width;
            this.ClipToBounds = true;
            this.MouseDown += ImageCanvas_MouseDown;
            this.MouseMove += ImageCanvas_MouseMove;
            this.MouseUp += ImageCanvas_MouseUp;
            this.Children.Add(selectionRect);
            selectionRect.Stroke = Media.Brushes.Black;
            selectionRect.StrokeDashArray = new DoubleCollection() { 2 };
            selectionRect.StrokeThickness = 2;
            Panel.SetZIndex(selectionRect, 9999);

            ink.Width = image.Width;
            ink.Height = image.Height;
            ink.Background = Media.Brushes.Transparent;
            ink.MouseLeftButtonUp += Ink_MouseLeftButtonUp;
            Panel.SetZIndex(ink, 9999);
            this.Children.Add(ink);
        }

        private void Ink_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            Dissolve();
            UpdateHistory("Paint Stroke");
            ink.Strokes.Clear();
        }

        private void ImageCanvas_MouseUp(object sender, MouseButtonEventArgs e) {
            switch (currentTool) {
                case Tool.Line:
                    Dissolve();
                    UpdateHistory("Add Line");
                    break;
                case Tool.Rectangle:
                    Dissolve();
                    UpdateHistory("Add Rectangle");
                    break;
                case Tool.Circle:
                    Dissolve();
                    UpdateHistory("Add Circle");
                    break;
                case Tool.Text:
                    TextBox txtBox = new TextBox() {
                        Background = new SolidColorBrush(this.Fill),
                        Foreground = new SolidColorBrush(this.Stroke),
                        FontFamily = new FontFamily(this.FontFamily),
                        FontSize = this.FontSize,
                        FontWeight = this.FontBold ? FontWeights.Bold : FontWeights.Normal,
                        FontStyle = this.FontItalic ? FontStyles.Italic : FontStyles.Normal,
                        TextDecorations = this.FontUnderline ? new TextDecorationCollection() { TextDecorations.Underline } : null,
                        HorizontalAlignment = HorizontalAlignment.Center
                    };
                    Canvas.SetLeft(txtBox, mousePressed.X);
                    Canvas.SetTop(txtBox, mousePressed.Y);
                    this.Children.Add(txtBox);
                    txtBox.Focus();
                    txtBox.LostFocus += TxtBox_LostFocus;
                    break;
            }
        }

        private void UpdateHistory(string operation) {
            OperationHistory.Add(image);
            History.Add(operation);
            HistoryIndex = History.Count - 1;
        }

        private void TxtBox_LostFocus(object sender, RoutedEventArgs e) {
            ClearChilds();
            TextBox txt = sender as TextBox;
            TextBox txtBox = new TextBox() {
                Background = new SolidColorBrush(this.Fill),
                Foreground = new SolidColorBrush(this.Stroke),
                BorderBrush = null,
                BorderThickness = new Thickness(0),
                FontFamily = new FontFamily(this.FontFamily),
                FontSize = this.FontSize,
                FontWeight = this.FontBold ? FontWeights.Bold : FontWeights.Normal,
                FontStyle = this.FontItalic ? FontStyles.Italic : FontStyles.Normal,
                TextDecorations = this.FontUnderline ? new TextDecorationCollection() { TextDecorations.Underline } : null,
                Text = txt.Text,
                CaretBrush = new SolidColorBrush(Colors.Transparent),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Canvas.SetLeft(txtBox, Canvas.GetLeft(txt));
            Canvas.SetTop(txtBox, Canvas.GetTop(txt));
            this.Children.Add(txtBox);

            IsTextToolEnabled = false;
            Dissolve();
            UpdateHistory("Add Text");
        }

        private void ImageCanvas_MouseMove(object sender, MouseEventArgs e) {
            mouse = e.GetPosition(this);
            double x, y, width, height; 
            if (e.LeftButton == MouseButtonState.Pressed) {
                switch(currentTool) {
                    case Tool.Select:
                        GetXYWidthHeight(out x, out y, out width, out height);
                        selectionRect.Width = width;
                        selectionRect.Height = height;
                        Canvas.SetLeft(selectionRect, x);
                        Canvas.SetTop(selectionRect, y);
                        break;
                    case Tool.Line:
                        if (currentLine != null) {
                            currentLine.X1 = mousePressed.X;
                            currentLine.Y1 = mousePressed.Y;
                            currentLine.Y2 = mouse.Y;
                            currentLine.X2 = mouse.X;
                        }
                        break;
                    case Tool.Circle:
                        if (currentCircle != null) {
                            GetXYWidthHeight(out x, out y, out width, out height);
                            Canvas.SetLeft(currentCircle, x);
                            Canvas.SetTop(currentCircle, y);
                            currentCircle.Width = width;
                            currentCircle.Height = height;
                        }
                        break;
                    case Tool.Rectangle:
                        if(currentRectangle != null) {
                            GetXYWidthHeight(out x, out y, out width, out height);
                            Canvas.SetLeft(currentRectangle, x);
                            Canvas.SetTop(currentRectangle, y);
                            currentRectangle.Width = width;
                            currentRectangle.Height = height;
                        }
                        break;
                }
            }            
        }

        private void GetXYWidthHeight(out double x, out double y, out double width, out double height) {
            if (mouse.X < mousePressed.X) {
                x = mouse.X;
                width = mousePressed.X - x;
            } else {
                x = mousePressed.X;
                width = mouse.X - mousePressed.X;
            }
            if (mouse.Y < mousePressed.Y) {
                y = mouse.Y;
                height = mousePressed.Y - y;
            } else {
                y = mousePressed.Y;
                height = mouse.Y - mousePressed.Y;
            }

        }

        private void ImageCanvas_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            mousePressed = e.GetPosition(this);

            switch(currentTool) {
                case Tool.Line:
                    Line line = new Line() {
                        Stroke = new SolidColorBrush(this.Stroke),
                        StrokeThickness = this.StrokeWidth
                    };
                    currentLine = line;
                    this.Children.Add(line);
                    break;
                case Tool.Rectangle:
                    Rectangle rectangle = new Rectangle() {
                        Stroke = new SolidColorBrush(this.Stroke),
                        StrokeThickness = this.StrokeWidth,
                        Fill = new SolidColorBrush(this.Fill)
                    };
                    currentRectangle = rectangle;
                    this.Children.Add(rectangle);
                    break;
                case Tool.Circle:
                    System.Windows.Shapes.Ellipse circle = new System.Windows.Shapes.Ellipse {
                        Stroke = new SolidColorBrush(this.Stroke),
                        StrokeThickness = this.StrokeWidth,
                        Fill = new SolidColorBrush(this.Fill)
                    };
                    currentCircle = circle;
                    this.Children.Add(circle);
                    break;
                case Tool.Dropper:
                    Bgr pixelColor = image[(int)mousePressed.Y, (int)mousePressed.X];
                    Color color = new Color() { A = 255, R = (byte)pixelColor.Red, G = (byte)pixelColor.Green, B = (byte)pixelColor.Blue };
                    if(e.LeftButton == MouseButtonState.Pressed) {
                        this.Stroke = color;
                    } else if(e.RightButton == MouseButtonState.Pressed) {
                        this.Fill = color;
                    }
                    break;
            }
        }

        private void ClearChilds() {
            this.Children.Clear();
            this.Children.Add(selectionRect);
            this.Children.Add(ink);
        }

        public void ApplyOperation(OperationList operationEnum, dynamic[] args) {
            IsNotSaved = true;
            switch(operationEnum) {
                case OperationList.None:
                    return;
                case OperationList.Resize:
                    args = new dynamic[] { ResizeWidth, ResizeHeight };
                    break;
                case OperationList.Scale:
                    args = new dynamic[] { ResizeScale };
                    break;
                case OperationList.Crop:
                    if (selectionRect.Width > 0 && selectionRect.Height > 0) {
                        args = new dynamic[] { Canvas.GetLeft(selectionRect), Canvas.GetTop(selectionRect), selectionRect.Width, selectionRect.Height };
                        IsSelectToolEnabled = false;
                        break;
                    }
                    else return;
                case OperationList.Undo:
                    if (HistoryIndex > 0) HistoryIndex = HistoryIndex - 1;
                    return;
                case OperationList.Redo:
                    if (HistoryIndex + 1 < OperationHistory.Count) HistoryIndex = HistoryIndex + 1;
                    return;
                case OperationList.Reset:
                    HistoryIndex = 0;
                    OperationHistory.Clear();
                    History.Clear();
                    operationEnum = OperationList.Original;
                    break;
            }

            DisableAllTools();
            Dissolve();

            Operation operation = Operations.ImageOperations[operationEnum];
            DisplayImage(operation.Operate(image, args));
            
            OperationHistory.Add(image);            
            History.Add(operation.OperationName);
            HistoryIndex = History.Count - 1;

        }

        protected override void OnRender(DrawingContext dc) {
            dc.DrawImage(ToBitmapImage(image.ToBitmap()), new Rect(0, 0, this.image.Width, this.image.Height));            
        }

        private static BitmapImage ToBitmapImage(Drawing.Bitmap bitmap) {
            using (MemoryStream memory = new MemoryStream()) {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = memory;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
                image.Freeze();
                return image;
            }
        }

        public WriteableBitmap SaveAsWriteableBitmap(Canvas surface) {
            if (surface == null) return null;

            Transform transform = surface.LayoutTransform;
            surface.LayoutTransform = null;
            Size size = new Size(surface.ActualWidth, surface.ActualHeight);
            surface.Measure(size);
            surface.Arrange(new Rect(size));
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap(
              (int)size.Width,
              (int)size.Height,
              96d,
              96d,
              PixelFormats.Pbgra32);
            renderBitmap.Render(surface);
            surface.LayoutTransform = transform;
            return new WriteableBitmap(renderBitmap);
        }

        public Drawing.Bitmap GetBitmap() {
            return image.ToBitmap();
        }

        public BitmapImage GetBitmapImage() {
            MemoryStream ms = new MemoryStream();
            ((System.Drawing.Bitmap)this.image.ToBitmap()).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }


        private Drawing.Bitmap BitmapFromWriteableBitmap(WriteableBitmap writeBmp) {
            Drawing.Bitmap bmp;
            using (MemoryStream outStream = new MemoryStream()) {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create((BitmapSource)writeBmp));
                enc.Save(outStream);
                bmp = new Drawing.Bitmap(outStream);
            }
            return bmp;
        }
    }
}