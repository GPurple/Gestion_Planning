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
    /// Logique d'interaction pour UC_Display_week.xaml
    /// </summary>
    public partial class UC_Display_week : UserControl
    {
        DateTime firstDayToDisplay = DateTime.Now;

        public UC_Display_week()
        {
            InitializeComponent();
            Brain.Instance.ucDispWeek = this;
            RefreshWeekToDisplay(firstDayToDisplay, 52);
        }

        private void PrecedentWeek(object sender, RoutedEventArgs e)
        {
            Brain.Instance.PreviousWeek();
        }

        private void NextWeek(object sender, RoutedEventArgs e)
        {
            Brain.Instance.NextWeek();
        }

        public void RefreshWeekToDisplay(DateTime newDayToDisplay, int nbWeek)
        {
            firstDayToDisplay = newDayToDisplay;
            DateTime dayToDisplay = firstDayToDisplay;
            TextWeekToDisplay.Text = "Semaine : " + nbWeek + "/" + dayToDisplay.Year;
            TextDay_lundi.Text = dayToDisplay.Day + "/" + dayToDisplay.Month;

            dayToDisplay = dayToDisplay.AddDays(1);
            TextDay_mardi.Text = dayToDisplay.Day + "/" + dayToDisplay.Month;

            dayToDisplay = dayToDisplay.AddDays(1);
            TextDay_mercredi.Text = dayToDisplay.Day + "/" + dayToDisplay.Month;

            dayToDisplay = dayToDisplay.AddDays(1);
            TextDay_jeudi.Text = dayToDisplay.Day + "/" + dayToDisplay.Month;

            dayToDisplay = dayToDisplay.AddDays(1);
            TextDay_vendredi.Text = dayToDisplay.Day + "/" + dayToDisplay.Month;

            dayToDisplay = dayToDisplay.AddDays(1);
            TextDay_samedi.Text = dayToDisplay.Day + "/" + dayToDisplay.Month;

            dayToDisplay = dayToDisplay.AddDays(1);
            TextDay_dimanche.Text = dayToDisplay.Day + "/" + dayToDisplay.Month;

        }
    }
}
