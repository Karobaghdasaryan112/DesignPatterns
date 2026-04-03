using DesignPatterns.Observer.Microsoft_IObserver_Implementation.Observables;
using DesignPatterns.Observer.Microsoft_IObserver_Implementation.Observers;

public class Program
{
    public static void Main(string[] args)
    {
        BaggageHandler provider = new();
        ArrivalsMonitor observer1 = new("BaggageClaimMonitor1");
        ArrivalsMonitor observer2 = new("SecurityExit");

        provider.BaggageStatus(712, "Detroit", 3);
        provider.BaggageStatus(713, "Detroit", 3); 
        provider.BaggageStatus(714, "Detroit", 3); 
        provider.BaggageStatus(715, "Detroit", 3); 
        provider.BaggageStatus(716, "Detroit", 3);

        observer1.Subscribe(provider);

        provider.BaggageStatus(712, "Kalamazoo", 3);
        provider.BaggageStatus(400, "New York-Kennedy", 1);
        provider.BaggageStatus(712, "Detroit", 3);
        observer2.Subscribe(provider);

        provider.BaggageStatus(511, "San Francisco", 2);
        provider.BaggageStatus(712);
        observer2.Unsubscribe();

        provider.BaggageStatus(400);
        provider.LastBaggageClaimed();
    }
}

