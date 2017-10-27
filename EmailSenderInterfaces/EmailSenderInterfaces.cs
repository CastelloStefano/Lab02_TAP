/*
 * Ver 2.0
 */

namespace EmailSenderInterfaces
{
    public interface IEmailSender
    {
        bool SendEmail(string to, string body);
    }
}
