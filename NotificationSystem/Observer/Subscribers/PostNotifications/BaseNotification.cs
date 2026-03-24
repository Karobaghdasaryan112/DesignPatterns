using NotificationSystem.BaseClsses;
using NotificationSystem.Contracts;
using NotificationSystem.Observer.Events;
using NotificationSystem.Observer.EvetHandlers;

public abstract class BaseNotification : IObserver<BaseEvent>
{
    protected readonly Dictionary<Type, IEventHandler<BaseEvent>> Observers = new()
    {
        [typeof(PostCreatedEvent)] = new PostCreatedEventHandler(),
        [typeof(PostLikedEvent)] = new PostLikedEventHandler(),
        [typeof(UserFollowedEvent)] = new UserFolowedEventHandler()
    };

    public virtual void OnNext(BaseEvent value)
    {
        if (Observers.TryGetValue(value.GetType(), out var handler))
        {
            BeforeHandle(value);
            handler.Handle(value);
            AfterHandle(value);
        }
    }

    protected abstract void BeforeHandle(BaseEvent value);
    protected abstract void AfterHandle(BaseEvent value);

    public void OnCompleted() { }
    public void OnError(Exception error)
    {
        Console.WriteLine($"[ERROR] {error.Message}");
    }
}