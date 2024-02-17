using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.DTOs.ActivityLogDTOs;

public class ActivityLogListDTO
{
    public int ItemId { get; set; }
    public string Message { get; set; }
    public DateTime TimeStamp { get; set; }
}
