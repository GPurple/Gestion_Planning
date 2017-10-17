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

        public UC_Disp_Month()
        {
            InitializeComponent();
            Brain.Instance.ucDispMonth = this;
        }

        public void RefreshMonthToDisplay(DateTime newDayToDisplay)
        {
            monthToDisplay = newDayToDisplay;
            TextMonth.Text = monthToDisplay.Month + "/" + monthToDisplay.Year;
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
