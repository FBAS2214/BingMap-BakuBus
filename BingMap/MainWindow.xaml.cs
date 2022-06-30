using BingMap.Services.Models;
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Maps.MapControl.WPF.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Timers;
using System.Windows;
using System.Windows.Threading;

namespace BingMap;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    private BakuBus? bakuBus;
    public BakuBus? BakuBus
    {
        get { return bakuBus; }
        set
        {
            bakuBus = value;
            NotifyPropertyChanged();
        }
    }


    public MainWindow()
    {
        DataContext = this;
        InitializeComponent();

        // m.CredentialsProvider = new ApplicationIdCredentialsProvider("your_key");

        // m.Center = new Location(40.4093, 49.8671);
        // m.ZoomLevel = 12;
        // m.Mode = new AerialMode();



        // Timer timer = new Timer();
        // timer.Interval = 1000;
        // timer.Elapsed += Timer_Elapsed;
        // timer.Start();



        // DispatcherTimer timer = new DispatcherTimer();
        // timer.Interval = new TimeSpan(0, 0, 0, 1);
        // timer.Tick += Timer_Tick;
        // timer.Start();
    }




    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        using HttpClient client = new HttpClient();

        var jsonString = await client.GetStringAsync("https://www.bakubus.az/az/ajax/apiNew1");

        BakuBus = JsonSerializer.Deserialize<BakuBus>(jsonString);
    }



    private void Timer_Tick(object? sender, EventArgs e)
    {
        // txt.Text = DateTime.Now.ToLongTimeString();
    }

    private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
    {
        // Dispatcher.Invoke(() => { txt.Text = DateTime.Now.ToLongTimeString(); });
    }




    public event PropertyChangedEventHandler? PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}