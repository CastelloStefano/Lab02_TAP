using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailSenderInterfaces;
using TinyDependencyInjectionContainer;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var resolver = new InterfaceResolver("../../../TDIC_Configuration.txt");
            //var sender = resolver.Instantiate<IEmailSender>();
            //sender.SendEmail("pippo", "pluto");

            Console.ReadKey();

        }
    }
}
