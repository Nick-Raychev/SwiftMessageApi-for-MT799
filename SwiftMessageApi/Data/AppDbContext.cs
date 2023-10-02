using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
         SwiftMessages = Set<SwiftMessage>();
    }

    public DbSet<SwiftMessage> SwiftMessages { get; set; }
}