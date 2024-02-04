using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.DTOs.CategoryDTOs;

public class CategoryUpdateDTO
{
    public string Name { get; set; }
    public int? ParentCategoryId { get; set; }
}

public class CategoryUpdateDTOValidator : AbstractValidator<CategoryUpdateDTO>
{
    public CategoryUpdateDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .MaximumLength(64);
    }
}