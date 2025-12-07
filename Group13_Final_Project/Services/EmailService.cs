using System.Net;
using System.Net.Mail;
using System.Text;
using Group13_Final_Project.Models;

namespace Group13_Final_Project.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;
        private readonly string _fromEmail;
        private readonly string _fromName;
        private readonly bool _enableSsl;

        public EmailService(IConfiguration configuration)
        {
            // Read from configuration - defaults for Gmail
            _smtpHost = configuration["Email:SmtpHost"] ?? "smtp.gmail.com";
            _smtpPort = int.Parse(configuration["Email:SmtpPort"] ?? "587");
            _smtpUsername = configuration["Email:Username"] ?? "";
            _smtpPassword = configuration["Email:Password"] ?? "";
            _fromEmail = configuration["Email:FromEmail"] ?? _smtpUsername;
            _fromName = configuration["Email:FromName"] ?? "Bevo's Books - Team 13";
            _enableSsl = bool.Parse(configuration["Email:EnableSsl"] ?? "true");
        }

        private async Task SendEmailAsync(string toEmail, string subject, string htmlBody)
        {
            // Skip if email not configured
            if (string.IsNullOrEmpty(_smtpUsername) || string.IsNullOrEmpty(_smtpPassword))
            {
                Console.WriteLine($"[EMAIL NOT CONFIGURED] Would send to: {toEmail}, Subject: {subject}");
                return;
            }

            try
            {
                using var client = new SmtpClient(_smtpHost, _smtpPort)
                {
                    Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
                    EnableSsl = _enableSsl
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_fromEmail, _fromName),
                    Subject = subject,
                    Body = htmlBody,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(toEmail);

                await client.SendMailAsync(mailMessage);
                Console.WriteLine($"[EMAIL SENT] To: {toEmail}, Subject: {subject}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EMAIL ERROR] Failed to send to {toEmail}: {ex.Message}");
                // Don't throw - email failure shouldn't break the application
            }
        }

        public async Task SendWelcomeEmailAsync(string toEmail, string firstName)
        {
            var subject = "Team 13: Welcome to Bevo's Books!";
            var body = $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .header {{ background-color: #0d6efd; color: white; padding: 20px; text-align: center; }}
        .content {{ padding: 20px; background-color: #f8f9fa; }}
        .footer {{ padding: 10px; text-align: center; font-size: 12px; color: #666; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>Welcome to Bevo's Books!</h1>
        </div>
        <div class='content'>
            <p>Dear {firstName},</p>
            <p>Thank you for creating an account with Bevo's Books! We're excited to have you as a customer.</p>
            <p>You can now:</p>
            <ul>
                <li>Browse our extensive collection of books</li>
                <li>Add items to your shopping cart</li>
                <li>Save your favorite payment methods</li>
                <li>Write reviews for books you've purchased</li>
            </ul>
            <p>Happy reading!</p>
            <p>Best regards,<br/>The Bevo's Books Team</p>
        </div>
        <div class='footer'>
            <p>Team 13 - MIS 333K Fall 2025</p>
        </div>
    </div>
</body>
</html>";

            await SendEmailAsync(toEmail, subject, body);
        }

        public async Task SendOrderConfirmationEmailAsync(string toEmail, string firstName, Order order, List<Book> recommendations)
        {
            var subject = $"Team 13: Order Confirmation #{order.OrderNumber}";

            var orderItemsHtml = new StringBuilder();
            foreach (var item in order.OrderDetails)
            {
                orderItemsHtml.AppendLine($@"
                    <tr>
                        <td style='padding: 8px; border-bottom: 1px solid #ddd;'>{item.Book?.Title ?? "Unknown"}</td>
                        <td style='padding: 8px; border-bottom: 1px solid #ddd;'>{item.Book?.Authors ?? "Unknown"}</td>
                        <td style='padding: 8px; border-bottom: 1px solid #ddd; text-align: center;'>{item.Quantity}</td>
                        <td style='padding: 8px; border-bottom: 1px solid #ddd; text-align: right;'>{item.Price:C}</td>
                        <td style='padding: 8px; border-bottom: 1px solid #ddd; text-align: right;'>{item.LineTotal:C}</td>
                    </tr>");
            }

            var recommendationsHtml = new StringBuilder();
            if (recommendations != null && recommendations.Any())
            {
                recommendationsHtml.AppendLine("<h3>You Might Also Like:</h3><ul>");
                foreach (var book in recommendations)
                {
                    var rating = book.AverageRating > 0 ? $" - Rating: {book.AverageRating:F1}/5" : "";
                    recommendationsHtml.AppendLine($"<li><strong>{book.Title}</strong> by {book.Authors} - {book.Price:C}{rating}</li>");
                }
                recommendationsHtml.AppendLine("</ul>");
            }

            var couponInfo = "";
            if (order.Coupon != null)
            {
                if (order.Coupon.CouponType == CouponTypeEnum.PercentOff)
                {
                    couponInfo = $@"<tr><td colspan='4' style='text-align: right; color: green;'>Coupon ({order.Coupon.CouponCode}): {order.Coupon.DiscountPercent}% off</td><td style='text-align: right; color: green;'>-{(order.Subtotal * order.Coupon.DiscountPercent.Value / 100):C}</td></tr>";
                }
                else
                {
                    couponInfo = $@"<tr><td colspan='4' style='text-align: right; color: green;'>Coupon ({order.Coupon.CouponCode}): Free Shipping</td><td style='text-align: right; color: green;'>Applied</td></tr>";
                }
            }

            var body = $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .header {{ background-color: #198754; color: white; padding: 20px; text-align: center; }}
        .content {{ padding: 20px; background-color: #f8f9fa; }}
        .footer {{ padding: 10px; text-align: center; font-size: 12px; color: #666; }}
        table {{ width: 100%; border-collapse: collapse; }}
        th {{ background-color: #0d6efd; color: white; padding: 10px; text-align: left; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>Order Confirmed!</h1>
        </div>
        <div class='content'>
            <p>Dear {firstName},</p>
            <p>Thank you for your order! Here are the details:</p>

            <p><strong>Order Number:</strong> #{order.OrderNumber}<br/>
            <strong>Order Date:</strong> {order.OrderDate:MMMM d, yyyy}<br/>
            <strong>Status:</strong> {order.OrderStatus}</p>

            <h3>Order Items:</h3>
            <table>
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Author</th>
                        <th style='text-align: center;'>Qty</th>
                        <th style='text-align: right;'>Price</th>
                        <th style='text-align: right;'>Total</th>
                    </tr>
                </thead>
                <tbody>
                    {orderItemsHtml}
                </tbody>
                <tfoot>
                    <tr><td colspan='4' style='text-align: right; padding-top: 10px;'><strong>Subtotal:</strong></td><td style='text-align: right; padding-top: 10px;'>{order.Subtotal:C}</td></tr>
                    <tr><td colspan='4' style='text-align: right;'>Shipping:</td><td style='text-align: right;'>{order.ShippingFee:C}</td></tr>
                    {couponInfo}
                    <tr><td colspan='4' style='text-align: right;'><strong>Total:</strong></td><td style='text-align: right;'><strong>{order.Total:C}</strong></td></tr>
                </tfoot>
            </table>

            {recommendationsHtml}

            <p>Thank you for shopping with us!</p>
            <p>Best regards,<br/>The Bevo's Books Team</p>
        </div>
        <div class='footer'>
            <p>Team 13 - MIS 333K Fall 2025</p>
        </div>
    </div>
</body>
</html>";

            await SendEmailAsync(toEmail, subject, body);
        }

        public async Task SendPasswordChangedEmailAsync(string toEmail, string firstName)
        {
            var subject = "Team 13: Your Password Has Been Changed";
            var body = $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .header {{ background-color: #ffc107; color: #333; padding: 20px; text-align: center; }}
        .content {{ padding: 20px; background-color: #f8f9fa; }}
        .footer {{ padding: 10px; text-align: center; font-size: 12px; color: #666; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>Password Changed</h1>
        </div>
        <div class='content'>
            <p>Dear {firstName},</p>
            <p>Your password has been successfully changed.</p>
            <p>If you did not make this change, please contact our support team immediately.</p>
            <p>Best regards,<br/>The Bevo's Books Team</p>
        </div>
        <div class='footer'>
            <p>Team 13 - MIS 333K Fall 2025</p>
        </div>
    </div>
</body>
</html>";

            await SendEmailAsync(toEmail, subject, body);
        }

        public async Task SendDiscontinuedItemEmailAsync(string toEmail, string firstName, string bookTitle, string bookAuthor)
        {
            var subject = "Team 13: An Item in Your Cart Has Been Discontinued";
            var body = $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .header {{ background-color: #dc3545; color: white; padding: 20px; text-align: center; }}
        .content {{ padding: 20px; background-color: #f8f9fa; }}
        .footer {{ padding: 10px; text-align: center; font-size: 12px; color: #666; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>Item Discontinued</h1>
        </div>
        <div class='content'>
            <p>Dear {firstName},</p>
            <p>We wanted to let you know that the following item in your shopping cart has been discontinued:</p>
            <p style='padding: 15px; background-color: #fff; border-left: 4px solid #dc3545;'>
                <strong>{bookTitle}</strong><br/>
                by {bookAuthor}
            </p>
            <p>This item has been removed from your cart. We apologize for any inconvenience.</p>
            <p>Please visit our website to browse our other available books!</p>
            <p>Best regards,<br/>The Bevo's Books Team</p>
        </div>
        <div class='footer'>
            <p>Team 13 - MIS 333K Fall 2025</p>
        </div>
    </div>
</body>
</html>";

            await SendEmailAsync(toEmail, subject, body);
        }
    }
}
