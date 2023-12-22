using AM_Api.Models.Worker;
using Microsoft.EntityFrameworkCore;

namespace AM_Api.DataAccess
{
    public class ContextDB : DbContext
    {
        public ContextDB() { }
        public ContextDB(DbContextOptions<ContextDB> options) : base(options) {
        }

        public virtual DbSet<Workers> Workers { get; set;}
    }
}
