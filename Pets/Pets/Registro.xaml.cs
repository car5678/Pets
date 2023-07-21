using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pets
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registro : ContentPage
	{
		string secret;

		public Registro (PetsToken petsToken, String secret)
		{
			InitializeComponent ();
			this.secret= secret;
		}

        private async void btnRegistro_Clicked(object sender, EventArgs e)
        {
			var client = new HttpClient();
			
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", App.token);

			HttpResponseMessage response = await client.GetAsync(App.url+"register");
			var responseBody = await response.Content.ReadAsStringAsync();
            object v = JsonConvert.DeserializeObject<List<Registrar>>(responseBody);

			Navigation.PushAsync(new Login(this.secret));

		}

		//private string get(){
		//	var client = new HttpClient();
			
		//	client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", App.token);

		//	HttpResponseMessage response = await client.GetAsync(App.url+"registroregister");
		//	var responseBody = await response.Content.ReadAsStringAsync();
  //          object v = JsonConvert.DeserializeObject<List<Registros>>(responseBody);
		//}
    }
}