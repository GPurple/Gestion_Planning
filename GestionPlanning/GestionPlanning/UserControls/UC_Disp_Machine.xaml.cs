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
    /// Logique d'interaction pour UC_Disp_Machine.xaml
    /// </summary>
    public partial class UC_Disp_Machine : UserControl
    {
        public UC_Disp_Machine()
        {
            InitializeComponent();
        }

        public void RefreshListToDisplay(ListeFicheMachines listeFichesMachines)
        {
            int nbMachine = 0;
            int sizeMax = 0;
            int nbFiches = 0;

            canvasDispListesMachines.Children.Clear();

            foreach (ListeMachine machine in listeFichesMachines.listeFichesByMachines)
            {
                
                UC_DispListe_Revet ucDispList = new UC_DispListe_Revet();
                nbFiches = 0;

                TextBlock textBlockNameMachine = new TextBlock();
                Canvas.SetLeft(textBlockNameMachine, nbMachine * 150 + 30);
                Canvas.SetTop(textBlockNameMachine, 20);
                textBlockNameMachine.Foreground = new SolidColorBrush(Colors.White);
                canvaDispNamesMachines.Children.Add(textBlockNameMachine);

                textBlockNameMachine.Text = machine.nameMachine;

                foreach (Fiche fiche in machine.listeFiches)
                {
                    ucDispList.stackPanelListMachine.Children.Add(new UC_Fiche_Machine(fiche));
                    nbFiches++;
                }
                if (sizeMax < nbFiches)
                {
                     sizeMax = nbFiches;
                }
                canvasDispListesMachines.Children.Add(ucDispList);
                Canvas.SetLeft(ucDispList, nbMachine * 150);
                ucDispList.stackPanelListMachine.Height = nbFiches * 160;
                ucDispList.Height = nbFiches * 160;
                nbMachine++;
            }

            //modifier dimension stack panel Hauteur et largeur en fonctino des données
            canvasDispListesMachines.Height = sizeMax * 160;
            canvasDispListesMachines.Width = nbMachine * 150 + 15;
            scrollViewerDispMachines.Width = nbMachine * 150 + 15;
            gridDispMachines.Width = nbMachine * 150 + 15;

        }
    }
}
