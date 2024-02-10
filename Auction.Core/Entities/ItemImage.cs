using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Core.Entities;

public class ItemImage : BaseEntity
{
    public int ItemId { get; set; }
    public Item Item { get; set; }
    public byte[] ImageData { get; set; }
    public bool IsActive { get; set; }
}
