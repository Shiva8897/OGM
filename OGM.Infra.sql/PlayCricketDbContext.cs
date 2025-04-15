using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OGM.Domain.Entities;

namespace OGM.Infra.sql
{
    public class PlayCricketDbContext : DbContext
    {
        public PlayCricketDbContext(DbContextOptions<PlayCricketDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }

}
