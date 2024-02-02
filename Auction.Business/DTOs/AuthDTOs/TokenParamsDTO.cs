using Auction.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.DTOs.AuthDTOs;

public class TokenParamsDTO
{
    public AppUser User { get; set; }
    public string Role { get; set; }
}
