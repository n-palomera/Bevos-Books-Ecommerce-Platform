using Group13_Final_Project.Models;

namespace Group13_Final_Project.Services
{
    public interface IEmailService
    {
        Task SendWelcomeEmailAsync(string toEmail, string firstName);
        Task SendOrderConfirmationEmailAsync(string toEmail, string firstName, Order order, List<Book> recommendations);
        Task SendPasswordChangedEmailAsync(string toEmail, string firstName);
        Task SendDiscontinuedItemEmailAsync(string toEmail, string firstName, string bookTitle, string bookAuthor);
    }
}
