using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Input;

using GraphEdu.Pages;


namespace GraphEdu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FigureMoving figure=null;
        Fractals fractal = null;
        Colors colors = null;
        Tutorial tutorial = null;
        StartPage startPage;
        public MainWindow()
        {
            InitializeComponent();

            startPage = new StartPage() { mainWindow = this};
            Main.Content = startPage;
            Keyboard.Focus(tutorial);

        }

        public void MouseDownGrapgEdu(object sender, MouseButtonEventArgs e)
        {
            if (startPage == null)
                startPage = new StartPage() { mainWindow = this };

            Main.Content = startPage;
        }
        public void MouseDownFractals(object sender, MouseButtonEventArgs e)
        {   if (fractal == null)
                fractal = new Fractals() { parentWindow = this};
           
            Main.Content = fractal;

        }

        public void ColorsClicked(object sender, MouseButtonEventArgs e)
        {
            if (colors == null)
                colors = new Colors() { DataContext = new ViewModels.ColorViewModel() { parentWindow = this} };

            Main.Content = colors;

        }
        public void MovingClicked(object sender, MouseButtonEventArgs e)
        {
            if (figure == null)
                figure = new FigureMoving() { parentWindow = this };

            Main.Content = figure;

        }

        public void TutorialClick(object sender, MouseButtonEventArgs e)
        {
            if (tutorial == null)
                tutorial = new Tutorial();

            Main.Content = tutorial;

        }


    }
}
