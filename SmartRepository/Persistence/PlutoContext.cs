using Microsoft.EntityFrameworkCore;
using SmartRepository.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRepository.Persistence
{
    public class PlutoContext : DbContext
    {
        public PlutoContext(DbContextOptions<PlutoContext> opts) : base(opts) { }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<lib_region> Lib_Regions { get; set; }
        public virtual DbSet<lib_province> Lib_Provinces { get; set; }
        public virtual DbSet<lib_city> Lib_Cities { get; set; }
        public virtual DbSet<lib_barangay> Lib_Barangays { get; set; }
    }
}
