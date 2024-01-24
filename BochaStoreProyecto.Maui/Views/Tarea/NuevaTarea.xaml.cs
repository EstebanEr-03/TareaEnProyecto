namespace BochaStoreProyecto.Maui.Views.Tarea;

using BochaStoreProyecto.Maui.Services;
using Tarea = BochaStoreProyecto.Maui.Models.Tarea;

public partial class NuevaTarea : ContentPage
{
    private Tarea _tarea;
    private readonly APIService _APIService;

    public NuevaTarea(APIService apiservice)
    {
        InitializeComponent();
        _APIService = apiservice;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _tarea = BindingContext as Tarea;
        if (_tarea != null)
        {
            EntryNombre.Text = _tarea.nombreTarea;
            EditorDescripcion.Text = _tarea.descripcionTarea;
            EntryEstado.Text = _tarea.estadoTarea;
        }
    }

    private async void OnClickGuardarNuevaTarea(object sender, EventArgs e)
    {
        if (_tarea != null)
        {
            _tarea.nombreTarea = EntryNombre.Text;
            _tarea.descripcionTarea = EditorDescripcion.Text;
            _tarea.estadoTarea = EntryEstado.Text;

            await _APIService.PutTarea(_tarea.idTarea, _tarea);
        }
        else
        {

            Tarea tarea = new Tarea
            {
                idTarea = 0,
                nombreTarea = EntryNombre.Text,
                descripcionTarea = EditorDescripcion.Text,
                estadoTarea = EntryEstado.Text
            };

            await _APIService.PostTarea(tarea);
        }
        await Navigation.PopAsync();
    }
}