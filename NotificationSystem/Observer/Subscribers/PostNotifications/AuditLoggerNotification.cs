using NotificationSystem.BaseClsses;

namespace NotificationSystem.Observer.Subscribers.PostNotifications;

public class AuditLoggerNotification : BaseNotification, IObserver<BaseEvent>
{
    protected override void BeforeHandle(BaseEvent value)
    {
        Console.WriteLine("🧾 Logging event...");
    }

    protected override void AfterHandle(BaseEvent value)
    {
        Console.WriteLine("✅ Logged!\n");
    }
}