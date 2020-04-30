using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinUsers.Services;

namespace XamarinUsers
{
    public partial class App : Application
    {
        private UserService userService;

        public App()
        {
            InitializeComponent();

            userService = new UserService(new System.Net.Http.HttpClient());

            MainPage = new MainPage(new ViewModel.MainPageViewModel(userService));
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
