namespace Atelier06
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
            int nbParties = -1;
            string reponse;
            Random rnd = new Random();
            // TODO : Exercice 1.1 - Utilisation du type Partie dans un seul tableau
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
                nbParties++;
                // TODO : Exercice 1.2 
                Partie p = new Partie(valeurSecrete);
                historique[nbParties] = p;

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
                // TODO : Exercice 1.3

                historique[nbParties].tentative = nbTentative;

                reponse = GetString("Voulez vous rejouer ?");

            } while (reponse.ToLower() == "oui" || reponse.ToLower() == "o");

            Console.WriteLine("Merci d'avoir joué");
            // TODO : Exercice 2
            if(pers == null)
            {
                reponse = GetString("Merci de saisir un nom de fichier");

                if (reponse == string.Empty)
                {
                    AfficheHistorique(nbParties, historique);
                }
                else
                {
                    AfficheHistorique(nbParties, historique, reponse);
                }
            }
            else
            {
                string nomFicher = $"{pers.nom}_{pers.prenom}_{DateTime.Now.ToShortDateString().Replace('/', '_')}";
                AfficheHistorique(nbParties, historique, nomFicher);
                
                //string nomFicher = $"{p.nom}_{p.prenom}_{DateTime.Now.ToString("DD_MM_YY")}";
                //string nomFicher = $"{p.nom}_{p.prenom}_{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}";
            }


            // TODO : Exercice 1.4


            FileStream fs = new FileStream("high.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.Write(meilleurScore);
            sw.Close();
            fs.Close();
        }

        static void AfficheHistorique(int compteur, Partie[] tableau)
        {
            Console.WriteLine("Vos parties : ");
            for (int i = 0; i <= compteur; i++)
            {
                Console.WriteLine($"Partie N°{i + 1}, {tableau[i].Info()}");
            }
        }

        static void AfficheHistorique(int compteur, Partie[] tableau, string nomFichier)
        {
            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                fs = new FileStream($"{nomFichier}.txt", FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);

                sw.WriteLine("Vos parties : ");
                for (int i = 0; i <= compteur; i++)
                {
                    sw.WriteLine($"Partie N°{i + 1}, {tableau[i].Info()}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Erreur lors de l'enregistrement du fichier");
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }

                if (fs != null)
                {
                    fs.Close();
                }
            }
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