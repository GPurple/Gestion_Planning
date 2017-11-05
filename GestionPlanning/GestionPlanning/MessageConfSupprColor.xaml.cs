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
    /// Logique d'interaction pour MessageConfSupprColor.xaml
    /// </summary>
    public partial class MessageConfSupprColor : Window
    {
        public String name;
        public MessageConfSupprColor(String nameRevet)
        {
            InitializeComponent();
            name = nameRevet;
        }
        
        private void ConfirmRetraitRevet(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ConfirmRetraitRevet(name);
        }

        private void CancelSupprRevet(object sender, RoutedEventArgs e)
        {
            Brain.Instance.CancelRetraitRevet(name);
        }
    }
}
