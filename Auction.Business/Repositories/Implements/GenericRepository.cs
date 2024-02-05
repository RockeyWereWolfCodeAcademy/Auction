using Auction.Business.Repositories.Interfaces;
using Auction.Core.Entities;
using Auction.Core.Entities.Common;
using Auction.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Repositories.Implements;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    readonly AuctionContext _context;

    public GenericRepository(AuctionContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task CreateAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public void Delete(T data)
    {
        Table.Remove(data);
    }

    public IQueryable<T> GetAll(bool notTracked = true, params string[] includes)
    {
        var data = Table.AsQueryable().Where(x => x.IsDeleted == false);
        if (includes.Any())
        {
            foreach (var include in includes)
            {
                data = data.Include(include);
            }
        }
        return notTracked ? data.AsNoTracking() : data;
    }


    public async Task<T> GetByIdAsync(int id, bool noTracking = true, params string[] includes)
    {
        var data = Table.AsQueryable();
        if (includes.Any())
        {
            foreach (var include in includes)
            {
                data = data.Include(include);
            }
        }
        return noTracking ? await data.AsNoTracking().SingleOrDefaultAsync(t => t.Id == id) : await data.SingleOrDefaultAsync(t => t.Id == id);
    }

    public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
    {
        return await Table.AnyAsync(expression);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
