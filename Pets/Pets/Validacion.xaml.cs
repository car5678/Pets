using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;

namespace Pets
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Validacion : ContentPage
	{
        MultipartFormDataContent mContent = new MultipartFormDataContent();
        string secret;
        Stream doc;
        public Validacion (string secret)
		{
            this.secret = secret;
			InitializeComponent ();
		}

        private async void ButtonDoc_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("hola", "camara no funciona", "OK");
                return;
            }

            var opcion = new StoreCameraMediaOptions
            {
                Directory = "img",
                SaveToAlbum = true,
                CompressionQuality = 50,
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.MaxWidthHeight,
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear,
                CustomPhotoSize = 50,
                Name = lblNombre + "_" + DateTime.Now
            };
            var foto = CrossMedia.Current.TakePhotoAsync(opcion);
            MiImagen.Source = ImageSource.FromStream(() =>
            {
                var stream = foto.Result.GetStream();

                //mContent.Add(new StreamImageSource("foto_documento"),new StreamContent(stream));

                foto.Dispose();
                return stream;
            });

        }
        private async void ButtonVal_Clicked(object sender, EventArgs e)
        {





            WebClient cliente = new WebClient();
            cliente.Headers[HttpRequestHeader.ContentType] = "application/json";
            cliente.Headers[HttpRequestHeader.Authorization] = "Bearer "+App.token;

            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", App.token);
            //client.DefaultRequestHeaders.Add("Conten-Type","multipart/form-data");

            //mContent.Add(new StringContent("Content-Type"  ) ,"multipart/form-data
            Persona p = new Persona(
                lblNombre.Text,
            lblApellido.Text,
            lbltelefono.Text,
            lblCorreo.Text,
            ""
                );

            string json = JsonConvert.SerializeObject(p);

            try
            {
                var result = cliente.UploadString(App.url + "persona", "PUT", json);
            }catch(Exception ex) { }

           

            Navigation.PushAsync(new Login(this.secret));

        }
    }
}