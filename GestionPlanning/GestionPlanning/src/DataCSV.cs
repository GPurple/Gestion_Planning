using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPlanning.src
{
    class DataCSV
    {
        int numéro;
        int ligne;
        DateTime date_cde;
        String rep; //inutile
        String operation; //DIV/MEC/AFF
        int sec_cde;//inutile
        String cpt_client;//inutile
        String client;
        String reference;//utile?
        String code_article;//utile?
        String compl_art;//inutile
        String delai_week;
        DateTime delai_day;
        String famille; //FAB/ARC/AFF/JET
        String transport;//inutile
        String dp;//inutile
        String pu_net;//inutile
        String exp_pu;//inutile
        String devise;//inutile
        String poids_cde;//inutile
        int quantity;
        String montant;//inutile
    }
}
