using System.Net;

namespace pOrtegaSemana7;

public partial class Actualizar : ContentPage
{
	Estudiante estd;
	public Actualizar(Estudiante objectoEstudiante)
	{
		InitializeComponent();
		estd = objectoEstudiante;
		initializer();
	}

	private void initializer()
	{
		txtNombre.Text = estd.nombre;
		txtApellido.Text = estd.apellido;
		txtEdad.Text = estd.edad.ToString();
		txtCodigo.Text = estd.codigo.ToString();
	}

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            cliente.UploadValues("http://127.0.0.1/moviles/post.php?nombre="+ txtNombre.Text + "&apellido=" + txtApellido.Text+ "&edad="+ txtEdad.Text + "&codigo="+ txtCodigo.Text, "PUT", parametros);
            Navigation.PushAsync(new Inicio());
        }
        catch (Exception ex)
        {
            DisplayAlert("Alert", ex.Message, "Cerrar");
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            cliente.UploadValues("http://127.0.0.1/moviles/post.php?codigo="+ txtCodigo.Text, "DELETE", parametros);
            DisplayAlert("OK", "Registro Eliminado", "Cerrar");
            Navigation.PushAsync(new Inicio());
        }
        catch (Exception ex)
        {
            DisplayAlert("Alert", ex.Message, "Cerrar");
        }
    }
}