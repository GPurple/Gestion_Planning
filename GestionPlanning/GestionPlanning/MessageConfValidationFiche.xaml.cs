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
    /// Logique d'interaction pour MessageConfValidationFiche.xaml
    /// </summary>
    public partial class MessageConfValidationFiche : Window
    {
        public int id;

        public MessageConfValidationFiche()
        {
            InitializeComponent();
        }

        public MessageConfValidationFiche(int idFiche)
        {
            id = idFiche;
            InitializeComponent();
            textMessageValidationFiche.Text = "Attention : La fiche " + idFiche + " va être validée comme effectuée";
        }

        private void ConfirmValidationFiche(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ValidateFabricationFiche(id);
        }

        private void CancelModifFiche(object sender, RoutedEventArgs e)
        {
            Brain.Instance.CancelFabricationFiche(id);
        }
    }
}
