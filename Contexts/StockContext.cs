using Microsoft.EntityFrameworkCore;
using PeakTaskBackend.Models;

namespace PeakTaskBackend.Contexts;

public class StockContext : DbContext
{
    public StockContext(DbContextOptions<StockContext> options) : base(options) { }
    
    public DbSet<StockItem> Stocks { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StockItem>().ToTable("Stock");
    }
}