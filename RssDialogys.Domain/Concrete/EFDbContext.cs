using System.Data.Entity;
using RssDialogys.Domain.Entities;

namespace RssDialogys.Domain.Concrete
{
    public class EfDbContext:DbContext
    {
        public EfDbContext()
            : base("RssDB")
        {

        }
        public DbSet<Item> Items { get; set; }
    }
}
