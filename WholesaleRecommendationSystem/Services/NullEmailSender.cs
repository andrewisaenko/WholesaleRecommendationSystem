﻿using Microsoft.AspNetCore.Identity.UI.Services;

namespace WholesaleRecommendationSystem.Services
{
    public class NullEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
