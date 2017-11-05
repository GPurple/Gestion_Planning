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
    /// Logique d'interaction pour UC_display_day.xaml
    /// </summary>
    public partial class UC_display_day : UserControl
    {
        DateTime dayToDisplay = DateTime.Now;

        public UC_display_day()
        {
            InitializeComponent();
            TextDay.Text = dayToDisplay.Day + "/" + dayToDisplay.Month + "/" + dayToDisplay.Year;
            Brain.Instance.ucDispDay = this;
            //Brain.Instance.ResetDay();
        }

        private void Btn_PreviousDay(object sender, RoutedEventArgs e)
        {
            Brain.Instance.PreviousDay();
        }

        private void Btn_NextDay(object sender, RoutedEventArgs e)
        {
            Brain.Instance.NextDay();
        }

        public void RefreshDayToDisplay(DateTime newDayToDisplay)
        {
            dayToDisplay = newDayToDisplay;
            TextDay.Text = dayToDisplay.Day + "/" + dayToDisplay.Month + "/" + dayToDisplay.Year;
        }

        public void RefreshDayToDisplay()
        {
            TextDay.Text = dayToDisplay.Day + "/" + dayToDisplay.Month + "/" + dayToDisplay.Year;
        }

        public void RefreshListToDisplay(List<Fiche> listeDay)
        {
            //revoir synchro 
            StackPanelDisplayDay.Children.Clear();
            foreach (Fiche fiche in listeDay)
            {
                if (fiche.check == false)
                {
                    UC_fiche_day ucfd = new UC_fiche_day(fiche);
                    StackPanelDisplayDay.Children.Add(ucfd);
                }
            }
            int nbList = StackPanelDisplayDay.Children.Count;
            StackPanelDisplayDay.Height = nbList * 50;
        }
    }
}
