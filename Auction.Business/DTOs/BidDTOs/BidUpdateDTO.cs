using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.DTOs.BidDTOs;

public class BidUpdateDTO
{
    public int ItemId { get; set; }
    public decimal Amount { get; set; }
}

public class BidUpdateDTOValidator : AbstractValidator<BidUpdateDTO>
{
    public BidUpdateDTOValidator()
    {
        RuleFor(x => x.ItemId)
            .NotEmpty()
            .NotNull();
        RuleFor(x => x.Amount)
            .NotEmpty()
            .NotNull();

    }
}
