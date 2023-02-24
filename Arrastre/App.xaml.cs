using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Arrastre
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Paginapadre();
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
