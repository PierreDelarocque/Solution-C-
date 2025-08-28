namespace Atelier07
{
    using Info;
    using System.IO;

    internal class Program
    {
        static void Main(string[] args)
        {
            Personne joueur = null;

            string info = GetString("Voulez-vous vous présenter ?");

            if (info.ToLower() == "oui")
            {
                string nom = GetString("Quel est votre nom ?");
                string prenom = GetString("Quel est votre prénom ?");
                joueur = new Personne(nom, prenom);
            }

            LeJeu(joueur);
        }

        static void LeJeu(Personne pers)
        {
            int valeurSecrete, valeurSaisie;
            int nbTentative, meilleurScore = 50;
            string reponse;
            Random rnd = new Random();
            Partie[] historique = new Partie[20];

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
                historique[Partie.GetNbParties() - 1] = p;

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
                historique[Partie.GetNbParties() - 1].tentative = nbTentative;

                reponse = GetString("Voulez vous rejouer ?");

            } while (reponse.ToLower() == "oui" || reponse.ToLower() == "o");

            Console.WriteLine("Merci d'avoir joué");

            // TODO : Exercice 3.2
            if (pers == null)
            {
                reponse = GetString("Merci de saisir un nom de fichier");

                if (reponse == string.Empty)
                {
                    historique.AfficheHistorique();
                }
                else
                {
                    historique.AfficheHistorique(reponse);
                }
            }
            else
            {
                string nomFicher = $"{pers.nom}_{pers.prenom}_{DateTime.Now.ToShortDateString().Replace('/', '_')}";
                historique.AfficheHistorique(nomFicher);
            }

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