using app2_xamarin.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app2_xamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new PersonaPage());
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
