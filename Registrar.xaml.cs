using System.Net;

namespace pOrtegaSemana7;

public partial class Registrar : ContentPage
{
	public Registrar()
	{
		InitializeComponent();
	}

    private void btnRegistrarForm_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente =	new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
            parametros.Add("codigo", txtCodigo.Text);
            cliente.UploadValues("http://127.0.0.1/moviles/post.php", "POST", parametros);
			Navigation.PushAsync(new Inicio());
        }
		catch(Exception ex) {
			DisplayAlert("Alert", ex.Message, "Cerrar");
		}
    }
}