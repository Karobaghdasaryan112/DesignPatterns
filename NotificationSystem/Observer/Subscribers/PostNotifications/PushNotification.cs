using NotificationSystem.BaseClsses;
using NotificationSystem.Entities;

namespace NotificationSystem.Observer.Subscribers.PostNotifications;

public class PushNotification : BaseNotification, IObserver<BaseEvent>
{
    protected override void BeforeHandle(BaseEvent value)
    {
        Console.WriteLine("🔔 Sending Push Notification...");
    }

    protected override void AfterHandle(BaseEvent value)
    {
        Console.WriteLine("✅ Push delivered!\n");
    }
}