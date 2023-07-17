using InteractiveDataDisplay.WPF;
using lab2.ViewModels;
using ScottPlot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls.DataVisualization.Charting;

namespace GraphEdu.ViewModels
{
    internal class FigureMovingViewModel: ViewModelBase
    {
        public string ButtonText { get=>buttonText; 
            set { buttonText = value;
                OnPropertyChanged("ButtonText");
            } }
        string buttonText = "Start";
        public double X1 { get => x1;
            set { x1 = value; OnPropertyChanged("X1"); }
        }
        double x1 =0;
        public double X2
        {
            get => x2;
            set { x2 = value; OnPropertyChanged("X2"); }
        }
        double x2=0; 
        public double X3
        {
            get => x3;
            set { x3 = value; OnPropertyChanged("X3"); }
        }
        double x3=5;

        public double Y1
        {
            get => y1;
            set { y1 = value; OnPropertyChanged("Y1"); }
        }
        double y1=3;
        public double Y2
        {
            get => y2;
            set { y2 = value; OnPropertyChanged("Y2"); }
        }
        double y2 = 0;
        public double Y3
        {
            get => y3;
            set { y3 = value; OnPropertyChanged("Y3"); }
        }
        double y3 = 0;
        public lab2.Commands.Command MovingFigure { get; set; }
        public bool moving = false;
    }
}
