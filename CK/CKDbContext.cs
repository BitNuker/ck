using CK.Entities;
using Microsoft.EntityFrameworkCore;

namespace CK
{
    public class  CKDbContext: DbContext
    {
        public CKDbContext(DbContextOptions<CKDbContext> options) :
          base(options)
    {

    }

    public DbSet<Portfolio> Portfolios { get; set; }
}
}
