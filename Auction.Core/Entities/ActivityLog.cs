using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Core.Entities;

public class ActivityLog
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public AppUser User { get; set; }
    public int ItemId { get; set; }
    public Item Item { get; set; }
    public string Message { get; set; }
    public string MessageTemplate { get; set; }
    public string Level { get; set; }
    public DateTime TimeStamp { get; set; }
    public string? Exception { get; set; }
    public string? Properties { get; set; }
    public string? LogEvent { get; set; }
}
