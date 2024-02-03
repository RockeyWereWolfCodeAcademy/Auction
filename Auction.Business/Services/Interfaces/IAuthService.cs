using Auction.Business.DTOs.AuthDTOs;
using Auction.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Services.Interfaces;

public interface IAuthService
{
    public Task<TokenDTO> Login(LoginDTO dto);
    public Task<bool> ConfirmEmail(string token, string email);
    public Task<string> GetConfirmationToken(RegisterDTO dto);
}
