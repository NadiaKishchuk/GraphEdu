﻿#pragma checksum "..\..\..\TutorialUserController\GameSnake.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4CFCD518A1CF710C06DD881AB259F436A86897A9DF204C339B699E513173B280"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GraphEdu.TutorialUserController;
using ScottPlot;
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


namespace GraphEdu.TutorialUserController {
    
    
    /// <summary>
    /// GameSnake
    /// </summary>
    public partial class GameSnake : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\TutorialUserController\GameSnake.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid pnlTitleBar;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\TutorialUserController\GameSnake.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbStatusScore;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\TutorialUserController\GameSnake.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbStatusSpeed;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\TutorialUserController\GameSnake.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas GameArea;
        
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
            System.Uri resourceLocater = new System.Uri("/GraphEdu;component/tutorialusercontroller/gamesnake.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\TutorialUserController\GameSnake.xaml"
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
            
            #line 9 "..\..\..\TutorialUserController\GameSnake.xaml"
            ((GraphEdu.TutorialUserController.GameSnake)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_ContentLoaded);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\TutorialUserController\GameSnake.xaml"
            ((GraphEdu.TutorialUserController.GameSnake)(target)).KeyUp += new System.Windows.Input.KeyEventHandler(this.Window_KeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.pnlTitleBar = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.tbStatusScore = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.tbStatusSpeed = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.GameArea = ((System.Windows.Controls.Canvas)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
