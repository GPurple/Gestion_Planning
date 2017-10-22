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
    /// Logique d'interaction pour UC_Fiche_week.xaml
    /// </summary>
    public partial class UC_Fiche_week : UserControl
    {
        private int idFiche = -1;
        private String textId = "Id : ";
        private String textName = "Nom : ";
        private String textDate = "Livraison : ";
        private String textQty = "Qté : ";
        private String textHeureFab = "Heure fab : ";
        private String textTimeFab = "Temps fab : ";
        private Color colorLeft_op = Colors.White;
        private Color colorRight_rec = Colors.White;
        private bool dispWarning = false;
        private bool dispAlerte = false;

        public UC_Fiche_week()
        {
            InitializeComponent();
            textIDficheWeek.Text = textId;
            textNameFicheWeek.Text = textName;
            textDateFicheWeek.Text = textDate;
            textQtyFicheWeek.Text = textQty;
            textHeureFabFicheWeek.Text = textHeureFab;
            textTempsFabFicheWeek.Text = textTimeFab;
            image_alerte.Visibility = Visibility.Collapsed; 
            image_warning.Visibility = Visibility.Collapsed;


        }

        public UC_Fiche_week(int newId, String newName, DateTime newDateLivraison, int newQty, bool newDispWarning, bool newDispAlerte, TypeOperation op, bool rec, DateTime newDateFabrication, int timeFab)
        {
            //TODO ajouter temps et heure fabrication et heure
            InitializeComponent();
            idFiche = newId;
            ModifyId(newId);
            ModifyName(newName);
            ModifyDate(newDateLivraison);
            ModifyTimeFab(timeFab);
            ModifyHourFab(newDateFabrication);
            ModifyQty(newQty);
            if (newDispAlerte == true)
            {
                DisplayAlerte();
            }
            else
            {
                HideAlerte();
            }
            if (newDispWarning == true)
            {
                DisplayWarning();
            }
            else
            {
                HideWarning();
            }
            switch (op)
            {
                case TypeOperation.na:
                    colorLeft_op = Colors.White;
                    break;
                case TypeOperation.fabrication:
                    colorLeft_op = Colors.LawnGreen;
                    break;
                case TypeOperation.aiguisage:
                    colorLeft_op = Colors.Firebrick;
                    break;
                default:
                    colorLeft_op = Colors.White;
                    break;
            }
            rectangleLeft_op.Fill = new SolidColorBrush(colorLeft_op);

            if (rec == true)
            {
                colorRight_rec = Colors.Gold;
            }
            else
            {
                colorRight_rec = colorLeft_op;
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

        public void ModifyDate(DateTime newDate)
        {
            if (newDate.CompareTo(new DateTime(2000, 1, 1)) > 0)
            {
                textDate = "Livraison : " + newDate.Day + "/" + newDate.Month + "/" + newDate.Year;
                textDateFicheWeek.Text = textDate;
            }
            else
            {
                textDate = "Livraison : NA";
                textDateFicheWeek.Text = textDate;
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
