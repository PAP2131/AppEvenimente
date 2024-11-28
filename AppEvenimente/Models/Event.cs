using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEvenimente.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string? NumeEveniment { get; set; }
        public DateTime DataEveniment { get; set; }
        public string? Locatie { get; set; }
    }
}
