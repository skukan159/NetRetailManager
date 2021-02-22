using System;
using System.Collections.Generic;
using System.Text;
using DataManager.Domain.DAO.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
