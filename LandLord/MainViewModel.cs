using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        public MainViewModel()
        {
            hauser = new ObservableCollection<string>();
        }

        [ObservableProperty]
        ObservableCollection<string> hauser;

        [ObservableProperty]
        string haus;

        [RelayCommand]
        public void Save()
        {
            Hauser.Add(Haus);
        }
    }
}
