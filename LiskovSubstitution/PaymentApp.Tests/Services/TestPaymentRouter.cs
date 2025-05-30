using PaymentApp.Interfaces;
using PaymentApp.Services;

namespace PaymentApp.Tests.Services;

public class TestPaymentRouter
{
  public class DummyPayment : ICharger
  {
    public bool Charged { get; private set; }

    public void Charge(decimal amount, string reference)
    {
      // Simulate charging logic
      Charged = true;
      Console.WriteLine($"Charged {amount} with reference {reference}.");
    }
  }

  public class DummyRefunde : IRefunder
  {
    public bool Refunded { get; private set; }

    public void Refund(decimal amount, string reference)
    {
      Refunded = true;
    }
  }

  [Fact]
  public void TryRefund_ShouldSkip_WhenNotSupported()
  {
    var dummyPayment = new DummyPayment();
    dummyPayment.Charge(100, "dummy"); // Simulate a charge
    var paymentRouter = new PaymentRouter([dummyPayment], []);

    var result = paymentRouter.TryRefund("dummy", 100, "ref123");

    Assert.False(result);
  }

  // TODO: Implement a positive scenario for refund
  [Fact]
  public void TryRefund_ShouldReturnTrue_WhenSupported()
  {
    var dummyPayment = new DummyPayment();
    var dummyRefunder = new DummyRefunde();
    var paymentRouter = new PaymentRouter([dummyPayment], [dummyRefunder]);
    paymentRouter.Charge("Dummy", 100, "dummy1");

    var result = paymentRouter.TryRefund("Dummy", 100, "dummy1");

    Assert.True(result);
    Assert.True(dummyPayment.Charged); // Assuming refund also charges in this dummy implementation
  }
}