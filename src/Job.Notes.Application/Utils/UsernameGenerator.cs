using System.Security.Cryptography;
using System.Text;

namespace Job.Notes.Application.Utils;

public static class UsernameGenerator
{
    public static string Generate(string name, string lastname, string mail)
    {
        var formatBaseName = name.Substring(0, 2) + lastname;
        var totalLength = name.Length + lastname.Length + mail.Length;
        var randomLength = new Random();
        var randomNumber = new Random();

        var prefixRandom = randomLength.Next(0, totalLength);
        var finalRandom = randomNumber.Next(100, 1000);


        var username = formatBaseName + prefixRandom + totalLength + finalRandom;
        return username.ToLower();
    }
}