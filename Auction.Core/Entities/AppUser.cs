using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Core.Entities;

public class AppUser : IdentityUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? ImageUrl { get; set; }
    public IEnumerable<Item>? Items { get; set; }
    public IEnumerable<Bid>? Bids { get; set; }
    public IEnumerable<ActivityLog>? ActivityLogs { get; set; }
}
