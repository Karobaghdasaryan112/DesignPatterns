using NotificationSystem.BaseClsses;
using NotificationSystem.Contracts;

namespace NotificationSystem.Observer.Events;

public class UserFollowedEvent(IEntity data) : BaseEvent(data)
{
    
}