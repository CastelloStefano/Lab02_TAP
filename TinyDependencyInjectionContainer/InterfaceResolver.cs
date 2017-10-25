using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyDependencyInjectionContainer
{
    public class InterfaceResolver
    {
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
