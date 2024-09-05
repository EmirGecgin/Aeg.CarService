using Aeg.CarService.Entity.CarService;
using Aeg.CarService.Entity.Web;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeg.CarService.Dal
{
    public class DataContext : DbContext
    {
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Announcements> Announcements { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<MapContact> MapContact { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
    }
}
