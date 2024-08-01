using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace LandLord
{
    public partial class EditHausViewModel : ObservableObject
    {
        private readonly IHausService _hausService;
        private readonly ICommunicationService _communicationService;
        private readonly IServiceProvider _serviceProvider;

        public EditHausViewModel(IServiceProvider serviceProvider, IHausService hausService, ICommunicationService communicationService)
        {
            _serviceProvider = serviceProvider;
            _hausService = hausService;
            _communicationService = communicationService;
            hausname = _communicationService.getHausName();
            haus = _hausService.getHausByName(hausname);



            displaywohnungen = new ObservableCollection<string>();

            // Lade die gespeicherten Häuser und füge sie der ObservableCollection hinzu
            var gespeicherteWohnungen = _hausService.getWohnungenByHaus(hausname);
            displaywohnungen = new ObservableCollection<string>();
            MessageBox.Show(hausname);
            foreach (var wohnung in gespeicherteWohnungen)
            {
                MessageBox.Show(wohnung.Geschoss);
                Displaywohnungen.Add(wohnung.Geschoss);
            }

        }

        private IHaus haus;

        [ObservableProperty]
        ObservableCollection<string> displaywohnungen;

        [ObservableProperty]
        string mietername = "Mietername";

        [ObservableProperty]
        string hausname;

        [ObservableProperty]
        string geschoss = "Geschoss";

        [RelayCommand]
        public void Save()
        {
            Mieter neuerMieter = new Mieter();
            neuerMieter.Name = mietername;
            Wohnung neueWohnung = new Wohnung(neuerMieter, Geschoss);
            _hausService.addWohnungZuHaus(haus.Name, neueWohnung);
            Displaywohnungen.Add(Geschoss);
        }
       
        [RelayCommand]
        public void SelectedWohnung(string wohnungNameSelected)  
        {
          
        }
        


    }
}
