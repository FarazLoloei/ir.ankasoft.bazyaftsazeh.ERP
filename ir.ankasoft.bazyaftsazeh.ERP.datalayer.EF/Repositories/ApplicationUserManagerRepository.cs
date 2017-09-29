using ir.ankasoft.entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;

namespace ir.ankasoft.bazyaftsazeh.ERP.datalayer.EF.Repositories
{
    //class ApplicationUserManagerRepository
    //{
    //}

    public class ApplicationUserManagerRepository : UserManager<ApplicationUser, long>
    {
        // *** ADD INT TYPE ARGUMENT TO CONSTRUCTOR CALL:
        public ApplicationUserManagerRepository(IUserStore<ApplicationUser, long> store)
            : base(store)
        {
            UserValidator = new UserValidator<ApplicationUser, long>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
        }

        public static ApplicationUserManagerRepository Create(
            IdentityFactoryOptions<ApplicationUserManagerRepository> options,
            IOwinContext context)
        {
            // *** PASS CUSTOM APPLICATION USER STORE AS CONSTRUCTOR ARGUMENT:
            var manager = new ApplicationUserManagerRepository(
                new ApplicationUserStore(context.Get<ApplicationDbContext>()));

            // Configure validation logic for usernames

            // *** ADD INT TYPE ARGUMENT TO METHOD CALL:
            manager.UserValidator = new UserValidator<ApplicationUser, long>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers.
            // This application uses Phone and Emails as a step of receiving a
            // code for verifying the user You can write your own provider and plug in here.

            // *** ADD long TYPE ARGUMENT TO METHOD CALL:
            manager.RegisterTwoFactorProvider("PhoneCode",
                new PhoneNumberTokenProvider<ApplicationUser, long>
                {
                    MessageFormat = "Your security code is: {0}"
                });

            // *** ADD long TYPE ARGUMENT TO METHOD CALL:
            manager.RegisterTwoFactorProvider("EmailCode",
                new EmailTokenProvider<ApplicationUser, long>
                {
                    Subject = "SecurityCode",
                    BodyFormat = "Your security code is {0}"
                });

            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                // *** ADD long TYPE ARGUMENT TO METHOD CALL:
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser, long>(
                        dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}