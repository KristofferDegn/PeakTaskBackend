namespace PeakTaskBackend.Models;

public class StockItem
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int Amount { get; set; }
    public string ItemNumber { get; set; }
    public string Location { get; set; }

    /* common practice would probably be to break location info down into fields somewhat like these
    public string Warehouse { get; set; }
    public string Rack { get; set; }
    public string Unit { get; set; }
    public string Shelf { get; set; }
    Or maybe just keep it as a formatted string that you decode in the Fe. depends on the actualities
    */
}