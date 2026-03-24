using NotificationSystem.BaseClsses;
using NotificationSystem.Contracts;

public class BaseNotification(Dictionary<Type, IEventHandler<BaseEvent>> observers) : IObserver<BaseEvent>
{

    public virtual void OnNext(BaseEvent value)
    {
        if (observers.TryGetValue(value.GetType(), out var handler))
        {
            BeforeHandle(value);
            handler.Handle(value);
            AfterHandle(value);
        }
    }

    protected virtual void BeforeHandle(BaseEvent value)
    {

    }

    protected virtual void AfterHandle(BaseEvent value)
    {

    }

    public void OnCompleted() { }
    public void OnError(Exception error)
    {
        Console.WriteLine($"[ERROR] {error.Message}");
    }

}