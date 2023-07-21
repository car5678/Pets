using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pets
{
    public partial class App : Application
    {

        public static string url = "https://mascota-app.onrender.com/";
        public static string token;

        private const string SECRET_KEY = "09d25e094faa6ca2556c818166b7a9563b93f7099f6f0f4caa6cf63b88e8d3e7";


        

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new Login( SECRET_KEY));
         //   MainPage = new NavigationPage(new Solicitud());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
