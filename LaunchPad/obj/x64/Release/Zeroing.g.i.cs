﻿#pragma checksum "..\..\..\Zeroing.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2A2636F1E4AEC275001F37939788E6442043F577C68278206DFECFFD006FD7AC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LaunchPad;
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


namespace LaunchPad {
    
    
    /// <summary>
    /// Zeroing
    /// </summary>
    public partial class Zeroing : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Zeroing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_title;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Zeroing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddBox;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Zeroing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_clear;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Zeroing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer scrl_box;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Zeroing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AddList;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Zeroing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_submit;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Zeroing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chk_amazon;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Zeroing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chk_ebay;
        
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
            System.Uri resourceLocater = new System.Uri("/LaunchPad;component/zeroing.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Zeroing.xaml"
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
            this.lbl_title = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.AddBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\..\Zeroing.xaml"
            this.AddBox.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.EnterClicked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_clear = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\Zeroing.xaml"
            this.btn_clear.Click += new System.Windows.RoutedEventHandler(this.Btn_clear_click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.scrl_box = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 5:
            this.AddList = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.btn_submit = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Zeroing.xaml"
            this.btn_submit.Click += new System.Windows.RoutedEventHandler(this.Btn_submit_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.chk_amazon = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 8:
            this.chk_ebay = ((System.Windows.Controls.CheckBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
