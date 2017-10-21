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
            Brain.Instance.ResetWeek();
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

        public void RefreshListToDisplay(ListeFichesWeek listeWeek)
        {
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
                UC_Fiche_week ucfw = new UC_Fiche_week(fiche.id, fiche.name, fiche.dateLivraison, fiche.quantiteElement, fiche.attentionRetard, fiche.alerteRetard, fiche.typeOperation, fiche.recouvrement, fiche.dateDebutFabrication, fiche.tempsFabrication);
                stackPanel.Children.Add(ucfw);
            }
            int nbList = stackPanel.Children.Count;
            stackPanel.Height = nbList * 145;
        }

        //TODO do a drag and drop à partir du tuto 
    }
}
