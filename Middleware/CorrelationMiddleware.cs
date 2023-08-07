namespace icarus.gateway.Middleware;
public class CorrelationMiddleware
{
    HttpContext _context;
    readonly string correlationHeader = "X-CorrelationHeader";
    public void AdicionarCorrelation()
        => _context.Request.Headers.Add(correlationHeader, Guid.NewGuid().ToString());
}
