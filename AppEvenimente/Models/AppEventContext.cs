using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEvenimente.Models
{
    public class AppEventContext: DbContext
    {
        public DbSet<Event> Evenimente { get; set; } = default!;
        public DbSet<Participant> Participanti { get; set; } = default!;
        public AppEventContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "appdata.db");
            optionsBuilder.UseSqlite($"Data Source={path}");
            
        }
    }
}
