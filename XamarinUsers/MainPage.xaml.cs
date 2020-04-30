using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinUsers.ViewModel;

namespace XamarinUsers
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel mainPageViewModel;

        public MainPage(MainPageViewModel vm)
        {
            BindingContext = vm;
            mainPageViewModel = vm;
            InitializeComponent();
        }

        void OnAddButtonClicked(object sender, EventArgs e)
        {
            mainPageViewModel.IsAddUserModalOpened = true;
        }
    }
}
