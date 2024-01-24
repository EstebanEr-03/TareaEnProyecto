namespace BochaStoreProyecto.Maui.Views.Tarea;
using BochaStoreProyecto.Maui.Services;
using Tarea = BochaStoreProyecto.Maui.Models.Tarea;
public partial class DetailsTarea : ContentPage
{
    private Tarea _tarea;
    private APIService _APIService;
    public DetailsTarea(APIService apiservice)
    {
        InitializeComponent();
        _APIService = apiservice;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _tarea = BindingContext as Tarea;
        Nombre.Text = _tarea.nombreTarea;
        Id.Text = "Id de la Tarea: " + _tarea.idTarea.ToString();
    }

    private async void Borrar_Clicked(object sender, EventArgs e)
    {
        await _APIService.DeleteTarea(_tarea.idTarea);
        await Navigation.PopAsync();
    }

    private async void Editar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NuevaTarea(_APIService)
        {
            BindingContext = _tarea,
        });
    }
}