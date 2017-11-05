using GestionPlanning.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GestionPlanning
{
    class Revetement
    {

        public Color color = Colors.White;
        public String name = "";

        public Revetement()
        {

        }

        public Revetement(Color newColor, String newName)
        {
            color = newColor;
            name = newName;
        }
    }

    class Values
    {

        //Les couleurs d'affichage des types d'opération
        public static Color COLOR_AFF = Colors.LawnGreen;//colorAffutage
        public static Color COLOR_FAB = Colors.Firebrick;//colorFabrication
        public static Color COLOR_NA = Colors.White; //colorNA

        //La liste des couleurs des revêtements
        public List<Revetement> listeRevetements = new List<Revetement>();

        public int timeProdDay = 7;

        //largeurFicheDay
        public int WIDTH_FICHE_DAY; //TODO récupérer en fonction de quelque chose
        //LargeurFicheWeek
        public int WIDTH_FICHE_WEEK;
        //LargeurFicheMonth
        public int WIDTH_FICHE_MONTH;

        //hauteurFicheDay
        public int HEIGHT_FICHE_DAY;
        //hauteurFicheWeek
        public int HEIGHT_FICHE_WEEK;
        //hauteurFicheMonth
        public int HEIGHT_FICHE_MONTH;

        //largeurDisplayScreen
        public int WIDTH_DISP_MAIN;
        //HauteurDisplayScreen
        public int HEIGHT_DISP_MAIN;
        //positionXDisplayScreen
        public int POSX_DISP_MAIN;
        //positionYDisplayScreen
        public int POSY_DISP_MAIN;

        //largeurMenu
        public int WIDTH_MENU;
        //hauteurMenu
        public int HEIGHT_MENU;

        public static Color COLOR_CREAM = Colors.Cornsilk;
        public static Color COLOR_CYAN = Colors.Cyan;
        public static Color COLOR_GREEN = Colors.Green;
        public static Color COLOR_GRAY = Colors.Gray;
        public static Color COLOR_NIGHTBLUE = Colors.RoyalBlue;
        public static Color COLOR_ORANGE = Colors.Orange;
        public static Color COLOR_PINK = Colors.Pink;
        public static Color COLOR_PURPLE = Colors.Purple;
        public static Color COLOR_RED = Colors.Red;
        public static Color COLOR_LIGHTGREEN = Colors.PaleGreen;

        private static Values instance;
        public static Values Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Values();
                }
                return instance;
            }
        }
        private Values()
        {
            //TODO WIDTH_FICHE_DAY = 
            WIDTH_FICHE_DAY = (int)(Brain.Instance.mainWindow.Width * 0.95);

            WIDTH_DISP_MAIN = (int)(Brain.Instance.mainWindow.Width * 0.96);
            HEIGHT_DISP_MAIN= (int)(Brain.Instance.mainWindow.Height * 0.85);
            
            POSX_DISP_MAIN = (int)(Brain.Instance.mainWindow.Width * 0.01);
            POSY_DISP_MAIN = (int)(Brain.Instance.mainWindow.Height * 0.08);

            WIDTH_FICHE_MONTH = (int)(Brain.Instance.mainWindow.Width * 0.90 /7);
            HEIGHT_FICHE_MONTH = (int)(Brain.Instance.mainWindow.Height * 0.70 / 5);

            WIDTH_FICHE_DAY = (int)(Brain.Instance.mainWindow.Width * 0.70 );
            HEIGHT_FICHE_DAY = (int)(Brain.Instance.mainWindow.Height * 0.1);
        }

        
    }
}
