﻿#pragma checksum "..\..\..\..\Views\KanbanBoard.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "68594ACA64E5A495FB727E89DE2637FA9B436344"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SapphirApp.ViewModels;
using SapphirApp.Views;
using Syncfusion.UI.Xaml.Kanban;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace SapphirApp.Views {
    
    
    /// <summary>
    /// KanbanBoard
    /// </summary>
    public partial class KanbanBoard : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 82 "..\..\..\..\Views\KanbanBoard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox SubTaskIsCompletedCheckBox;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\Views\KanbanBoard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SubTaskTitleTextBox;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\..\Views\KanbanBoard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TaskTagTextBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SapphirApp;component/views/kanbanboard.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\KanbanBoard.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.SubTaskIsCompletedCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 2:
            this.SubTaskTitleTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TaskTagTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            
            #line 170 "..\..\..\..\Views\KanbanBoard.xaml"
            ((Syncfusion.UI.Xaml.Kanban.SfKanban)(target)).CardTapped += new System.EventHandler<Syncfusion.UI.Xaml.Kanban.KanbanTappedEventArgs>(this.SfKanban_CardTapped);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

