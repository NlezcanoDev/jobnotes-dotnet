using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Job.Notes.External.Jwt.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Job.Notes.External.Jwt.GetTokenJwt;

public class GetTokenJwtService : IGetTokenJwtModel
{
    private readonly IConfiguration _configuration;
    
    public GetTokenJwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public TokenResponseModel Execute(UserCredentialsModel credentialsModel)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = _configuration["JwtKey"] ?? string.Empty;
        var expires = DateTime.UtcNow.AddDays(15);

        var singingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var claims = new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, credentialsModel.Id.ToString()),
            new Claim("Mail", credentialsModel.Mail)
        });

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = claims,
            Expires = expires,
            SigningCredentials = new SigningCredentials(singingKey, SecurityAlgorithms.HmacSha256),
            Issuer = null,
            Audience = null,
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new TokenResponseModel()
        {
            Token = tokenHandler.WriteToken(token),
            Expiration = expires
        };
    }
}