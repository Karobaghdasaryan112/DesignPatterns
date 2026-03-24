using NotificationSystem.BaseClsses;
using NotificationSystem.Contracts;
using NotificationSystem.Entities;

namespace NotificationSystem.Observer.Subscribers.PostNotifications;

public class SmsNotification : BaseNotification,IObserver<BaseEvent>
{
    public SmsNotification(Dictionary<Type, IEventHandler<BaseEvent>> observers) : base(observers)
    {
    }

    protected override void BeforeHandle(BaseEvent value)
    {
        Console.WriteLine("📱 Sending SMS...");
    }

    protected override void AfterHandle(BaseEvent value)
    {
        Console.WriteLine("✅ SMS sent!\n");
    }
}