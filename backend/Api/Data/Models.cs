namespace Api.Data;

// Given by the exercise. You may add fields or indexes; say why in your README.

public class Subscription
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public string Name { get; set; } = "";
}

public class MeteringEvent
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid SubscriptionId { get; set; }
    public string ExternalEventId { get; set; } = "";
    public string Dimension { get; set; } = "";       // e.g. "api-calls", "seats"
    public decimal Quantity { get; set; }
    public DateTime EventTimeUtc { get; set; }         // when the usage happened
    public DateTime ReceivedAtUtc { get; set; }        // when we received it
}
