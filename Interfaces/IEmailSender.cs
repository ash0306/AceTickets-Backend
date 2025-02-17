﻿namespace MovieBookingBackend.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message, byte[] attachment = null, string attachmentName = null);
    }
}
