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
            //Brain.Instance.ResetWeek();
        }

        public void ResizeDispMachine()
        {

            btnPrecedentWeek.Margin = new Thickness((int)(Values.Instance.WIDTH_DISP_MAIN * 0.05), (int)(Values.Instance.HEIGHT_DISP_MAIN * 0.03), 0, 0);
            btnNextWeek.Margin = new Thickness((int)(Values.Instance.WIDTH_DISP_MAIN * 0.85), (int)(Values.Instance.HEIGHT_DISP_MAIN * 0.03), 0, 0);

            SPDisplayDay_lundi.Width = (int)(Values.Instance.WIDTH_DISP_MAIN * 0.96 /7);
            SPDisplayDay_lundi.Margin = new Thickness((int)(SPDisplayDay_lundi.Width * 0), 0, 0, 0);

            SPDisplayDay_mardi.Width = (int)(Values.Instance.WIDTH_DISP_MAIN * 0.96 / 7);
            SPDisplayDay_mardi.Margin = new Thickness((int)(SPDisplayDay_mardi.Width * 1), 0, 0, 0);

            SPDisplayDay_mercredi.Width = (int)(Values.Instance.WIDTH_DISP_MAIN * 0.96 / 7);
            SPDisplayDay_mercredi.Margin = new Thickness((int)(SPDisplayDay_mercredi.Width * 2),0, 0, 0);

            SPDisplayDay_jeudi.Width = (int)(Values.Instance.WIDTH_DISP_MAIN * 0.96 / 7);
            SPDisplayDay_jeudi.Margin = new Thickness((int)(SPDisplayDay_jeudi.Width * 3), 0, 0, 0);

            SPDisplayDay_vendredi.Width = (int)(Values.Instance.WIDTH_DISP_MAIN * 0.96 / 7);
            SPDisplayDay_vendredi.Margin = new Thickness((int)(SPDisplayDay_vendredi.Width * 4), 0, 0, 0);

            SPDisplayDay_samedi.Width = (int)(Values.Instance.WIDTH_DISP_MAIN * 0.96 / 7);
            SPDisplayDay_samedi.Margin = new Thickness((int)(SPDisplayDay_samedi.Width * 5), 0, 0, 0);

            SPDisplayDay_dimanche.Width = (int)(Values.Instance.WIDTH_DISP_MAIN * 0.96 / 7);
            SPDisplayDay_dimanche.Margin = new Thickness((int)(SPDisplayDay_dimanche.Width * 6), 0 , 0, 0);

            int height_tmp = (int)(Values.Instance.HEIGHT_DISP_MAIN * 0.12);
            int width_tmp = (int)(Values.Instance.WIDTH_DISP_MAIN * 0.96 / 7);
            int buff = (int)(Values.Instance.WIDTH_DISP_MAIN * 0.96 / 14);

            TextDay_lundi.Margin = new Thickness((int)(width_tmp * 0) + buff, height_tmp, 0, 0);
            TextDay_mardi.Margin = new Thickness((int)(width_tmp * 1) + buff, height_tmp, 0, 0);
            TextDay_mercredi.Margin = new Thickness((int)(width_tmp * 2) + buff, height_tmp, 0, 0);
            TextDay_jeudi.Margin = new Thickness((int)(width_tmp * 3) + buff, height_tmp, 0, 0);
            TextDay_vendredi.Margin = new Thickness((int)(width_tmp * 4) + buff, height_tmp, 0, 0);
            TextDay_samedi.Margin = new Thickness((int)(width_tmp * 5) + buff, height_tmp, 0, 0);
            TextDay_dimanche.Margin = new Thickness((int)(width_tmp * 6) + buff, height_tmp, 0, 0);
            
            gridDispWeek.Width = (int)(Values.Instance.WIDTH_DISP_MAIN * 0.96);
            gridDispWeek.Height = (int)(Values.Instance.HEIGHT_DISP_MAIN * 0.8);
            gridDispWeek.Margin = new Thickness(0, (int)(Values.Instance.HEIGHT_DISP_MAIN * 0.0), 0, 0);

            scrollViewWeek.Width = (int)(Values.Instance.WIDTH_DISP_MAIN * 0.96);
            scrollViewWeek.Height = (int)(Values.Instance.HEIGHT_DISP_MAIN * 0.75);
            scrollViewWeek.Margin = new Thickness(0, (int)(Values.Instance.HEIGHT_DISP_MAIN * 0.2), 0, 0);

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
            ResizeDispMachine();

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

        public void RefreshListToDisplay(ListeFichesWeek listeWeek)
        {

            ResizeDispMachine();
            RefreshListToDisplayOneDay(listeWeek.listeLundi, SPDisplayDay_lundi);
            RefreshListToDisplayOneDay(listeWeek.listeMardi, SPDisplayDay_mardi);
            RefreshListToDisplayOneDay(listeWeek.listeMercredi, SPDisplayDay_mercredi);
            RefreshListToDisplayOneDay(listeWeek.listeJeudi, SPDisplayDay_jeudi);
            RefreshListToDisplayOneDay(listeWeek.listeVendredi, SPDisplayDay_vendredi);
            RefreshListToDisplayOneDay(listeWeek.listeSamedi, SPDisplayDay_samedi);
            RefreshListToDisplayOneDay(listeWeek.listeDimanche, SPDisplayDay_dimanche);
        }

        public void RefreshListToDisplayOneDay(List<Fiche> listeDay, StackPanel stackPanel)
        {
            stackPanel.Children.Clear();
            foreach (Fiche fiche in listeDay)
            {
                if (fiche.check == false)
                {
                    UC_Fiche_week ucfw = new UC_Fiche_week(fiche);
                    stackPanel.Children.Add(ucfw);
                }
            }
            int nbList = stackPanel.Children.Count;
            stackPanel.Height = nbList * 145;
            if (gridDispWeek.Height < nbList * 145)
            {
                gridDispWeek.Height = nbList * 145;
            }
            Brain.Instance.VerifOverflowTimeDay(listeDay);
        }
        
    }
}
