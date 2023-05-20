using CFTrackerServices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTrackerServices.Data
{
    public class CFTrackerContext : DbContext
    {
        public CFTrackerContext(DbContextOptions<CFTrackerContext> options)
            :base(options)
        {
        }

        public DbSet<UserInfo> Users { get; set; } = null!;
        public DbSet<LungFunction> LungFunctions { get; set; }
        public DbSet<BodyMassIndex> BodyMassIndexes { get; set; }
    }
}
