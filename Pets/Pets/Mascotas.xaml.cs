using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pets
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Mascotas : ContentPage
	{
		public Mascotas ()
		{
			InitializeComponent ();
		}
	}
}