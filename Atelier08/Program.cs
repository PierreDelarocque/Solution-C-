namespace Atelier08
{
    using Info;
    using System.IO;

    internal class Program
    {
        static void Main(string[] args)
        {
            // TODO : Exercice 2.1
            Joueur joueur = null;
           
            

            
            
                string nom = GetString("Quel est votre nom ?");
                string prenom = GetString("Quel est votre prénom ?");
                joueur = new Joueur(nom, prenom);
            

            LeJeu(joueur);
        }

        // TODO : Exercice 2.2
        static void LeJeu(Joueur joueur)
        {
            int valeurSecrete, valeurSaisie;
            int nbTentative, meilleurScore = 50;
            string reponse;
            Random rnd = new Random();
           

            if (File.Exists("high.txt"))
            {
                FileStream fsHigh = new FileStream("high.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fsHigh);

                meilleurScore = int.Parse(sr.ReadLine());

                sr.Close();
                fsHigh.Close();
            }

            do
            {
                valeurSecrete = rnd.Next(100);
                nbTentative = 0;
                Partie p = new Partie(valeurSecrete);
                joueur.parties[Partie.GetNbParties() - 1] = p;

                do
                {
                    try
                    {
                        nbTentative++;
                        valeurSaisie = GetEntier("Veuillez saisir un entier entre 0 et 100");
                    }
                    catch (Exception ex)
                    {
                        valeurSaisie = -1;
                        Console.WriteLine(ex.Message);
                        continue;
                    }

                    if (valeurSaisie > valeurSecrete)
                    {
                        Console.WriteLine("La valeur saisie est trop grande");
                    }
                    else if (valeurSaisie < valeurSecrete)
                    {
                        Console.WriteLine("La valeur saisie est trop petite");
                    }

                } while (valeurSaisie != valeurSecrete);

                Console.WriteLine("Bravo, vous avez trouvé la bonne valeur");

                if (nbTentative < meilleurScore)
                {
                    Console.WriteLine("Vous avez battu le meilleur score");
                    meilleurScore = nbTentative;
                }
                Console.WriteLine($"Vous avez trouvé en {nbTentative} coup(s)");
                joueur.parties[Partie.GetNbParties() - 1].tentative = nbTentative;

                reponse = GetString("Voulez vous rejouer ?");

            } while (reponse.ToLower() == "oui" || reponse.ToLower() == "o");

            Console.WriteLine("Merci d'avoir joué");

            // TODO : Exercice 2.3
            
                string nomFicher = $"{joueur.nom}_{joueur.prenom}_{DateTime.Now.ToShortDateString().Replace('/', '_')}";
                joueur.parties.AfficheHistorique(nomFicher);
            

            FileStream fs = new FileStream("high.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.Write(meilleurScore);
            sw.Close();
            fs.Close();
        }

        static string GetString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        static int GetEntier(string message)
        {
            Console.WriteLine(message);
            string chaine = Console.ReadLine();

            if (!int.TryParse(chaine, out int val))
            {
                throw new Exception("La valeur saisie n’est pas valide.");
            }

            return val;
        }

    }
}