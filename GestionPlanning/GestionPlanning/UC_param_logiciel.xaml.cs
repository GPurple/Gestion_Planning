using GestionPlanning.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestionPlanning
{
    /// <summary>
    /// Logique d'interaction pour UC_param_logiciel.xaml
    /// </summary>
    public partial class UC_param_logiciel : UserControl
    {
        public UC_param_logiciel()
        {
            InitializeComponent();
            Brain.Instance.ucParamLog = this;
            Brain.Instance.ucParamLog.Visibility = Visibility.Hidden;
        }

        private void DisplayModifs(object sender, RoutedEventArgs e)
        {
            Brain.Instance.DisplayListeModifs();
            Brain.Instance.ucParamLog.Visibility = Visibility.Hidden;
        }

        private void ChangeUser(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ChangeUser();
            Brain.Instance.ucParamLog.Visibility = Visibility.Hidden;
        }

        private void ModifyPathsFiles(object sender, RoutedEventArgs e)
        {
            Brain.Instance.DispWindowPaths();
            Brain.Instance.ucParamLog.Visibility = Visibility.Hidden;
        }

        private void ValidateUC(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ucParamLog.Visibility = Visibility.Hidden;
        }

        private void MouseLeft(object sender, MouseButtonEventArgs e)
        {
            Brain.Instance.ucParamLog.Visibility = Visibility.Hidden;
        }

        private void MouseLeft(object sender, MouseEventArgs e)
        {
            Brain.Instance.ucParamLog.Visibility = Visibility.Hidden;
        }

        private void MouseLeft(object sender, DragEventArgs e)
        {
            Brain.Instance.ucParamLog.Visibility = Visibility.Hidden;

        }
    }
}
