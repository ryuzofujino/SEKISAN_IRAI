using Microsoft.EntityFrameworkCore;
using SEKISAN_IRAI.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Request> Requests { get; set; }
}
