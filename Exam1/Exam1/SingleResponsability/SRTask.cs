// Refactor this ProcessOrders method so that each class has one responsibility (Fix any errors you find)

using System.Text;
namespace Exam1.SingleResponsability {
    public class OrderService
    {
        private readonly List<Order> _processedOrders = new List<Order>();
        private readonly List<string> _logs = new List<string>();

        public static List<Order> InititiateOrderService()
        {
            var orders = new List<Order>
            {
                new Order("A100", 2, 15.50m),
                new Order("B200", 1, 99.99m),
                new Order("C300", 5, 7.25m)
            };
            return orders;

        }

        public void validateOrder(Order order)
        {
            if (order.Quantity <= 0)
            {
                _logs.Add($"[{DateTime.UtcNow}] Invalid quantity for order {order.Id}");
                return;
            }
            if (order.UnitPrice <= 0)
            {
                _logs.Add($"[{DateTime.UtcNow}] Invalid price for order {order.Id}");
                return;
            }
        }

        public void AddOrder(Order order)
        {
            _processedOrders.Add(order);
        }

        public string GetOrderReport()
        {
            var report = new StringBuilder();
            report.AppendLine("---- Order Report ----");
            foreach (var order in _processedOrders)
            {
                report.AppendLine($"Order {order.Id}: {order.Quantity} × {order.UnitPrice:C} = {order.Total:C}");
            }
            return report.ToString();
        }
        
        public void LogsClear()
        {
            _logs.Clear();
        }

        public void ProcessOrders()
        {
            // 1. Inline order data
            var orders = InititiateOrderService();


            foreach (var order in orders)
            {
                // 2. Validate each order
                validateOrder(order);
                // 3. Compute total
                //order.Total is now a computed property, no assignment needed
                // 4. Add to processed list
                AddOrder(order);
            }

            // 6. “Send” report by printing to console
            Console.WriteLine(GetOrderReport());
            // 7. Clear logs for next run
            LogsClear();
        }
    }

    public record Order(
    string Id,
    int Quantity,
    decimal UnitPrice
    )
    {
        public decimal Total => Quantity * UnitPrice;
    }
}



