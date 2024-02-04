using Auction.Business.DTOs.CategoryDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.DTOs.ItemDTOs;

public class ItemCreateDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal StartingPrice { get; set; }
    public DateTime StartingTime { get; set; }
    public DateTime EndingTime { get; set; }
    public string SellerId { get; set; }
    public int CategoryId { get; set; }
}

public class ItemCreateDTOValidator : AbstractValidator<ItemCreateDTO>
{
    public ItemCreateDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .MaximumLength(64);
        RuleFor(x => x.Description)
           .NotEmpty()
           .NotNull()
           .MinimumLength(3)
           .MaximumLength(1024);
        RuleFor(x => x.StartingPrice)
            .NotEmpty()
            .NotNull()
            .GreaterThanOrEqualTo(0);
        RuleFor(x=> x.StartingTime)
            .NotEmpty()
            .NotNull()
            .GreaterThanOrEqualTo(DateTime.UtcNow);
        RuleFor(x=> x.EndingTime)
            .NotEmpty()
            .NotNull()
            .GreaterThanOrEqualTo(DateTime.UtcNow)
            .NotEqual(x=> x.StartingTime);
    }
}
