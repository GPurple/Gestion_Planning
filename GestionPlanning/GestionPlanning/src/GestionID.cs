using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace GestionPlanning.src
{

    //Les données à sauvegarder
    [XmlRoot("ListeModifications")]
    [XmlInclude(typeof(Modification))]
    public class DataSaveModif
    {
        //La liste des erreurs
        [XmlArray("ListeModifs")]
        [XmlArrayItem("Modification")]
        public List<Modification> listeModifs = new List<Modification>();

        public DataSaveModif() { }
    }

    public enum TypeModification { placementAuto, replacementAuto, refreshData, modifFiche, connexion , validationFiche, changementPath, changementNameFile};

    //[Serializable]
    [XmlType("Modification")]
    [XmlInclude(typeof(DateTime))]
    public class Modification
    {
        public TypeModification modification;
        public String nameUser;
        public int idFiche;
        public String text;
        public DateTime dateModif;
        public String valueModif;

        public Modification()
        {

        }

        public Modification(TypeModification newTypeModif, String newNameUser, int newIdFiche, String newText, DateTime newDateModif, String newValue)
        {
            modification = newTypeModif;
            nameUser = newNameUser;
            idFiche = newIdFiche;
            text = newText;
            dateModif = newDateModif;
            valueModif = newValue;
        }
    }
    

    class GestionModifs
    {

        //Init fichier txt
        public String pathFile = "";
        public String nameFile = "Fichier_Modifications";
        
        public void AddModif(Modification modification)
        {
            //ouvrir fichier
            DataSaveModif dataSaveModif = ReadDatas();

            
            int nbModifs = 0;
            foreach (Modification modif in dataSaveModif.listeModifs)
            {
                if (modif.dateModif.CompareTo(DateTime.Now.AddMonths(-1)) < 0)
                {
                    dataSaveModif.listeModifs.Remove(modif);
                }
                if(nbModifs>200)
                {
                    break;
                }
                nbModifs++;
            }
            dataSaveModif.listeModifs.Add(modification);
            SaveDatas(dataSaveModif);
            //charger les erreurs et supprimer celles 
        }

        public DataSaveModif ReadDatas()
        {
            DataSaveModif data = new DataSaveModif();

            if (File.Exists(pathFile + nameFile + ".xml"))
            {
                //Ouverture du fichier
                Stream stream = new FileStream(pathFile + nameFile + ".xml", FileMode.OpenOrCreate, FileAccess.Read);

                Type[] extraTypes = { typeof(Modification) };

                XmlSerializer serializer = new XmlSerializer(typeof(DataSaveModif), extraTypes);

                if (stream.Position != 0)
                {
                    stream.Position = 0;
                }
                if (System.IO.File.Exists(this.pathFile + this.nameFile + ".xml"))
                {
                    try
                    {
                        data = (DataSaveModif)serializer.Deserialize(stream);
                    }
                    catch (System.IO.IOException e)
                    {
                        MessageBox.Show("Erreur lecture fichier modifications");
                    }
                }
                //Fermeture du fichier
                stream.Close();
            }
            else
            {
                MessageBox.Show("Erreur:  Le fichier de modifications n'existe pas");
            }
            return data;
        }

        public void SaveDatas(DataSaveModif data)
        {
            // Delete a file by using File class static method...
            String file_V1 = this.pathFile + this.nameFile + ".xml";
            String file_V2 = this.pathFile + this.nameFile + "V2" + ".xml";

            //Ouverture du fichier
            Stream stream = new FileStream(file_V2, FileMode.OpenOrCreate);

            //TODO ajouter erreur sauvegarde données

            Type[] extraTypes = { typeof(Modification) };
            XmlSerializer serializer = new XmlSerializer(typeof(DataSaveModif), extraTypes);

            serializer.Serialize(stream, data);

            //Fermeture du fichier
            stream.Close();

            if (System.IO.File.Exists(file_V1))
            {
                try
                {
                    System.IO.File.Delete(file_V1);
                }
                catch (System.IO.IOException e)
                {
                    //TODO gérer erreur
                    Console.WriteLine(e.Message);
                    return;
                }
            }
            FileSystem.Rename(file_V2, file_V1);
        }
    }


    class GestionID
    {
        

        public GestionID()
        {

        }

       

    }
}
