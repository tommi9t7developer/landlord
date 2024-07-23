using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LandLord
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly HausService _hausService;
        private readonly CommunicationService _communicationService;
        private readonly IServiceProvider _serviceProvider;
        public MainViewModel(IServiceProvider serviceProvider, HausService hausService, CommunicationService communicationService)
        {
            _serviceProvider = serviceProvider;
            hauser = new ObservableCollection<string>();
            echteHauser = new List<Haus>();
            _hausService = hausService;
            _communicationService = communicationService;
        }

        List<Haus> echteHauser;

        [ObservableProperty]
        ObservableCollection<string> hauser;

        [ObservableProperty]
        string hausname;

        [RelayCommand]
        public void Save()
        {
            Haus neuesHaus = new Haus(hausname);
            _hausService.AddHaus(neuesHaus);
            Hauser.Add(hausname);
        }

        [RelayCommand]
        public void Selected()  // Methode des MainViewModel
        {

            var editHausWindow = _serviceProvider.GetRequiredService<EditHaus>();
            editHausWindow.Show();
        }
    }
}
