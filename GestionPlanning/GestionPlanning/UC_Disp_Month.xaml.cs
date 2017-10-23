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

        public void RefreshMonthToDisplay(DateTime newDayToDisplay, ListeFichesMonth listeFichesMonth)
        {
            monthToDisplay = newDayToDisplay;
            TextMonth.Text = monthToDisplay.Month + "/" + monthToDisplay.Year;

            Canva_disp_fiche.Children.Clear();
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    UC_fiche_month ucFicheMonth = new UC_fiche_month(listeFichesMonth.tabMonthFicheDay[j, i]);
                    //TODO modifier ucFicheMonth avec listeFichesMonth.tabMonthFicheDay[j, i];
                    Canva_disp_fiche.Children.Add(ucFicheMonth);
                    Canvas.SetLeft(ucFicheMonth, i * 120);
                    Canvas.SetTop(ucFicheMonth, j * 90);
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
