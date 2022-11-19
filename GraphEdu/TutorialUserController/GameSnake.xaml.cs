using GraphEdu.Windows;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
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

namespace GraphEdu.TutorialUserController
{
    public class SnakePart
    {
        public UIElement UiElement { get; set; }

        public Point Position { get; set; }

        public bool IsHead { get; set; }
    }


    public partial class GameSnake : UserControl
    {
        public GameSnake()
        {
            InitializeComponent();
            gameTickTimer.Tick += GameTickTimer_Tick;
            Focus();
            Focusable = true;
            Visibility = Visibility.Visible;
            Keyboard.Focus(this);

        }
        List<string> informationTexts = new List<string>()
        {
            "Колір - це властивість матеріальних об'єктів, яка сприймається як усвідомлене зорове\r\nвідчуття та виникає в результаті дії на око потоків видимого електронно-магнітного випромінювання (з довжинами хвиль від 380 до 760 нм)",
            "Основними конструктивами векторного об’єкту є\r\n·        Шлях – це маршрут, що з'єднує початкову та кінцеву точку.\r\n·        Сегмент - окрема частина шляху, може бути як прямою, так і кривою лінією.\r\n·        Вузол - початкова або кінцева точка сегмента.",
            "Растрова модель представляє зображення у вигляді комбінації точок (пікселів), яким притаманні свій колір та яскравість і які певним чином розташовані у координатній сітці.",
            "Піксель (Pixel) – це скорочення, утворене від терміну Picture Element (англ.). Растром називають матрицю пікселів. Поняття матриці вказує на розміщення пікселів за координатами по горизонталі та вертикалі.",
            "На один піксел чорно-білого зображення відводиться 1 біт інформації - чорний та білий. Глибина кольору - 1 біт."
        };
        Image[] images = new Image[3]
        {
            new Image(){

                Width = SnakeSquareSize,
                Height = SnakeSquareSize,
                Source = new BitmapImage(
                new Uri("./../images/Foods/apple.png",UriKind.Relative))
             },
            new Image(){

                Width = SnakeSquareSize,
                Height = SnakeSquareSize,
                Source =  new BitmapImage(
                new Uri("./../images/Foods/carrot.png",UriKind.Relative))},
            new Image(){

                Width = SnakeSquareSize,
                Height = SnakeSquareSize,
                Source =  new BitmapImage(
                new Uri("./../images/Foods/pineapple.png", UriKind.Relative))}

        };
  
        const int SnakeStartLength = 3;
        const int SnakeStartSpeed = 400;
        const int SnakeSpeedThreshold = 100;
        const int SnakeSquareSize = 62;
        private int currentScore = 0;

        private SolidColorBrush snakeBodyBrush = Brushes.Yellow;
        private SolidColorBrush snakeHeadBrush = Brushes.YellowGreen;
        private List<SnakePart> snakeParts = new List<SnakePart>();
        private System.Windows.Threading.DispatcherTimer gameTickTimer = new System.Windows.Threading.DispatcherTimer();
        public enum SnakeDirection { Left, Right, Up, Down };
        private SnakeDirection snakeDirection = SnakeDirection.Right;
        private int snakeLength;
        private Random random = new Random();
        private UIElement snakeFood = null;
        private SolidColorBrush foodBrush = Brushes.Red;

        private void DrawSnakeFood()
        {
            Point foodPosition = GetNextFoodPosition();
            snakeFood = images[random.Next(0, 3)];
            GameArea.Children.Add(snakeFood);
            Canvas.SetTop(snakeFood, foodPosition.Y);
            Canvas.SetLeft(snakeFood, foodPosition.X);
        }
        private void EatSnakeFood()
        {
            snakeLength++;
            currentScore++;
            int timerInterval = Math.Max(SnakeSpeedThreshold, (int)gameTickTimer.Interval.TotalMilliseconds - (currentScore * 2));
            gameTickTimer.Interval = TimeSpan.FromMilliseconds(timerInterval);
            gameTickTimer.IsEnabled = false;
            new InformationWindow(informationTexts[random.Next(0, informationTexts.Count)]).ShowDialog();
            gameTickTimer.IsEnabled = true;
            GameArea.Children.Remove(snakeFood);
            DrawSnakeFood();
            UpdateGameStatus();
        }
        private void UpdateGameStatus()
        {
            this.tbStatusScore.Text = currentScore.ToString();
            this.tbStatusSpeed.Text = gameTickTimer.Interval.TotalMilliseconds.ToString();
        }
        private void EndGame()
        {
            gameTickTimer.IsEnabled = false;
            new InformationWindow("Оооу... Ти програв(((. Спробуй ще раз!!!", "Ok").ShowDialog();
            PlayButton.Visibility = Visibility.Visible;
        }

        void PlayButtonClicked(object sender, EventArgs e)
        {
            StartNewGame();
        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            Focus();
            Focusable = true;
            Visibility = Visibility.Visible;
            Keyboard.Focus(this);
            SnakeDirection originalSnakeDirection = snakeDirection;
            switch (e.Key)
            {
                case Key.Up:
                    if (snakeDirection != SnakeDirection.Down)
                        snakeDirection = SnakeDirection.Up;
                    break;
                case Key.Down:
                    if (snakeDirection != SnakeDirection.Up)
                        snakeDirection = SnakeDirection.Down;
                    break;
                case Key.Left:
                    if (snakeDirection != SnakeDirection.Right)
                        snakeDirection = SnakeDirection.Left;
                    break;
                case Key.Right:
                    if (snakeDirection != SnakeDirection.Left)
                        snakeDirection = SnakeDirection.Right;
                    break;
                case Key.Space:
                    StartNewGame();
                    break;
            }
            if (snakeDirection != originalSnakeDirection)
                MoveSnake();
        }
        private void DoCollisionCheck()
        {
            SnakePart snakeHead = snakeParts[snakeParts.Count - 1];

            if ((snakeHead.Position.X == Canvas.GetLeft(snakeFood)) && (snakeHead.Position.Y == Canvas.GetTop(snakeFood)))
            {
                EatSnakeFood();
                return;
            }

            if ((snakeHead.Position.Y < 0) || (snakeHead.Position.Y >= GameArea.ActualHeight) ||
            (snakeHead.Position.X < 0) || (snakeHead.Position.X >= GameArea.ActualWidth))
            {
                EndGame();
            }

            foreach (SnakePart snakeBodyPart in snakeParts.Take(snakeParts.Count - 1))
            {
                if ((snakeHead.Position.X == snakeBodyPart.Position.X) && (snakeHead.Position.Y == snakeBodyPart.Position.Y))
                    EndGame();
            }
        }
        private Point GetNextFoodPosition()
        {
            int maxX = (int)(GameArea.ActualWidth / SnakeSquareSize);
            int maxY = (int)(GameArea.ActualHeight / SnakeSquareSize);
            int foodX = random.Next(0, maxX) * SnakeSquareSize;
            int foodY = random.Next(0, maxY) * SnakeSquareSize;

            foreach (SnakePart snakePart in snakeParts)
            {
                if ((snakePart.Position.X == foodX) && (snakePart.Position.Y == foodY))
                    return GetNextFoodPosition();
            }

            return new Point(foodX, foodY);
        }

        private void StartNewGame()
        {
            PlayButton.Visibility = Visibility.Hidden;
            foreach (SnakePart snakeBodyPart in snakeParts)
            {
                if (snakeBodyPart.UiElement != null)
                    GameArea.Children.Remove(snakeBodyPart.UiElement);
            }
            snakeParts.Clear();
            if (snakeFood != null)
                GameArea.Children.Remove(snakeFood);

            // Reset stuff
            currentScore = 0;
            snakeLength = SnakeStartLength;
            snakeDirection = SnakeDirection.Right;
            snakeParts.Add(new SnakePart() { Position = new Point(SnakeSquareSize * 5, SnakeSquareSize * 5) });
            gameTickTimer.Interval = TimeSpan.FromMilliseconds(SnakeStartSpeed);

            // Draw the snake again and some new food...
            DrawSnake();
            DrawSnakeFood();

            // Update status
            UpdateGameStatus();

            // Go!        
            gameTickTimer.IsEnabled = true;
        }
        private void GameTickTimer_Tick(object sender, EventArgs e)
        {
            MoveSnake();
        }
        private void Window_ContentLoaded(object sender, EventArgs e)
        {
            DrawGameArea();
        }
        private void MoveSnake()
        {
            // Remove the last part of the snake, in preparation of the new part added below  
            while (snakeParts.Count >= snakeLength)
            {
                GameArea.Children.Remove(snakeParts[0].UiElement);
                snakeParts.RemoveAt(0);
            }
            // Next up, we'll add a new element to the snake, which will be the (new) head  
            // Therefore, we mark all existing parts as non-head (body) elements and then  
            // we make sure that they use the body brush  
            foreach (SnakePart snakePart in snakeParts)
            {
                (snakePart.UiElement as Rectangle).Fill = snakeBodyBrush;
                snakePart.IsHead = false;
            }

            // Determine in which direction to expand the snake, based on the current direction  
            SnakePart snakeHead = snakeParts[snakeParts.Count - 1];
            double nextX = snakeHead.Position.X;
            double nextY = snakeHead.Position.Y;
            switch (snakeDirection)
            {
                case SnakeDirection.Left:
                    nextX -= SnakeSquareSize;
                    break;
                case SnakeDirection.Right:
                    nextX += SnakeSquareSize;
                    break;
                case SnakeDirection.Up:
                    nextY -= SnakeSquareSize;
                    break;
                case SnakeDirection.Down:
                    nextY += SnakeSquareSize;
                    break;
            }

            // Now add the new head part to our list of snake parts...  
            snakeParts.Add(new SnakePart()
            {
                Position = new Point(nextX, nextY),
                IsHead = true
            });
            //... and then have it drawn!  
            DrawSnake();
            // We'll get to this later...  
            DoCollisionCheck();          
        }

        private void DrawSnake()
        {
            foreach (SnakePart snakePart in snakeParts)
            {
                if (snakePart.UiElement == null)
                {
                    snakePart.UiElement = new Rectangle()
                    {
                        Width = SnakeSquareSize,
                        Height = SnakeSquareSize,
                        Fill = (snakePart.IsHead ? snakeHeadBrush : snakeBodyBrush)
                    };
                    GameArea.Children.Add(snakePart.UiElement);
                    Canvas.SetTop(snakePart.UiElement, snakePart.Position.Y);
                    Canvas.SetLeft(snakePart.UiElement, snakePart.Position.X);
                }
            }
        }
        private void DrawGameArea()
        {
            bool doneDrawingBackground = false;
            int nextX = 0, nextY = 0;
            int rowCounter = 0;
            bool nextIsOdd = false;
            Brush brushLight = (SolidColorBrush)new BrushConverter().ConvertFrom("#E5E8FF"),
                brushDark = (SolidColorBrush)new BrushConverter().ConvertFrom("#858DC9");

            while (doneDrawingBackground == false)
            {
                Rectangle rect = new Rectangle
                {
                    Width = SnakeSquareSize,
                    Height = SnakeSquareSize,
                    Fill = nextIsOdd ? brushLight : brushDark
                };
                GameArea.Children.Add(rect);
                Canvas.SetTop(rect, nextY);
                Canvas.SetLeft(rect, nextX);

                nextIsOdd = !nextIsOdd;
                nextX += SnakeSquareSize;
                if (nextX >= GameArea.ActualWidth)
                {
                    nextX = 0;
                    nextY += SnakeSquareSize;
                    rowCounter++;
                    nextIsOdd = (rowCounter % 2 != 0);
                }

                if (nextY >= GameArea.ActualHeight)
                    doneDrawingBackground = true;
            }
            AddButton();
        }

        Button PlayButton;
        void AddButton()
        {
            PlayButton = new Button();
            PlayButton.Width = 200;
            PlayButton.Height = 84;
            PlayButton.MaxHeight = 84;
            PlayButton.MaxWidth = 200;
            PlayButton.Content = "Play";

            PlayButton.FontFamily = new FontFamily("Nirmala UI");
            PlayButton.FontSize = 28;
            PlayButton.Visibility = Visibility.Visible;
            PlayButton.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#E5E8FF");
            PlayButton.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#12173D");
            PlayButton.Click+= new RoutedEventHandler((x,y)=>StartNewGame());
            GameArea.Children.Add(PlayButton);
            Canvas.SetTop(PlayButton, 200);
            Canvas.SetLeft(PlayButton, 300);
        }
    }


}
