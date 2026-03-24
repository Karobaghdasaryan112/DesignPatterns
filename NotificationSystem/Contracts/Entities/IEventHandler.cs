using NotificationSystem.BaseClsses;

namespace NotificationSystem.Contracts;

public interface IEventHandler<out T> where T : BaseEvent
{
    public void Handle(BaseEvent baseEvent);
}