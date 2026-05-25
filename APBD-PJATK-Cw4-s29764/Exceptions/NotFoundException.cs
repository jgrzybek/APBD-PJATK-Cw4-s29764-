namespace APBD_PJATK_Cw4_s29764.Exceptions;

public class NotFoundException(string what, int id) : Exception($"{what} with id {id} not found");