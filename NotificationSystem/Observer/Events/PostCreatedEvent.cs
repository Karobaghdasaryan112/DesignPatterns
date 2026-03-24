using NotificationSystem.BaseClsses;
using NotificationSystem.Contracts;

namespace NotificationSystem.Observer.Events;

public class PostCreatedEvent(IEntity data) : BaseEvent(data)
{
       
}