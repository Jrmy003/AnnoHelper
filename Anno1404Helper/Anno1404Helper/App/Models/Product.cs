namespace Anno1404Helper.App.Models;

public class Product
{
    public int Guid { get; set; }
    public string IconPath { get; set; }
    public LocaText LocaText { get; set; }
    public string Name { get; set; }
    public List<int> Producers { get; set; }
}