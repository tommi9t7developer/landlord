using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace LandLord
{
    public partial class EditHausViewModel : ObservableObject
    {
        private readonly HausService _hausService;
        private readonly CommunicationService _communicationService;

        public EditHausViewModel(HausService hausService, CommunicationService communicationService)
        {
            _hausService = hausService;
            _communicationService = communicationService;
            hausname = _communicationService.getHausName();
            haus = _hausService.getHausByName(hausname);
        }

        private Haus haus;

        [ObservableProperty]
        string hausname;




    }
}
