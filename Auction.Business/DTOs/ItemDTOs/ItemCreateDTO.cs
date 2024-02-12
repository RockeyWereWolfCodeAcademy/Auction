using Auction.Business.DTOs.CategoryDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public int CategoryId { get; set; }
    public IFormFile ActiveImage { get; set; }
    public IEnumerable<IFormFile> Images { get; set; }
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
            .NotNull()
            .GreaterThanOrEqualTo(0);
        RuleFor(x=> x.StartingTime)
            .NotEmpty()
            .NotNull()
            .GreaterThanOrEqualTo(new DateTime(DateTime.UtcNow.Ticks / 600000000 * 600000000));
        RuleFor(x=> x.EndingTime)
            .NotEmpty()
            .NotNull()
            .GreaterThanOrEqualTo(new DateTime(DateTime.UtcNow.Ticks / 600000000 * 600000000))
            .GreaterThan(x=> x.StartingTime);
        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .NotNull();
        RuleFor(x => x.ActiveImage)
            .Must(x => x.Length <= 1048576).WithMessage("Image should me smaller than 1 mb");
        RuleFor(x => x.Images)
            .ForEach(x => x.Must(x => x.Length <= 1048576)).WithMessage("Image should me smaller than 1 mb");
    }
}
