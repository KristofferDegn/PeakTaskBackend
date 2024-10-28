using PeakTaskBackend.Contexts;
using PeakTaskBackend.Models;

namespace PeakTaskBackend.Helpers;

public static class DbInitializer
{
    public static void Initialize(StockContext stockContext)
    {
        stockContext.Database.EnsureCreated();
        // Look for any students.
        if (stockContext.Stocks.Any())
        {
            return;   // DB has been seeded
        }
        
        int totalStockItems = 10;
        Random rand = new Random();

        for (int i = 0; i < totalStockItems; i++)
        {

            var stockItem = new StockItem()
            {
                Description = $"StockItem{i}",
                Amount = rand.Next(1000, 9999),
                ItemNumber = $"SI-{i}-{GetRandomLetter()}",
                Location = $"{rand.Next(30)}-{GetRandomLetter()}{GetRandomLetter()}-{rand.Next(99)}"
            };
            stockContext.Stocks.Add(stockItem);

        }

        stockContext.SaveChangesAsync();
    }

    public static char GetRandomLetter()
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        Random rand = new Random();
        int num = rand.Next(chars.Length);
        return chars[num];
    }
}