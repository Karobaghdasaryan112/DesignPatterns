using NotificationSystem.BaseClsses;
using NotificationSystem.Contracts;

namespace NotificationSystem.Observer.Subscribers.PostNotifications;

public class AuditLoggerNotification : BaseNotification, IObserver<BaseEvent>
{
    public AuditLoggerNotification(Dictionary<Type, IEventHandler<BaseEvent>> observers) : base(observers)
    {
    }

    protected override void BeforeHandle(BaseEvent value)
    {
        Console.WriteLine("🧾 Logging event...");
    }

    protected override void AfterHandle(BaseEvent value)
    {
        Console.WriteLine("✅ Logged!\n");
    }
}