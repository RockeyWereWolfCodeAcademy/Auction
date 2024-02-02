using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.DTOs.AuthDTOs;

public class TokenDTO
{
    public string Token { get; set; }
    public DateTime ValidUntil { get; set; }
}
