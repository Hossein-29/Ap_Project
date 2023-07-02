﻿#pragma checksum "..\..\MainOrderRegistrationWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4399DB879297A11019A5778C1EA773EDBFF6465FD3715CB6583C05421BC05BB9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfPostCompany;


namespace WpfPostCompany {
    
    
    /// <summary>
    /// MainOrderRegistrationWindow
    /// </summary>
    public partial class MainOrderRegistrationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\MainOrderRegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SenderAddress;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\MainOrderRegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RecieverAddress;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\MainOrderRegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox PackageType;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\MainOrderRegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox HasExpensiveContent;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\MainOrderRegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PackageWeight;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\MainOrderRegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox PostType;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\MainOrderRegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PhoneNumber;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\MainOrderRegistrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label EmployeeUserName;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfPostCompany;component/mainorderregistrationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainOrderRegistrationWindow.xaml"
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
            this.SenderAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.RecieverAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.PackageType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.HasExpensiveContent = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.PackageWeight = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.PostType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.PhoneNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 79 "..\..\MainOrderRegistrationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CalculateFinalPriceBtn);
            
            #line default
            #line hidden
            return;
            case 9:
            this.EmployeeUserName = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

