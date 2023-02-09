using Microsoft.EntityFrameworkCore;
using mapping_dto.Models;

namespace mapping_dto.Data
{
    public class DbContextClass : DbContext
    {
        private readonly IConfiguration Configuration;

         public DbContextClass(DbContextOptions<DbContextClass> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}