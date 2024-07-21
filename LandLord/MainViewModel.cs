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
            echteHauser = new List<Haus>();
        }

        List<Haus> echteHauser;

        [ObservableProperty]
        ObservableCollection<string> hauser;

        [ObservableProperty]
        string haus;

        [RelayCommand]
        public void Save()
        {
            Hauser.Add(Haus);
            Haus neuesHaus = new Haus(haus);
            echteHauser.Add(neuesHaus);
        }

        [RelayCommand]
        public void Selected()
        {
            //if (Haus != null)
            {
                var editWindow = new EditHaus();
                editWindow.ShowDialog();
            }
        }
    }
}
