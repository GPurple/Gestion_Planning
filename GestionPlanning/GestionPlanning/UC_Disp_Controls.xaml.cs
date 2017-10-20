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
    /// Logique d'interaction pour UC_Disp_Controls.xaml
    /// </summary>
    public partial class UC_Disp_Controls : UserControl
    {
        public UC_Disp_Controls()
        {
            InitializeComponent();
            Brain.Instance.ucDispControl = this;
        }

        private void DisplayDay(object sender, RoutedEventArgs e)
        {
            Brain.Instance.DisplayDay();
        }

        private void DisplayWeek(object sender, RoutedEventArgs e)
        {
            Brain.Instance.DisplayWeek();
        }

        private void DisplayMonth(object sender, RoutedEventArgs e)
        {
            Brain.Instance.DisplayMonth();
        }

        private void ResetDay(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ResetDay();
        }

        private void ResetWeek(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ResetWeek();
        }

        private void ResetMonth(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ResetMonth();
        }

        private void RefreshData(object sender, RoutedEventArgs e)
        {
            Brain.Instance.RefreshData();
        }

        private void PlacementAuto(object sender, RoutedEventArgs e)
        {
            Brain.Instance.PlacementAutoAll();
        }

        private void ReplacementRetardAuto(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ReplacementRetardAutoAll();
        }

        private void SaveData(object sender, RoutedEventArgs e)
        {
            Brain.Instance.SaveListeInData();
        }
    }
}
