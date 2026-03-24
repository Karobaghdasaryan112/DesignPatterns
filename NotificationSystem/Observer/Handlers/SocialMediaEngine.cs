using NotificationSystem.BaseClsses;

namespace NotificationSystem.Observer.Handlers;

public class SocialMediaProvider : IObservable<BaseEvent>
{
    private readonly HashSet<IObserver<BaseEvent>> _observers = [];
    
    public IDisposable Subscribe(IObserver<BaseEvent> observer)
    {
        _observers.Add(observer);
        return new UnSubscribe(_observers, observer);
    }

    public void Notify(BaseEvent baseEvent)
    {
        foreach (var observer in _observers)
        {
            observer.OnNext(baseEvent);
        }   
    }
    
}

public class UnSubscribe : IDisposable
{
    private readonly ISet<IObserver<BaseEvent>> _observers = null!;
    private readonly IObserver<BaseEvent> _currentObserver = null!;

    public UnSubscribe(
        ISet<IObserver<BaseEvent>> observer,
        IObserver<BaseEvent> currentObserver) =>
        (observer, currentObserver) = (_observers, _currentObserver);

    public void Dispose()
    {
        _observers?.Remove(_currentObserver);
    }
}