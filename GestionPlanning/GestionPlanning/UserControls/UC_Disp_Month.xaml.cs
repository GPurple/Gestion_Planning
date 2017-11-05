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
    /// Logique d'interaction pour UC_Disp_Month.xaml
    /// </summary>
    public partial class UC_Disp_Month : UserControl
    {
        DateTime monthToDisplay = DateTime.Now;
        UC_fiche_month[,] tabFicheDispMonth = new UC_fiche_month[5, 7];

        public UC_Disp_Month()
        {
            InitializeComponent();
            Brain.Instance.ucDispMonth = this;
        }

        public void ResizeDispMachine()
        {
            //TODO afficher les boutons
            BtnPreviousMonth.Margin = new Thickness((int)(Values.Instance.WIDTH_DISP_MAIN * 0.05), (int)(Values.Instance.HEIGHT_DISP_MAIN * 0.03), 0, 0);
            btnNextMonth.Margin = new Thickness((int)(Values.Instance.WIDTH_DISP_MAIN * 0.85), (int)(Values.Instance.HEIGHT_DISP_MAIN * 0.03), 0, 0);


            Canva_disp_fiche.Width = (int)(Values.Instance.WIDTH_DISP_MAIN * 0.96);
            Canva_disp_fiche.Height = (int)(Values.Instance.HEIGHT_DISP_MAIN * 0.9);
            Canva_disp_fiche.Margin = new Thickness((int)(Values.Instance.WIDTH_DISP_MAIN * 0.03), (int)(Values.Instance.HEIGHT_DISP_MAIN * 0.1), 0, 0);
        }       

        public void RefreshMonthToDisplay(DateTime newDayToDisplay, ListeFichesMonth listeFichesMonth)
        {

            ResizeDispMachine();

            monthToDisplay = newDayToDisplay;
            TextMonth.Text = monthToDisplay.Month + "/" + monthToDisplay.Year;

            Canva_disp_fiche.Children.Clear();
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    UC_fiche_month ucFicheMonth = new UC_fiche_month(listeFichesMonth.tabMonthFicheDay[j, i]);
                    Canva_disp_fiche.Children.Add(ucFicheMonth);

                    Canvas.SetLeft(ucFicheMonth, i * (int)(Values.Instance.WIDTH_FICHE_MONTH));
                    Canvas.SetTop(ucFicheMonth, j * (int)(Values.Instance.HEIGHT_FICHE_MONTH));

                    ucFicheMonth.Width = (int)(Values.Instance.WIDTH_FICHE_MONTH);
                    ucFicheMonth.Height = (int)(Values.Instance.HEIGHT_FICHE_MONTH);
                }
            }
        }

        private void PreviousMonth(object sender, RoutedEventArgs e)
        {
            Brain.Instance.PreviousMonth();
        }

        private void NextMonth(object sender, RoutedEventArgs e)
        {
            Brain.Instance.NextMonth();
        }
    }
}
