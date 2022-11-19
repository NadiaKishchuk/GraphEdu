using lab2.ViewModels;

using System;

using System.Drawing;
using System.Linq;

using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.IO;
using System.IO.Compression;
using System.Windows.Input;

namespace GraphEdu.ViewModels
{
    public class ColorViewModel: ViewModelBase
    {
        public lab2.Commands.Command CommandPopup { get; set; }
        public lab2.Commands.Command DownloadImageCommand { get; set; }
        public lab2.Commands.Command UploadImageCommand { get; set; }
        public ImageSource ImageSourceHSL { get; set; }
        public ImageSource ImageSourceCMYK { get; set; }
        public WriteableBitmap WriteableBitmapHSL { get; set; }
        public WriteableBitmap WriteableBitmapCMYK { get; set; }
        public lab2.Commands.Command ChangeSaturationYellow { get; set; }

        public lab2.Commands.Command TutorialClick { get; set; }
        public MainWindow parentWindow;
        public ColorViewModel()
        {
            CommandPopup = new lab2.Commands.Command(ManagePopup);
            ChangeSaturationYellow = new lab2.Commands.Command(ChangeYellowSaturation);
            UploadImageCommand = new lab2.Commands.Command(UploadImage);
            TutorialClick = new lab2.Commands.Command((x) => parentWindow.TutorialClick(null, null));


        }
      
        public double Hue { get; set; }
        public double Saturation { get; set; }
        public double Lightness { get; set; }
        
        public double Cian { get; set; }
        public double Magenta { get; set; }
        public double Yellow { get; set; }
        public double Black { get; set; }
   
        void DownloadImage(object args)
        {
            System.Windows.Controls.Image image =args as System.Windows.Controls.Image;

            if (image != null)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Title = "Save picture as ";
                save.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (save.ShowDialog() == true)
                {
                    JpegBitmapEncoder jpg = new JpegBitmapEncoder();
                    jpg.Frames.Add(BitmapFrame.Create(WriteableBitmapCMYK));
                    using (Stream stm = File.Create(save.FileName))
                    {
                        jpg.Save(stm);
                    }
                }
            }
        }
        private System.Windows.Media.Color pixelColor;
        public System.Windows.Media.Color PixelColor
        {
            get { return pixelColor; }
            set
            {
                pixelColor = value;
                OnPropertyChanged("PixelColor");
                changeColors();

            }
        }
        private System.Windows.Media.Color pixelColorHSL;
        public System.Windows.Media.Color PixelColorHSL
        {
            get { return pixelColorHSL; }
            set
            {
                pixelColorHSL = value;
                OnPropertyChanged("PixelColorHSL");
            }
        }
        System.Windows.Media.Color pixelColorCMYK;
        public System.Windows.Media.Color PixelColorCMYK
        {
            get { return pixelColorHSL; }
            set
            {
                pixelColorHSL = value;
                OnPropertyChanged("PixelColorCMYK");
            }
        }
        void changeColors()
        {
            double H=1, S=1, L=1;
            FromRGBToHSL(PixelColor, ref H, ref S, ref L);
            Hue = H;
            Saturation = S;
            Lightness = L;
            FromHSLToRGB(ref pixelColorHSL,H,S,L);
            OnPropertyChanged(nameof(Hue));
            OnPropertyChanged(nameof(Saturation));
            OnPropertyChanged(nameof(Lightness));
            OnPropertyChanged(nameof(PixelColorHSL));

            double C = 1, M = 1, Y = 1, K = 1;
            FromRGBToCMYK(pixelColorHSL, ref C, ref M, ref Y, ref K);
            Cian = C*100;
            Magenta = M*100;
            Yellow = Y * 100;
            Black = K * 100;
            FromCMYKToRGB(ref pixelColorCMYK, C,M,Y,K);
            OnPropertyChanged(nameof(Cian));
            OnPropertyChanged(nameof(Magenta));
            OnPropertyChanged(nameof(Yellow));
            OnPropertyChanged(nameof(Black));
            OnPropertyChanged(nameof(PixelColorCMYK));
        }

        void FromRGBToCMYK(System.Windows.Media.Color color, ref double C, ref double M,
            ref double Y, ref double K)
        {
            double R = color.R / 255.0, G = color.G / 255.0, B = color.B / 255.0;
            double[] colors = new double[] { R, G, B };
            double max = colors.Max();
            K = 1 - max;
            C = (1 - R - K) / (1 - K);
            M = (1-G-K)/ (1 - K);
            Y = (1-B-K)/ (1 - K);
            checkNan(ref C);
            checkNan(ref M);
            checkNan(ref Y);

        }
        void checkNan(ref double val)
        {
            if (val== double.NaN)
                val = 0;
        }
        void FromCMYKToRGB(ref System.Windows.Media.Color color, double C, double M,
            double Y, double K)
        {
            
            color.R =(byte) (255 * (1 - C) * (1 - K));
            color.G = (byte)(255 * (1 - M) * (1 - K));
            color.B = (byte)(255 * (1 - Y) * (1 - K));
        }
        
        void FromHSLToRGB(ref System.Windows.Media.Color color, double H, double S, double L)
        {
            H %= 360;
            S /= 100;
            L /= 100;

            double C = (1 - Math.Abs(2 * L - 1)) * S;

            double X = C * (1 - Math.Abs((H / 60) % 2-1) );

            double m = L - C / 2;
            double R,G, B;
            if(H>=0 && H < 60)
            {
                R = C;G = X;B = 0;
            }else if (H >= 60 && H < 120)
            {
                R = X; G = C; B = 0;
            }
            else if (H >= 120 && H < 180)
            {
                R = 0; G = C; B = X;
            }
            else if (H >= 180 && H < 240)
            {
                R = 0; G = X; B = C;
            }
            else if (H >= 240 && H < 300)
            {
                R = X; G = 0; B = C;
            }
            else 
            {
                R = C; G = 0; B = X;
            }
            color.R = (byte)((R + m) * 255);
            color.G = (byte)((G + m) * 255);
            color.B = (byte)((B + m) * 255);
        }
        void FromRGBToHSL(in System.Windows.Media.Color color, ref double H, ref double S, ref double  L)
        {
            double R = color.R / 255.0, G = color.G / 255.0, B = color.B / 255.0;
            double [] colors = new double[] {R,G,B};
            double min = colors.Min();
            double max = colors.Max();
            if (max ==min)
                H = 0;
           
            else if (color.R > color.B && color.R > color.G && color.G>=color.B)
            {
                H = 60 * (G - B) / (max - min);
            }else if (color.R > color.B && color.R > color.G && color.G < color.B)
            {
                H = 60 * (G - B) / (max - min)+ 360;
            }else if (max == G)
            {
                H = 60 * (B - R) / (max - min) + 120;
            }
            else if (max == B)
            {
                H = 60 * (R - G) / (max - min) + 240;
            }

            L = (max + min) /2 ;
            if (L == 0||max ==min)
            {
                S = 0;
            }else if (L < 0.5)
            {
                S = (max - min)/(2*L);
            }else if (L >= 0.5)
            {
                S = (max - min) / (2-2 * L);
            }
            S *= 100;
            L *= 100;

        }
        void ConvertImage(BitmapImage bitmap)
        {
            WriteableBitmapHSL?.Clear();
            WriteableBitmapCMYK?.Clear();
            WriteableBitmapHSL = BitmapFactory.New((int)bitmap.PixelWidth, (int)bitmap.PixelHeight);
            WriteableBitmapCMYK = BitmapFactory.New((int)bitmap.PixelWidth, (int)bitmap.PixelHeight);
            int stride = bitmap.PixelWidth * 4;
            int size = bitmap.PixelHeight * stride;
            byte[] pixels = new byte[size];
            bitmap.CopyPixels(pixels, stride, 0);
            System.Windows.Media.Color color = new System.Windows.Media.Color();
            double H, S, L;
            S = H = L = 0;
            double C, M, Y, K;
            C = M = Y = K = 0;
            int index = 0;
            for (int i = 0; i < bitmap.PixelHeight; ++i)
            {
                for (int j = 0; j < bitmap.PixelWidth; ++j)
                {
                    index = i * stride + 4 * j;
                    color.R = pixels[index + 2];
                    color.G = pixels[index + 1];
                    color.B = pixels[index];
                    color.A = pixels[index + 3];

                    FromRGBToHSL(in color, ref H, ref S, ref L);
                    FromHSLToRGB(ref color, H, S, L);
                    WriteableBitmapHSL.SetPixel(j, i,color);
                    FromRGBToCMYK(color, ref C, ref M, ref Y, ref K);
                    FromCMYKToRGB(ref color, C, M, Y, K);
                    WriteableBitmapCMYK.SetPixel(j, i, color);
                }
            }
            ImageSourceHSL = WriteableBitmapHSL;
            ImageSourceCMYK = WriteableBitmapCMYK;
            OnPropertyChanged(nameof(ImageSourceHSL));
            OnPropertyChanged(nameof(WriteableBitmapCMYK));

        }
        int saturationValue;
        int SaturationValue {
            get => saturationValue;
            set { saturationValue = value;OnPropertyChanged("SaturationValue"); } 
        }
       
        void ChangeYellowSaturation(object arg)
        {
            if (WriteableBitmapHSL == null)
                return;
            System.Windows.Media.Color color;
            double h=1, s=1, l=1;
            double C, M, Y, K;
            C = M = Y = K = 0;
            double valueForSaturation= (double)arg;
            
            for (int i = 0; i < WriteableBitmapHSL.PixelHeight; ++i)
            {
                for (int j = 0; j < WriteableBitmapHSL.PixelWidth; ++j)
                {
                    color= WriteableBitmapHSL.GetPixel(j, i);
                    FromRGBToHSL(in color, ref h, ref s, ref l);
                    if (h>= 30&&h<=90) {
                        s += valueForSaturation;
                        if (s < 0)
                            s = 0;
                        if (s > 100)
                            s = 100;
                        FromHSLToRGB(ref color, h, s, l);
                        FromRGBToCMYK(color, ref C, ref M, ref Y, ref K);
                        FromCMYKToRGB(ref color, C, M, Y, K);
                        WriteableBitmapCMYK.SetPixel(j, i, color);
                    } 
                }
            }
            OnPropertyChanged(nameof(ImageSourceHSL));
        }
       
        void UploadImage(object args)
        {
            BitmapImage bitmap = UploadImage();
            if(bitmap != null)
            {
                OnPropertyChanged(nameof(ImageSource));
                
                ConvertImage(bitmap);
            }
        }
        BitmapImage UploadImage()
        {
            Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog();
            open.Title = "Open Picture";
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            BitmapImage bitmap = null;
            if (open.ShowDialog() == true)
            {
                try
                {
                    bitmap = new BitmapImage(new Uri(open.FileName)); 
                }
                catch (System.Exception c) { 
                    Console.Write("Exception" + c); 
                }
            }
            
            return bitmap;
        }
        void ManagePopup(object arg)
        {
            
            var popup =(System.Windows.Controls.Primitives.Popup) arg;
            if (popup.IsOpen)
            {
                popup.IsOpen = false;
            }else
                popup.IsOpen = true;
        }

    }
}
