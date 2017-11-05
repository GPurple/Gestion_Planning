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
    /// Logique d'interaction pour UC_Disp_modifs.xaml
    /// </summary>
    public partial class UC_Disp_modifs : UserControl
    {
        public UC_Disp_modifs()
        {
            InitializeComponent();
            Brain.Instance.ucDispModifs = this;
        }

        public void ResizeDispModif()
        {
            rectangleDisp.Width = (int)(Values.Instance.WIDTH_DISP_MAIN * 0.90);
            rectangleDisp.Height = (int)(Values.Instance.HEIGHT_DISP_MAIN * 0.83);
            rectangleDisp.Margin = new Thickness((int)(Values.Instance.WIDTH_DISP_MAIN * 0), (int)(Values.Instance.HEIGHT_DISP_MAIN * 0.10), 0, 0);
            
            scrollViewerDisp.Width = (int)(Values.Instance.WIDTH_DISP_MAIN * 0.90);
            scrollViewerDisp.Height = (int)(Values.Instance.HEIGHT_DISP_MAIN * 0.83);
            scrollViewerDisp.Margin = new Thickness((int)(Values.Instance.WIDTH_DISP_MAIN * 0), (int)(Values.Instance.HEIGHT_DISP_MAIN * 0.10), 0, 0);

            StackPanelModifs.Width = (int)(Values.Instance.WIDTH_DISP_MAIN * 0.90);
            scrollViewerDisp.Height = (int)(Values.Instance.HEIGHT_DISP_MAIN * 0.83);
            scrollViewerDisp.Margin = new Thickness((int)(Values.Instance.WIDTH_DISP_MAIN * 0), (int)(Values.Instance.HEIGHT_DISP_MAIN * 0.10), 0, 0);

        }


        public void DisplayModifs(DataSaveModif data)
        {
            ResizeDispModif();

            StackPanelModifs.Children.Clear();
            StackPanelModifs.Height = 0;
            foreach (Modification modif in data.listeModifs)
            {

                TextBlock text = new TextBlock();
                text.Text = modif.dateModif.ToString() + " - " + modif.nameUser + " - " + modif.text;
                if(modif.modification == TypeModification.modifFiche)
                {
                    text.Text = text.Text + " - Fiche : " + modif.idFiche;
                }
                if (modif.modification == TypeModification.validationFiche)
                {
                    text.Text = text.Text + " - Fiche : " + modif.idFiche;
                }
                StackPanelModifs.Children.Add(text);
                StackPanelModifs.Height = StackPanelModifs.Height + text.Height;
            }
        }
    }
}
