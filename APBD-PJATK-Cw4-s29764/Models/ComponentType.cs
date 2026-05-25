namespace APBD_PJATK_Cw4_s29764.Models;

public class ComponentType
{
    public int Id { get; set; }
    public string Abbreviation { get; set; }  =  string.Empty;
    public string Name { get; set; }  =  string.Empty;
    public IEnumerable<Component> Components { get; set; } = [];
}