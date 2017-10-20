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
    /// Logique d'interaction pour UC_fiche_month.xaml
    /// </summary>
    public partial class UC_fiche_month : UserControl
    {
        private String textNbFiches = "Nombre fiches : ";
        private bool dispWarning = false;
        private bool dispAlerte = false;

        public UC_fiche_month()
        {
            InitializeComponent();
        }
    }
}
