namespace APBD_PJATK_Cw4_s29764.Models;

public class Component
{
    public string Code { get; set; } =  String.Empty;
    public string Name { get; set; } =  string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ComponentManufacturersId { get; set; }
    public int ComponentTypesId { get; set; }
    public IEnumerable<PcComponent> PcComponents { get; set; } = [];
    public ComponentType ComponentType { get; set; } = null!;
    public ComponentManufacturer ComponentManufacturer { get; set; } = null!;
}