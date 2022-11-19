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
using System.Windows.Shapes;

namespace GraphEdu.Windows
{
    /// <summary>
    /// Interaction logic for InformationWindow.xaml
    /// </summary>
    public partial class InformationWindow : Window
    {
        public InformationWindow(string text)
        {
            InitializeComponent();
            TextWithInfo.
                Inlines.Add(new Run(text));

        }
        public InformationWindow(string text, string textButton):this(text)
        {
            ButtonClose.Content = textButton;

        }

        private void ContinueClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
