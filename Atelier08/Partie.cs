using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier08
{
    internal class Partie
    {
        #region Membres statiques
        private static int compteurParties = 0;

        public static int GetNbParties()
        {
            return compteurParties;
        }
        #endregion

        #region Attributs

        private int valeur;
        public int tentative;
        #endregion

        #region Constructeurs
        public Partie() : this(0)
        {

        }

        public Partie(int valeur)
        {
            this.valeur = valeur;
            // respect best practice
            this.tentative = 0;
            compteurParties++;  
        }
        #endregion

        #region Méthodes
        public string Info()
        {
            return $"{this.valeur} trouvé en {this.tentative} coup(s)";
        }

        public int GetValeur()
        {
            return valeur;
        }
        #endregion
    }
}
