namespace Atelier03
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
                    // TODO : Exercice 1.4 - Utilisation de la fonction getEntier
                    valeurSaisie = GetEntier("Veuillez saisir un entier entre 0 et 100");

                    nbTentative++;

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

                // TODO : Exercice 1.5 - Utilisation de la fonction getString
                reponse = GetString("Voulez vous rejouer ?");

            } while (reponse.ToLower() == "oui" || reponse.ToLower() == "o");

            Console.WriteLine("Merci d'avoir joué");

            // TODO : Exercice 1.2 - Ancien code d'affichage d'historique
            AfficheHistorique(nbParties, historiqueValeur, historiqueTentative);
        }

        // TODO : Exercice 1.1 - Fonction d'affichage d'historique
        static void AfficheHistorique(int compteur, int[] tabValeur, int[] tabCoup)
        {
            Console.WriteLine("Vos parties : ");
            for (int i = 0; i <= compteur; i++)
            {
                Console.WriteLine($"Partie N°{i + 1}, valeur secrète={tabValeur[i]}, trouvé en {tabCoup[i]} coups");
            }
        }

        // TODO : Exercice 1.3 - Fonctions d'interactions utilisateur: getString et getEntier
        static string GetString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        static int GetEntier(string message)
        {
            Console.WriteLine(message);
            string chaine = Console.ReadLine();

            if (int.TryParse(chaine, out int val))
                return val;
            else 
                return -1;
        }

    }
}