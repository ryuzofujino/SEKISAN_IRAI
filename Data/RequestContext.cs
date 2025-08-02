using Microsoft.EntityFrameworkCore;
using SEKISAN_IRAI.Models;

namespace SEKISAN_IRAI.Data;

public class RequestContext : DbContext
{
    public RequestContext(DbContextOptions<RequestContext> options) : base(options)
    {
    }

    public DbSet<Request> Requests => Set<Request>();
}