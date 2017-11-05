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
    /// Logique d'interaction pour UC_display_day.xaml
    /// </summary>
    public partial class UC_display_day : UserControl
    {
        DateTime dayToDisplay = DateTime.Now;

        public UC_display_day()
        {
            InitializeComponent();
            TextDay.Text = dayToDisplay.Day + "/" + dayToDisplay.Month + "/" + dayToDisplay.Year;
            Brain.Instance.ucDispDay = this;
        }

        public void ResizeDispMachine()
        {
            btnPreviousDay.Margin = new Thickness((int)(Values.Instance.WIDTH_DISP_MAIN * 0.05), (int)(Values.Instance.HEIGHT_DISP_MAIN * 0.03), 0, 0);
            btnNextDay.Margin = new Thickness((int)(Values.Instance.WIDTH_DISP_MAIN * 0.85), (int)(Values.Instance.HEIGHT_DISP_MAIN * 0.03), 0, 0);
            
            scrollViewDispDay.Width = (int)(Values.Instance.WIDTH_DISP_MAIN * 0.96);
            scrollViewDispDay.Height = (int)(Values.Instance.HEIGHT_DISP_MAIN * 0.85);
            scrollViewDispDay.Margin = new Thickness((int)(Values.Instance.WIDTH_DISP_MAIN * 0), (int)(Values.Instance.HEIGHT_DISP_MAIN * 0.1), 0, 0);
        }

        private void Btn_PreviousDay(object sender, RoutedEventArgs e)
        {
            Brain.Instance.PreviousDay();
        }

        private void Btn_NextDay(object sender, RoutedEventArgs e)
        {
            Brain.Instance.NextDay();
        }

        public void RefreshDayToDisplay(DateTime newDayToDisplay)
        {

            ResizeDispMachine();
            dayToDisplay = newDayToDisplay;
            TextDay.Text = dayToDisplay.Day + "/" + dayToDisplay.Month + "/" + dayToDisplay.Year;
        }

        public void RefreshDayToDisplay()
        {

            ResizeDispMachine();
            TextDay.Text = dayToDisplay.Day + "/" + dayToDisplay.Month + "/" + dayToDisplay.Year;
        }

        public void RefreshListToDisplay(List<Fiche> listeDay)
        {
            ResizeDispMachine();
            StackPanelDisplayDay.Children.Clear();
            foreach (Fiche fiche in listeDay)
            {
                if (fiche.check == false)
                {
                    UC_fiche_day ucfd = new UC_fiche_day(fiche);
                    StackPanelDisplayDay.Children.Add(ucfd);
                }
            }
            int nbList = StackPanelDisplayDay.Children.Count;
            StackPanelDisplayDay.Height = nbList * 50;
        }
    }
}
