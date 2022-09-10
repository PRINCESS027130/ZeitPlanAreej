using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.BackgroundVideoView;
using ZeitPlan.LoginSystem;

namespace ZeitPlan
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
          
        }

        private void BtnGetStarted_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Login(""));
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Login("Admin"));

        }

       

        private void Teacher_Tapped(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Login("Teacher"));

        }

        private void Student_Tapped(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Login("Student"));

        }

        private void Reset_Default_Tapped(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new Login("Reset_Default"));

        }
    }
}
