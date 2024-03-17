namespace Anno1404Helper.App.Models;

public class ProductFilter
{
    public int Guid { get; set; }
    public string Icon { get; set; }
    public LocaText LocaText { get; set; }
    public string Name { get; set; }
    public List<int> Products { get; set; }
}