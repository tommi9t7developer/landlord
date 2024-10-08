﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LandLord.Services;
using LandLord.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
        private readonly IHausService _hausService;
        private readonly ICommunicationService _communicationService;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<MainViewModel> _logger;

        public MainViewModel(IServiceProvider serviceProvider, IHausService hausService, ICommunicationService communicationService, ILogger<MainViewModel> logger)
        {
            _serviceProvider = serviceProvider;
            //hauser = new ObservableCollection<string>();
            //echteHauser = new List<Haus>();
            _hausService = hausService;
            _communicationService = communicationService;

            // Lade die gespeicherten Häuser und füge sie der ObservableCollection hinzu
            var gespeicherteHaeuser = _hausService.GetHaeuser();
            hauser = new ObservableCollection<string>();
            foreach (var haus in gespeicherteHaeuser)
            {
                Hauser.Add(haus.Name);
            }

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            // Beispielhaftes Logging
            _logger.LogInformation("MainViewModel wurde erstellt.");
        }

        //List<Haus> echteHauser;

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
        public void Selected(string hausNameSelected)  // Methode des MainViewModel
        {
            _communicationService.setHausName(hausNameSelected);
            var editHausWindow = _serviceProvider.GetRequiredService<EditHaus>();
            editHausWindow.Show();
        }
    }
}
