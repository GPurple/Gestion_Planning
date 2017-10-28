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
    /// Logique d'interaction pour Window_Identification.xaml
    /// </summary>
    public partial class Window_Identification : Window
    {
        public Window_Identification()
        {
            InitializeComponent();
            Brain.Instance.WinPageIdentification = this;
        }

        private void ValidateIdentifiant(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ValidateIdentification(TextBoxIdentifiant.Text, "");
        }

        private void CloseAll(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Brain.Instance.CloseAll();
        }
    }
}
