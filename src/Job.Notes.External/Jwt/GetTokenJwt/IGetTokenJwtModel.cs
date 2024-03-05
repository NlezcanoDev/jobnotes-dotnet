using Job.Notes.External.Jwt.Models;

namespace Job.Notes.External.Jwt.GetTokenJwt;

public interface IGetTokenJwtModel
{
    TokenResponseModel Execute(UserCredentialsModel credentialsModel);
}