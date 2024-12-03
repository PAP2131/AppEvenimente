using AppEvenimente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppEvenimente.Views
{
    /// <summary>
    /// Interaction logic for AddEditEventWindow.xaml
    /// </summary>
    public partial class AddEditEventWindow : Window
    {
        public Event CurrentEvent { get; private set; }
        private readonly bool _isEditMode;

        public AddEditEventWindow(Event? editEvent = null)
        {
            InitializeComponent();
            _isEditMode = editEvent != null;
            CurrentEvent = editEvent ?? new Event
            {
                Data = DateTime.Now // Setare implicită pentru data evenimentului
            };
            DataContext = this;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Validare simplă (opțională)
            if (string.IsNullOrWhiteSpace(CurrentEvent.NumeEveniment))
            {
                MessageBox.Show("Numele evenimentului nu poate fi gol!", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

    }
}
