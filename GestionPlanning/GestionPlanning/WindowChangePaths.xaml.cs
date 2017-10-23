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
using System.Windows.Shapes;

namespace GestionPlanning
{
    /// <summary>
    /// Logique d'interaction pour WindowChangePaths.xaml
    /// </summary>
    public partial class WindowChangePaths : Window
    {
        public WindowChangePaths()
        {
            InitializeComponent();
        }
        
        private void LeaveWindowModifPaths(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void ChangeNameFileCsv(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ChangeNameFileCsv(textNameCsv.Text);
        }

        private void ChangePathFileCsv(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ChangePathFileCsv(textPathCsv.Text);
        }

        private void ChangePathFichierSauvegarde(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ChangePathFichierSauvegarde(textPathFichierSauvegarde.Text);
        }

        private void ChangePathFichierModifs(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ChangePathFichierModifs(textPathFichierModifications.Text);
        }
    }
}
