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
    /// Logique d'interaction pour MessageConfRetraitFichePlanning.xaml
    /// </summary>
    public partial class MessageConfRetraitFichePlanning : Window
    {
        public int id;

        public MessageConfRetraitFichePlanning()
        {
            InitializeComponent();
        }

        public MessageConfRetraitFichePlanning(int idFiche)
        {
            id = idFiche;
            InitializeComponent();
            textMessageValidationFiche.Text = "Attention : La fiche " + idFiche + " va être retirée du planing et revenir dans les listes non placée";
        }

        private void ConfirmValidationRetrait(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ConfirmationPlacementFiche(id);
        }

        private void CancelRetraitFiche(object sender, RoutedEventArgs e)
        {
            Brain.Instance.CancelPlacementFiche(id);
        }
    }
}
