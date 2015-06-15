using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tests_Reflexion
{
    class Program
    {
        static void Main(string[] args)
        {
            var launcher = new DemoRefletion();
            launcher.Run();
            Console.ReadKey();
        }
    }

    class DemoRefletion
    {
        internal Assembly LoadAssembly()
        {
            Console.WriteLine("\n\n---- Chargement de la lib ----\n");
            const string libReflexionPath = @"..\..\..\LibReflexion\bin\Debug\LibReflexion.dll";
            Assembly maDll = Assembly.LoadFrom(libReflexionPath);
            Console.WriteLine("Librairy chargée !");
            return maDll;
        }
        internal Dictionary<String, Type> GetTypes(Assembly myLib)
        {
            Console.WriteLine("\n\n---- Récupération des types ----\n");
            var typesDic = new Dictionary<string, Type>();
            foreach (var type in myLib.GetTypes())
            {
                typesDic.Add(type.Name, type);
                Console.WriteLine(type.Namespace + "." + type.Name);
            }
            return typesDic;
        }
        internal void GetMembers(Dictionary<String, Type> types)
        {
            Console.WriteLine("\n\n---- Récupération des membres ----\n");
            foreach (var type in types)
            {
                MemberInfo[] members = type.Value.GetMembers();
                Console.WriteLine(type.Value.Namespace + "." + type.Value.Name + " :");
                foreach (var member in members)
                {
                    Console.WriteLine("\t" + " (" + member.MemberType + ")\t" + member.Name + ", " + member.DeclaringType);
                }
            }
        }
        internal void Instanciation(Type type)
        {
            Console.WriteLine("\n\n---- Instantiation de type ----\n");

            var test = Activator.CreateInstance(type);
            Console.WriteLine("Type de l'objet = " + test.GetType());
        }
        internal void Invoke(String methodName, Type type)
        {
            Console.WriteLine("\n\n---- Invocation de méthode ----");

            try
            {
                var test = Activator.CreateInstance(type);
                bool result = (bool)test.GetType().InvokeMember(methodName, BindingFlags.Default | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, test, null);
                Console.WriteLine("Result = " + ((result) ? "tu as retourné true" : "tu as retourné false"));
            }
            catch (System.MissingMethodException mme)
            {
                // Dans le cas ou la méthode n'est pas un membre de ce type ...
                Console.WriteLine("Méthode '" + methodName + "' introuvable.");
            }
        }
        internal void SetField(Type type)
        {
            Console.WriteLine("\n\n---- Definition de la valeur d'un champ ----\n");
            Object test = Activator.CreateInstance(type);
            const string propName = "Nom";

            FieldInfo field = type.GetField(propName);
            if (field != null)
            {
                Console.WriteLine("test.Nom = " + field.GetValue(test));
                Console.WriteLine("Je modifie la valeur de Nom à la volée...");
                field.SetValue(test, "Robert");
                Console.WriteLine("test.Nom = " + field.GetValue(test));
            }
            else
            {
                Console.WriteLine("Impossible de récupérer l'attribut : " + propName);
            }
        }

        public void Run()
        {
            Console.WriteLine("\n======== LIB RELEXION ========");
            Assembly myLib = LoadAssembly();
            Dictionary<String, Type> types = GetTypes(myLib);
            GetMembers(types);
            Instanciation(types.First().Value);
            Invoke("FaireDesChoses", types.First().Value);
            SetField(types["Person"]);
        }
    }

}
