using Microsoft.EntityFrameworkCore;
using NfcAdapters.Database.Entities;
using System;

namespace NfcAdapters.Database
{
    public class AdapterContext : DbContext
    {
        public AdapterContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<DbUser> DbUsers { get; set; } = null!;
        public DbSet<Adapter> Adapters { get; set; } = null!;
        public DbSet<AdapterType> AdapterTypes { get; set; } = null!;
        public DbSet<Lending> Lendings { get; set; } = null!;

    }
}
