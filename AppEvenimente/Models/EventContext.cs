using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEvenimente.Models
{
    public class EventContext: DbContext
    {
        public DbSet<Event> Evenimente { get; set; }
        public DbSet<Participant> Participanti { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=evenimente.db");
        }
    }
}
