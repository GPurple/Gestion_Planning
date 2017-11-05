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

namespace GestionPlanning
{
    /// <summary>
    /// Logique d'interaction pour Window_Create_Fiche.xaml
    /// </summary>
    public partial class Window_Create_Fiche : Window
    {      
        public Window_Create_Fiche(List<TypeColor> listeColors)
        {
            InitializeComponent();
            DateTime dateNow = DateTime.Now;
            textBoxDateFabrication.Text = dateNow.Day + "/" + dateNow.Month + "/" + dateNow.Year;
            textBoxDateLivraison.Text = dateNow.Day + "/" + dateNow.Month + "/" + dateNow.Year;

            imageAttention_ID.Visibility = Visibility.Collapsed;
            imageAttention_dateLiv.Visibility = Visibility.Collapsed;
            imageAttention_dateFab.Visibility = Visibility.Collapsed;
            imageAttention_heureFab.Visibility = Visibility.Collapsed;
            imageAttention_TempsFab.Visibility = Visibility.Collapsed;
            imageAttention_NumMach.Visibility = Visibility.Collapsed;
            imageAttention_QtyEl.Visibility = Visibility.Collapsed;
            imageAttention_SizeText.Visibility = Visibility.Collapsed;

            bool first = true;
            foreach (TypeColor color in listeColors)
            {
                comboBoxRevetement.Items.Add(color.name);
                if (first == true)
                {
                    comboBoxRevetement.SelectedItem = color.name;
                }
            }
        }

        private void ValiderCreationFiche(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ValidateCreationFiche();
        }

        private void CancelCreationFiche(object sender, RoutedEventArgs e)
        {
            Brain.Instance.CancelCreationFiche();
        }
        
    }
}
