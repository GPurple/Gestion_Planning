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
    /// Logique d'interaction pour UC_Disp_Controls.xaml
    /// </summary>
    public partial class UC_Disp_Controls : UserControl
    {
        //liste combobox nom 
        //liste machine

        public UC_Disp_Controls()
        {
            InitializeComponent();
            Brain.Instance.ucDispControl = this;
            ComboBoxName.Items.Add("Tous noms");
            ComboBoxName.SelectedItem = "Tous noms";

            ComboBoxOperation.Items.Add("Toutes operations");
            ComboBoxOperation.Items.Add("Fabrication");
            ComboBoxOperation.Items.Add("Aiguisage");
            ComboBoxOperation.Items.Add("NA");
            ComboBoxOperation.SelectedItem = "Toutes operations";

            ComboBoxSearchReco.Items.Add("Tous recouvrements");
            ComboBoxSearchReco.Items.Add("Oui");
            ComboBoxSearchReco.Items.Add("Non");
            ComboBoxSearchReco.SelectedItem = "Tous recouvrements";

            ComboBoxSearchMachine.Items.Add("Toutes machines");
            ComboBoxSearchMachine.SelectedItem = "Toutes machines";

            ComboBoxSearchRetard.Items.Add("Tous retards");
            ComboBoxSearchRetard.Items.Add("Attention");
            ComboBoxSearchRetard.Items.Add("Alerte");
            ComboBoxSearchRetard.Items.Add("Alerte/retard");
            ComboBoxSearchRetard.Items.Add("Sans problème");
            ComboBoxSearchRetard.SelectedItem = "Tous retards";
        }

        private void DisplayDay(object sender, RoutedEventArgs e)
        {
            Brain.Instance.DisplayDay();
        }

        private void DisplayWeek(object sender, RoutedEventArgs e)
        {
            Brain.Instance.DisplayWeek();
        }

        private void DisplayMonth(object sender, RoutedEventArgs e)
        {
            Brain.Instance.DisplayMonth();
        }

        private void DisplayListeSimple(object sender, RoutedEventArgs e)
        {
            Brain.Instance.DisplayListeSimple();
        }

        private void ResetDay(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ResetDay();
        }

        private void ResetWeek(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ResetWeek();
        }

        private void ResetMonth(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ResetMonth();
        }

        private void RefreshData(object sender, RoutedEventArgs e)
        {
            Brain.Instance.RefreshData();
        }

        private void PlacementAuto(object sender, RoutedEventArgs e)
        {
            Brain.Instance.PlacementAutoAll();
        }

        private void ReplacementRetardAuto(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ReplacementRetardAutoAll();
        }

        private void SaveData(object sender, RoutedEventArgs e)
        {
            Brain.Instance.SaveListeInData();
        }

        public void SetListName(List<String> listeName)
        {
            ComboBoxName.Items.Clear();
            ComboBoxName.Items.Add("Tous noms");
            ComboBoxName.SelectedItem = "Tous noms";

            foreach (String name in listeName)
            {
                if (!ComboBoxName.Items.Contains(name))
                {
                    ComboBoxName.Items.Add(name);
                }
            }
        }

        public void SetListMachine(List<String> listeMachine)
        {
            ComboBoxSearchMachine.Items.Clear();
            ComboBoxSearchMachine.Items.Add("Toutes machines");
            ComboBoxSearchMachine.SelectedItem = "Toutes machines";

            foreach (String machine in listeMachine)
            {
                if (!ComboBoxSearchMachine.Items.Contains(machine))
                {
                    ComboBoxSearchMachine.Items.Add(machine);
                }
            }
        }

        private void SearchFiches(object sender, RoutedEventArgs e)
        {
            Brain.Instance.TriFiches(ComboBoxName.Text,
                ComboBoxOperation.Text,
                ComboBoxSearchReco.Text,
                ComboBoxSearchMachine.Text,
                ComboBoxSearchRetard.Text
                );
        }

        private void CreateFiche(object sender, RoutedEventArgs e)
        {
            Brain.Instance.CreateFiche();
        }
    }
}
