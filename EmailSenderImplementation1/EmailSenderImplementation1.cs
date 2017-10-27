/*
 * Ver 2.0
 */

using System;

namespace EmailSenderImplementation1
{
    public class EmailSenderImplementationOne : EmailSenderInterfaces.IEmailSender
    {
        public bool SendEmail(string to, string body)
        {
            Console.WriteLine("EmailSenderImpl 1"+" "+to+" "+body);
            return true;
        
        }
    }
}
