/*
 * Ver 2.0
 */
 
 using System;
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
