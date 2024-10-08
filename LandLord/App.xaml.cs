﻿using System.Configuration;
using System.Data;
using System.Windows;
using LandLord.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LandLord
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Erstellen und Konfigurieren des Service-Providers
            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            // Starten Sie das Hauptfenster
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        public static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Registrieren Sie Ihre Services hier
                    services.AddSingleton<IHausService, HausService>();  // Eine einzige Instanz des Dienstes wird erstellt und für die gesamte Lebensdauer der Anwendung wiederverwendet.
                    services.AddSingleton<ICommunicationService, CommunicationService>();
                    services.AddTransient<MainWindow>();    // MainWindow wird bei Bedarf erstellt
                    services.AddTransient<MainViewModel>(); // MainViewModel wird bei Bedarf erstellt
                    services.AddTransient<EditHaus> ();
                    services.AddTransient<EditHausViewModel>();

                    // Logging hinzufügen
                    services.AddLogging(configure =>
                    {
                        configure.AddConsole();  // Console-Logger hinzufügen
                        configure.AddDebug();    // Debug-Logger hinzufügen
                        configure.SetMinimumLevel(LogLevel.Information);  // Minimum Log-Level setzen
                    });
                });
    }
    }
