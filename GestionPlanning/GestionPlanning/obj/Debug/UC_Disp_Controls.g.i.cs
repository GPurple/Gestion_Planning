﻿#pragma checksum "..\..\UC_Disp_Controls.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "ACA300910C7E89496A6C8AB40A177E86"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using GestionPlanning;
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


namespace GestionPlanning {
    
    
    /// <summary>
    /// UC_Disp_Controls
    /// </summary>
    public partial class UC_Disp_Controls : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\UC_Disp_Controls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDispDay;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\UC_Disp_Controls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnResetDay;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\UC_Disp_Controls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDispWeek;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\UC_Disp_Controls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnResetWeek;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\UC_Disp_Controls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDispMonth;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\UC_Disp_Controls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnResetMonth;
        
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
            System.Uri resourceLocater = new System.Uri("/GestionPlanning;component/uc_disp_controls.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UC_Disp_Controls.xaml"
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
            this.btnDispDay = ((System.Windows.Controls.Button)(target));
            
            #line 9 "..\..\UC_Disp_Controls.xaml"
            this.btnDispDay.Click += new System.Windows.RoutedEventHandler(this.DisplayDay);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnResetDay = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\UC_Disp_Controls.xaml"
            this.btnResetDay.Click += new System.Windows.RoutedEventHandler(this.ResetDay);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnDispWeek = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\UC_Disp_Controls.xaml"
            this.btnDispWeek.Click += new System.Windows.RoutedEventHandler(this.DisplayWeek);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnResetWeek = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\UC_Disp_Controls.xaml"
            this.btnResetWeek.Click += new System.Windows.RoutedEventHandler(this.ResetWeek);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnDispMonth = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\UC_Disp_Controls.xaml"
            this.btnDispMonth.Click += new System.Windows.RoutedEventHandler(this.DisplayMonth);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnResetMonth = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\UC_Disp_Controls.xaml"
            this.btnResetMonth.Click += new System.Windows.RoutedEventHandler(this.ResetMonth);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

