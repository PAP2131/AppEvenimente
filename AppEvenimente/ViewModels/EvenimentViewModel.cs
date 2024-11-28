using AppEvenimente.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEvenimente.ViewModels
{
    public class EvenimentViewModel
    {
        public ObservableCollection<Event> Eveninimente { get; set; } = new();

        public EvenimentViewModel()
        {
            LoadEvenimente();
        }

        private void LoadEvenimente()
        {
            using (var db=new EventContext())
            {
                var evenimente = db.Evenimente.Include(e=>e.Participanti).ToList();
                Eveninimente = new ObservableCollection<Event>(evenimente);
            }
        }

        public void AddEvent(Event eveniment)
        {
            using (var db = new EventContext())
            {
                db.Evenimente.Add(eveniment);
                db.SaveChanges();
                Eveninimente.Add(eveniment);
            }
        }
    }
}
