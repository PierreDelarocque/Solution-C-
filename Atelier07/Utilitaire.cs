using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atelier07
{
    internal static class Utilitaire
    {
        // TODO : Exercice 3.1
        public static void AfficheHistorique(this Partie[] tableau)
        {
            Console.WriteLine("Vos parties : ");
            for (int i = 0; i <= Partie.GetNbParties(); i++)
            {
                Console.WriteLine($"Partie N°{i + 1}, {tableau[i].Info()}");
            }
        }

        public static void AfficheHistorique(this Partie[] tableau, string nomFichier)
        {
            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                fs = new FileStream($"{nomFichier}.txt", FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);

                sw.WriteLine("Vos parties : ");
                for (int i = 0; i <= Partie.GetNbParties(); i++)
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
    }
}
