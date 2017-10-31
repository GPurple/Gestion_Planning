using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GestionPlanning.src
{
    class FichierXcel
    {
        public String path_file = "";
        public String name_file = "CHARGE_ATELIER_BRUTE_AOS";
        
        /**
         * @brief Synchronisation des fiches avec le fichier excel généré
         * @note Récupération de la date de livraison de chaque fiche
         * @retval Confirmation de la synchronisation des fiches 
         * -1 = erreur
         * 0 = pas besoin de synchro
         * 1 = synchronisation
         * @param listeFiches La liste des fiches
         * */
        public int LoadFiches(List<Fiche> listeFiches)
        {
            //récupération nomfichier depuis fichier de sauvegarde ex: FichierSauvegarde.getEmplacement + getName 
            //Ouverture du fichier
            //ajout des nouvelles fiches dans la liste
            //placer les fiches dans la liste en fonction des dates de rendu

            String file = path_file + name_file + ".csv";
           
            string[] tab_line = new string[20]; // tableau qui va contenir les sous-chaines extraites d'une ligne.
            char[] splitter = { ';' }; // délimiteur du fichier texte
            String[] tab_date = new String[3];
            char[] splitter_date = { '/' }; // délimiteur du fichier texte
            String line="";
            Fiche fiche_tmp;

            // Code
            try
            {
                if (File.Exists(file))
                {
                    // On vérifie si le fichier existe avant de l'ouvrir
                    StreamReader st = new StreamReader(file);
                    line = st.ReadLine();
                    // on parcours les lignes jusqu'à la fin du fichier
                    while (line != null)
                    {
                        tab_line = line.Split(splitter); // récupération de la premiere ligne du fichier
                        fiche_tmp = new Fiche();
                        //id de la commande
                        try
                        {
                            fiche_tmp.id = int.Parse(tab_line[0]);
                        }
                        catch (Exception ex)
                        {
                            fiche_tmp.id = -1;
                        }

                        //famille [14]
                        if (String.Compare(tab_line[14], "AFF ") == 0 || String.Compare(tab_line[14], "AFF ") == 0)
                        {
                            fiche_tmp.typeOperation = TypeOperation.aiguisage;
                        }
                        else if (String.Compare(tab_line[14], "FAB") == 0 || String.Compare(tab_line[14], "FAB ") == 0)
                        {
                            fiche_tmp.typeOperation = TypeOperation.fabrication;
                        }
                        else
                        {
                            fiche_tmp.typeOperation = TypeOperation.na;
                        }


                        //pas de recouvrement

                        //client [7]
                        fiche_tmp.name = String.Copy(tab_line[8]);

                        //delai day 13
                        try
                        {
                            tab_date = tab_line[13].Split(splitter_date);
                            fiche_tmp.dateLivraison = new DateTime(
                                int.Parse(tab_date[2]),
                                int.Parse(tab_date[1]),
                                int.Parse(tab_date[0]));
                        }
                        catch (Exception ex)
                        {
                            fiche_tmp.dateLivraison = new DateTime();
                        }

                        //quantité 21
                        try
                        {
                            fiche_tmp.quantiteElement = int.Parse(tab_line[21]);
                        }
                        catch (Exception ex)
                        {
                            fiche_tmp.quantiteElement = -1;
                        }

                        //Si la fiche possède un identifiant elle est placée dans la liste
                        if (fiche_tmp.id > 0 && !listeFiches.Exists(x => x.id == fiche_tmp.id))
                        {
                            listeFiches.Add(fiche_tmp);
                        }

                        line = st.ReadLine();
                    } // Fin while (ligne!=null)
                    st.Close(); // Fermeture du fichier CSV
                    //trie des fiches par id croissant
                    listeFiches = listeFiches.OrderBy(fiche => fiche.id).ToList();

                    return 1;
                } // Fin If (file.exists)
                else
                {
                    MessageBox.Show("Erreur: Le fichier csv n'existe pas");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur ouverture fichier CSV");
                return -1;
            }
        }
    }
}
