namespace Api.Tenancy;

public interface ICurrentTenant
{
    Guid TenantId { get; } // the tenant of the logged-in user
}

// Stand-in for real authentication: reads the tenant from the X-Tenant-Id header.
// Keep it; real sign-in is out of scope for this exercise.
public class HeaderCurrentTenant(IHttpContextAccessor http) : ICurrentTenant
{
    public Guid TenantId =>
        Guid.TryParse(http.HttpContext?.Request.Headers["X-Tenant-Id"], out var id)
            ? id
            : throw new UnauthorizedAccessException("Missing or invalid X-Tenant-Id header.");
}
