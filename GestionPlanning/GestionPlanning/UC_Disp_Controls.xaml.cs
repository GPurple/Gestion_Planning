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
            ComboBoxName.Items.Add("All");
            ComboBoxName.SelectedItem = "All";

            ComboBoxOperation.Items.Add("All");
            ComboBoxOperation.Items.Add("Fabrication");
            ComboBoxOperation.Items.Add("Aiguisage");
            ComboBoxOperation.Items.Add("NA");
            ComboBoxOperation.SelectedItem = "All";

            ComboBoxSearchReco.Items.Add("All");
            ComboBoxSearchReco.Items.Add("Oui");
            ComboBoxSearchReco.Items.Add("Non");
            ComboBoxSearchReco.SelectedItem = "All";

            ComboBoxSearchMachine.Items.Add("All");
            ComboBoxSearchMachine.SelectedItem = "All";

            ComboBoxSearchRetard.Items.Add("All");
            ComboBoxSearchRetard.Items.Add("Attention");
            ComboBoxSearchRetard.Items.Add("Alerte");
            ComboBoxSearchRetard.Items.Add("Alerte/retard");
            ComboBoxSearchRetard.Items.Add("Sans problème");
            ComboBoxSearchRetard.SelectedItem = "All";
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
            ComboBoxName.Items.Add("All");
            ComboBoxName.SelectedItem = "All";

            foreach (String name in listeName)
            {
                if (!ComboBoxName.Items.Contains(name))
                {
                    ComboBoxName.Items.Add(name);
                }
            }
        }

        public void SetListNumMachine(List<int> listeNumMachine)
        {
            ComboBoxSearchMachine.Items.Clear();
            ComboBoxSearchMachine.Items.Add("All");
            ComboBoxSearchMachine.SelectedItem = "All";

            foreach (int numero in listeNumMachine)
            {
                if (!ComboBoxSearchMachine.Items.Contains(numero))
                {
                    ComboBoxSearchMachine.Items.Add(numero);
                }
            }
        }


        private void SearchByName(object sender, RoutedEventArgs e)
        {
            String item = ComboBoxName.Text;
            Brain.Instance.SearchByName(item);
        }

        private void SearchByOperation(object sender, RoutedEventArgs e)
        {
            String item = ComboBoxOperation.Text;
            Brain.Instance.SearchByOperation(item);
        }

        private void SearchReco(object sender, RoutedEventArgs e)
        {
            //TODO
            String item = ComboBoxSearchReco.Text;
            Brain.Instance.SearchByReco(item);
        }

        private void SearchNumMachine(object sender, RoutedEventArgs e)
        {
            String item = ComboBoxSearchMachine.Text;
            Brain.Instance.SearchByMachine(item);
        }

        private void SearchNumRetard(object sender, RoutedEventArgs e)
        {
            String item = ComboBoxSearchMachine.Text;
            Brain.Instance.SearchByRetard(item);
        }

        
    }
}
