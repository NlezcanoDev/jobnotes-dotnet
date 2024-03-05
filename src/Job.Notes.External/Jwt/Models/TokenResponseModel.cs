namespace Job.Notes.External.Jwt.Models;

public class TokenResponseModel
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}