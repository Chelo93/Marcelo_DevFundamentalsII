using System.Text.Json;
using PaymentApp.Interfaces;
using PaymentApp.Models;

namespace PaymentApp.Cli;

public class PaymentCli(IPaymentRouter paymentRouter)
{
  private readonly IPaymentRouter _paymentRouter = paymentRouter;

  public void Run(string[] args)
  {
    // TODO: Implement validation for input arguments
    if (args.Length != 1)
    {
        Console.WriteLine("please provide a single argument containing JSON data.");
        return;
    }
    var json = args[0]; //
    var orders = JsonSerializer.Deserialize<List<Order>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;

    foreach (var order in orders)
    {
      _paymentRouter.Charge(order.Method, order.Amount, order.Reference);
    }

    Console.WriteLine("\n--- Cancel & refund second order ---");

    var cancelledOrder = orders[1];
    _paymentRouter.TryRefund(cancelledOrder.Method, cancelledOrder.Amount, cancelledOrder.Reference);
  }

}