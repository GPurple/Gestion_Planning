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
    /// Logique d'interaction pour Window_Modif_Charge.xaml
    /// </summary>
    public partial class Window_Modif_Charge : Window
    {
        public Window_Modif_Charge()
        {
            InitializeComponent();
            textBlockTime.Text = "Charge machine par jour : ";
            Brain.Instance.winModifCharge = this;
        }

        public void SetNewTime(int time)
        {
            TimeSpan timeSpan = new TimeSpan(0, time, 0);
            textBlockTime.Text = "Charge machine par jour : " + timeSpan.Hours + "h" + timeSpan.Minutes;
        }
        
        private void CancelModifTime(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ValidateModifTimeHeure(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ValidateModifTimeHeures(textBoxNewTimeHeures.Text);
        }

        private void ValidateModifTimeMinutes(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ValidateModifTimeMinutes(textBoxNewTimeMinutes.Text);
        }

        private void textBoxNewTime_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
