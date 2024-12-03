using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEvenimente.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string NumeParticipant { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int EvenimentId { get; set; }
        public Event Eveniment { get; set; } = default!;
    }
}

