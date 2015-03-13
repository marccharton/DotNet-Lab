using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibReflexion
{
    public class Person
    {
        public string Nom;
        public string Prenom;

        public bool FaireDesChoses()
        {
            Console.WriteLine("[LibReflexion.Person.FaireDesChoses] Je fais des choses");
            return true;
        }
    }

    public class Class2
    {
        public Person gens;

        public void run()
        {
            gens = new Person();
            gens.Prenom = "Jean Jaques";
            gens.Nom = "Chalumeaux";
        }
    }
}
