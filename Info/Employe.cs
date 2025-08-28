

namespace Info;

public class Employe : Personne
{
    private int numero = 0;
    public string fonction = string.Empty;  
    private double salaire = 0;


    public Employe(string nom, string prenom, string adresse, int age, string fonction,
 double salaire) : base(nom, prenom, adresse, age)
    {
        this.fonction = fonction;
        this.salaire = salaire;
    }
    

    public Employe(Personne p,string  fonction, double salaire) : this(p.nom, p.prenom, p.adresse, p.age, fonction, salaire)
    {

    }

    public override string ToString()
    {
        return $"{base.ToString()}, Fonction: {this.fonction}";
    }

    public void Augmenter(double montantAugmentation)
    {
                this.salaire = montantAugmentation;
    }

    public void Affecter(string newAffectation)
    {
                       this.fonction = newAffectation;
    }
}
