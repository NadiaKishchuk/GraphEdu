using System;
using System.Collections.Generic;
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

namespace GraphEdu.Pages
{
    /// <summary>
    /// Interaction logic for Tutorial.xaml
    /// </summary>
    public partial class Tutorial : Page
    {
        public Tutorial()
        {
            InitializeComponent();
            SnakeControl.Focus();
            SnakeControl.Focusable = true;
            SnakeControl.Visibility = Visibility.Visible;
            Keyboard.Focus(SnakeControl);
            blocks =new List<TextBlock> { ColorTextBox, FigureMovingTextBox, FractalTextBox };
            InitializeInformation();

            InformationController.InformationText.Document = informationDocuments[0];

        }
        void InitializeInformation()
        {
            informationDocuments = new FlowDocument[3];
            var paragraph = new Paragraph(new Run(File.ReadAllText(@"D:\3 year-2\CG\GraphEdu\Color.txt")));
            informationDocuments[0] = new FlowDocument(paragraph);
            paragraph = new Paragraph(new Run(File.ReadAllText(@"D:\3 year-2\CG\GraphEdu\FigureMoving.txt")));
            informationDocuments[1] = new FlowDocument(paragraph);
            paragraph = new Paragraph(new Run(File.ReadAllText(@"D:\3 year-2\CG\GraphEdu\Fractal.txt")));
            informationDocuments[2] = new FlowDocument(paragraph);
        }

        void GameTextBoxClick(object o, EventArgs args)
        {
            SnakeControl.Visibility = Visibility.Visible;
            InformationController.Visibility = Visibility.Hidden;

            SnakeTextBox.FontWeight = FontWeights.DemiBold;
            InformationTextBox.FontWeight = FontWeights.Normal;
            blocks.ForEach(b => b.FontWeight = FontWeights.Normal);
            
        }
        void InformationTextBoxClick(object o, EventArgs args)
        {
            SnakeControl.Visibility = Visibility.Hidden;
            InformationController.Visibility = Visibility.Visible;

            SnakeTextBox.FontWeight = FontWeights.Normal;
            InformationTextBox.FontWeight = FontWeights.DemiBold;
            ChangeView(CurentPartTutorialName);
        }
        string CurentPartTutorialName = "ColorTextBox";
        List<TextBlock> blocks;
        FlowDocument[] informationDocuments;
        void TutorialPartClick(object o, EventArgs args)
        {
            InformationTextBoxClick(o, args);
            var box = (TextBlock)o;
            if (box.Name.Equals(CurentPartTutorialName))
                return;
            ChangeView(box.Name);
            CurentPartTutorialName = box.Name;

        }
        void ChangeView(string nameTextBlock)
        {
            int len = blocks.Count;
            for ( int i=0;i<len; i++)
            {
                if (blocks[i].Name.Equals(nameTextBlock))
                { blocks[i].FontWeight = FontWeights.Heavy;
                    InformationController.InformationText.Document = informationDocuments[i]; }
                else
                    blocks[i].FontWeight = FontWeights.Normal; 

            }
        }
    }
}
