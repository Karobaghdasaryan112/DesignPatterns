using NotificationSystem.BaseClsses;
using NotificationSystem.Contracts;

namespace NotificationSystem.Observer.Subscribers.PostNotifications;

public class EmailNotification : BaseNotification
{
    public EmailNotification(Dictionary<Type, IEventHandler<BaseEvent>> observers) : base(observers)
    {
    }

    protected override void BeforeHandle(BaseEvent value)
    {
        Console.WriteLine("📧 Sending Email...");
    }

    protected override void AfterHandle(BaseEvent value)
    {
        Console.WriteLine("✅ Email sent!\n");
    }
}