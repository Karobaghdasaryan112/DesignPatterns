using NotificationSystem.BaseClsses;
using NotificationSystem.Contracts;
using NotificationSystem.Entities;

namespace NotificationSystem.Observer.Subscribers.PostNotifications;

public class PushNotification : BaseNotification, IObserver<BaseEvent>
{
    public PushNotification(Dictionary<Type, IEventHandler<BaseEvent>> observers) : base(observers)
    {
    }

    protected override void BeforeHandle(BaseEvent value)
    {
        Console.WriteLine("🔔 Sending Push Notification...");
    }

    protected override void AfterHandle(BaseEvent value)
    {
        Console.WriteLine("✅ Push delivered!\n");
    }
}