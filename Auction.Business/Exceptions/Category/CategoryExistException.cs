using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Exceptions.Category;

public class CategoryExistException : Exception
{
    public CategoryExistException() : base("Category already exists") { }
    public CategoryExistException(string? message) : base(message) { }
}
