/*
 * Ver 2.0
 */

 using System;
using System.Collections.Generic;
 using System.Diagnostics;
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
            var sender = resolver.Instantiate<IEmailSender>();
            if (sender != null) sender.SendEmail("paperino", "foo");
            else Debug.WriteLine("Bad New Sender is NULL");
            sender?.SendEmail("pippo", "di brutto");
            Console.ReadLine();
       
        }
    }
}
