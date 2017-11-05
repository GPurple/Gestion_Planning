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

        public void ResizeDispMachine()
        {
            this.Height = (int)(Values.Instance.HEIGHT_DISP_MAIN);
            scrollViewListe.Width = (int)(Values.Instance.WIDTH_DISP_MAIN * 0.96);
            scrollViewListe.Height = (int)(Values.Instance.HEIGHT_DISP_MAIN * 0.85);
            scrollViewListe.Margin = new Thickness((int)(Values.Instance.WIDTH_DISP_MAIN * 0), (int)(Values.Instance.HEIGHT_DISP_MAIN * 0.1), 0, 0);
        }

        public void RefreshListToDisplay(List<Fiche> listeSimple)
        {
            ResizeDispMachine();
            StackPanelDisplayListe.Children.Clear();
            foreach (Fiche fiche in listeSimple)
            {
                if (fiche.check == false)
                {
                    UC_fiche_day ucfd = new UC_fiche_day(fiche);
                    StackPanelDisplayListe.Children.Add(ucfd);
                }
            }
            int nbList = StackPanelDisplayListe.Children.Count;
            StackPanelDisplayListe.Height = nbList * 50;
        }
    }
}
