using NotificationSystem.BaseClsses;

namespace NotificationSystem.Observer.Subscribers.PostNotifications;

public class EmailNotification : BaseNotification,IObserver<BaseEvent>
{
    protected override void BeforeHandle(BaseEvent value)
    {
        Console.WriteLine("📧 Sending Email...");
    }

    protected override void AfterHandle(BaseEvent value)
    {
        Console.WriteLine("✅ Email sent!\n");
    }
}