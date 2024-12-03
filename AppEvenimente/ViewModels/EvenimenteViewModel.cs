using AppEvenimente.Models;
using AppEvenimente.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AppEvenimente.ViewModels
{
    public class EvenimenteViewModel : INotifyPropertyChanged
    {
        private readonly AppEventContext _context = new AppEventContext();

        public ObservableCollection<Event> Evenimente { get; set; } = new();

        private Event? _selectedEveniment;
        public Event? SelectedEveniment
        {
            get => _selectedEveniment;
            set
            {
                _selectedEveniment = value;
                OnPropertyChanged(nameof(SelectedEveniment));
                EditCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }
        public RelayCommand EditCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public EvenimenteViewModel()
        {
            EditCommand = new RelayCommand(EditEveniment, () => SelectedEveniment != null);
            DeleteCommand = new RelayCommand(DeleteEveniment, () => SelectedEveniment != null);
            LoadEvenimente();
        }

        private void LoadEvenimente()
        {
            Evenimente.Clear();
            var evenimente = _context.Evenimente.ToList();
            foreach (var eveniment in evenimente)
                Evenimente.Add(eveniment);
        }

        public ICommand AddCommand => new RelayCommand(AddEveniment);
        

        private void AddEveniment()
        {
            var addWindow = new AddEditEventWindow();
            if (addWindow.ShowDialog() == true) // Așteaptă răspunsul utilizatorului
            {
                try
                {
                    // Adaugă evenimentul în contextul bazei de date
                    _context.Evenimente.Add(addWindow.CurrentEvent);

                    // Salvează modificările în baza de date
                    _context.SaveChanges();

                    // Reîncărcarea datelor pentru a reflecta modificările
                    LoadEvenimente();
                }
                catch (Exception ex)
                {
                    // Gestionarea erorilor
                    MessageBox.Show($"Eroare la adăugarea evenimentului: {ex.Message}",
                        "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void EditEveniment()
        {
            if (SelectedEveniment == null) return;

            var editWindow = new AddEditEventWindow(new Event
            {
                Id = SelectedEveniment.Id,
                NumeEveniment = SelectedEveniment.NumeEveniment,
                Data = SelectedEveniment.Data,
                Locatie = SelectedEveniment.Locatie
            });

            if (editWindow.ShowDialog() == true)
            {
                var originalEvent = _context.Evenimente.Find(editWindow.CurrentEvent.Id);
                if (originalEvent != null)
                {
                    originalEvent.NumeEveniment = editWindow.CurrentEvent.NumeEveniment;
                    originalEvent.Data = editWindow.CurrentEvent.Data;
                    originalEvent.Locatie = editWindow.CurrentEvent.Locatie;
                    _context.SaveChanges();
                    LoadEvenimente();
                }
            }
        }

        private void DeleteEveniment()
        {
            if (SelectedEveniment == null) return;

            _context.Evenimente.Remove(SelectedEveniment);
            _context.SaveChanges();
            LoadEvenimente();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
