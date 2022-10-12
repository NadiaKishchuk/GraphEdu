﻿#pragma checksum "..\..\..\Pages\Fractals.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9456818F2D3C31D1B3CD7053C7664349EF9EF8A82F1A986952DBDEB8B59FB8A0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GraphEdu;
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
using System.Windows.Interactivity;
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
        
        
        #line 38 "..\..\..\Pages\Fractals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image FractalImage;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Pages\Fractals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonPaint;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Pages\Fractals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup PopupPaint;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\Pages\Fractals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Syncfusion.Windows.Shared.ColorPicker ColorPicker1;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Pages\Fractals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Syncfusion.Windows.Shared.ColorPicker ColorPicker2;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\Pages\Fractals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Syncfusion.Windows.Shared.ColorPicker ColorPicker3;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Pages\Fractals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HintButtonFractals;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\Pages\Fractals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button QuestionButtonFractals;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\Pages\Fractals.xaml"
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
            
            #line 41 "..\..\..\Pages\Fractals.xaml"
            this.FractalImage.MouseMove += new System.Windows.Input.MouseEventHandler(this.FractalImageMouseMove);
            
            #line default
            #line hidden
            
            #line 42 "..\..\..\Pages\Fractals.xaml"
            this.FractalImage.Drop += new System.Windows.DragEventHandler(this.FractalImageMouseDrop);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 45 "..\..\..\Pages\Fractals.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveFractal);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 54 "..\..\..\Pages\Fractals.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ZoomOutImage);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 63 "..\..\..\Pages\Fractals.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ZoomInImage);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ButtonPaint = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\Pages\Fractals.xaml"
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
            
            #line 81 "..\..\..\Pages\Fractals.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ApplyColor);
            
            #line default
            #line hidden
            return;
            case 11:
            this.HintButtonFractals = ((System.Windows.Controls.Button)(target));
            return;
            case 12:
            this.QuestionButtonFractals = ((System.Windows.Controls.Button)(target));
            
            #line 104 "..\..\..\Pages\Fractals.xaml"
            this.QuestionButtonFractals.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Question_MouseEnter);
            
            #line default
            #line hidden
            return;
            case 13:
            this.popupQuestion = ((System.Windows.Controls.Primitives.Popup)(target));
            
            #line 109 "..\..\..\Pages\Fractals.xaml"
            this.popupQuestion.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Question_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 115 "..\..\..\Pages\Fractals.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).RequestNavigate += new System.Windows.Navigation.RequestNavigateEventHandler(this.Hyperlink_RequestNavigate);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

