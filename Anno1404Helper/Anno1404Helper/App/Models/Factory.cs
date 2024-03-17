namespace Anno1404Helper.App.Models;

public class Factory
{
    public int Guid { get; set; }
    public string IconPath { get; set; }
    public List<Input> Inputs { get; set; }
    public LocaText LocaText { get; set; }
    public string Name { get; set; }
    public List<Output> Outputs { get; set; }
    public double Tpmin { get; set; }
}