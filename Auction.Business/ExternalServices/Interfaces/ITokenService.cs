using Auction.Business.DTOs.AuthDTOs;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.ExternalServices.Interfaces;

public interface ITokenService
{
    public TokenDTO GenerateJWT(TokenParamsDTO dto);
    public JwtSecurityToken ValidateToken(string token);
}
