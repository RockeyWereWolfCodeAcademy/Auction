using Auction.Business.DTOs.AuthDTOs;
using Auction.Business.ExternalServices.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.ExternalServices.Implements;

public class TokenService : ITokenService
{
    readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public TokenDTO GenerateJWT(TokenParamsDTO dto)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        List<Claim> claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.User.Id));
        claims.Add(new Claim(ClaimTypes.Name, dto.User.UserName));
        claims.Add(new Claim(ClaimTypes.GivenName, dto.User.Name + "_" + dto.User.Surname));
        claims.Add(new Claim(ClaimTypes.Role, dto.Role));

        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
          _configuration["Jwt:Issuer"],
          claims,
          notBefore: DateTime.UtcNow,
          expires: DateTime.UtcNow.AddMinutes(120),
          signingCredentials: credentials);

        return new TokenDTO
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            ValidUntil = token.ValidTo
        };
    }
}
