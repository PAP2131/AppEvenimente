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
        public string NumeEveniment { get; set; } = string.Empty;
        public DateTime Data { get; set; }
        public string Locatie { get; set; } = string.Empty;

        public ICollection<Participant> Participanti { get; set; } = new List<Participant>();
    }
}
