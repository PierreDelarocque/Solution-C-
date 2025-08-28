using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info;

namespace Atelier08;

internal class Joueur : Personne
{
    public Partie[] parties;

    public Joueur(string nom, string prenom) : base(nom, prenom)
    {
        this.parties = new Partie[20];
    }

}
