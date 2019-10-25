using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;

namespace MyImageProcessing.ImageOperations {
    public static class Operations {

        public static Dictionary<OperationList, Operation> ImageOperations { get; set; }
        static Operations() {
            ImageOperations = new Dictionary<OperationList, Operation>();

            // Original
            ImageOperations.Add(OperationList.Original, new Operation() {
                OperationName = "Original Image",
                Operate = (image, args) => image
            });

            // Grayscale
            ImageOperations.Add(OperationList.GrayScale, new Operation() {
                OperationName = "GrayScale",
                Operate = (image, args) => image.Convert<Gray, byte>().Convert<Bgr, byte>()
            });

            // Invert Brightness
            ImageOperations.Add(OperationList.InvertBrightness, new Operation() {
                OperationName = "Invert Brightness",
                Operate = (image, args) => image.Not()
            });

            // Invert Red And Blue
            ImageOperations.Add(OperationList.InvertRedBlue, new Operation() {
                OperationName = "Invert Red And Blue",
                Operate = (image, args) => {
                    Image<Gray, byte>[] splitted = image.Split();
                    return new Image<Bgr, byte>(new Image<Gray, byte>[] {
                        splitted[2], splitted[1], splitted[0]
                    });
                }
            });

            // Invert Red And Green
            ImageOperations.Add(OperationList.InvertRedGreen, new Operation() {
                OperationName = "Invert Red And Green",
                Operate = (image, args) => {
                    Image<Gray, byte>[] splitted = image.Split();
                    return new Image<Bgr, byte>(new Image<Gray, byte>[] {
                        splitted[0], splitted[2], splitted[1]
                    });
                }
            });

            // Invert Blue And Green
            ImageOperations.Add(OperationList.InvertBlueGreen, new Operation() {
                OperationName = "Invert Blue And Green",
                Operate = (image, args) => {
                    Image<Gray, byte>[] splitted = image.Split();
                    return new Image<Bgr, byte>(new Image<Gray, byte>[] {
                        splitted[1], splitted[0], splitted[2]
                    });
                }
            });

            // Invert Hue
            ImageOperations.Add(OperationList.InvertHue, new Operation() {
                OperationName = "Invert Hue",
                Operate = (image, args) => {
                    Image<Gray, byte>[] splitted = image.Convert<Hsv, byte>().Split();
                    splitted[0]._Not();
                    return new Image<Hsv, byte>(splitted).Convert<Bgr, byte>();
                }
            });

            // Extract Red Channel
            ImageOperations.Add(OperationList.ExtractChannelRed, new Operation() {
                OperationName = "Extract Red Channel",
                Operate = (image, args) => {
                    Image<Gray, byte>[] splitted = image.Split();
                    return new Image<Bgr, byte>(new Image<Gray, byte>[] {
                        new Image<Gray, byte>(image.Width, image.Height),
                        new Image<Gray, byte>(image.Width, image.Height),
                        splitted[2]
                    });
                }
            });

            // Extract Green Channel
            ImageOperations.Add(OperationList.ExtractChannelGreen, new Operation() {
                OperationName = "Extract Green Channel",
                Operate = (image, args) => {
                    Image<Gray, byte>[] splitted = image.Split();
                    return new Image<Bgr, byte>(new Image<Gray, byte>[] {
                        new Image<Gray, byte>(image.Width, image.Height),
                        splitted[1],
                        new Image<Gray, byte>(image.Width, image.Height)
                    });
                }
            });

            // Extract Blue Channel
            ImageOperations.Add(OperationList.ExtractChannelBlue, new Operation() {
                OperationName = "Extract Blue Channel",
                Operate = (image, args) => {
                    Image<Gray, byte>[] splitted = image.Split();
                    return new Image<Bgr, byte>(new Image<Gray, byte>[] {
                        splitted[0],
                        new Image<Gray, byte>(image.Width, image.Height),
                        new Image<Gray, byte>(image.Width, image.Height)
                    });
                }
            });

            // Monotone
            ImageOperations.Add(OperationList.Monotone, new Operation() {
                OperationName = "Montone Image",
                Operate = (image, args) => {
                    System.Windows.Media.Color color = args[0];
                    Image<Gray, float>[] splitted = new Image<Gray, float>[] {
                        new Image<Gray, float>(image.Width, image.Height),
                        new Image<Gray, float>(image.Width, image.Height),
                        new Image<Gray, float>(image.Width, image.Height)
                    };
                    Image<Gray, float> gray = image.Convert<Gray, float>();
                    for (int i = 0; i < image.Height; i++) {
                        for (int j = 0; j < image.Width; j++) {
                            float factor = (gray.Data[i, j, 0] / 255);
                            splitted[0].Data[i, j, 0] = factor * color.B;
                            splitted[1].Data[i, j, 0] = factor * color.G;
                            splitted[2].Data[i, j, 0] = factor * color.R;
                        }
                    }
                    return new Image<Bgr, float>(splitted).Convert<Bgr, byte>();
                }
            });

            // Rotate Left
            ImageOperations.Add(OperationList.RotateLeft, new Operation() {
                OperationName = "Rotate Left",
                Operate = (image, args) => image.Rotate(-90, new Bgr(), false)
            });

            // Rotate Right
            ImageOperations.Add(OperationList.RotateRight, new Operation() {
                OperationName = "Rotate Right",
                Operate = (image, args) => image.Rotate(90, new Bgr(), false)
            });

            // Flip Horizontal
            ImageOperations.Add(OperationList.FlipHorizontal, new Operation() {
                OperationName = "Flip Horizontal",
                Operate = (image, args) => image.Flip(Emgu.CV.CvEnum.FlipType.Horizontal)
            });

            // Flip Vertical
            ImageOperations.Add(OperationList.FlipVertical, new Operation() {
                OperationName = "Flip Vertical",
                Operate = (image, args) => image.Flip(Emgu.CV.CvEnum.FlipType.Vertical)
            });

            // Blur
            ImageOperations.Add(OperationList.Blur, new Operation() {
                OperationName = "Blur Image",
                Operate = (image, args) => {
                    int hDimension = (int)args[0];
                    Image<Bgr, byte> newImage = image.Copy();
                    Matrix<float> horizontalKernal = new Matrix<float>(hDimension, hDimension);
                    for (int i = 0; i < hDimension; i++) {
                        horizontalKernal[(int)(hDimension / 2), i] = 1;
                    }
                    horizontalKernal /= hDimension;
                    CvInvoke.Filter2D(newImage, newImage, horizontalKernal, new Point(-1, -1));
                    int vDimension = (int)args[1];

                    Matrix<float> verticalKernal = new Matrix<float>(vDimension, vDimension);
                    for (int i = 0; i < vDimension; i++) {
                        verticalKernal[i, (int)(vDimension / 2)] = 1;
                    }
                    verticalKernal /= vDimension;
                    CvInvoke.Filter2D(newImage, newImage, verticalKernal, new Point(-1, -1));
                    return newImage;
                }
            });

            // Gaussain Blur
            ImageOperations.Add(OperationList.GaussianBlur, new Operation() {
                OperationName = "Gaussian Blur",
                Operate = (image, args) => image.SmoothGaussian((int)args[0])
            });

            // Basic
            ImageOperations.Add(OperationList.Basic, new Operation() {
                OperationName = "Basic Image Operation",
                Operate = (image, args) => {
                    // Brightness

                    if (args[0] != 0) {
                        Image<Gray, byte>[] splitted = image.Convert<Hsv, byte>().Split();
                        double brightnessFactor = args[0];
                        splitted[2] += brightnessFactor;
                        image = new Image<Hsv, byte>(splitted).Convert<Bgr, byte>();
                    }

                    // Contrast
                    if(args[1] != 0) {
                        double contrastFactor = (259 * (args[1] + 255)) / (255 * (259 - args[1]));
                        Image<Gray, byte>[] splittedBgr = image.Split();
                        byte result;
                        for (int i = 0; i < image.Height; i++) {
                            for (int j = 0; j < image.Width; j++) {
                                for (int k = 0; k < 3; k++) {
                                    double color = splittedBgr[k].Data[i, j, 0];
                                    color = (contrastFactor * (color - 128) + 128);
                                    if (color < 0) result = 0;
                                    else if (color > 255) result = 255;
                                    else result = (byte)(color);
                                    splittedBgr[k].Data[i, j, 0] = result;
                                }
                            }
                        }
                        image = new Image<Bgr, byte>(splittedBgr);
                    }

                    // Sharpness
                    if(args[2] != 0) {
                        Image<Bgr, byte> newImage = image.Copy();
                        float[,] sharpnessKernel = {
                            {0, -0.1f, 0 },
                            {-0.1f, 1.4f, -0.1f },
                            {0, -0.1f, 0 },
                        };
                        for (int i = 0; i < args[2]; i++) {
                            CvInvoke.Filter2D(newImage, newImage, new ConvolutionKernelF(sharpnessKernel), new Point(-1, -1));
                        }
                        image = newImage;

                    }
                    return image;
                }
            });

            ImageOperations.Add(OperationList.EdgeDetection, new Operation() {
                OperationName = "Edge Detection",
                Operate = (image, args) => {
                    if (args[0] != 0) {
                        Image<Bgr, byte> newImage = image.Copy();
                        float[,] edgeKernel = {
                            {-0.5f, -0.5f, -0.5f },
                            {-0.5f,     4, -0.5f },
                            {-0.5f, -0.5f, -0.5f },
                        };
                        CvInvoke.Filter2D(newImage, newImage, new ConvolutionKernelF(edgeKernel) * System.Convert.ToInt32(args[0]), new Point(-1, -1));
                        image = newImage;
                    }
                    return image;
                }
            });

            ImageOperations.Add(OperationList.Emboss, new Operation() {
                OperationName = "Emboss",
                Operate = (image, args) => {
                    Image<Bgr, byte> newImage = image.Copy();
                    float[,] embossKernel = {
                        {-2, -1, 0 },
                        {-1,  1, 1 },
                        { 0,  1, 2 }
                    };
                    CvInvoke.Filter2D(newImage, newImage, new ConvolutionKernelF(embossKernel), new Point(-1, -1));
                    image = newImage;
                    return image;
                }
            });

            ImageOperations.Add(OperationList.TopSobel, new Operation() {
                OperationName = "Top Sobel",
                Operate = (image, args) => {
                    Image<Bgr, byte> newImage = image.Copy();
                    float[,] topSobelKernel = {
                        { 1,  2,  1 },
                        { 0,  0,  0 },
                        {-1, -2, -1 }
                    };
                    CvInvoke.Filter2D(newImage, newImage, new ConvolutionKernelF(topSobelKernel), new Point(-1, -1));
                    image = newImage;
                    return image;
                }
            });

            ImageOperations.Add(OperationList.BottomSobel, new Operation() {
                OperationName = "Bottom Sobel",
                Operate = (image, args) => {
                    Image<Bgr, byte> newImage = image.Copy();
                    float[,] bottomSobelKernel = {
                        {-1, -2, -1 },
                        { 0,  0,  0 },
                        { 1,  2,  1 }
                    };
                    CvInvoke.Filter2D(newImage, newImage, new ConvolutionKernelF(bottomSobelKernel), new Point(-1, -1));
                    image = newImage;
                    return image;
                }
            });

            ImageOperations.Add(OperationList.LeftSobel, new Operation() {
                OperationName = "Left Sobel",
                Operate = (image, args) => {
                    Image<Bgr, byte> newImage = image.Copy();
                    float[,] leftSobelKernel = {
                        { 1,  0, -1 },
                        { 2,  0, -2 },
                        { 1,  0, -1 }
                    };
                    CvInvoke.Filter2D(newImage, newImage, new ConvolutionKernelF(leftSobelKernel), new Point(-1, -1));
                    image = newImage;
                    return image;
                }
            });

            ImageOperations.Add(OperationList.RightSobel, new Operation() {
                OperationName = "Right Sobel",
                Operate = (image, args) => {
                    Image<Bgr, byte> newImage = image.Copy();
                    float[,] rightSobelKernel = {
                        {-1,  0, 1 },
                        {-2,  0, 2 },
                        {-1,  0, 1 }
                    };
                    CvInvoke.Filter2D(newImage, newImage, new ConvolutionKernelF(rightSobelKernel), new Point(-1, -1));
                    image = newImage;
                    return image;
                }
            });

            ImageOperations.Add(OperationList.Resize, new Operation() {
                OperationName = "Resize Image",
                Operate = (image, args) => {
                    return image.Resize((int)args[0], (int)args[1], Emgu.CV.CvEnum.Inter.Cubic);
                }
            });

            ImageOperations.Add(OperationList.Scale, new Operation() {
                OperationName = "Scale",
                Operate = (image, args) => {
                    double scale = System.Convert.ToDouble(args[0]) / 100;
                    return image.Resize(scale, Emgu.CV.CvEnum.Inter.Cubic);
                }
            });

            ImageOperations.Add(OperationList.Crop, new Operation() {
                OperationName = "Crop Image",
                Operate = (image, args) => {
                    return image.Copy(new Rectangle((int)args[0], (int)args[1], (int)args[2], (int)args[3]));
                }
            });
        }
    }
}
