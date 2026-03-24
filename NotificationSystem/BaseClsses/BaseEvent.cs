using NotificationSystem.Contracts;

namespace NotificationSystem.BaseClsses;

public class BaseEvent(IEntity data)
{
    public IEntity GetData() => data;
    public DateTime GetDate() => DateTime.Now;
}