﻿#pragma checksum "..\..\UserControlWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "495A8E6A0D2D287DFE2EF39F665AA799"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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


namespace MultiDimEditor {
    
    
    /// <summary>
    /// UserControlWindow
    /// </summary>
    public partial class UserControlWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\UserControlWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbAllUsers;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\UserControlWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbFindUser;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\UserControlWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbLevel;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\UserControlWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRemUser;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\UserControlWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSel;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\UserControlWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNewLogin;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\UserControlWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNewPassword;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\UserControlWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbNewLevel;
        
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
            System.Uri resourceLocater = new System.Uri("/MultiDimEditor;component/usercontrolwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UserControlWindow.xaml"
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
            this.cbAllUsers = ((System.Windows.Controls.ComboBox)(target));
            
            #line 7 "..\..\UserControlWindow.xaml"
            this.cbAllUsers.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbAllUsers_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbFindUser = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\UserControlWindow.xaml"
            this.tbFindUser.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbFindUser_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbLevel = ((System.Windows.Controls.ComboBox)(target));
            
            #line 21 "..\..\UserControlWindow.xaml"
            this.cbLevel.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbLevel_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnRemUser = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\UserControlWindow.xaml"
            this.btnRemUser.Click += new System.Windows.RoutedEventHandler(this.btnRemUser_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnSel = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\UserControlWindow.xaml"
            this.btnSel.Click += new System.Windows.RoutedEventHandler(this.btnSel_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.tbNewLogin = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\UserControlWindow.xaml"
            this.tbNewLogin.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbFindUser_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tbNewPassword = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\UserControlWindow.xaml"
            this.tbNewPassword.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbFindUser_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 31 "..\..\UserControlWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.cbNewLevel = ((System.Windows.Controls.ComboBox)(target));
            
            #line 35 "..\..\UserControlWindow.xaml"
            this.cbNewLevel.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbLevel_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

