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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Window_Identification winIdentification = new Window_Identification();
            Brain.Instance.WinPageIdentification = winIdentification;
            winIdentification.Show();
            this.Hide();
            Brain.Instance.mainWindow = this;
            Brain.Instance.InitDisplay();
            //image_alerteGeneral.Visibility = Visibility.Collapsed;
            //image_warningGeneral.Visibility = Visibility.Collapsed;
            UC_modif_fiche.Visibility = Visibility.Collapsed;
        }

        public void DisplayFichesNotPlaced(List<Fiche> liste)
        {
            STFichesNotPlaced.Children.Clear();
            foreach (Fiche fiche in liste)
            {
                UC_Fiche_week dspFicheWeek = new UC_Fiche_week(fiche.id, fiche.name, fiche.dateLivraison, fiche.quantiteElement, fiche.attentionRetard, fiche.alerteRetard, fiche.typeOperation, fiche.recouvrement, fiche.dateDebutFabrication, fiche.tempsFabrication);
                STFichesNotPlaced.Children.Add(dspFicheWeek);
            }
            int nbList = STFichesNotPlaced.Children.Count;
            STFichesNotPlaced.Height = nbList * 145;
        }

        private void EraseDataFichierSauvegarde(object sender, RoutedEventArgs e)
        {
            Brain.Instance.EraseDataFichierSauvegarde();
        }
    }
}
