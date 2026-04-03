namespace DesignPatterns.Observer.Microsoft_IObserver_Implementation.Events
{
    /// <summary>
    /// Immutable data structure that encapsulates baggage information
    /// delivered to observers: flight number, origin, and carousel.
    /// </summary>
    public readonly record struct BaggageInfo(
        int FlightNumber,
        string From,
        int Carousel
    );
}
