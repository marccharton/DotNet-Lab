using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Héritage
{
    class Mere : Interface
    {
        protected StringBuilder _logger;

        public Mere(StringBuilder pLogger)
        {
            _logger = pLogger;
        }

        public virtual void Run()
        {
            Console.WriteLine("-- [Mere](Run) --------------------");
        }

        /// <summary>
        /// La méthode change log n'est pas "overidden" par les filles mais appele les autres méthodes qui elles, le sont.
        /// </summary>
        public virtual void ChangeLog()
        {
            this.WriteConsole();
            this.WriteLog();
        }

        /// <summary>
        /// Affiche un message dans la console (la méthode est surchargée par la classe fille)
        /// </summary>
        public virtual void WriteConsole()
        {
        }

        /// <summary>
        /// Affiche un message dans le log (la méthode est surchargée par la classe fille)
        /// </summary>
        public virtual void WriteLog()
        {
        }
    }
}
