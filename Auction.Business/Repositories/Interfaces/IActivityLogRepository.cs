using Auction.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Repositories.Interfaces;

public interface IActivityLogRepository
{
    IQueryable<ActivityLog> GetAll(bool notTracked = true, params string[] includes);
}
