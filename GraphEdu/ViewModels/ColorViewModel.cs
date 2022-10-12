using lab2.ViewModels;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using ColorHelper;
using System.Windows;

namespace GraphEdu.ViewModels
{
    public class ColorViewModel: ViewModelBase
    {
        public lab2.Commands.Command CommandPopup { get; set; }
        public lab2.Commands.Command DownloadImageCommand { get; set; }
        public lab2.Commands.Command UploadImageCommand { get; set; }
        public ImageSource ImageSource { get; set; }
        public WriteableBitmap WriteableBitmap { get; set; }
        public ColorViewModel()
        {
            CommandPopup = new lab2.Commands.Command(ManagePopup);

            UploadImageCommand = new lab2.Commands.Command(UploadImage);
           

        }
        string colorInHSL;
        public string ColorInHSL
        {
            get { return colorInHSL; }
            set
            {
                colorInHSL = value;
                OnPropertyChanged("ColorInHSL");
            }
        }
        string colorInCMYK;
        public string ColorInCMYK
        {
            get { return colorInCMYK; }
            set
            {
                colorInCMYK = value;
                OnPropertyChanged("ColorInCMYK");
            }
        }
       
        public string Red { get; set; }
        public string Green { get; set; }
        public string Blue { get; set; }
        
        public string Cian { get; set; }
        public string Magenta { get; set; }
        public string Yellow { get; set; }
        public string Black { get; set; }

        private double mousePosX;
        private double mousePosY;

        public int Heigth { get; set; }
        public int Width { get; set; }

        public double MousePosX
        {
            get { return mousePosX; }
            set
            {
                if (value.Equals(mousePosX)) return;
                mousePosX = value;
               // changeColor();
                OnPropertyChanged("MousePosX");
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
            }
        }

        public double MousePosY
        {
            get { return mousePosY; }
            set
            {
                if (value.Equals(mousePosY)) return;
                mousePosY = value;
               // changeColor();
                OnPropertyChanged("MousePosY");
            }
        }
        void UploadImage(object args)
        {
            
            
            Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog();
            open.Title = "Open Picture";
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            if (open.ShowDialog() == true)
            {
                try
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(open.FileName));

                    WriteableBitmap = BitmapFactory.New((int)bitmap.Width, (int)bitmap.Height);
                    ImageSource img = bitmap;
                    
                    int stride = bitmap.PixelWidth * 4;
                    int size = bitmap.PixelHeight * stride;
                    byte[] pixels = new byte[size];
                    bitmap.CopyPixels(pixels, stride, 0);
                    byte red, green,blue, alpha;
                    int index = 0;
                    for (int i = 0; i < img.Height; ++i)
                    {
                        for (int j = 0; j < img.Width; ++j)
                        {
                            index = i * stride + 4 * j;
                             red = pixels[index+2];
                             green = pixels[index +1];
                             blue = pixels[index ];
                             alpha = pixels[index + 3];
                            WriteableBitmap.SetPixel(j, i, red, green, blue);
                        }
                    }
                    OnPropertyChanged(nameof(WriteableBitmap));
                    ImageSource = bitmap;
                    OnPropertyChanged(nameof(ImageSource));


                }
                catch (System.Exception c) { 
                    Console.Write("Exception" + c); }
                
            }
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
