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


            UC_Disp_Day.Width = Values.Instance.WIDTH_DISP_MAIN;
            UC_Disp_Day.Height = Values.Instance.HEIGHT_DISP_MAIN;

            UC_Disp_Week.Width = Values.Instance.WIDTH_DISP_MAIN;
            UC_Disp_Week.Height = Values.Instance.HEIGHT_DISP_MAIN;

            UC_Disp_Month.Width = Values.Instance.WIDTH_DISP_MAIN;
            UC_Disp_Month.Height = Values.Instance.HEIGHT_DISP_MAIN;               

            UC_Disp_Machines.Width = Values.Instance.WIDTH_DISP_MAIN;
            UC_Disp_Machines.Height = Values.Instance.HEIGHT_DISP_MAIN;
                        
            UC_Disp_Simple.Width = Values.Instance.WIDTH_DISP_MAIN;
            UC_Disp_Simple.Height = Values.Instance.HEIGHT_DISP_MAIN;

            UC_DispModifs.Width = Values.Instance.WIDTH_DISP_MAIN;
            UC_DispModifs.Height = Values.Instance.HEIGHT_DISP_MAIN;

            gridUcDisplayPlanning.Margin = new Thickness(Values.Instance.POSX_DISP_MAIN, Values.Instance.POSY_DISP_MAIN, 0, 0);

            gridUcDisplayPlanning.Width = Values.Instance.WIDTH_DISP_MAIN;
            gridUcDisplayPlanning.Height = Values.Instance.HEIGHT_DISP_MAIN;

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
