﻿#pragma checksum "..\..\..\Pages\Fractals.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D418962531FF37DBE6242E15C3A67834234EF7A07C15F68C2F9E6F600C7357E0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ScottPlot;
using Syncfusion;
using Syncfusion.Windows;
using Syncfusion.Windows.Controls.Media;
using Syncfusion.Windows.Controls.Navigation;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace GraphEdu {
    
    
    /// <summary>
    /// Fractals
    /// </summary>
    public partial class Fractals : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\Pages\Fractals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image FractalImage;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\Pages\Fractals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonPaint;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\Pages\Fractals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup PopupPaint;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\Pages\Fractals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Syncfusion.Windows.Shared.ColorPicker ColorPicker1;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\Pages\Fractals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Syncfusion.Windows.Shared.ColorPicker ColorPicker2;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\Pages\Fractals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Syncfusion.Windows.Shared.ColorPicker ColorPicker3;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\Pages\Fractals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HintButtonFractals;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\Pages\Fractals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button QuestionButtonFractals;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\Pages\Fractals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup popupQuestion;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GraphEdu;component/pages/fractals.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\Fractals.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.FractalImage = ((System.Windows.Controls.Image)(target));
            
            #line 40 "..\..\..\Pages\Fractals.xaml"
            this.FractalImage.MouseMove += new System.Windows.Input.MouseEventHandler(this.FractalImageMouseMove);
            
            #line default
            #line hidden
            
            #line 41 "..\..\..\Pages\Fractals.xaml"
            this.FractalImage.Drop += new System.Windows.DragEventHandler(this.FractalImageMouseDrop);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 47 "..\..\..\Pages\Fractals.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveFractal);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 56 "..\..\..\Pages\Fractals.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ZoomOutImage);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 65 "..\..\..\Pages\Fractals.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ZoomInImage);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ButtonPaint = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\Pages\Fractals.xaml"
            this.ButtonPaint.Click += new System.Windows.RoutedEventHandler(this.PopupPaintControl);
            
            #line default
            #line hidden
            return;
            case 6:
            this.PopupPaint = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 7:
            this.ColorPicker1 = ((Syncfusion.Windows.Shared.ColorPicker)(target));
            return;
            case 8:
            this.ColorPicker2 = ((Syncfusion.Windows.Shared.ColorPicker)(target));
            return;
            case 9:
            this.ColorPicker3 = ((Syncfusion.Windows.Shared.ColorPicker)(target));
            return;
            case 10:
            
            #line 83 "..\..\..\Pages\Fractals.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ApplyColor);
            
            #line default
            #line hidden
            return;
            case 11:
            this.HintButtonFractals = ((System.Windows.Controls.Button)(target));
            return;
            case 12:
            this.QuestionButtonFractals = ((System.Windows.Controls.Button)(target));
            
            #line 106 "..\..\..\Pages\Fractals.xaml"
            this.QuestionButtonFractals.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Question_MouseEnter);
            
            #line default
            #line hidden
            return;
            case 13:
            this.popupQuestion = ((System.Windows.Controls.Primitives.Popup)(target));
            
            #line 111 "..\..\..\Pages\Fractals.xaml"
            this.popupQuestion.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Question_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 117 "..\..\..\Pages\Fractals.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).RequestNavigate += new System.Windows.Navigation.RequestNavigateEventHandler(this.Hyperlink_RequestNavigate);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 122 "..\..\..\Pages\Fractals.xaml"
            ((System.Windows.Documents.Bold)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.TutorialClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

