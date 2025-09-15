namespace SingleResponsibility
{
    public class OrderManager
    {
        public void ProcessOrder(Order order)
        {
            if (!ValidateOrder(order))
            {
                LogError("Invalid order");
                return;
            }

            var discount = CalculateDiscount(order);
            SendConfirmationEmail(order.CustomerEmail);
        }

        private bool ValidateOrder(Order order)
        {
            // Validering af ordre
            return order.Amount > 0;
        }

        private decimal CalculateDiscount(Order order)
        {
            // Rabatberegning
            return order.Amount > 1000 ? 0.1m : 0.0m;
        }

        private void SendConfirmationEmail(string email)
        {
            // Simulerer e-mail afsendelse
            Console.WriteLine($"Email sent to {email}");
        }

        private void LogError(string message)
        {
            // Simulerer logning
            Console.WriteLine($"Error: {message}");
        }
    }

    public class Order
    {
        public string CustomerEmail { get; internal set; }
        public int Amount { get; internal set; }
    }
}
