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

        public EditHausViewModel(IHausService hausService, ICommunicationService communicationService)
        {
            _hausService = hausService;
            _communicationService = communicationService;
            hausname = _communicationService.getHausName();
            haus = _hausService.getHausByName(hausname);
            wohnungen = new ObservableCollection<string>();
        }

        private IHaus haus;

        [ObservableProperty]
        ObservableCollection<string> wohnungen;

        [ObservableProperty]
        string mietername = "Mietername";

        [ObservableProperty]
        string hausname;

        [ObservableProperty]
        string geschoss = "Geschoss";

        [RelayCommand]
        public void Save()
        {
            Wohnung neueWohnung = new Wohnung();
            //Mieter und geschoss dazu
            Mieter neuerMieter = new Mieter(Mietername);
            neueWohnung.setMieter(neuerMieter);
            neueWohnung.setGeschoss(Geschoss);

            _hausService.addWohnungZuHaus(haus.Name, neueWohnung);
            Wohnungen.Add(Geschoss);
        }
       
        [RelayCommand]
        public void SelectedWohnung(string wohnungNameSelected)  
        {
          
        }
        


    }
}
