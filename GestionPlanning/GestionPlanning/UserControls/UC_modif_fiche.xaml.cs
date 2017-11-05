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
    /// Logique d'interaction pour UC_modif_fiche.xaml
    /// </summary>
    public partial class UC_modif_fiche : UserControl
    {
        public int idFiche = -1;
        public UC_modif_fiche()
        {
            InitializeComponent();
            imageAttention_dateLiv.Visibility = Visibility.Visible;
        }

        private void AnnulerModifFiche(object sender, RoutedEventArgs e)
        {
            Brain.Instance.CancelModificationFiche(idFiche);
        }

        private void ValiderModifFiche(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ValidateModificationFiche(idFiche);
        }

        public void ModifyDataFiche(Fiche fiche)
        {
            idFiche = fiche.id;
            textId.Text = "ID : " + fiche.id;
            textDateLivraison.Text = "Date livraison : " + fiche.dateLivraison.Day + "/" + fiche.dateLivraison.Month + "/" + fiche.dateLivraison.Year;
            textName.Text = "Nom :" + fiche.name;
            
            switch (fiche.typeOperation)
            {
                case TypeOperation.fabrication:
                    radioButtonOpFabrication.IsChecked = true;
                    break;
                case TypeOperation.aiguisage:
                    RadioButtonOpAffutage.IsChecked = true;
                    break;
                case TypeOperation.na:
                    RadioButtonOpNA.IsChecked = true;
                    break;
                default:
                    RadioButtonOpNA.IsChecked = true;
                    break;
            }
            
            
            textBoxDateLivraison.Text = fiche.dateLivraison.Day + "/" + fiche.dateLivraison.Month + "/" + fiche.dateLivraison.Year;
            textBoxDateFabrication.Text = fiche.dateDebutFabrication.Day + "/" + fiche.dateDebutFabrication.Month + "/" + fiche.dateDebutFabrication.Year;
            textBoxHeureFabrication.Text = fiche.dateDebutFabrication.Hour + ":" + fiche.dateDebutFabrication.Minute;
            textBoxTempsFabrication.Text = "" + fiche.tempsFabrication;
            TextBoxNumMachine.Text = "" + fiche.machine;
            TextBoxQty.Text = "" + fiche.quantiteElement;
            textBoxTextFiche.Text = fiche.textDescription;

            //TODO modif radio button
            //int id, int qty, DateTime dateLivraison, DateTime date
            imageAttention_dateLiv.Visibility = Visibility.Collapsed;
            imageAttention_dateFab.Visibility = Visibility.Collapsed;
            imageAttention_heureFab.Visibility = Visibility.Collapsed;
            imageAttention_TempsFab.Visibility = Visibility.Collapsed;
            imageAttention_NumMach.Visibility = Visibility.Collapsed;
            imageAttention_QtyEl.Visibility = Visibility.Collapsed;
            imageAttention_SizeText.Visibility = Visibility.Collapsed;
        }
    }
}
