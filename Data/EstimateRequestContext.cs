using Microsoft.EntityFrameworkCore;
using SEKISAN_IRAI.Models;

namespace SEKISAN_IRAI.Data;

public class EstimateRequestContext : DbContext
{
    public EstimateRequestContext(DbContextOptions<EstimateRequestContext> options) : base(options)
    {
    }

    public DbSet<EstimateRequest> EstimateRequests => Set<EstimateRequest>();
}