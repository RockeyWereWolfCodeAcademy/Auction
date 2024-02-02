﻿using Auction.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Contexts;

public class AuctionContext : IdentityDbContext<AppUser>
{
    public AuctionContext(DbContextOptions options) : base(options) { }

    public DbSet<AppUser> Users { get; set; }
}
