using AppEvenimente.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppEvenimente.ViewModels
{
    public class ParticipantViewModel
    {
        public ObservableCollection<Participant> Participanti { get; set; } = new();
        public ObservableCollection<Event> Eveninimente { get; set; } = new();
        public Participant ParticipantSelectat { get; set; } = new();
        public Event EvinimentSelectat { get; set; }  = new();

        public ParticipantViewModel()
        {
            LoadParticipanti();
        }

        private void LoadParticipanti()
        {
            using (var db = new EventContext())
            {
                Participanti = new ObservableCollection<Participant>(db.Participanti.Include(p => p.Event).ToList());
                Eveninimente = new ObservableCollection<Event>(db.Evenimente.ToList());
            }
        }

        public void AddParticipant(Participant participant)
        {
            try
            {
                using (var db = new EventContext())
                {
                    db.Participanti.Add(participant);
                    db.SaveChanges();
                    Participanti.Add(participant);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Eroare la adaugarea participantilor: {ex.Message}");
            }
        }
    }
}
