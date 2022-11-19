using InteractiveDataDisplay.WPF;
using ScottPlot.Drawing.Colormaps;
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

namespace GraphEdu.Pages
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }
        public MainWindow mainWindow;

        public void MouseDownFractals(object sender, MouseButtonEventArgs e)
        {
            mainWindow.MouseDownFractals(sender, e);

        }

        public void ColorsClicked(object sender, MouseButtonEventArgs e)
        {
            mainWindow.ColorsClicked(sender, e);

        }
        public void MovingClicked(object sender, MouseButtonEventArgs e)
        {
            mainWindow.MovingClicked(sender, e);

        }

        public void TutorialClick(object sender, MouseButtonEventArgs e)
        {
            mainWindow.TutorialClick(sender, e);
        }
    }
}
