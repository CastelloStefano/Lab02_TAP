using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderImplementation2
{
    public class EmailSenderImplementationTwo : EmailSenderInterfaces.IEmailSender
    {
        public bool SendEmail(string to, string body)
        {
            Console.WriteLine("EmailSenderImpl 2" + " " + to + " " + body);
            return true;
        }
    }
}
