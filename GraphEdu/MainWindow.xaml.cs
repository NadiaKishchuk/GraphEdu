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
using System.Windows.Media.Imaging;
namespace GraphEdu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new Colors() { DataContext  = new ViewModels.ColorViewModel()};
        }
        
        private void MouseDownFractals(object sender, MouseButtonEventArgs e)
        {   
            Main.Content = new Fractals() ;
        }

        private void ColorsClicked(object sender, MouseButtonEventArgs e)
        {
          
           
            
        }
        
    }
}
