namespace Api.Data;

// Synthetic data so the frontend has something to show. Change or extend it freely.
public static class SeedData
{
    public static readonly Guid TenantA = Guid.Parse("11111111-1111-1111-1111-111111111111");
    public static readonly Guid TenantB = Guid.Parse("22222222-2222-2222-2222-222222222222");
    public static readonly Guid SubscriptionA = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
    public static readonly Guid SubscriptionB = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");

    public static void Apply(AppDbContext db)
    {
        if (db.Subscriptions.Any()) return;

        db.Subscriptions.AddRange(
            new Subscription { Id = SubscriptionA, TenantId = TenantA, Name = "Contoso Analytics" },
            new Subscription { Id = SubscriptionB, TenantId = TenantB, Name = "Fabrikam Reports" });

        db.MeteringEvents.AddRange(
            Event(SubscriptionA, TenantA, "evt-1", "api-calls", 1200, new(2026, 10, 3, 10, 0, 0), new(2026, 10, 3, 10, 5, 0)),
            Event(SubscriptionA, TenantA, "evt-2", "seats", 15, new(2026, 10, 15, 0, 0, 0), new(2026, 10, 15, 0, 2, 0)),
            Event(SubscriptionA, TenantA, "evt-3", "api-calls", 800, new(2026, 10, 31, 23, 30, 0), new(2026, 11, 1, 8, 0, 0)),
            Event(SubscriptionB, TenantB, "evt-4", "api-calls", 50, new(2026, 10, 5, 9, 0, 0), new(2026, 10, 5, 9, 1, 0)));

        db.SaveChanges();
    }

    private static MeteringEvent Event(Guid sub, Guid tenant, string ext, string dim, decimal qty, DateTime at, DateTime received) => new()
    {
        Id = Guid.NewGuid(),
        TenantId = tenant,
        SubscriptionId = sub,
        ExternalEventId = ext,
        Dimension = dim,
        Quantity = qty,
        EventTimeUtc = DateTime.SpecifyKind(at, DateTimeKind.Utc),
        ReceivedAtUtc = DateTime.SpecifyKind(received, DateTimeKind.Utc),
    };
}
