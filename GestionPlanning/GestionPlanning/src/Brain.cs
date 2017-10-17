using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static GestionPlanning.src.FichierSauvegarde;

namespace GestionPlanning.src
{
    enum DispPlanning { day, week, month } // day = 1
    enum TriOp { all, fab, aff }; //all = 1
    enum TriReco { all, yes, non }; //all = 1
    class Brain
    {
        //Affichage du jour ou de la semaine
        public DispPlanning dispPlanning = DispPlanning.week; 

        //Le jour à afficher ou le premier jour de la semaine ou du mois à afficher
        public DateTime dateToDisplay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day); 

        //Afficher les opérations
        public TriOp triOperation; //operation fabrication all=0/fabrication/affutage/ -> faire une enum

        //Afficher les recouvrements
        public TriReco triReco; //recouvrement all=0/oui/non/

        //La liste de fiches completes
        public List<Fiche> listeFiches = new List<Fiche>();

        //La liste de fiches pour une journée
        public List<Fiche> listeDay = new List<Fiche>();

        //La liste de fiches pour une semaine
        public ListeFichesWeek listeWeek = new ListeFichesWeek();

        //La liste de fiches pour une semaine
        public ListeFichesMonth listeMonth = new ListeFichesMonth();

        //La liste de fiches non placées
        public List<Fiche> listeNonPlacees = new List<Fiche>();

        //Le fichier de sauvegarde
        public FichierXcel fichierXcel = new FichierXcel();

        //Le fichier xcel
        public FichierSauvegarde fichierSauvegarde = new FichierSauvegarde();

        public MainWindow mainWindow;
        public UC_Disp_Controls ucDispControl;
        public UC_display_day ucDispDay;
        public UC_Display_week ucDispWeek;
        public UC_Disp_Month ucDispMonth;

        private static Brain instance;

        public static Brain Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Brain();
                }
                return instance;
            }
        }
        
        /**
         * @brief Initialisation du brain au démarrage
         * @note none
         * @param none
         */
        private Brain() {
            //TODO créer une pile d'évenements 
            //afficher de base la semaine actuelle
           
            dateToDisplay = DateTime.Now;
            dispPlanning = DispPlanning.week;
        }


        public void Main()
        {
            //start 
            fichierXcel.LoadFiches(listeFiches);
            //Tri des fiches par id
            listeFiches = listeFiches.OrderBy(fiche => fiche.id).ToList();
            fichierSauvegarde.SynchroListe(listeFiches);
            //TODO display listes en fonction des paramètres (week, affutage, recouvrement, type)
            ResetWeek();
        }

        /**
         * @brief Recupération de la liste des fiches en fonction d'un nom
         * @note none
         * @param none
         */
        public List<Fiche> GetListFiches(String name)
        {
            //Une liste contenant les références de fiches seulement pour un tri en fonction des noms
            List<Fiche> listFichesName = new List<Fiche>();
            return listFichesName;
        }

        /**
         * @brief Récupération d'une fiche en fonction de son id
         * @note none
         * @param id l'identifiant de la fiche
         * @retval Fiche la fiche
         */
        public Fiche GetFiche(int id)
        {
            return new Fiche();
        }

        /**
         * @brief Retour de la liste synchronisée depuis le serveur
         * @note none
         * @param none
         * @retval ListFiches La liste depuis le serveur 
         */
        public void SynchroFiches()
        {
            int checkLoad = 0, checkSynchro = 0;
            checkLoad = fichierXcel.LoadFiches(listeFiches);
            checkSynchro = fichierSauvegarde.SynchroListe(listeFiches);
            //ici les fiches sont synchronisées
            switch (dispPlanning)
            {
                case DispPlanning.week:
                    this.GetListCurrentWeek();
                    //TODO display week (param week,listeWeek)
                    break;
                case DispPlanning.day:
                    this.GetListCurrentDay();
                    //TODO display day (param day,listeWeek)
                    break;
                default:
                    break;
            }
            this.PlacementAutoAll();
            //TODO display liste non placée (param nonPlacee,listeNonplacee)
            
        }


        //-------------------------------
        //Gestion des fiches
        //-------------------------------

        /**
         * @brief Place automatiquement toutes les fiches dans l'emploi du temps en fonction de leurs paramètres
         * @note la synchro doit être appellées
         * @param none
         * */
        public void PlacementAutoAll()
        {

        }

        /**
         * @brief Place automatiquement une seule fiche dans l'emploi du temps
         * @note la synchro doit être appellées
         * @retVal La liste synchronisée
         * @param idFiche L'identifiant de la fiche 
         * */
        public void PlacementAutoOneFiche(int idFiche)
        {
            
        }

        public List<Fiche> GetListDay()
        {
            return listeDay;

        }

        public ListeFichesWeek GetListWeek()
        {
            return listeWeek;
        }

        public ListeFichesMonth GetListMonth()
        {
            return listeMonth;
        }

        

        public ListeFichesMonth GetListNextMonth()
        {
            return listeMonth;
        }

        public ListeFichesMonth GetListPrecedentMonth()
        {
            return listeMonth;
        }

        public ListeFichesMonth ResetMonth()
        {
            return listeMonth;
        }
        
        /**
         * @brief Rafraichit la liste avec la semaine suivante
         * @note si il y a un tri special, appliquer le tri 
         * @retVal La liste synchronisée
         * @param listeWeek La liste de fiches de la semaine suivante
         * */
        public ListeFichesWeek GetListNextWeek()
        {
            return listeWeek;
        }

        /**
        * @brief Rafraichit la liste avec la semaine précédente
        * @note si il y a un tri special, appliquer le tri
        * @retVal La liste synchronisée
         * @param listeWeek La liste de fiches de la semaine précédente
        * */
        public ListeFichesWeek GetListPrecedentWeek()
        {
            return listeWeek;
        }

        /**
         * @brief Récupère les fiches de la semaine affichée
         * @note si il y a un tri special, appliquer le tri
         * @retVal La liste synchronisée
         * @param listeWeek La liste de fiches de la semaine actuelle
         * */
        public ListeFichesWeek GetListCurrentWeek()
        {
            return listeWeek;
        }

        /**
         * @brief Rafraichit la liste avec la semaine actuelle
         * @note si il y a un tri special, appliquer le tri
         * @retVal La liste synchronisée
         * @param listeWeek La liste de fiches de la semaine actuelle
         * */
        public ListeFichesWeek ResetWeek()
        {
            return listeWeek;
        }

        /**
        * @brief Rafraichit la liste avec la semaine suivante
        * @note si il y a un tri special, appliquer le tri 
        * @retVal La liste synchronisée
        * @param listeJour La liste de fiches du jour suivant
        * */
        public List<Fiche> GetListNextDay()
        {
            return listeDay;
        }

        /**
        * @brief Rafraichit la liste avec la semaine précédente
        * @note si il y a un tri special, appliquer le tri
        * @retVal La liste synchronisée
         * @param listeJour La liste de fiches du jour précédent
        * */
        public List<Fiche> GetListPrecedentDay()
        {
            return listeDay;
        }

        /**
         * @brief Rafraichit la liste avec la semaine actuelle
         * @note si il y a un tri special, appliquer le tri
         * @retVal La liste synchronisée
         * @param listeJour La liste de fiches du jour actuel
         * */
        public List<Fiche> GetListCurrentDay()
        {
            return listeDay;
        }

        /**
         * @brief Rafraichit la liste avec le jour actuel
         * @note si il y a un tri special, appliquer le tri
         * @retVal La liste synchronisée
         * @param listeWeek La liste de fiches de la semaine actuelle
         * */
        public List<Fiche> ResetDay()
        {
            return listeDay;
        }

        /**
         * @brief Modifie le nombre d'éléments de la liste
         * */
        public void ModifyQtyElements(int idFiche, int nbElements)
        {

        }

        /**
         * @brief Modifier le nom
         * */

        /**
         * @brief Modifier l'id? probablement interdit 
         * */

        /**
         * @brief Modification quantité éléments
         * */

        /**
         * @brief Modifier le temps de création de l'élement
         * */

        /**
         * @brief Modifier la machine de l'élément
         * */

        /**
         * @brief Modifier la date de début de fabrication + heure
         * */

        /**
         * @brief Modifier la date de livraison? privé
         * */

        /**
         * @brief Modifier le type de fabrication? privé
         * */

        /**
         * @brief Modifier le type de recouvrement ? privé
         * */

        /**
         * @brief Modification de l'état du retard de placement


        /**
         * @brief Modifier le texte de la fiche
         * */

        /**
         * @brief Modifier toute une fiche
         * */

        /**
         * @brief Affiche la liste du jour 
         * @note choisit le premier jour de la semaine ou du mois si besoin 
         * */
        public void DisplayDay()
        {
            if(dispPlanning == DispPlanning.month)
            {
                //date a afficher = premier jour du mois
            }
            else if (dispPlanning == DispPlanning.week)
            {
                //date à afficher = premier jour de la semaine
            }

            dispPlanning = DispPlanning.day;
            mainWindow.UC_Disp_Day.Visibility = Visibility.Visible;
            mainWindow.UC_Disp_Week.Visibility = Visibility.Collapsed;
            mainWindow.UC_Disp_Month.Visibility = Visibility.Collapsed;

            //TODO rafraichir liste du jour par rapport à la date
            //liste = GetListCurrentDay()
        }

        /**
         * @brief Affiche la liste de la semaine
         * @note choisit la première semaine du mois si besoin, sinon semaine du jour choisit
         * */
        public void DisplayWeek()
        {
            //utiliser premiere semaine du mois ou semaine du jour
            mainWindow.UC_Disp_Day.Visibility = Visibility.Collapsed;
            mainWindow.UC_Disp_Week.Visibility = Visibility.Visible;
            mainWindow.UC_Disp_Month.Visibility = Visibility.Collapsed;

            //TODO obtenir premier jour de la semaine
        }

        /**
        * @brief Affiche la liste de la semaine
        * @note choisit le mois de la semaine ou du jour choisit
        * */
        public void DisplayMonth()
        {
            mainWindow.UC_Disp_Day.Visibility = Visibility.Collapsed;
            mainWindow.UC_Disp_Week.Visibility = Visibility.Collapsed;
            mainWindow.UC_Disp_Month.Visibility = Visibility.Visible;
            //TODO obtenir premier jour du mois
        }

        public void NextDay()
        {
            dateToDisplay = dateToDisplay.AddDays(1);
            ucDispDay.RefreshDayToDisplay(dateToDisplay);
            //TODO ucDispDay.RefrshListToDisplay(liste)

        }

        public void PreviousDay()
        {
            dateToDisplay = dateToDisplay.AddDays(-1);
            ucDispDay.RefreshDayToDisplay(dateToDisplay);
            //TODO ucDispDay.RefrshListToDisplay(liste)
        }

        public void NextWeek()
        {
            DateTime newDate = dateToDisplay.AddDays(7);
            dateToDisplay = newDate;
            ucDispWeek.RefreshWeekToDisplay(dateToDisplay,52);
            //TODO ucDispDay.RefrshListToDisplay(liste)
        }

        public void PreviousWeek()
        {
            DateTime newDate = dateToDisplay.AddDays(-7);
            dateToDisplay = newDate;
            ucDispWeek.RefreshWeekToDisplay(dateToDisplay, 52);
            //TODO ucDispDay.RefrshListToDisplay(liste)
        }
        public void NextMonth()
        {
            dateToDisplay = dateToDisplay.AddMonths(1);
            dateToDisplay = new DateTime(dateToDisplay.Year, dateToDisplay.Month,1);
            ucDispMonth.RefreshMonthToDisplay(dateToDisplay);
            //TODO ucDispDay.RefrshListToDisplay(liste)
        }

        public void PreviousMonth()
        {
            dateToDisplay = dateToDisplay.AddMonths(-1);
            dateToDisplay = new DateTime(dateToDisplay.Year, dateToDisplay.Month, 1);
            ucDispMonth.RefreshMonthToDisplay(dateToDisplay);
            //TODO ucDispDay.RefrshListToDisplay(liste)
        }

        /**
        * @param time Le temps de fabrication
        * @param machine Le numéro de machine
        * @param dateBeginning La date de début de fabrication + heure
        * @param dateLivraison
        * @param enum typeFabrication
        * @param enum covering
        * @param enum retardPlacement (aucun/avant 2jours/ apres date rendu)
        * @param text
        * */

        /*
         * Fonctions d'essai du logiciel
         * */
        public int Test1_saveLoadDatas_dummy()
        {
            SaveData dummyData = new SaveData();
            CreateDummyData(dummyData);

            //Sauvegarde des données dans le fichier
            fichierSauvegarde.SaveDatas(dummyData);

            //vider les données
            dummyData.nameFileCSV = "";
            dummyData.pathFileCSV = "";
            dummyData.displayDay = false;
            dummyData.listeFiches.Clear();

            //Charger les données
            dummyData = fichierSauvegarde.ReadDatas();

            //Comparer les données avec les données d'entrée (au moins une donnée)
            if (dummyData.nameFileCSV == "fileCsV" && dummyData.pathFileCSV == "" && dummyData.displayDay == true)
            {
               if (dummyData.listeFiches != null && dummyData.listeFiches.Count>0)
                {
                    if (dummyData.listeFiches[0].typeOperation == TypeOperation.fabrication)
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }

        public void CreateDummyData(SaveData data)
        {
            //Génerer fausses données (créer 1 fiche)
            listeFiches.Add(new Fiche("AOS", 32000, 10, new DateTime(2018, 01, 01), TypeOperation.fabrication, true));

            data.nameFileCSV = "fileCsV";
            data.pathFileCSV = "";
            /*colorFabrication = new List<TypeColor>(),
            colorRecouvrement = new List<TypeColor>(),
            colorOption = new List<TypeColor>(),*/
            data.displayDay = true;
            data.listeFiches = listeFiches;
        }

        /*
         * Fonctions d'essai du logiciel
         * */
        public int Test2_saveLoadDatas_dummy()
        {

            List<Fiche> list_test = new List<Fiche>();
            if(fichierXcel.LoadFiches(list_test)>=0)
            {
                //list_test = list_test.OrderBy(fiche => fiche.id).ToList();
                fichierSauvegarde.SynchroListe(list_test);
                return 1;
            }
            else
            {
                return 0;
            }

            //TODO vérifier la bonne forme des fiches
        }

        public void Test3_displayListe()
        {
            int nbList = 0;

            List<Fiche> list_test = new List<Fiche>();
            Fiche fiche1 = new Fiche();
            fiche1.id = 1234; fiche1.name = "Test1";fiche1.dateLivraison = new DateTime(2017, 12, 12); fiche1.quantiteElement = 12; fiche1.typeOperation = TypeOperation.fabrication; fiche1.recouvrement = true;
            list_test.Add(fiche1);

            Fiche fiche2 = new Fiche();
            fiche2.id = 2345; fiche2.name = "Test2"; fiche2.dateLivraison = new DateTime(2018, 12, 12); fiche2.quantiteElement = 1; fiche2.typeOperation = TypeOperation.aiguisage; fiche2.recouvrement = true;
            list_test.Add(fiche2);

            Fiche fiche3 = new Fiche();
            fiche3.id = 121134; fiche3.name = "Test3"; fiche3.dateLivraison = new DateTime(2016, 12, 12); fiche3.quantiteElement = 3; fiche3.typeOperation = TypeOperation.na; fiche3.recouvrement = false;
            list_test.Add(fiche3);

            Fiche fiche4 = new Fiche();
            fiche4.id = 121134; fiche4.name = "Test4"; fiche4.dateLivraison = new DateTime(2016, 12, 12); fiche4.quantiteElement = 120; fiche4.typeOperation = TypeOperation.fabrication; fiche4.recouvrement = false;
            list_test.Add(fiche4);

            

            /*if (fichierXcel.LoadFiches(list_test) >= 0  
)             {
                //list_test = list_test.OrderBy(fiche => fiche.id).ToList();
                fichierSauvegarde.SynchroListe(list_test); 
            }*/

            //TODO ajouter nouvelles uc dans UC_display_day
            //TODO liste déroulante
            //ajouter seulement 3 fiches
            for (int i =0;i<4; i++)
            {
                UC_fiche_day ucfd = new UC_fiche_day(list_test[i].id, list_test[i].name, list_test[i].dateLivraison, list_test[i].quantiteElement, true, false, list_test[i].typeOperation, list_test[i].recouvrement);
                mainWindow.UC_Disp_Day.StackPanelDisplayDay.Children.Add(ucfd);

                UC_Fiche_week ucfw = new UC_Fiche_week(list_test[i].id, list_test[i].name, list_test[i].dateLivraison, list_test[i].quantiteElement, true, false, list_test[i].typeOperation, list_test[i].recouvrement);
                mainWindow.UC_Disp_Week.SPDisplayDay_lundi.Children.Add(ucfw);

                UC_Fiche_week ucfw_2 = new UC_Fiche_week(list_test[i].id, list_test[i].name, list_test[i].dateLivraison, list_test[i].quantiteElement, false, true, list_test[i].typeOperation, list_test[i].recouvrement);
                mainWindow.UC_Disp_Week.SPDisplayDay_mercredi.Children.Add(ucfw_2);

                UC_Fiche_week ucfw_3 = new UC_Fiche_week(list_test[i].id, list_test[i].name, list_test[i].dateLivraison, list_test[i].quantiteElement, false, true, list_test[i].typeOperation, list_test[i].recouvrement);
                mainWindow.UC_Disp_Week.SPDisplayDay_samedi.Children.Add(ucfw_3);

                UC_Fiche_week ucfnp = new UC_Fiche_week(list_test[i].id, list_test[i].name, list_test[i].dateLivraison, list_test[i].quantiteElement, false, true, list_test[i].typeOperation, list_test[i].recouvrement);
                mainWindow.STFichesNotPlaced.Children.Add(ucfnp);
            }
            mainWindow.UC_Disp_Day.RefreshDayToDisplay(dateToDisplay);
            
            nbList = mainWindow.UC_Disp_Day.StackPanelDisplayDay.Children.Count;
            mainWindow.UC_Disp_Day.StackPanelDisplayDay.Height = nbList * 40;

            nbList = ucDispWeek.SPDisplayDay_lundi.Children.Count;
            ucDispWeek.SPDisplayDay_lundi.Height = nbList * 70;

            nbList = ucDispWeek.SPDisplayDay_mardi.Children.Count;
            ucDispWeek.SPDisplayDay_mardi.Height = nbList * 70;

            nbList = ucDispWeek.SPDisplayDay_mercredi.Children.Count;
            ucDispWeek.SPDisplayDay_mercredi.Height = nbList * 70;

            nbList = mainWindow.STFichesNotPlaced.Children.Count;
            mainWindow.STFichesNotPlaced.Height = nbList * 70;
        }
    }

}
