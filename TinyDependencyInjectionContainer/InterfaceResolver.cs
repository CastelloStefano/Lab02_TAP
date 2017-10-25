using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace TinyDependencyInjectionContainer
{
    public class InterfaceResolver
    {
        public InterfaceResolver(String str)
        {
            try
            {
                IKernel controllerKernel = new StandardKernel();
                foreach (var line in File.ReadAllLines(str))
                {
                    if (line.StartsWith("#")) continue;
                    var item = line.Split('*');
                    var InterfaceAssembly = Assembly.LoadFrom(item[0]);
                    var ImplementationAssembly = Assembly.LoadFrom(item[2]);
                    foreach (var type in InterfaceAssembly.GetTypes())
                        if (type.IsInterface && type.FullName.Equals(item[1]))
                        {
                            Console.WriteLine("Todo1 " + type.FullName);
                            //TODO 1 
                        }
                    foreach (var implType in ImplementationAssembly.GetTypes())
                    {
                        if (implType.IsClass && implType.FullName.Equals(item[3]))
                        {
                            Console.WriteLine("Todo2 " + implType.FullName);
                            //TODO 2
                        }
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
                throw;
            }


        }

        /*
         *
         *Una class library, TinyDependencyInjectionContainer, contenente la classe InterfaceResolver con le seguenti caratteristiche:
         * il costruttore dovrà ricevere in input un nome di file,
         * che dovrà essere nel formato sotto esposto, 
         * che memorizzerà le associazioni interfaccia->implementazione. 
         * In caso il file non sia nel formato corretto o un assembly/interfaccia/classe indicato nel file non esista, 
         * il costruttore non dovrà andare a buon fine.
         * un metodo generico Instantiate:
         * T Instantiate<T>() where T : class
         * che dovrà restituire un (nuovo) oggetto della classe che implementa l'interfaccia T, come specificato nel file di configurazione passato al costruttore (oppure null se nel file di configurazione non c'è nessuna associazione per quell'interfaccia)
*/
        public T Instantiate<T>() where T : class
        {
            return null;
        }
    }
}
