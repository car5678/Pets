using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        string secret;
        private  PetsToken petsToken = new PetsToken();
        
        public Login( string secret)
        {
            InitializeComponent();
            this.secret = secret;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {



            try
            {
                WebClient cliente = new WebClient();
                cliente.Headers[HttpRequestHeader.ContentType] = "application/json";

                Usuario user = new Usuario(lblUser.Text, lblPass.Text);

                string json = JsonConvert.SerializeObject(user);

                App.token = cliente.UploadString(App.url + "login", "POST", json).Replace("Bearer ", String.Empty);
                App.token = App.token.Replace("\"", String.Empty);

                if (App.token.Contains("msg"))
                {
                    var msg = App.token.Replace("msg",string.Empty).Replace("{",string.Empty).Replace("}",string.Empty);
                    
                    DisplayAlert("Alerta", msg.ToString(),"OK");
                    return ;
                }

                var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(this.secret));
                var expiration = DateTime.UtcNow.AddHours(1);

                SecurityToken securityToken;
                TokenValidationParameters validationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidAudience = App.url,
                    ValidIssuer = App.url,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = this.LifetimeValidator,
                    IssuerSigningKey = securityKey
                };


                var parametros= tokenHandler.ValidateToken(App.token, validationParameters, out securityToken).Claims.ToArray();

                petsToken.ID = int.Parse(parametros[1].Value);
                petsToken.Username = parametros[0].Value;
                petsToken.IsActive = bool.Parse(parametros[2].Value);
                petsToken.Formulario = bool.Parse(parametros[3].Value);

                if (petsToken.IsActive)
                {
                    DisplayAlert("Alerta", "Usuario no activo","OK");
                    return;
                }

                if (petsToken.Formulario)
                {
                    Navigation.PushAsync(new Mascotas());
                    return;
                }

                Navigation.PushAsync(new Validacion(this.secret));



            }
            catch (Exception ex)
            {
                DisplayAlert("Ok", ex.Message, "OK");
                //DependencyService.Get<Mensaje>().longAlert(ex.Message);
            }



        }
        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return true;
        }
        private void ButtonCrear_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro(petsToken,this.secret));
        }
    }
}