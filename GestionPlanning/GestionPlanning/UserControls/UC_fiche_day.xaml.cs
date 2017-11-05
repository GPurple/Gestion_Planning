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
    /// Logique d'interaction pour UC_fiche_day.xaml
    /// </summary>
    public partial class UC_fiche_day : UserControl
    {
        private int idFiche = -1;
        private String textId = "Id : ";
        private String textName = "Nom : ";
        private String textDateLivraison = "Livraison : ";
        private String textDateFabrication = "Fabrication : ";
        private String textQty = "Qté : ";
        private Color colorLeft_op = Values.COLOR_NA;
        private Color colorRight_rec = Values.COLOR_NA;
        private String textHeureFab = "Heure fab : ";
        private String textTimeFab = "Temps fab : ";
        private String textDateFab = "Date Fabrication : ";
        private String textMachine = "Machine : ";
        private bool dispWarning = false;
        private bool dispAlerte = false;
        private bool dispSimple = false;

        public UC_fiche_day()
        {
            InitializeComponent();
            textIDficheDay.Text = textId;
            textNameFicheDay.Text = textName;
            textDateLivFicheDay.Text = textDateLivraison;
            textDateFabFicheDay.Text = textDateFabrication;
            textQtyFicheDay.Text = textQty;
            textHeureFabFicheWeek.Text = textHeureFab;
            textTempsFabFicheWeek.Text = textTimeFab;
            image_alerte.Visibility = Visibility.Collapsed; 
            image_warning.Visibility = Visibility.Collapsed;
            textDateFabFicheDay.Text = textDateFab;

        }

        public UC_fiche_day(Fiche newFiche)
        {
            InitializeComponent();
            idFiche = newFiche.id;
            ModifyId(newFiche.id);
            ModifyName(newFiche.name);
            ModifyDateLiv(newFiche.dateLivraison);
            ModifyDateFab(newFiche.dateDebutFabrication);
            ModifyTimeFab(newFiche.tempsFabrication);
            ModifyHourFab(newFiche.dateDebutFabrication);
            ModifyQty(newFiche.quantiteElement);
            ModifyMachine(newFiche.machine);
            if (newFiche.alerteRetard == true)
            {
                DisplayAlerte();
            }
            else
            {
                HideAlerte();
            }
            if (newFiche.attentionRetard == true)
            {
                DisplayWarning();
            }
            else
            {
                HideWarning();
            }
            switch (newFiche.typeOperation)
            {
                case TypeOperation.na:
                    colorLeft_op = Values.COLOR_NA;
                    break;
                case TypeOperation.fabrication:
                    colorLeft_op = Values.COLOR_FAB;
                    break;
                case TypeOperation.aiguisage:
                    colorLeft_op = Values.COLOR_AFF;
                    break;
                default:
                    colorLeft_op = Values.COLOR_NA;
                    break;
            }
            rectangleLeft_op.Fill = new SolidColorBrush(colorLeft_op);

            if (newFiche.recouvrement != null)
            {
                colorRight_rec = newFiche.recouvrement.color;
            }
            else
            {
                colorRight_rec = Colors.White;
            }

            rectangleRight_rec.Fill = new SolidColorBrush(colorRight_rec);
        }
                
        private void ModifyId(int newId)
        {
            textId = "Id : " + newId;
            textIDficheDay.Text = textId;
        }

        private void ModifyName(String newName)
        {
            textName = "Nom : " + newName;
            textNameFicheDay.Text = textName;
        }

        private void ModifyMachine(String newMachine)
        {
            textMachine = "Machine : " + newMachine;
            textMachineFicheDay.Text = textMachine;

        }
        private void ModifyDateLiv(DateTime newDate)
        {
            if (newDate.CompareTo(new DateTime(2000, 1, 1)) > 0)
            {
                textDateLivraison = "Livraison : " + newDate.Day + "/" + newDate.Month + "/" + newDate.Year;
                textDateLivFicheDay.Text = textDateLivraison;
            }
            else
            {
                textDateLivraison = "Livraison : NA";
                textDateLivFicheDay.Text = textDateLivraison;
            }
        }

        private void ModifyDateFab(DateTime newDate)
        {
            if (newDate.CompareTo(new DateTime(2000, 1, 1)) > 0)
            {
                textDateFabrication = "Fabrication : " + newDate.Day + "/" + newDate.Month + "/" + newDate.Year;
                textDateFabFicheDay.Text = textDateFabrication;
            }
            else
            {
                textDateFabrication = "Fabrication : NA";
                textDateFabFicheDay.Text = textDateFabrication;
            }
        }

        private void ModifyTimeFab(int timeFab)
        {

            if (timeFab >= 0)
            {
                textHeureFab = "Temps fab : " + timeFab + "min";
                textTempsFabFicheWeek.Text = textHeureFab;
            }
            else
            {
                textHeureFab = "Temps fab : NA";
                textTempsFabFicheWeek.Text = textHeureFab;
            }
        }

        private void ModifyHourFab(DateTime newDate)
        {
            if (newDate.Hour > 0)
            {
                textTimeFab = "Heure fab : " + newDate.Hour + "h" + newDate.Minute;
                textHeureFabFicheWeek.Text = textTimeFab;
            }
            else
            {
                textTimeFab = "Heure fab : NA";
                textHeureFabFicheWeek.Text = textTimeFab;
            }
        }

        private void ModifyQty(int newQty)
        {
            textQty = "Qté : " + newQty;
            textQtyFicheDay.Text = textQty;
        }

        private void DisplayAlerte()
        {
            image_alerte.Visibility = Visibility.Visible;
            dispAlerte = true;
        }

        private void HideAlerte()
        {
            image_alerte.Visibility = Visibility.Collapsed;
            dispAlerte = false;
        }

        private void DisplayWarning()
        {
            image_warning.Visibility = Visibility.Visible;
            dispWarning = true;
        }

        private void HideWarning()
        {
            image_warning.Visibility = Visibility.Collapsed;
            dispWarning = false;
        }

        private void ModifyFiche(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ClickModifyFiche(idFiche);
        }

        private void ValidateFabricationFiche(object sender, RoutedEventArgs e)
        {
            Brain.Instance.DemandValidationFiche(idFiche);
        }

        private void PlacementFicheAuto(object sender, RoutedEventArgs e)
        {
            Brain.Instance.PlacementFicheAuto(idFiche);
        }
    }
}
