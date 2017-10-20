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
            Brain.Instance.mainWindow = this;
            Brain.Instance.InitDisplay();
            image_alerteGeneral.Visibility = Visibility.Collapsed;
            image_warningGeneral.Visibility = Visibility.Collapsed;
        }

        /**
         * @brief Lancement du test 1
        * @note Test de sauvegarde et chargement des données 
        * @param none
        * */
        private void StartTest1(object sender, RoutedEventArgs e)
        {
            textStateTest1.Text = "start";
            if (Brain.Instance.Test1_saveLoadDatas_dummy() == 1)
            {
                textStateTest1.Text = "OK";
            }
            else
            {
                textStateTest1.Text = "echec";
            }
        }

        private void StartTest2(object sender, RoutedEventArgs e)
        {
            textStateTest2.Text = "start";
            if (Brain.Instance.Test2_saveLoadDatas_dummy() == 1)
            {
                textStateTest2.Text = "OK";
            }
            else
            {
                textStateTest2.Text = "echec";
            }
        }

        private void StartTest3(object sender, RoutedEventArgs e)
        {
            Brain.Instance.Test3_displayListe();
        }
        
        /*
         * display week
         * -> obtenir la référence de la liste
         * -> afficher les elements de la liste un à un -> if(week) display listeFichesWeek.monday.element(n)
         * display day
         * next week
         * precedent week
         * current week
         * tri name
         * tri operation(fabrication/affutage/all)
         * tri recouvrement(oui/non/all)
         * annuler tris (les tris peuvent s'additionner)
         * options
         *  -> modifier nom fichier géneré? -> l'écrire dans un fichier de sauvegarde d'options
         *  -> modifier emplacement fichier géneré -> l'écrire dans un fichier de sauvegarde d'options
         *  -> modifier emplacement txt? 
         *  -> changer couleurs?
         *  
         * */

        public void DisplayFichesNotPlaced(List<Fiche> liste)
        {
            STFichesNotPlaced.Children.Clear();
            foreach (Fiche fiche in liste)
            {
                UC_Fiche_week dspFicheWeek = new UC_Fiche_week(fiche.id, fiche.name, fiche.dateLivraison, fiche.quantiteElement, fiche.attentionRetard, fiche.alerteRetard, fiche.typeOperation, fiche.recouvrement);
                STFichesNotPlaced.Children.Add(dspFicheWeek);
            }
            int nbList = STFichesNotPlaced.Children.Count;
            STFichesNotPlaced.Height = nbList * 90;
        }

        private void EraseDataFichierSauvegarde(object sender, RoutedEventArgs e)
        {
            Brain.Instance.EraseDataFichierSauvegarde();
        }
    }
}
