using NotificationApp.Interfaces;
using NotificationApp.Models;

namespace NotificationApp.Services;

// NOTE: This can be MobileNotiicationFacade depends on the context
public class NotificationFacade(IEmailSender email, ISmsSender sms, IPushSender push) : INotificationFacade
{
  private readonly IEmailSender _emailSender = email;
  private readonly ISmsSender _smsSender = sms;
  private readonly IPushSender _pushSender = push;

  // OPTIONAL: Create a high interface INotification for all notification types (BTW, the notifacion types might empty)
  public void Notify(OrderEvent orderEvent)
  {
    var subject = $"Order #{orderEvent.OrderId} status: {orderEvent.Status}";
    var body = $"Hi {orderEvent.Customer}, your order is now {orderEvent.Status}";

    //TODO: enhance these calls
    var notificationActions = new List<Action>();

    if (orderEvent.NotifyEmail && !string.IsNullOrWhiteSpace(orderEvent.CustomerEmail))
        notificationActions.Add(() => _emailSender.SendEmail(orderEvent.CustomerEmail, subject, body));

    if (orderEvent.NotifySms && !string.IsNullOrWhiteSpace(orderEvent.CustomerPhone))
        notificationActions.Add(() => _smsSender.SendSms(orderEvent.CustomerPhone, body));

    if (orderEvent.NotifyPush && !string.IsNullOrWhiteSpace(orderEvent.DeviceToken))
        notificationActions.Add(() => _pushSender.SendPush(orderEvent.DeviceToken, "Order Update", body));

    foreach (var action in notificationActions)
    {
        action();
    }
  }
}