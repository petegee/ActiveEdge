using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using Shared;
using IApplicationUserManager = Domain.IApplicationUserManager;

namespace ActiveEdge.Infrastructure
{
    public class ApplicationUserManager : UserManager<ApplicationUser>, IApplicationUserManager
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
            // Configure validation logic for usernames
            UserValidator = new UserValidator<ApplicationUser>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            // Configure user lockout defaults
            UserLockoutEnabledByDefault = true;
            DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            MaxFailedAccessAttemptsBeforeLockout = 5;

            //// Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            //// You can write your own provider and plug it in here.
            //this.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<User>
            //{
            //    MessageFormat = "Your security code is {0}"
            //});
            //this.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ushort>
            //{
            //    Subject = "Security Code",
            //    BodyFormat = "Your security code is {0}"
            //});
            EmailService = new EmailService();
            //SmsService = new SmsService();

             var dataProtectionProvider = Startup.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                var dataProtector = dataProtectionProvider.Create("ASP.NET Identity");

                UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtector);
            }
        }

    }

    public class EmailService : IIdentityMessageService
    {
        /// <summary>This method should send the message</summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendAsync(IdentityMessage message)
        {
            var toAddress = new MailAddress(message.Destination);

            MailMessage mailMessage = new MailMessage(new MailAddress("no-reply@activeedge.co.nz"), toAddress);

            mailMessage.Subject = message.Subject;
            mailMessage.Body = message.Body;

            var smtpClient = new SmtpClientAdaptor();

            return smtpClient.SendMailAsync(mailMessage);


        }
    }

    public class SmtpClientAdaptor : ISmtpClientAdaptor, IDisposable
    {
        private readonly SmtpClient _client;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public SmtpClientAdaptor()
        {
            _client = new SmtpClient();
        }

        public Task SendMailAsync(MailMessage message)
        {
            return _client.SendMailAsync(message);
        }
        public void Send(MailMessage message)
        {
            _client.Send(message);

        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            _client?.Dispose();
        }
    }

    public interface ISmtpClientAdaptor
    {
        void Send(MailMessage message);
        Task SendMailAsync(MailMessage message);
    }
}