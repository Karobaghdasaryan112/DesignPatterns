using NotificationSystem.BaseClsses;
using NotificationSystem.Contracts;

namespace NotificationSystem.Observer.Events;

public class PostLikedEvent(IEntity data) : BaseEvent(data)
{
    
}