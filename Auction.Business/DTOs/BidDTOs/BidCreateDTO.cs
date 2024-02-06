using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.DTOs.BidDTOs;

public class BidCreateDTO
{
    public int ItemId { get; set; }
    public decimal Amount { get; set; }
}

public class BidCreateDTOValidator : AbstractValidator<BidCreateDTO>
{
    public BidCreateDTOValidator()
    {
        RuleFor(x => x.ItemId)
            .NotEmpty()
            .NotNull();
        RuleFor(x => x.Amount)
            .GreaterThanOrEqualTo(0)
            .NotNull();

    }
}
