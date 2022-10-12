using GraphEdu.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphEdu
{
    /// <summary>
    /// Interaction logic for Fractals.xaml
    /// </summary>
    public partial class Fractals : Page
    {
        double curentZoom = 1,
            centerXMul=1,centerYMul=1;
        Color color1,color2,color3;

        WriteableBitmap writeableBitmap;
        public Fractals()
        {
            InitializeComponent();
            DataContext = new FractalsViewModel();
            color1 = ColorPicker1.Color;
            color2 = ColorPicker2.Color;
            color3 = ColorPicker3.Color;
            writeableBitmap = BitmapFactory.New((int)FractalImage.Width, (int)FractalImage.Height);
           DrawFractal(FractalImage, color1, color2, color3, curentZoom);
        }
        void DrawFractal(in Image image,  Color color1,  Color color2,  Color color3,double zoom=1, int maxIteration = 50,double centerXMul=1, double centerYMul=1) 
        {

            int  curIteration = 0;

            Complex pointComplex;
            writeableBitmap.Clear();
            
            Color color = new Color();
            color.A = 255;

            int width = (int)image.Width,
                height = (int)image.Height;
            double w = 8*zoom;
            double h = w * height / width;
            double xmin = -w / 2*centerXMul;
            double ymin = -h / 2* centerYMul;
            double x, y = ymin;
            double dx = image.Height / image.Width, dy = image.Width / image.Height;


            double xmax = xmin + w, ymax = ymin + h;
            dx = (xmax - xmin) / image.Width;
            dy = (ymax - ymin) / image.Height;
            for (int i = 0; i < height; ++i, y += dy)
            {
                x = xmin;
                for (int j = 0; j < width; ++j, x += dx)
                {
                    pointComplex = new Complex(x, y);
                    curIteration = 0;
                    while (curIteration < maxIteration)
                    {
                        pointComplex = pointComplex * pointComplex.Sin();

                        if (pointComplex.Imagine * pointComplex.Real > 20 || pointComplex.IsInfinity())
                        {
                            break;
                        }
                        ++curIteration;
                    }
                    PointColor(ref color, curIteration, maxIteration,color1,color2,color3);

                    writeableBitmap.SetPixel(j, i, color);
                    
                }
            }

            image.Source = writeableBitmap;
        }
        
        void ZoomInImage(object sender, EventArgs e)
        {
            curentZoom *= 0.8;
            DrawFractal(FractalImage, color1, color2, color3, zoom:curentZoom, centerXMul: centerXMul, centerYMul: centerYMul);
        }
        void ZoomOutImage(object sender, EventArgs e)
        {
            curentZoom *=1.25;
            DrawFractal(FractalImage, color1, color2, color3, zoom: curentZoom, centerXMul: centerXMul, centerYMul: centerYMul);
        }
        void SaveFractal(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Save picture as ";
            save.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (FractalImage != null)
            {
                if (save.ShowDialog() == true)
                {
                    JpegBitmapEncoder jpg = new JpegBitmapEncoder();
                    jpg.Frames.Add(BitmapFrame.Create(writeableBitmap));
                    using (Stream stm = File.Create(save.FileName))
                    {
                        jpg.Save(stm);
                    }
                }
            }
        }
        void ApplyColor(object sender, RoutedEventArgs e)
        {
            color1 = ColorPicker1.Color;
            color2 = ColorPicker2.Color;
            color3 = ColorPicker3.Color;
            PopupPaint.IsOpen = false;
            DrawFractal(FractalImage, color1, color2, color3, curentZoom, centerXMul: centerXMul, centerYMul: centerYMul);
        }
        void PointColor(ref Color color, int curIteration, int maxIteration,
            Color color1,Color color2,Color color3)
        {
            if (curIteration == maxIteration)
            {
                color.B = color.G = color.R = 0;//чорний
            }
            else
            {
                if (curIteration < 1)
                {
                    color.B = 0;
                    color.G = 0;
                    color.R = 255;//червоний
                }
                else if (curIteration < 2)
                {
                    color.B = 0;
                    color.G = 146;
                    color.R = 239;//оранжевий
                }
                else if (curIteration < 4)
                {
                    //color.B = 1;
                    //color.G = 227;
                    //color.R = 248;//жовтий
                    color = color3;
                }
                else if (curIteration < 5)
                {
                    color.B = 177;
                    color.G = 51;
                    color.R = 21;// яскраво темно синій 
                }
                else if (curIteration < 6)
                {
                    //color.B = 238;
                    //color.G = 59;
                    //color.R = 243;// яскраво фіолетоий фуксія
                    color = color2;
                }
                else if (curIteration < 8)
                {
                    color.B = 177;
                    color.G = 131;
                    color.R = 91;//брудно синій
                }
                else if (curIteration < 10)
                {
                    color.B = 189;
                    color.G = 159;
                    color.R = 182;//ніжно фіолетовий
                }
                else if (curIteration < 70)
                {
                    //color.B = 0;
                    //color.G = 255;//green
                    //color.R = 0;
                    color = color1;
                }
                else
                {
                    color.B = color.G = color.R = 255;
                }

            }
            color.A = 255;
        }
        Point startMovePos;
        void FractalImageMouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                startMovePos = e.GetPosition(FractalImage);
                DragDrop.DoDragDrop(FractalImage, FractalImage, DragDropEffects.Move);
            }
        }
        void FractalImageMouseDrop(object sender, DragEventArgs e)
        {
            Point dropPosition = e.GetPosition(FractalImage);
            centerXMul +=2*(dropPosition.X -startMovePos.X)/FractalImage.Width;
            centerYMul +=2* (dropPosition.Y - startMovePos.Y)/FractalImage.Height;
            DrawFractal(FractalImage, ColorPicker1.Color, ColorPicker2.Color, ColorPicker3.Color,
                zoom:curentZoom, centerXMul:centerXMul,centerYMul: centerYMul);
        }
     
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // for .NET Core you need to add UseShellExecute = true
            // see https://docs.microsoft.com/dotnet/api/system.diagnostics.processstartinfo.useshellexecute#property-value
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
      
       
     
        private void PopupPaintControl(object sender, RoutedEventArgs e)
        {
            if (PopupPaint.IsOpen)
                PopupPaint.IsOpen = false;
            else
                PopupPaint.IsOpen = true;
        }
   
        private void Question_MouseLeave(object sender, MouseEventArgs e)
        {
            if (popupQuestion.IsOpen)
                popupQuestion.IsOpen = false;
            else
                popupQuestion.IsOpen = true;
        }
        private void Question_MouseEnter(object sender, MouseEventArgs e)
        {
            if (popupQuestion.IsOpen)
                popupQuestion.IsOpen = false;
            else
                popupQuestion.IsOpen = true;
            
        }
    }
}
