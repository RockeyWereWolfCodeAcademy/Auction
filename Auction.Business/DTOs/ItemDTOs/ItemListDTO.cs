using Auction.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.DTOs.ItemDTOs;

public class ItemListDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal StartingPrice { get; set; }
    public decimal CurrentPrice { get; set; }
    public DateTime StartingTime { get; set; }
    public DateTime EndingTime { get; set; }
    public string SellerId { get; set; }
    public string SellerUsername { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public bool IsDeleted { get; set; }
}
