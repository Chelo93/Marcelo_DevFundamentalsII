using NotificationApp.Interfaces;
using NotificationApp.Models;
using NotificationApp.Services;

namespace NotificationApp.Tests.Services;

public class TestNotificationFacade
{
  public sealed class StubSms : ISmsSender
  {
    public bool Called { get; private set; }

    public void SendSms(string to, string text)
    {
      Called = true;
    }
  }

  public sealed class StubPush : IPushSender
  {
    public bool Called { get; private set; }

    public void SendPush(string token, string title, string message)
    {
      Called = true;
    }
  }

  public sealed class StubEmail : IEmailSender
  {
    public bool Called { get; private set; }

    public void SendEmail(string to, string subject, string body)
    {
      throw new NotImplementedException();
    }
  }

  [Fact]
  public void Notify_FacadeCallsOnlyRequestedChanels()
  {
    var email = new StubEmail();
    var sms = new StubSms();
    var push = new StubPush();
    var facade = new NotificationFacade(email, sms, push);

    var orderEvent = new OrderEvent(1, "Alberth", "Packed", false, true, true, "alberth@jalasoft.com", "+59178945612", "345");

    facade.Notify(orderEvent);

    Assert.True(sms.Called);
    Assert.True(push.Called);
    Assert.False(email.Called);
  }

  // TODO: Negative scenario
  [Fact]
  public void Notify_FacadeCallsNoChanels()
  {
    var email = new StubEmail();
    var sms = new StubSms();
    var push = new StubPush();
    var facade = new NotificationFacade(email, sms, push);

    var orderEvent = new OrderEvent(1, "Alberth", "Packed", false, false, false, "", "", "");
    facade.Notify(orderEvent);

    Assert.False(sms.Called);
    Assert.False(push.Called);
    Assert.False(email.Called);
  }


}