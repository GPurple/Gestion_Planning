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
    /// Logique d'interaction pour UC_Fiche_Machine.xaml
    /// </summary>
    public partial class UC_Fiche_Machine : UserControl
    {
        
        private int idFiche = -1;
        private String textId = "Id : ";
        private String textName = "Nom : ";
        private String textDateLiv = "Livraison : ";
        private String textDateFab = "Fabrication : ";
        private String textQty = "Qté : ";
        private String textHeureFab = "Heure fab : ";
        private String textTimeFab = "Temps fab : ";
        private Color colorLeft_op = Values.COLOR_NA;
        private Color colorRight_rec = Values.COLOR_NA;
        private bool dispWarning = false;
        private bool dispAlerte = false;

        public UC_Fiche_Machine()
        {
            InitializeComponent();
            textIDficheWeek.Text = textId;
            textNameFicheWeek.Text = textName;
            textDateLivFicheWeek.Text = textDateLiv;
            textDateFabFicheWeek.Text = textDateLiv;
            textQtyFicheWeek.Text = textQty;
            textHeureFabFicheWeek.Text = textHeureFab;
            textTempsFabFicheWeek.Text = textTimeFab;
            image_alerte.Visibility = Visibility.Collapsed;
            image_warning.Visibility = Visibility.Collapsed;            
        }
        
        public UC_Fiche_Machine(Fiche newFiche)
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

        public void ModifyId(int newId)
        {
            textId = "Id : " + newId;
            textIDficheWeek.Text = textId;
        }

        public void ModifyName(String newName)
        {
            textName = "Nom : " + newName;
            textNameFicheWeek.Text = textName;
        }

        public void ModifyDateFab(DateTime newDate)
        {
            if (newDate.CompareTo(new DateTime(2000, 1, 1)) > 0)
            {
                textDateFab = "Fabrication : " + newDate.Day + "/" + newDate.Month + "/" + newDate.Year;
                textDateFabFicheWeek.Text = textDateFab;
            }
            else
            {
                textDateFab = "Fabrication : NA";
                textDateFabFicheWeek.Text = textDateFab;
            }
        }

        public void ModifyDateLiv(DateTime newDate)
        {
            if (newDate.CompareTo(new DateTime(2000, 1, 1)) > 0)
            {
                textDateLiv = "Livraison : " + newDate.Day + "/" + newDate.Month + "/" + newDate.Year;
                textDateLivFicheWeek.Text = textDateLiv;
            }
            else
            {
                textDateLiv = "Livraison : NA";
                textDateLivFicheWeek.Text = textDateLiv;
            }
        }

        public void ModifyTimeFab(int timeFab)
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

        public void ModifyHourFab(DateTime newDate)
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

        public void ModifyQty(int newQty)
        {
            textQty = "Qté : " + newQty;
            textQtyFicheWeek.Text = textQty;
        }

        public void DisplayAlerte()
        {
            image_alerte.Visibility = Visibility.Visible;
            dispAlerte = true;
        }

        public void HideAlerte()
        {
            image_alerte.Visibility = Visibility.Collapsed;
            dispAlerte = false;
        }

        public void DisplayWarning()
        {
            image_warning.Visibility = Visibility.Visible;
            dispWarning = true;
        }

        public void HideWarning()
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

        private void PlacementAutoFiche(object sender, RoutedEventArgs e)
        {
            Brain.Instance.PlacementFicheAuto(idFiche);
        }
    }
}
