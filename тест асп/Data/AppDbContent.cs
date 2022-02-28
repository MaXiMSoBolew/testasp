
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using тест_асп.Data.models;

namespace тест_асп.Data
{
    public class AppDbContent : DbContext
    {
        public AppDbContent(DbContextOptions<AppDbContent> options) : base(options)
        {}
        public DbSet<Car> Cars { get; set; }
        public DbSet<category> Category { get; set; }
        public DbSet<ShopCarItem> shopCarItems { get; set; }
    }
}
