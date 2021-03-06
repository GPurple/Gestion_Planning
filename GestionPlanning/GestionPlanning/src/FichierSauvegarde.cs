﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;
using static GestionPlanning.src.FichierSauvegarde;

namespace GestionPlanning.src
{

    //Les données à sauvegarder
    [XmlRoot("Data")]
    [XmlInclude(typeof(Fiche))]
    [XmlInclude(typeof(TimeSpan))]
    public class SaveData
    {
        //Les données

        public String pathFileCSV;

        public String nameFileCSV;

        public String pathFileModifs;
        
        public Boolean displayDay;

        //Date de la dernière modification pour savoir si le chargement est utile
        public DateTime dateLastModif;


        public int minChargeTime;

        //La liste des fiches 
        [XmlArray("ListeFiches")]
        [XmlArrayItem("Fiche")]
        public List<Fiche> listeFiches = new List<Fiche>();

        [XmlArray("ListeColors")]
        [XmlArrayItem("TypeColor")]
        public List<TypeColor> listeColor = new List<TypeColor>();

        public SaveData() { }
    }

    //La structure contenant les données sur la couleur d'une fiche pas lié au type
    //ex : fabrication : vert, aiguisage: rouge, recouvrement : orange
    [XmlType("TypeColor")]
    [XmlInclude(typeof(Color))]
    public class TypeColor
    {
        public String name = "";
        public Color color = Colors.White;

        public TypeColor()
        {
        }

        public TypeColor(String newName, Color newColor)
        {
            name = newName;
            color = newColor;
        }
    }

    public class FichierSauvegarde
    {
        public String pathFileFinal = @"\\serveur\partages\DonneesPlanning\";
        public String pathFile = "";
        public String nameFile = "Fichier_Sauvegarde";
        public DateTime dateLastModif = new DateTime(2000,1,1);
        public SaveData dataCom = new SaveData();

        

        public String nameFileCsv = "";
        public String pathFileCsv = "";
        public String pathFileModifs = "";

        public String newNameFileCsv = "";
        public String newPathFileCsv = "";
        public String newPathFileModifs = "";

        public int minChargeTime = 0;

        public List<TypeColor> listeColors = new List<TypeColor>();
        /* *
         * Données sauvegardées:
         * 1 = nom fichier sauvegarde
         * 2 = path fichier sauvegarde
         * 
         * Elements d'une fiche:
         * 0 = element déjà fait ou annulé
         * 1 = nom
         * 2 = id
         * 3 = quantité élements
         * 4 = date début prod
         * 5 = date rendu
         * 6 = temps prod
         * 7 = type prod
         * 8 = recouvrement
         * 9 = machine
         * 10 = retard
         * = texte
         * */
        public FichierSauvegarde()
        {
            //Récupération des données du fichier
            //dataCom = ReadDatas();
            //chargement du path fichier xcel
            /*if (data.pathFileCSV != null)
            {
                pathFile = String.Copy(data.pathFileCSV);
            }
            else
            {
                pathFile = "";
            }
            //chargement du nom du fichier xcel
            nameFile = String.Copy(data.nameFileCSV);
            */
            //Pas de modif de dateLastModif car il n'y a pas de synchro des données

        }

        /**
         * @brief Synchroniser les fiches existantes
         * @note Ajoute les nouvelles fiches dans le fichier et modifie les fiches de la liste si besoin
         * @param listeFiches La référence de la liste des fiches 
         * @retval 0 = pas de modification, 1 = modification, -1 = erreur
         * */
        public List<Fiche> SynchroListe(List<Fiche> listeFichesConnues)
        {
            Boolean nodatemodif = false;
            int idFichePrec = 0;
            SaveData data = ReadDatas();

            minChargeTime = data.minChargeTime;
            
            if (data == null)
            {
                return null;
            }

            if (data.nameFileCSV != null && data.nameFileCSV != "")
            {
                Brain.Instance.fichierXcel.name_file = data.nameFileCSV;
                nameFileCsv = data.nameFileCSV;
            }

            if (data.pathFileCSV != null)
            {
                Brain.Instance.fichierXcel.path_file = data.pathFileCSV;
                pathFileCsv = data.pathFileCSV;
            }

            if (data.pathFileCSV != null)
            {
                Brain.Instance.gestionModif.pathFile = data.pathFileModifs;
                pathFileModifs = data.pathFileModifs;
            }            
            if (newNameFileCsv != null && newNameFileCsv!="")
            {
                data.nameFileCSV = newNameFileCsv;
            }
            else
            {
                data.nameFileCSV = Brain.Instance.fichierXcel.name_file;
            }

            if (newPathFileCsv != null)
            {
                data.pathFileCSV = newPathFileCsv;
            }
            if (newPathFileModifs != null)
            {
                data.pathFileModifs = newPathFileModifs;
            }

            if (data.dateLastModif.Year<2000) //si la date de modif est à 0 elles n'a jamais été faite donc on charge les données
            {
                nodatemodif = true;
            }
            TimeSpan diffDateModif = data.dateLastModif - dateLastModif;

            //Si la différence entre la dernière sauvegarde et la date de sauvegarde du fichier est différente, effectuer la synchro
            if (diffDateModif.Seconds > 0 || nodatemodif)
            {
                //La liste sauvegardée est triée par id
                List<Fiche> listeFichesSaved = data.listeFiches;
                List<Fiche> listeFichesTmp = new List<Fiche>();
                listeFichesTmp.Clear();
                listeFichesSaved = listeFichesSaved.OrderBy(fiche => fiche.id).ToList();
                listeFichesConnues = listeFichesConnues.OrderBy(fiche => fiche.id).ToList();
               
                //listeFichesSaved = listeFichesSaved.OrderBy(fiche => fiche.id).ToList();
                //si il existe une fiche dans le fichier de sauvegarde qui n'est pas chargée,elle est chargée -> une autre boucle dans l'autre sens?
                foreach (Fiche ficheSaved in listeFichesSaved)
                {
                    foreach (Fiche ficheConnue in listeFichesConnues)
                    {
                        if (ficheSaved.id == ficheConnue.id)
                        {
                            // synchro des fiches dans fiche connues
                            //charger toutes les valeurs enregistrées
                            ficheConnue.tempsFabrication = ficheSaved.tempsFabrication;
                            ficheConnue.typeOperation = ficheSaved.typeOperation;
                            ficheConnue.recouvrement = ficheSaved.recouvrement;
                            ficheConnue.quantiteElement = ficheSaved.quantiteElement;
                            ficheConnue.machine = ficheSaved.machine;
                            ficheConnue.dateDebutFabrication = ficheSaved.dateDebutFabrication;
                            ficheConnue.dateLivraison = ficheSaved.dateLivraison;
                            ficheConnue.textDescription = ficheSaved.textDescription;
                            ficheConnue.check = ficheSaved.check;
                            break;
                        }
                        else if (ficheConnue.id > ficheSaved.id)
                        {
                            TimeSpan ts = DateTime.Now - ficheSaved.dateLivraison;
                            //si la fiche sauvegardée n'est pas dans la liste connue et qu'elle n'est pas dépassée, la placer dans la liste
                            if ( idFichePrec!= ficheSaved.id || ficheSaved.id == 0)
                            {
                                if (ts.Days < 30)
                                {
                                    listeFichesTmp.Add(ficheSaved);
                                }
                                else if (ficheSaved.check == false)
                                {
                                    listeFichesTmp.Add(ficheSaved);
                                }
                            }
                            //Si la fiche est passée, fin de la boucle
                            break;
                        }
                    }
                    idFichePrec = ficheSaved.id;                    
                }
                foreach (Fiche ficheTmp in listeFichesTmp)
                {
                    listeFichesConnues.Add(ficheTmp);
                }
                this.listeColors = data.listeColor;
                this.minChargeTime = data.minChargeTime;
                //Trier fiches par id
                listeFichesConnues = listeFichesConnues.OrderBy(fiche => fiche.id).ToList();
                data.listeFiches = listeFichesConnues;
                dataCom = data;
                //à la fin la liste est réecrite dans le fichier
                SaveDatas(data);
                return listeFichesTmp;
            }
            else //Si date dernière modif fichier == date connue alors pas besoin de synchro
            {
                return null;
            }
        }

        public int SaveListe(List<Fiche> listeFichesConnues)
        {
            try
            {
                SaveData data = ReadDatas();
                dateLastModif = DateTime.Now;
                data.dateLastModif = dateLastModif;
                data.listeFiches = listeFichesConnues;
                SaveDatas(data);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        

        public int SaveListe(List<Fiche> listeFichesConnues, List<TypeColor> listeColors)
        {
            try
            {
                SaveData data = ReadDatas();
                dateLastModif = DateTime.Now;
                data.dateLastModif = dateLastModif;
                data.listeFiches = listeFichesConnues;
                data.listeColor = listeColors;
                dataCom = data;
                SaveDatas(data);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int SaveChargeTimeData(int newChargeTime)
        {
            try
            {
                SaveData data = ReadDatas();
                dateLastModif = DateTime.Now;
                data.minChargeTime = newChargeTime;
                this.minChargeTime = newChargeTime;
                SaveDatas(data);
                dataCom = data;
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void EraseData()
        {
            String file = this.pathFile + this.nameFile + ".xml";

            if (System.IO.File.Exists(file))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    System.IO.File.Delete(file);
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
        }
        
        /*
         * @brief Lire fichier sauvegarde
         * 
         * */
        public SaveData ReadDatas()
        {
            SaveData data = new SaveData();

            try
            {
                if (File.Exists(pathFile + nameFile + ".xml"))
                {
                    //Ouverture du fichier
                    Stream stream = new FileStream(pathFile + nameFile + ".xml", FileMode.OpenOrCreate, FileAccess.Read);

                    Type[] extraTypes = { typeof(Fiche) };

                    XmlSerializer serializer = new XmlSerializer(typeof(SaveData), extraTypes);

                    if (stream.Position != 0)
                    {
                        stream.Position = 0;
                    }
                    if (System.IO.File.Exists(this.pathFile + this.nameFile + ".xml"))
                    {
                        try
                        {
                            data = (SaveData)serializer.Deserialize(stream);
                        }
                        catch (System.IO.IOException e)
                        {

                        }
                    }
                    //Fermeture du fichier
                    stream.Close();
                }
            }
            catch
            {
                MessageBox.Show("Erreur ouverture fichier sauvegarde");
            }
            return data;
        }
        
        public int SaveDatas(SaveData data)
        {
            // Delete a file by using File class static method...
            String file_V1 = this.pathFile + this.nameFile + ".xml";
            String file_V2 = this.pathFile + this.nameFile + "V2" + ".xml";

            if (System.IO.File.Exists(file_V2))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    System.IO.File.Delete(file_V2);
                }
                catch (System.IO.IOException e)
                {
                    
                }
            }

            //Ouverture du fichier
            Stream stream = new FileStream(file_V2, FileMode.OpenOrCreate);
            
            //TODO ajouter erreur sauvegarde données

            Type[] extraTypes = { typeof(Fiche) };
            XmlSerializer serializer = new XmlSerializer(typeof(SaveData),extraTypes);
            
            serializer.Serialize(stream, data);

            //Fermeture du fichier
            stream.Close();

            if (System.IO.File.Exists(file_V1))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    System.IO.File.Delete(file_V1);
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    return 0;
                }
            }
            try
            {
                FileSystem.Rename(file_V2, file_V1);
            }
            catch
            {
                MessageBox.Show("Erreur sauvegarde dans fichier sauvegarde \n ");
            }

            return 1;
        }

        public int RenommerFichierXcel(String newName)
        {
            Brain.Instance.fichierXcel.name_file = newName;
            dataCom.nameFileCSV = newName;
            if (SaveDatas(dataCom) == 1)
            {
                MessageBox.Show("Le nom du fichier a été modifié correctement \n ");
            }
            return 1;
        }

        public int ModifierPathFichierXcel(String newPath)
        {
            char val = newPath.LastOrDefault<char>();
            if (val != '\\')
            {
                newPath = newPath + '\\';
            }
            Brain.Instance.fichierXcel.path_file = newPath;
            dataCom.pathFileCSV = newPath;
            if(SaveDatas(dataCom) == 1)
            {
                MessageBox.Show("Le chemin d'accès a été modifié correctement \n ");
            }
            return 1;
        }

        public int ModifierPathFichierModifs(String newPath)
        {
            Brain.Instance.gestionModif.pathFile = newPath;
            dataCom.pathFileModifs = newPath;
            SaveDatas(dataCom);
            return 1;
        }
    }
}
