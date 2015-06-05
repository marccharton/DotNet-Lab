using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Héritage
{
    /// <summary>
    /// Test de logger partagé entre deux classes filles.
    /// Le logger est dans la classe mère.
    /// Chacune des classes filles peuvent modifier le logger - ainsi que la fonction contenant les filles (main) -
    /// le logger est dans le même état partout
    /// </summary>
    class Program
    {
        /// <summary>
        /// Point d'entrée unique
        /// </summary>
        /// <param name="args"> Liste de paramètre classique</param>
        static void Main(string[] args)
        {
            Console.WriteLine("============ INIT ============" + Environment.NewLine);

            #region Initialisation des variables

            // Initialisation du logger
            var logger = new StringBuilder();

            // Ajout d'un message au logger
            Console.WriteLine("-- [Program](Main) --------------------\n j'ajoute : 'AVANT F1'"); logger.AppendLine("AVANT F1");
            
            // Initialisation de la fille1
            Fille1 f1 = new Fille1(logger);

            // Ajout d'un message au logger
            Console.WriteLine("-- [Program](Main) --------------------\n j'ajoute : 'APRES F1 et AVANT F2'"); logger.AppendLine("APRES F1 et AVANT F2");

            // Initialisation de la fille2
            Fille2 f2 = new Fille2(logger);

            // Ajout d'un message au logger
            Console.WriteLine("-- [Program](Main) --------------------\n j'ajoute : 'APRES F1 et F2'"); logger.AppendLine("APRES F1 et F2");

            // Initialisation du random
            Random rd = new Random();

            #endregion

            Console.WriteLine("============ RUN ============" + Environment.NewLine);

            // 
            // On lance la fonction principale de chaque fille
            // Cette fonction affiche le contenu du logger
            f1.Run();
            f2.Run();

            Console.WriteLine("============ LOG ============" + Environment.NewLine);

            #region Modification du logger

            Console.WriteLine("-- [Program](Main) --------------------\n j'ajoute : 'message du main'");
            logger.AppendLine("message du main");

            // 
            // On lance 5 modification du logger
            // On alterne de manière aléatoire entre la fille 1 et la fille 2
            for (int i = 0; i < 5; i++)
            {
                int nb = rd.Next(0, 2);
                switch (nb)
                {
                    case 0: Append(f1); break;
                    case 1: Append(f2); break;
                }
            }

            #endregion

            Console.WriteLine("============ RUN ============" + Environment.NewLine);

            //
            // On re-lance l'affichage du logger
            // On est censé afficher le même log depuis la fille 1 que depuis la fille 2
            f1.Run();
            f2.Run();

            Console.ReadLine();
        }


        static void Append(Fille1 f1)
        {
            f1.ChangeLog();
        }

        static void Append(Fille2 f2)
        {
            f2.ChangeLog();
        }
    }
}
