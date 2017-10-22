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
    /// Logique d'interaction pour UC_Display_Simple.xaml
    /// </summary>
    public partial class UC_Display_Simple : UserControl
    {
        public UC_Display_Simple()
        {
            InitializeComponent();
            Brain.Instance.ucDispSimple = this;
        }

        public void RefreshListToDisplay(List<Fiche> listeSimple)
        {
            //revoir synchro 
            StackPanelDisplayListe.Children.Clear();
            foreach (Fiche fiche in listeSimple)
            {
                if (fiche.check == false)
                {
                    UC_fiche_day ucfd = new UC_fiche_day(fiche.id, fiche.name, fiche.dateLivraison, fiche.quantiteElement, fiche.attentionRetard, fiche.alerteRetard, fiche.typeOperation, fiche.recouvrement, fiche.dateDebutFabrication, fiche.tempsFabrication,true);
                    StackPanelDisplayListe.Children.Add(ucfd);
                }
            }
            int nbList = StackPanelDisplayListe.Children.Count;
            StackPanelDisplayListe.Height = nbList * 50;
        }
    }
}
