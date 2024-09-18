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
using Microsoft.Win32;
using System.Diagnostics.Eventing.Reader;
using LandLord.Services;
using LandLord.ViewModels;

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


            displaypdfs = new ObservableCollection<string>();
            displaywohnungen = new ObservableCollection<string>();

            // Lade die gespeicherten Häuser und füge sie der ObservableCollection hinzu
            var gespeicherteWohnungen = _hausService.getWohnungenByHaus(hausname);
            displaywohnungen = new ObservableCollection<string>();
            MessageBox.Show(hausname);
            foreach (var wohnung in gespeicherteWohnungen)
            {
                Displaywohnungen.Add(wohnung.Geschoss);
            }

        }

        private IHaus haus;

        [ObservableProperty]
        ObservableCollection<string> displaywohnungen;

        [ObservableProperty]
        ObservableCollection<string> displaypdfs;

        [ObservableProperty]
        string pdfAdress;


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
            var wohnung = _hausService.getWohnungByNames(Hausname, wohnungNameSelected);
            if (wohnung != null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                openFileDialog.Title = "Select a PDF file";

                if (openFileDialog.ShowDialog() == true)
                {
                    _hausService.addPdfToWohnung(Hausname, wohnungNameSelected, openFileDialog.FileName);
                    MessageBox.Show("PDF added successfully: " + openFileDialog.FileName, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else MessageBox.Show("Wohnung nicht gefunden");
        }

        [RelayCommand]

        public void ShowPdfs(string wohnungNameSelected)
        {

            var pdfs = _hausService.getPdfsfromWohnung(Hausname, wohnungNameSelected);

            if (pdfs != null)
            {
                foreach (var pdf in pdfs)
                {
                    if (pdf != null)
                        Displaypdfs.Add(pdf);
                    else MessageBox.Show("PDF nicht gefunden");
                }


            }

        }

        [RelayCommand]

        public void  ShowPdf(string pdfSelected)
        {
            PdfAdress = pdfSelected;
        }

       


    
    }
}
