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
        public UC_modif_fiche()
        {
            InitializeComponent();
            Brain.Instance.ucModifFiche = this;
        }

        private void AnnulerModifFiche(object sender, RoutedEventArgs e)
        {
            Brain.Instance.CancelModificationFiche(0);
        }

        private void ValiderModifFiche(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ValidateModificationFiche(0);
        }

        public void ModifyDataFiche(Fiche fiche)
        {

            textId.Text = "ID : " + fiche.id;
            TextBoxQty.Text = "" + fiche.quantiteElement;
                //int id, int qty, DateTime dateLivraison, DateTime date
        }
    }
}
