namespace APBD_PJATK_Cw4_s29764.DTOs;

public record ComponentResponse(
    string Code,
    string Name,
    string Description,
    ComponentManufacturerResponse Manufacturer,
    ComponentTypeResponse Type
    );