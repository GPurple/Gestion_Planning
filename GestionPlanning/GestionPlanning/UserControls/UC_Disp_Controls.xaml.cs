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

            ComboBoxSearchReco.Items.Add("Tous revêtements");
            ComboBoxSearchReco.SelectedItem = "Tous revêtements";

            ComboBoxSearchMachine.Items.Add("Toutes machines");
            ComboBoxSearchMachine.SelectedItem = "Toutes machines";

            ComboBoxSearchRetard.Items.Add("Tous retards");
            ComboBoxSearchRetard.Items.Add("Attention");
            ComboBoxSearchRetard.Items.Add("Alerte");
            ComboBoxSearchRetard.Items.Add("Alerte/retard");
            ComboBoxSearchRetard.Items.Add("Sans problème");
            ComboBoxSearchRetard.SelectedItem = "Tous retards";

            CollapseAllZones();

        }

        private void DisplayDay(object sender, RoutedEventArgs e)
        {
            Brain.Instance.DisplayDay();
            CollapseAllZones();
        }

        private void DisplayWeek(object sender, RoutedEventArgs e)
        {
            Brain.Instance.DisplayWeek();
            CollapseAllZones();
        }

        private void DisplayMonth(object sender, RoutedEventArgs e)
        {
            Brain.Instance.DisplayMonth();
            CollapseAllZones();
        }

        private void DisplayListeSimple(object sender, RoutedEventArgs e)
        {
            Brain.Instance.DisplayListeSimple();
            CollapseAllZones();
        }

        private void ResetDay(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ResetDay();
            CollapseAllZones();
        }

        private void ResetWeek(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ResetWeek();
            CollapseAllZones();
        }

        private void ResetMonth(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ResetMonth();
            CollapseAllZones();
        }

        private void RefreshData(object sender, RoutedEventArgs e)
        {
            Brain.Instance.RefreshData();
            CollapseAllZones();
        }

        private void PlacementAuto(object sender, RoutedEventArgs e)
        {
            Brain.Instance.PlacementAutoAll();
            CollapseAllZones();
        }

        private void ReplacementRetardAuto(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ReplacementRetardAutoAll();
            CollapseAllZones();
        }

        private void SaveData(object sender, RoutedEventArgs e)
        {
            Brain.Instance.SaveListeInData();
            CollapseAllZones();
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
            CollapseAllZones();
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
            CollapseAllZones();
        }

        public void SetListRevetements(List<TypeColor> listeColors)
        {
            ComboBoxSearchReco.Items.Clear();
            ComboBoxSearchReco.Items.Add("Tous revêtements");
            ComboBoxSearchReco.SelectedItem = "Tous revêtements";
            foreach (TypeColor color in listeColors)
            {
                ComboBoxSearchReco.Items.Add(color.name);
            }
            CollapseAllZones();
        }

        private void SearchFiches(object sender, RoutedEventArgs e)
        {
            Brain.Instance.TriFiches(ComboBoxName.Text,
                ComboBoxOperation.Text,
                ComboBoxSearchReco.Text,
                ComboBoxSearchMachine.Text,
                ComboBoxSearchRetard.Text,
                textBoxBCCM.Text
                );
            CollapseAllZones();
        }

        private void CreateFiche(object sender, RoutedEventArgs e)
        {
            Brain.Instance.CreateFiche();
            CollapseAllZones();
        }

        private void DisplayListeMachines(object sender, RoutedEventArgs e)
        {
            Brain.Instance.DisplayListeMachines();
            CollapseAllZones();
        }

        private void CollapseAllZones()
        {
            canvasDispTri.Visibility = Visibility.Collapsed;
            canvasDispAffich.Visibility = Visibility.Collapsed;
            canvasDispModifsDatas.Visibility = Visibility.Collapsed;
            canvasDispParams.Visibility = Visibility.Collapsed;
            canvasDispPlacement.Visibility = Visibility.Collapsed;
        }

        private void DispButtonsTri(object sender, RoutedEventArgs e)
        {
            if (canvasDispTri.Visibility == Visibility.Collapsed)
            {
                CollapseAllZones();
                canvasDispTri.Visibility = Visibility.Visible;
                textBoxBCCM.Text = "BCCM";
            }
            else
            {
                CollapseAllZones();
            }
        }

        private void DispButtonAffichage(object sender, RoutedEventArgs e)
        {            
            if (canvasDispAffich.Visibility == Visibility.Collapsed)
            {
                CollapseAllZones();
                canvasDispAffich.Visibility = Visibility.Visible;
            }
            else
            {
                CollapseAllZones();
            }
        }

        private void DispButtonParam(object sender, RoutedEventArgs e)
        {
            if (canvasDispParams.Visibility == Visibility.Collapsed)
            {
                CollapseAllZones();
                canvasDispParams.Visibility = Visibility.Visible;
            }
            else
            {
                CollapseAllZones();
            }
        }
        
        private void DispButtonPlacement(object sender, RoutedEventArgs e)
        {
            if (canvasDispPlacement.Visibility == Visibility.Collapsed)
            {
                CollapseAllZones();
                canvasDispPlacement.Visibility = Visibility.Visible;
            }
            else
            {
                CollapseAllZones();
            }
        }

        private void DispButtonModifs_Click(object sender, RoutedEventArgs e)
        {
            if (canvasDispModifsDatas.Visibility == Visibility.Collapsed)
            {
                CollapseAllZones();
                canvasDispModifsDatas.Visibility = Visibility.Visible;
            }
            else
            {
                CollapseAllZones();
            }
        }

        private void DisplayModifs(object sender, RoutedEventArgs e)
        {
            Brain.Instance.DisplayListeModifs();
            CollapseAllZones();
        }

        private void ChangeUser(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ChangeUser();
            CollapseAllZones();
        }

        private void ModifyPathsFiles(object sender, RoutedEventArgs e)
        {
            Brain.Instance.DispWindowPaths();
            CollapseAllZones();
        }
                
        private void ModifyColors(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ClickModifyColor();
            CollapseAllZones();
        }

        private void ModifyChargeMachine(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ModifyChargeMachine();
            CollapseAllZones();
        }
    }
}
