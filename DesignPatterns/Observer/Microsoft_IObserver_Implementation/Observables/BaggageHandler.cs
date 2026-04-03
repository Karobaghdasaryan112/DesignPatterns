using DesignPatterns.Observer.Microsoft_IObserver_Implementation.Events;

namespace DesignPatterns.Observer.Microsoft_IObserver_Implementation.Observables
{
    //Subscription Method
    //To add new Observer into observers for feature Notifications
    public sealed class BaggageHandler : IObservable<BaggageInfo>
    {
        private readonly HashSet<IObserver<BaggageInfo>> _observers = [];
        private readonly HashSet<BaggageInfo> _flights = [];

        public IDisposable Subscribe(IObserver<BaggageInfo> observer)
        {
            if (_observers.Add(observer))
                foreach (var item in _flights)
                    Notify_Event(item);

            return new UnSubscriber<BaggageInfo>(_observers, observer);
        }


        public void BaggageStatus(int flightNumber) =>
            BaggageStatus(flightNumber, string.Empty, 0);

        public void BaggageStatus(int flightNumber, string from, int carousel)
        {

            var info = new BaggageInfo(flightNumber, from, carousel);

            if ((carousel > 0 &&
                 _flights.Add(info))
                ||
                (carousel is 0 &&
                 _flights.RemoveWhere(flight => flight.FlightNumber == flightNumber) > 0))
                Notify_Event(info);

        }

        private void Notify_Event(BaggageInfo info)
            => _observers.ToList().ForEach(o => o.OnNext(info));

        private void Notify_Complete()
            => _observers.ToList().ForEach(o => o.OnCompleted());


        public void LastBaggageClaimed()
        {
            Notify_Complete();
            _observers.Clear();
        }

    }

    public class UnSubscriber<BaggageInfo> : IDisposable
    {
        private readonly ISet<IObserver<BaggageInfo>> _observers;
        private readonly IObserver<BaggageInfo> _observer;

        internal UnSubscriber(ISet<IObserver<BaggageInfo>> observers, IObserver<BaggageInfo> observer)
        {
            _observers = observers;
            _observer = observer;
        }


        public void Dispose() => _observers.Remove(_observer);

    }
}
