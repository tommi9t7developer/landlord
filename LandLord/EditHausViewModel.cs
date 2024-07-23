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

        public EditHausViewModel(HausService hausService)
        {
            _hausService = hausService;
        }

      

    }
}
