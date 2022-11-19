using ScottPlot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;

using Microsoft.Win32;



namespace GraphEdu.Pages
{
    /// <summary>
    /// Interaction logic for FigureMoving.xaml
    /// </summary>
    public partial class FigureMoving : Page
    {
       
        public FigureMoving()
        {
            InitializeComponent();
            triangle = new Polygon();
            triangle.Stroke = System.Windows.Media.Brushes.Black;
            triangle.Fill = System.Windows.Media.Brushes.LightSeaGreen;
            triangle.StrokeThickness = 2;
            APoint = new TextBlock() { Text="A"};
            BPoint = new TextBlock() { Text = "B" };
            CPoint = new TextBlock() { Text = "C" };
            
            TriangleMatrix = new double[3, 3] { {1,1,1 },{1,1,1 },{ 1,1,1} };
            MovingMatrix = new double[3, 3] { {1,0,1 },{0,1,0 },{0.1,0.1,1 } };
            ZoomMatrix = new double[3, 3];
            ZoomMatrix[2, 2] = 1;

        }
        public MainWindow parentWindow;
        public void TutorialClick(object sender, MouseButtonEventArgs e)
        {
            parentWindow.TutorialClick(null, null);
        }
        double[,] TriangleMatrix;
        double[,] MovingMatrix;
        double[,] ZoomMatrix;
        double scaling = 5;
        int amountMove = 50;
        int curAmountMove = 0;
        double lineWidth = 20;
        double TextPerPoint = 5;
        Polygon triangle;
        public bool moving = false;
        bool Up = true;
        System.Timers.Timer timer;
        Point A, B, C;
        TextBlock APoint, BPoint,CPoint;
        double ZeroPointX, ZeroPointY;
        Point startMovePos;
        int firstX, firstY;
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // for .NET Core you need to add UseShellExecute = true
            // see https://docs.microsoft.com/dotnet/api/system.diagnostics.processstartinfo.useshellexecute#property-value
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
        void PointToMatrix()
        {
            PointToMatrxRow(0, A);
            PointToMatrxRow(1, B);
            PointToMatrxRow(2, C);
        }
       void MatrixToPoint()
        {
            MatrixToPointRow(0, ref A);
            MatrixToPointRow(1, ref B);
            MatrixToPointRow(2,ref C);
        }
        void MatrixToPointRow(int index, ref Point point)
        {
            point.X = TriangleMatrix[index, 0];
            point.Y = TriangleMatrix[index, 1];
        }
        void updateZoomMatrix(double ZoomVal)
        {
            ZoomMatrix[0,0] = ZoomVal;
            ZoomMatrix[1,1] = ZoomVal;
            ZoomMatrix[2, 2] = ZoomVal;
        }
        
        void PointToMatrxRow(int index, in Point point)
        {
            TriangleMatrix[index,0] = point.X;
            TriangleMatrix[index, 1] = point.Y;

        }
        void SaveImage(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            
            save.Title = "Save picture as ";
            save.Filter = "Image Files(*.png; *.jpg; *.jpeg; *.gif; *.bmp)|*.png; *.jpg; *.jpeg; *.gif; *.bmp";
            save.DefaultExt = ".png";
            if (CanvaElement != null)
            {
                if (save.ShowDialog() == true)
                {
                    Size size = new Size(Width, Height);
                    CanvaElement.Measure(size);

                    var rtb = new RenderTargetBitmap(
                        (int)Width, //width
                        (int)Height, //height
                        96, //dpi x
                        96, //dpi y
                        PixelFormats.Pbgra32 // pixelformat
                        );
                    rtb.Render(CanvaElement);

                    var enc = new System.Windows.Media.Imaging.PngBitmapEncoder();
                    enc.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(rtb));

                    using (var stm = System.IO.File.Create(save.FileName))
                    {
                        enc.Save(stm);
                    }
                }
            }
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
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (moving)
            {
                moving = false;
                but.Content = "Start";
                timer.Elapsed-= new ElapsedEventHandler(DrawOnCanva);
                timer.Stop();
                timer.Dispose();
            }
            else
            {
                moving = true;
                but.Content = "Stop";
                timer = new System.Timers.Timer();
                timer.Interval = 100;
                timer.Enabled = true;
                timer.AutoReset = true;
                curAmountMove = 0;
                scaling = ScalingFactor.Value??1;

                retrievePoint();
                if (!CheckInput())
                {
                    (new WarningWindow()).ShowDialog();
                    return;
                }
                WarningText.Visibility = Visibility.Hidden;
                triangle.Points[0] = GetPointInCanva(A);
                triangle.Points[1] = GetPointInCanva(B);
                triangle.Points[2] = GetPointInCanva(C);
                SetLetterPoint(triangle.Points[0], APoint);
                SetLetterPoint(triangle.Points[1], BPoint);
                SetLetterPoint(triangle.Points[2], CPoint);

                Up = true;
                updateMovingMatrix(0.1);
                updateZoomMatrix( Math.Pow(scaling,1.0/amountMove));
                
                timer.Elapsed += new ElapsedEventHandler(DrawOnCanva);
                timer.Start();
            }
        }

        bool CheckInput()
        {
            double oneSide = Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
            double secondSide = Math.Sqrt(Math.Pow(B.X - C.X, 2) + Math.Pow(B.Y - C.Y, 2));
            double third = Math.Sqrt(Math.Pow(C.X - A.X, 2) + Math.Pow(C.Y - A.Y, 2));

            if(oneSide+secondSide>third&&
                secondSide+third>oneSide
                &&third+oneSide>secondSide)
                return true;
            return false;
        }
        void retrievePoint()
        {
            A.X = X1DoubleBox.Value ?? triangle.Points[0].X;
            A.Y = Y1DoubleBox.Value ?? triangle.Points[0].Y;
            B.X = X2DoubleBox.Value ?? triangle.Points[1].X;
            B.Y = Y2DoubleBox.Value ?? triangle.Points[1].Y;
            C.X = X3DoubleBox.Value ?? triangle.Points[2].X;
            C.Y = Y3DoubleBox.Value ?? triangle.Points[2].Y;
        }
        
        void DrawOnCanva (object arg, ElapsedEventArgs a)
        {

            if (!triangle.Dispatcher.CheckAccess())
            {
                triangle.Dispatcher.Invoke(updateCanva);
            }
        }
        void ZoomIn(object sender, EventArgs e)
        {
            lineWidth *= 1.2;
            TextPerPoint /= 1.2;
            CanvaElement.Children.Clear();
            PageLoaded(null, null);
        }

        void ZoomOut(object sender, EventArgs e)
        {
            CanvaElement.Children.Clear();
            lineWidth /= 1.2;
            TextPerPoint *= 1.2;
            PageLoaded(null, null);
        }

        Point FromCanvaPoint(in Point point)
        {
            var retPoint = new Point();

            retPoint.X = point.X / lineWidth + firstX;
            retPoint.Y = firstY- point.Y / lineWidth;
            return retPoint;
        }
        Point GetPointInCanva(double x, double y)
        {
            return new Point((x - firstX) * lineWidth, (firstY - y) * lineWidth);
        }
        Point GetPointInCanva(in Point point)
        {
            return GetPointInCanva(point.X, point.Y);
        }
        double[,] MultipleMatrix(double[,]firstMatrix, double[,]secondMatrix)
        {
            
            int rows = firstMatrix.GetLength(0); ;
            int cols = firstMatrix.GetLength(1);
            double[,] newTriangleMatrix = new double[rows, cols];
            double mulValue;
            for( int i=0;i< rows; ++i)
            {
                for( int j = 0; j < cols; ++j)
                {
                    mulValue = 0;
                    for (int k = 0; k < cols; ++k)
                    {
                        mulValue += firstMatrix[i, k] * secondMatrix[k, j];

                    }
                    newTriangleMatrix[i, j] = mulValue;
                }
            }
            for (int i = 0; i < rows; ++i)
            {
                newTriangleMatrix[i, cols - 1] = 1;
            }
                return newTriangleMatrix;
        }

        void UpdateZoomMatrix(ref double[,] matrix)
        {
            matrix[0, 0] = 1/ matrix[0, 0];
            matrix[1, 1] = 1/ matrix[1, 1];
            matrix[2, 2] = 1/ matrix[2, 2];
        }

       void updateMovingMatrix(double val)
        {
            MovingMatrix[2, 0] = MovingMatrix[2, 1] = val;
        }

        bool checkBoundaryPointsUp(in Point point)
        {
            if(point.X<=1|| point.Y <= 1)
                return false;
            return true;
        }

        bool checkBoundaryPointsDown(in Point point)
        {
            if (point.X >= CanvaElement.ActualWidth-1 || point.Y >= CanvaElement.ActualHeight-1)
                return false;
            return true;
        }
        void updateCanva()
        {
            A = FromCanvaPoint(triangle.Points[0]);
            B = FromCanvaPoint(triangle.Points[1]);
            C = FromCanvaPoint(triangle.Points[2]);
            PointToMatrix();
            if (curAmountMove == amountMove||!checkBoundaryPointsUp(triangle.Points[0])
                || !checkBoundaryPointsUp(triangle.Points[1])
                || !checkBoundaryPointsUp(triangle.Points[2]))
            { Up = false; UpdateZoomMatrix(ref ZoomMatrix); updateMovingMatrix(-0.1); }

            //TriangleMatrix =MultipleMatrix(TriangleMatrix, ZoomMatrix);

            //TriangleMatrix = MultipleMatrix(TriangleMatrix, MovingMatrix);
            TriangleMatrix = MultipleMatrix(TriangleMatrix, MultipleMatrix(MovingMatrix, ZoomMatrix));
            if (Up)
            {               
                curAmountMove++;
            } else
            {
                curAmountMove--;
                if (curAmountMove <= 0 || !checkBoundaryPointsDown(triangle.Points[0])
                || !checkBoundaryPointsDown(triangle.Points[1])
                || !checkBoundaryPointsDown(triangle.Points[2])) 
                { Up = true; UpdateZoomMatrix(ref ZoomMatrix); updateMovingMatrix(0.1); }
              
            }
            MatrixToPoint();
            Point point = GetPointInCanva(A);
            triangle.Points[0] = new System.Windows.Point(point.X, point.Y);
            point = GetPointInCanva(B);

            triangle.Points[1] = new System.Windows.Point(point.X, point.Y);
            point = GetPointInCanva(C);
            triangle.Points[2] = new System.Windows.Point(point.X, point.Y);

            SetLetterPoint(triangle.Points[0], APoint);
            SetLetterPoint(triangle.Points[1], BPoint);
            SetLetterPoint(triangle.Points[2], CPoint);
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            CanvaElement.Children.Clear();
            but.Content = "Start";
            var height = CanvaElement.ActualHeight;
            var width = CanvaElement.ActualWidth;
            ZeroPointX = width / 2;
            ZeroPointY = height / 2;
            DrawVertivalLine(width, height);
            DrawHorizontalLine(width, height);

            retrievePoint();
            System.Windows.Point Point1 = GetPointInCanva(A);
            System.Windows.Point Point2 = GetPointInCanva(B);
            System.Windows.Point Point3 = GetPointInCanva(C);
            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);

            triangle.Points = myPointCollection;


            CanvaElement.Children.Add(triangle);

            CanvaElement.Children.Add(APoint);
            CanvaElement.Children.Add(BPoint);
            CanvaElement.Children.Add(CPoint);
            SetLetterPoint(triangle.Points[0], APoint);
            SetLetterPoint(triangle.Points[1], BPoint);
            SetLetterPoint(triangle.Points[2], CPoint);




        }
       
        void CanvaMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                startMovePos = e.GetPosition(CanvaElement);
                DragDrop.DoDragDrop(CanvaElement, CanvaElement, DragDropEffects.Move);
            }
        }
        void CanvaMouseDrop(object sender, DragEventArgs e)
        {
            Point dropPosition = e.GetPosition(CanvaElement);
            var diffX = dropPosition.X - startMovePos.X;
            var diffY = dropPosition.Y - startMovePos.Y;
            var height = CanvaElement.ActualHeight;
            var width = CanvaElement.ActualWidth;
            ZeroPointX -= diffX;
            ZeroPointY -= diffY;
            CanvaElement.Children.Clear();
            DrawVertivalLine(width, height);
            DrawHorizontalLine(width, height);
            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(GetPointInCanva(A));
            myPointCollection.Add(GetPointInCanva(B));
            myPointCollection.Add(GetPointInCanva(C));
            triangle.Points = myPointCollection;
            CanvaElement.Children.Add(triangle);

            CanvaElement.Children.Add(APoint);
            CanvaElement.Children.Add(BPoint);
            CanvaElement.Children.Add(CPoint);
            SetLetterPoint(triangle.Points[0], APoint);
            SetLetterPoint(triangle.Points[1], BPoint);
            SetLetterPoint(triangle.Points[2], CPoint);

        }
        void DrawVertivalLine(double width, double height)
        {
            int startX = (int)((ZeroPointX- width) / lineWidth);
            firstX = startX;
                 
            for(double i =0; i < width; i+= lineWidth)
            {
                Line myLine = new Line()
                {
                    X1 = i,
                    X2 = i,
                    Y1 = 0,
                    Y2 = height,
                    Stroke = System.Windows.Media.Brushes.Black,
                    StrokeThickness = 1
                };

                if (startX == 0)
                    myLine.StrokeThickness = 3;
                CanvaElement.Children.Add(myLine);

                if ((int)TextPerPoint != 0 && i > 0 && startX % (int)TextPerPoint == 0)
                {
                    Text(i, height- ZeroPointY, startX.ToString(), System.Windows.Media.Colors.Black);
                }
                ++startX;
            }
        }

        void DrawHorizontalLine(double width, double height)
        {
            int startY = (int)(( height- ZeroPointY) / lineWidth);
            firstY = startY; 
            for (double i = 0; i < height; i += lineWidth)
            {
                Line myLine = new Line()
                {
                    X1 = 0,
                    X2 = width,
                    Y1 = i,
                    Y2 = i,
                    Stroke = System.Windows.Media.Brushes.Black,
                    StrokeThickness = 1
                };

                if (startY == 0)
                {
                    myLine.StrokeThickness = 3;
                    CanvaElement.Children.Add(myLine);
                    --startY;
                    continue;
                }
                
                CanvaElement.Children.Add(myLine);

                if ((int)TextPerPoint != 0 && i > 0 && startY % (int)TextPerPoint == 0)
                {
                    Text(width- ZeroPointX, i, startY.ToString(), System.Windows.Media.Colors.Black);
                }
                --startY;
            }
        }
        private void Text(double x, double y, string text, Color color)
        {

            TextBlock textBlock = new TextBlock();

            textBlock.Text = text;

            textBlock.Foreground = new SolidColorBrush(color);

            Canvas.SetLeft(textBlock, x);

            Canvas.SetTop(textBlock, y);

            CanvaElement.Children.Add(textBlock);

        }
        void SetLetterPoint(in System.Windows.Point point, TextBlock text)
        {
            text.Foreground = new SolidColorBrush(System.Windows.Media.Colors.Black);

            Canvas.SetLeft(text, point.X);

            Canvas.SetTop(text, point.Y);
        }


    }
}
