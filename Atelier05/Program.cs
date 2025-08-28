namespace Atelier05
{
    using System.IO;

    internal class Program
    {
        static void Main(string[] args)
        {
            int valeurSecrete, valeurSaisie;
            int nbTentative, meilleurScore = 50;
            int nbParties = -1;
            string reponse;
            Random rnd = new Random();
            int[] historiqueValeur = new int[20];
            int[] historiqueTentative = new int[20];

            // TODO : Exercice 3 - Lecture du fichier de meilleur score

            //Problème au niveau du FileMode.Open
            //if(File.Exists("high.txt"))
            //OpenOrCreate
            //try / catch +> Utile dans le cadre d'un fichier modifié, supprimé, ou encore que sa lecture pose un problème

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
                historiqueValeur[nbParties] = valeurSecrete;

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

                historiqueTentative[nbParties] = nbTentative;

                reponse = GetString("Voulez vous rejouer ?");

            } while (reponse.ToLower() == "oui" || reponse.ToLower() == "o");

            Console.WriteLine("Merci d'avoir joué");
            // TODO : Exercice 1.2 - Gestion du choix d'affichage de l'historique
            reponse = GetString("Merci de saisir un nom de fichier");

            //string.Empty est egal à ""
            // null signifie une abscence de valeur
            // "" signifie une chaine de caractère vide
            //if (reponse == string.Empty)
            //if(string.IsNullOrEmpty(reponse))

            if (reponse == string.Empty)
            {
                AfficheHistorique(nbParties, historiqueValeur, historiqueTentative);
            }
            else
            {
                AfficheHistorique(nbParties, historiqueValeur, historiqueTentative, reponse);
            }

            // TODO : Exercice 2 - Sauvegarde du meilleur score
            FileStream fs = new FileStream("high.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.Write(meilleurScore);
            sw.Close();
            fs.Close();
        }
        static void AfficheHistorique(int compteur, int[] tabValeur, int[] tabCoup)
        {
            Console.WriteLine("Vos parties : ");
            for (int i = 0; i <= compteur; i++)
            {
                Console.WriteLine($"Partie N°{i + 1}, valeur secrète={tabValeur[i]}, trouvé en {tabCoup[i]} coups");
            }
        }

        // TODO : Exercice 1.1 - Création d'une surcharge à AfficheHistorique
        static void AfficheHistorique(int compteur, int[] tabValeur, int[] tabCoup, string nomFichier)
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
                    sw.WriteLine($"Partie N°{i + 1}, valeur secrète={tabValeur[i]}, trouvé en {tabCoup[i]} coups");
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