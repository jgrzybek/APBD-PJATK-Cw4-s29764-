namespace APBD_PJATK_Cw4_s29764.Models;

public class ComponentManufacturer
{
    public int Id { get; set; }
    public string Abbreviation { get; set; } = string.Empty;
    public string FullName { get; set; } =  string.Empty;
    public DateOnly FoundationDate { get; set; }
    public IEnumerable<Component> Components { get; set; } = [];
}