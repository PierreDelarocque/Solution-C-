namespace Info
{
    public class Personne
    {
        #region Attributs
        public string nom;
        public string prenom;
        public string adresse;
        public int age;
        #endregion

        #region Constructeurs
        public Personne(): this("Do" , "John", string.Empty, 0)
        {
            
        }

        public Personne(string nom, string prenom) : this(nom, prenom, string.Empty, 0)
        {
            
        }

        public Personne(string nom, string prenom, string adresse, int age)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.age = age;
        }
        #endregion

        #region Méthodes
        public string GetInfo()
        {
            if(age == 0 && adresse == string.Empty) 
            {
                return $"{nom} {prenom}, aucun autre information disponible";
            }
            else
            {
                return $"{nom} {prenom}, {age} ans, habite {adresse}";
            }
        }

        public override string ToString()
        {
            if (age == 0 && adresse == string.Empty)
            {
                return $"{nom} {prenom}, aucun autre information disponible";
            }
            else
            {
                return $"{nom} {prenom}, {age} ans, habite {adresse}";
            }
        }
        #endregion
    }
}