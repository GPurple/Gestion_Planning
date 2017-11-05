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
using static GestionPlanning.src.FichierSauvegarde;

namespace GestionPlanning
{
    /// <summary>
    /// Logique d'interaction pour Window_Modif_Colors.xaml
    /// </summary>
    public partial class Window_Modif_Colors : Window
    {
        public Window_Modif_Colors()
        {
            InitializeComponent();
        }

        public void DisplayColors(List<TypeColor> listeColors)
        {
            StackPanelDisplayRevetements.Children.Clear();
            foreach (TypeColor color in listeColors)
            {

                UC_Modif_Revet ucModifRevet = new UC_Modif_Revet(color);
                StackPanelDisplayRevetements.Children.Add(ucModifRevet);
            }
            int nbColor = StackPanelDisplayRevetements.Children.Count;
            StackPanelDisplayRevetements.Height = nbColor * 50;

            textNbColors.Text = nbColor + "/10";
        }

        private void ClickAddColor(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ClickAddColor();
        }

        private void CancelModif(object sender, RoutedEventArgs e)
        {
            Brain.Instance.CancelModifColors();
        }
    }
}
