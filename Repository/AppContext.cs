

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppContext : IdentityDbContext<AppUser, IdentityRole<int>, int>{
    public AppContext(DbContextOptions options) : base(options) 
    {
        
    }

    public DbSet<Contact> Contacts { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Stock> Stocks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Stock>().Navigation(e => e.Product).AutoInclude();
        builder.Entity<Order>().Navigation(e => e.OrderItems).AutoInclude();
        builder.Entity<OrderItem>().Navigation(e => e.Product).AutoInclude();
        base.OnModelCreating(builder);
    }


}