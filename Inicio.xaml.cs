using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace pOrtegaSemana7;

public partial class Inicio : ContentPage
{
	private const string Url = "http://127.0.0.1/moviles/post.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> estud;

    public Inicio()
	{
		InitializeComponent();
		Obtener();
		
	}

	public async void Obtener()
	{
		var content  = await cliente.GetStringAsync(Url);
		List<Estudiante> mostrarEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		estud = new ObservableCollection<Estudiante>(mostrarEst);
		listaEstudiantes.ItemsSource = estud;
	}

    private void btnRegistrar_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Registrar());
    }

    private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var objetoEstudiante = (Estudiante)e.SelectedItem;
		Navigation.PushAsync(new Actualizar(objetoEstudiante));
    }
}