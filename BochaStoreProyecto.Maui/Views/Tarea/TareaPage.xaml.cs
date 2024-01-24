namespace BochaStoreProyecto.Maui.Views.Tarea;
using BochaStoreProyecto.Maui.Services;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Collections.ObjectModel;
using Tarea = BochaStoreProyecto.Maui.Models.Tarea;
public partial class TareaPage : ContentPage
{
    ObservableCollection<Tarea> tareas;
    private readonly APIService _APIService;

    public TareaPage(APIService apiservice)
    {
        InitializeComponent();
        _APIService = apiservice;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        string username = "BOCHASTORE";
        Username.Text = username;
        List<Tarea> ListaTareas = await _APIService.GetTareas(); // Asegúrate de tener un método GetTareas en tu servicio
        tareas = new ObservableCollection<Tarea>(ListaTareas);
        listaTareas.ItemsSource = tareas;
    }

    private async void OnClickNuevaTarea(object sender, EventArgs e)
    {
        var toast = Toast.Make("On Click Boton Nueva Tarea", ToastDuration.Short, 14);
        await toast.Show();
        await Navigation.PushAsync(new NuevaTarea(_APIService));
    }

    private async void listaTareas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en ver Tarea", ToastDuration.Short, 14);
        await toast.Show();
        Tarea tarea = e.SelectedItem as Tarea;
        await Navigation.PushAsync(new DetailsTarea(_APIService)
        {
            BindingContext = tarea,
        });
    }
}
