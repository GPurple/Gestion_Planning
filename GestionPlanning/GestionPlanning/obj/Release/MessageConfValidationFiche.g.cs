﻿#pragma checksum "..\..\MessageConfValidationFiche.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "731C370733E8931543A53EB60A0F360E"
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
    /// MessageConfValidationFiche
    /// </summary>
    public partial class MessageConfValidationFiche : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\MessageConfValidationFiche.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textMessageValidationFiche;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\MessageConfValidationFiche.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConfirm;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\MessageConfValidationFiche.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancelModif;
        
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
            System.Uri resourceLocater = new System.Uri("/GestionPlanning;component/messageconfvalidationfiche.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MessageConfValidationFiche.xaml"
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
            this.textMessageValidationFiche = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.btnConfirm = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\MessageConfValidationFiche.xaml"
            this.btnConfirm.Click += new System.Windows.RoutedEventHandler(this.ConfirmValidationFiche);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnCancelModif = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\MessageConfValidationFiche.xaml"
            this.btnCancelModif.Click += new System.Windows.RoutedEventHandler(this.CancelModifFiche);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

