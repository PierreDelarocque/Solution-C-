namespace Atelier04
{
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

            do
            {
                valeurSecrete = rnd.Next(100);
                nbTentative = 0;
                nbParties++;
                historiqueValeur[nbParties] = valeurSecrete;

                do
                {
                    // TODO : Exercice 3 - Mise en oeuvre du Try/Catch
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
            AfficheHistorique(nbParties, historiqueValeur, historiqueTentative);
        }
        static void AfficheHistorique(int compteur, int[] tabValeur, int[] tabCoup)
        {
            Console.WriteLine("Vos parties : ");
            for (int i = 0; i <= compteur; i++)
            {
                Console.WriteLine($"Partie N°{i + 1}, valeur secrète={tabValeur[i]}, trouvé en {tabCoup[i]} coups");
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
            // TODO : Exercice 2 - Levée d'exception

            if (!int.TryParse(chaine, out int val))
            {
                throw new Exception("La valeur saisie n’est pas valide.");
            }

            return val;
        }

    }
}