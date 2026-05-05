namespace IntegratedIdentity.Dtos
{
    public record UserDto(string Name,
                                string NationalId,                                
                                string TerminalCode,
                                string Password);
}
