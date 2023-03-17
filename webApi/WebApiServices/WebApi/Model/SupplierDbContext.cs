using Microsoft.EntityFrameworkCore;

namespace WebApi.Model
{
    public class SupplierDbContext: DbContext
    {
        public SupplierDbContext(DbContextOptions<SupplierDbContext> opt) :base(opt)
        {
                
        }

        public DbSet<Suppliers> suppliers { get; set; } 

    }
}
