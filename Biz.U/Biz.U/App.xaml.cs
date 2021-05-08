using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;




namespace Biz.U
{
    public partial class App : Application
    {
        public App()
        {           
            Color cor = new Color();

            if(Device.RuntimePlatform == Device.UWP)
            {
                cor = Color.FromHex("#303E6D");
            }            

            InitializeComponent();

            MainPage = new NavigationPage(new Views.LoginView()) { BarBackgroundColor = cor, BarTextColor = Color.White };
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
