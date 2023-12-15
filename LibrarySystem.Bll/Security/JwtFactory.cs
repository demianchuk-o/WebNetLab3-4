using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using LibrarySystem.DAL.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LibrarySystem.Bll.Security;

public class JwtFactory
{
    private readonly IConfiguration _configuration;

    public JwtFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateJwt(User user, string role)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, role)
        };

        var key = Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value);
        
        var symmetricKey = new SymmetricSecurityKey(key);
        var creds = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
}