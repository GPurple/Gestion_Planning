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
        
        //Les différents controls utilisateurs
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
            dateToDisplay = DateTime.Now;
        }

        static public void Main()
        {

        }

        public void InitDisplay()
        {
            ////TODO display listes en fonction des paramètres (week, affutage, recouvrement, type)
            dispPlanning = DispPlanning.week;
            dateToDisplay = DateTime.Now;
            while (dateToDisplay.DayOfWeek != DayOfWeek.Monday)
            {
                dateToDisplay = dateToDisplay.AddDays(-1);
            }
            RefreshData();
        }
        
        /**
         * @brief Recupération de la liste des fiches en fonction d'un nom
         * @note none
         * @param none
         */
        public List<Fiche> GetListFichesByName(String name)
        {
            //Une liste contenant les références de fiches seulement pour un tri en fonction des noms
            List<Fiche> listFichesName = new List<Fiche>();
            return listFichesName;
        }

        /**
         * @brief Recupération de la liste des fiches en fonction d'un nom
         * @note none
         * @param none
         */
        public List<Fiche> GetListFichesByOperation(TypeOperation typeOp)
        {
            //Une liste contenant les références de fiches seulement pour un tri en fonction des noms
            List<Fiche> listFichesOperation = new List<Fiche>();
            return listFichesOperation;
        }

        /**
         * @brief Recupération de la liste des fiches en fonction d'un nom
         * @note none
         * @param none
         */
        public List<Fiche> GetListFichesByRecouvrement(Boolean reco)
        {
            //Une liste contenant les références de fiches seulement pour un tri en fonction des noms
            List<Fiche> listFichesRec = new List<Fiche>();
            return listFichesRec;
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
         * @brief Place automatiquement toutes les fiches dans l'emploi du temps en fonction de leurs paramètres
         * @note la synchro doit être appellées
         * @param none
         * */
        public void PlacementAutoAll()
        {
            foreach (Fiche fiche in listeFiches)
            {
                //si la fiche n'a pas de date de fabrication
                if (fiche.dateDebutFabrication.CompareTo(new DateTime(2000, 1, 1)) < 0)
                {
                    //si la fiche a une date de livraison
                    if (fiche.dateLivraison.CompareTo(new DateTime(2000, 1, 1)) > 0)
                    {
                        fiche.dateDebutFabrication = fiche.dateLivraison.AddDays(-2);
                        //Si la fabrication tombe un week end elle est décalée de 2 jours supplémentaire
                        if (fiche.dateDebutFabrication.DayOfWeek == DayOfWeek.Sunday || fiche.dateDebutFabrication.DayOfWeek == DayOfWeek.Saturday)
                        {
                            fiche.dateDebutFabrication = fiche.dateDebutFabrication.AddDays(-2);
                        }
                        //Déplacement de 2 jours si recouvrement et prise en compte du week end
                        if (fiche.recouvrement == true)
                        {
                            fiche.dateDebutFabrication = fiche.dateLivraison.AddDays(-2);
                            if (fiche.dateDebutFabrication.DayOfWeek == DayOfWeek.Sunday || fiche.dateDebutFabrication.DayOfWeek == DayOfWeek.Saturday)
                            {
                                fiche.dateDebutFabrication = fiche.dateDebutFabrication.AddDays(-2);
                            }
                        }
                        if (fiche.dateDebutFabrication.CompareTo(DateTime.Now) < 0)
                        {
                            fiche.dateDebutFabrication = DateTime.Now;
                        }
                    }
                    else
                    {
                        fiche.dateDebutFabrication = DateTime.Now;
                    }
                }
            }
            SaveListeInData();
            ProcessListNotPlaced();
            ProcessListCurrentDay();
            listeWeek.ProcessListCurrentWeek(listeFiches, dateToDisplay);
            //TODO ProcessListMonth
            DisplayFiches();
        }

        //Replace les fiches dont la date de fabrication est dépassée sans être validée
        public void ReplacementRetardAutoAll()
        {
            foreach (Fiche fiche in listeFiches)
            {
                if (fiche.dateDebutFabrication.CompareTo(DateTime.Now) < 0 && fiche.check == false)
                {
                    fiche.dateDebutFabrication = DateTime.Now;
                }
            }
            SaveListeInData();
            ProcessListNotPlaced();
            ProcessListCurrentDay();
            listeWeek.ProcessListCurrentWeek(listeFiches, dateToDisplay);
            //TODO ProcessListMonth
            DisplayFiches();
        }

        //Place automatiquement une seule fiche dans l'emploi du temps
        public void PlacementAutoOneFiche(int idFiche)
        {
            //TODO
        }

        //Detection des alertes et des warnings dans la liste
        public void FindAlerteListeFull(List<Fiche> liste)
        {
            mainWindow.image_alerteGeneral.Visibility = Visibility.Collapsed;
            mainWindow.image_warningGeneral.Visibility = Visibility.Collapsed;
            foreach (Fiche fiche in liste)
            {
                FindAlerteListeInFor(fiche);
            }
        }

        //Detection des alertes et des warnings pour une fiche
        public void FindAlerteListeInFor(Fiche fiche)
        {
            DateTime dateLivraison = new DateTime();
            DateTime dateFabrication = new DateTime();
            
            //TODO prise en compte des week ends
            if (fiche.dateLivraison != null && fiche.dateLivraison.CompareTo(new DateTime(2000, 1, 1)) > 0)
            {
                if (fiche.dateDebutFabrication.CompareTo(new DateTime(2000, 1, 1)) > 0 )
                {
                    dateLivraison = fiche.dateLivraison;
                    dateFabrication = fiche.dateDebutFabrication;
                }
                else //Si la fiche n'a pas de date de fabrication, on prend en compte le retard par rapport à la date d'aujourd'hui
                {
                    dateLivraison = fiche.dateLivraison;
                    dateFabrication = DateTime.Now;
                }

                TimeSpan time = dateFabrication - dateLivraison;
                if(time.Days > 0 ) //date fabrication après date livraison
                {
                    fiche.alerteRetard = true;
                    fiche.attentionRetard = false;
                    mainWindow.image_alerteGeneral.Visibility = Visibility.Visible;
                }
                else if (time.Days <2) //moins de 2 jours entre fabrication et livraison en semaine
                {
                    fiche.alerteRetard = false;
                    fiche.attentionRetard = true;
                    mainWindow.image_warningGeneral.Visibility = Visibility.Visible;
                }
                else if (time.Days < 4 && (dateLivraison.AddDays(-1).DayOfWeek == DayOfWeek.Sunday || dateLivraison.AddDays(-2).DayOfWeek == DayOfWeek.Sunday))
                {
                    fiche.alerteRetard = false;
                    fiche.attentionRetard = true;
                    mainWindow.image_warningGeneral.Visibility = Visibility.Visible;
                }
                else 
                {
                    fiche.alerteRetard = false;
                    fiche.attentionRetard = false;
                }
            }
        }

        //récupère la liste du jour
        public void ProcessListCurrentDay()
        {
            listeDay.Clear();
            foreach (Fiche fiche in listeFiches)
            {
                FindAlerteListeInFor(fiche);
                if (fiche.dateDebutFabrication.Year == dateToDisplay.Year
                    && fiche.dateDebutFabrication.Month == dateToDisplay.Month
                    && fiche.dateDebutFabrication.Day == dateToDisplay.Day)
                {
                    listeDay.Add(fiche);
                }
            }
        }

        //récupère la liste du mois
        public void ProcessListCurrentMonth()
        {
            //listeMonth
            foreach (Fiche fiche in listeFiches)
            {
                FindAlerteListeInFor(fiche);
                if (fiche.dateLivraison.Year == dateToDisplay.Year
                    && fiche.dateLivraison.Month == dateToDisplay.Month
                    && fiche.dateLivraison.Day == dateToDisplay.Day)
                {
                    listeDay.Add(fiche);
                }
            }
        }

        //récupère la liste du jour
        public void ProcessListNotPlaced()
        {
            listeNonPlacees.Clear();
            foreach (Fiche fiche in listeFiches)
            {
                FindAlerteListeInFor(fiche);
                if(fiche.dateDebutFabrication.Year < 2000)
                {
                    listeNonPlacees.Add(fiche);
                }
            }
        }

        //Modifie le nombre d'éléments de la liste
        public void ModifyQtyElements(int idFiche, int nbElements)
        {

        }

        //resynchronise les données avec fichier Xcel et fichierSauvegarde
        public void RefreshData()
        {
            if (fichierXcel.LoadFiches(listeFiches) >= 0)
            {
                fichierSauvegarde.SynchroListe(listeFiches);
                FindAlerteListeFull(listeFiches);
                ProcessListCurrentDay();
                listeWeek.ProcessListCurrentWeek(listeFiches, dateToDisplay);
                //processListCurrentMonth
                ProcessListNotPlaced();
                DisplayFiches();
            }
        }
        
        //suauvegarde les données dans le fichier sauvegarde
        public void SaveListeInData()
        {
            fichierSauvegarde.SaveListe(listeFiches);
        }

        //affiche les listes actuelles
        public void DisplayFiches()
        {
            mainWindow.DisplayFichesNotPlaced(listeNonPlacees);
            switch (dispPlanning)
            {
                case DispPlanning.day:
                    DisplayDay();
                    break;
                case DispPlanning.week:
                    DisplayWeek();
                    break;
                case DispPlanning.month:
                    DisplayMonth();
                    break;
                default:
                    DisplayDay();
                    break;
            }
        }

        //Affiche la liste du jour 
        public void DisplayDay()
        {
            dispPlanning = DispPlanning.day;
            mainWindow.UC_Disp_Day.Visibility = Visibility.Visible;
            mainWindow.UC_Disp_Week.Visibility = Visibility.Collapsed;
            mainWindow.UC_Disp_Month.Visibility = Visibility.Collapsed;
            
            ProcessListCurrentDay();
            ucDispDay.RefreshDayToDisplay(dateToDisplay);
            ucDispDay.RefreshListToDisplay(listeDay);
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

            //obtenir premier jour de la semaine et afficher numéro semaine et jours
            int numberWeek = GetNumberWeek(dateToDisplay);
            ucDispWeek.RefreshWeekToDisplay(dateToDisplay, numberWeek);

            //obtenir les fiches de la semaine affichée et les afficher
            listeWeek.ProcessListCurrentWeek(listeFiches, dateToDisplay);
            ucDispWeek.RefreshListToDisplay(listeWeek);
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
            dateToDisplay = new DateTime(dateToDisplay.Year, dateToDisplay.Month, 1);
            ucDispMonth.RefreshMonthToDisplay(dateToDisplay);
        }

        public void NextDay()
        {
            dateToDisplay = dateToDisplay.AddDays(1);
            ucDispDay.RefreshDayToDisplay(dateToDisplay);
            ProcessListCurrentDay();
            ucDispDay.RefreshListToDisplay(listeDay);
        }

        public void PreviousDay()
        {
            dateToDisplay = dateToDisplay.AddDays(-1);
            ucDispDay.RefreshDayToDisplay(dateToDisplay);
            ProcessListCurrentDay();
            ucDispDay.RefreshListToDisplay(listeDay);
        }

        public void ResetDay()
        {
            dateToDisplay = DateTime.Now;
            ucDispDay.RefreshDayToDisplay(dateToDisplay);
            ProcessListCurrentDay();
            ucDispDay.RefreshListToDisplay(listeDay);
        }

        public void NextWeek()
        {
            dateToDisplay = dateToDisplay.AddDays(7);
            while (dateToDisplay.DayOfWeek != DayOfWeek.Monday)
            {
                dateToDisplay = dateToDisplay.AddDays(-1);
            }
            DisplayWeek();
        }

        public void PreviousWeek()
        {
            dateToDisplay = dateToDisplay.AddDays(-7);
            while (dateToDisplay.DayOfWeek != DayOfWeek.Monday)
            {
                dateToDisplay = dateToDisplay.AddDays(-1);
            }
            DisplayWeek();
        }

        public void ResetWeek()
        {
            dateToDisplay = DateTime.Now;
            while (dateToDisplay.DayOfWeek != DayOfWeek.Monday)
            {
                dateToDisplay = dateToDisplay.AddDays(-1);
            }
            //DisplayWeek();
        }

        public void NextMonth()
        {
            dateToDisplay = dateToDisplay.AddMonths(1);
            dateToDisplay = new DateTime(dateToDisplay.Year, dateToDisplay.Month,1);
            ucDispMonth.RefreshMonthToDisplay(dateToDisplay);
            //TODO ucDispDay.RefrshListToDisplay(liste)
        }

        public void ResetMonth()
        {
            dateToDisplay = DateTime.Now;
            dateToDisplay = new DateTime(dateToDisplay.Year, dateToDisplay.Month, 1);
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

        private int GetNumberWeek(DateTime date)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;
            return cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
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
                listeFiches = list_test;

                foreach (Fiche fiche in listeFiches)
                {
                    fiche.dateDebutFabrication = fiche.dateLivraison;
                }

                return 1;
            }
            else
            {
                return 0;
            }

            
            
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

        public void EraseDataFichierSauvegarde()
        {
            listeFiches.Clear();
            fichierSauvegarde.EraseData();
        }

        //TODO modif valeurs d'une fiche

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
    }

}
