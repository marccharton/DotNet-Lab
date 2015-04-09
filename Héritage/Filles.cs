using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// La différence entre new et override : new cache l'implémentation de la mere. 
/// Si on défini un objet avec le type de la mere alors c'est la methode mere qui sera appelée sans passer par la fille.
/// Je préfère override car on peut définir des objet avec le type mère (générique) et auqnd même appeler les méthodes filles.
/// </summary>
namespace Héritage
{
    class Fille1 : Mere
    {
        public Fille1(StringBuilder pLogger)
            : base(pLogger)
        {
        }

        public override void Run()
        {
            base.Run();
            Console.WriteLine("-- [Fille1](Run)--------------------");
            Console.WriteLine("LOGGER : " + _logger.ToString());
        }
        public override void WriteConsole()
        {
            Console.WriteLine("-- [Fille1](ChangeLog) --------------------\n j'ajoute : 'Message de fille1'");
        }
        public override void WriteLog()
        {
            _logger.AppendLine("Message de fille1");
        }

    }

    class Fille2 : Mere
    {
        public Fille2(StringBuilder pLogger)
            : base(pLogger)
        {

        }

        public override void Run()
        {
            base.Run();
            Console.WriteLine("-- [Fille2](Run) --------------------");
            Console.WriteLine("LOGGER : " + _logger.ToString());
        }
        public override void WriteConsole()
        {
            Console.WriteLine("-- [Fille2](ChangeLog) --------------------\nj'ajoute : 'Message de fille2'");
        }
        public override void WriteLog()
        {
            _logger.AppendLine("Message de fille2");
        }
    }

}
