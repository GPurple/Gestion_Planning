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
    /// Logique d'interaction pour Window_Add_Color.xaml
    /// </summary>
    public partial class Window_Add_Color : Window
    {
        public Color color = Colors.White;

        public Window_Add_Color()
        {
            InitializeComponent();
        }
        
        private void CancelCretionColor(object sender, RoutedEventArgs e)
        {
            Brain.Instance.CancelCreationColor();
        }

        private void ValidateCreationColor(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ValidateCreationColor();
        }

        private void ChoiceColorGreen(object sender, RoutedEventArgs e)
        {

        }

        private void ChoiceColorRed(object sender, RoutedEventArgs e)
        {

        }

        private void ChoiceColorCyan(object sender, RoutedEventArgs e)
        {

        }

        private void ChoiceColorBlueNight(object sender, RoutedEventArgs e)
        {

        }
    }
}
