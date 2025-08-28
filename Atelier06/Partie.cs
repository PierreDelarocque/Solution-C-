using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier06
{
    internal class Partie
    {
        #region Attributs
        public int valeur;
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
        }
        #endregion

        #region Méthodes
        public string Info()
        {
            return $"{this.valeur} trouvé en {this.tentative} coup(s)";
        }
        #endregion
    }
}
