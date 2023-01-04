using Microsoft.EntityFrameworkCore;
using NGUYENVANA025.Data;

namespace NGUYENVANA025.Data
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options):base(options)
       {

       }
       public DbSet<Company> Company{get; set;}=default!;
    }
}