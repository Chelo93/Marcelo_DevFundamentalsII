using PaymentApp.Interfaces;

namespace PaymentApp.Services;

public class PaymentRouter(IEnumerable<ICharger> chargers, IEnumerable<IRefunder> refunders) : IPaymentRouter
{
  private readonly Dictionary<string, ICharger> _chargers = chargers.ToDictionary(c => c.GetType().Name[..^7].ToLower()); 
  private readonly Dictionary<string, IRefunder> _refunders = refunders.ToDictionary(r => r.GetType().Name[..^7].ToLower());

  public void Charge(string method, decimal amount, string reference)
  {
    method = method.ToLower();
    _chargers[method].Charge(amount, reference);
  }

  // TODO: Enhance this method apply simple Single Responsibility Principle
  public bool TryRefund(string method, decimal amount, string reference)
  {
    method = method.ToLower();
    var isRefunderAvailable = ValidateIfRefunderExists(method, amount, reference);
    return isRefunderAvailable;
  }

  private bool ValidateIfRefunderExists(string method, decimal amount, string reference)
  {
    var isRefunderAvailable = _refunders.TryGetValue(method, out var refunder);
    if (isRefunderAvailable)
    {
      refunder!.Refund(amount, reference);
    }
    else
    {
      ShowRefundNotSupportedMessage(method);
    }
    return isRefunderAvailable;
  }

  private static void ShowRefundNotSupportedMessage(string method)
  {
    Console.WriteLine($"Refund not supported for method {method}.");
  }
}