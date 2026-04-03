using System.Runtime.CompilerServices;
using DesignPatterns.Observer.Microsoft_IObserver_Implementation.Events;
using DesignPatterns.Observer.Microsoft_IObserver_Implementation.Observables;

namespace DesignPatterns.Observer.Microsoft_IObserver_Implementation.Observers
{
    //Custom Implementation Of Each Observer
    public sealed class ArrivalsMonitor(string name) : IObserver<BaggageInfo>
    {
        private readonly List<string> _flights = [];
        private readonly string _format = "{0,-20} {1,5} {2,3}";
        private IDisposable? _cancellation;

        public void Subscribe(BaggageHandler provider) =>
            _cancellation = provider.Subscribe(this);

        public void Unsubscribe()
        {
            _cancellation?.Dispose();
            _flights.Clear();
        }

        public void OnCompleted() => _flights.Clear();

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(BaggageInfo info)
        {
            var updated = false;

            if (info.Carousel is 0)
            {
                var flightNumber = $"{info.FlightNumber,5}";
                for (var index = _flights.Count - 1; index >= 0; index--)
                {
                    var flightInfo  = _flights[index];
                    if (flightInfo.Substring(21, 5).Equals(flightNumber))
                    {
                        updated = true;
                        _flights.RemoveAt(index);
                    }
                }
            }
            else
            {
                // Add flight if it doesn't exist in the collection.
                string flightInfo = string.Format(_format, info.From, info.FlightNumber, info.Carousel);
                if (!_flights.Contains(flightInfo))
                {
                    _flights.Add(flightInfo);
                    updated = true;
                }
            }

            if (updated)
            {
                _flights.Sort();
                Console.WriteLine($"Arrivals information from {name}");
                foreach (string flightInfo in _flights)
                {
                    Console.WriteLine(flightInfo);
                }

                Console.WriteLine();
            }
        }


    }
}
