using Microsoft.AspNetCore.Identity;
using EventPulse.Data;

namespace EventPulse.Services
{
    // A placeholder email sender - it doesn't actually send anything,
    // it just satisfies Identity's requirement so Register/login pages don't crash.
    // Swap this out for a real email provider (SendGrid, SMTP) later.
    public class NoOpEmailSender : IEmailSender<ApplicationUser>
    {
        public Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink)
            => Task.CompletedTask;

        public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
            => Task.CompletedTask;

        public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
            => Task.CompletedTask;
    }
}