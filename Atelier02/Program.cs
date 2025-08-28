namespace Atelier02
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
                    Console.WriteLine("Veuillez saisir un entier entre 0 et 100");

                    //Soit l'un soit l'autre
                    //reponse = Console.ReadLine();
                    //valeurSaisie = int.Parse(reponse);

                    valeurSaisie = int.Parse(Console.ReadLine());

                    nbTentative++;

                    if (valeurSaisie > valeurSecrete)
                    {
                        Console.WriteLine("La valeur saisie est trop grande");
                    }
                    else if (valeurSaisie < valeurSecrete)
                    {
                        Console.WriteLine("La valeur saisie est trop petite");
                    }

                    // Remplacement des if par un switch
                    //switch (valeurSaisie)
                    //{
                    //    case var _ when valeurSaisie > valeurSecrete:
                    //        Console.WriteLine("La valeur saisie est trop grande");
                    //        break;
                    //}

                } while (valeurSaisie != valeurSecrete);

                Console.WriteLine("Bravo, vous avez trouvé la bonne valeur");

                if (nbTentative < meilleurScore)
                {
                    Console.WriteLine("Vous avez battu le meilleur score");
                    meilleurScore = nbTentative;
                }

                //Console.WriteLine($"Vous avz trouvé en {0} coup(s)", nbTentative);
                Console.WriteLine($"Vous avez trouvé en {nbTentative} coup(s)");

                historiqueTentative[nbParties] = nbTentative;

                Console.WriteLine("Voulez vous rejouer ?");
                reponse = Console.ReadLine();
            } while (reponse.ToLower() == "oui" || reponse.ToLower() == "o");
            //Oui OUI O o

            Console.WriteLine("Merci d'avoir joué");

            Console.WriteLine("Vos parties : ");
            for (int i = 0; i <= nbParties; i++)
            {
                Console.WriteLine($"Partie N°{i + 1}, valeur secrète={historiqueValeur[i]}, trouvé en {historiqueTentative[i]} coups");
            }
        }
    }
}