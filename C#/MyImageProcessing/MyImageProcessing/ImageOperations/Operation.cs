using Emgu.CV;
using Emgu.CV.Structure;

namespace MyImageProcessing.ImageOperations {
    public delegate Image<Bgr, byte> OperationDelegate(Image<Bgr, byte> image, dynamic[] args);

    public class Operation {
        public string OperationName { get; set; }
        public OperationDelegate Operate { get; set; }
    }
}
