using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GestionPlanning.src
{
    //Les données à sauvegarder
    [XmlRoot("ListeErreurs")]
    [XmlInclude(typeof(Fiche))]
    public class SaveErreurs
    {
        //La liste des erreurs
        [XmlArray("ListeFiches")]
        [XmlArrayItem("Fiche")]
        public List<Erreur> listeErreur = new List<Erreur>();

        public SaveErreurs() { }
    }

    //[Serializable]
    [XmlType("Erreur")]
    [XmlInclude(typeof(DateTime))]
    public class Erreur
    {
        TypeErreur erreur;
        DateTime dateErreur;
    }

    public enum TypeErreur { AccesFileSave, AccesFileCsv};

    class GestionErreur
    {
        //Init fichier txt
        public String pathFile = "";
        public String nameFile = "Fichier_Erreur";

        public GestionErreur()
        {
            
        }

        public void SaveErreur(String err)
        {
            //ouvrir fichier
            SaveErreurs data = ReadDatas();

            //charger les erreurs et supprimer celles 
        }

        public String LoadErreurs()
        {
            return "";
        }

        public SaveErreurs ReadDatas()
        {
            SaveErreurs data = new SaveErreurs();

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
                        data = (SaveErreurs)serializer.Deserialize(stream);
                    }
                    catch (System.IO.IOException e)
                    {

                    }
                }
                //Fermeture du fichier
                stream.Close();
            }
            return data;
        }
    }
}
