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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Window_Identification winIdentification = new Window_Identification();
            Brain.Instance.WinPageIdentification = winIdentification;
            winIdentification.Show();
            this.Hide();
            Brain.Instance.mainWindow = this;
            Brain.Instance.InitDisplay();
        }

        private void DisplayParamLog(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ucParamLog.Visibility = Visibility.Visible;
        }

        private void CloseAll(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Brain.Instance.CloseAll();
        }
    }
}
