using Microsoft.EntityFrameworkCore;
using GoodsCore.Models;

namespace Goods.Models
{
    public class GoodAppContext : DbContext
        {
            public DbSet<Good> Goods { get; set; }

           public DbSet<Group> Groups { get; set; }

        public GoodAppContext(DbContextOptions<GoodAppContext> options) : base(options)
            {

            }
        }
    }

