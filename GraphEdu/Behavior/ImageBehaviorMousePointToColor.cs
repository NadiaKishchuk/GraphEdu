using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GraphEdu.Behavior
{
    internal class ImageBehaviorMousePointToColor:Behavior<Image>
    {
        
            public static readonly DependencyProperty SelectedColorProperty =
                DependencyProperty.Register("SelectedColor", typeof(Color),
                                            typeof(ImageBehaviorMousePointToColor),
                                            new UIPropertyMetadata(new Color()));


            public Color SelectedColor
            {
                get { return (Color)GetValue(SelectedColorProperty); }
                set { SetValue(SelectedColorProperty, value); }
            }


            protected override void OnAttached()
            {
                base.OnAttached();

                AssociatedObject.MouseMove += AssociatedObject_MouseMove;
            }

            protected override void OnDetaching()
            {
                base.OnDetaching();

                AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
            }

           

            private void AssociatedObject_MouseMove(object sender, MouseEventArgs e)
            {
               
                    SamplePixelForColor();
                
            }

        private void SamplePixelForColor()
        {
            Point point = Mouse.GetPosition(AssociatedObject);
            BitmapSource bitmapSource = (BitmapSource)AssociatedObject.Source;
            var color = new Color();
            int stride =bitmapSource.PixelWidth * 4;
            int size = bitmapSource.PixelHeight * stride;
            byte[] pixels = new byte[size];
            bitmapSource.CopyPixels(pixels, stride, 0);
            int index = ((int)(point.Y* bitmapSource.PixelWidth / AssociatedObject.ActualWidth))
                * stride + ((int)(point.X* bitmapSource.Height/AssociatedObject.ActualHeight)) * 4;
            color.R = pixels[index + 2];
            color.G = pixels[index + 1];
            color.B = pixels[index];
            color.A = pixels[index + 3];
            SelectedColor = color; 

            
            
            

        }

    }
}
