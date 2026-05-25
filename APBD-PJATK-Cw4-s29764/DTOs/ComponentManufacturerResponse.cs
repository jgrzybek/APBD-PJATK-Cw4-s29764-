namespace APBD_PJATK_Cw4_s29764.DTOs;

public record ComponentManufacturerResponse(
    int Id,
    string Abbreviation,
    string FullName,
    DateOnly FoundationDate
);