using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeitPlan.View_Model;

namespace ZeitPlan.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Manage_Class : ContentPage
    {
        public Manage_Class()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                LoadingInd.IsRunning = true;
                LoadData();
                LoadingInd.IsRunning = false;
            }
            catch (Exception ex)
            {
                LoadingInd.IsRunning = false;
                await DisplayAlert("Error", "Something went wrong, please  try again later" + ex.Message, "ok");
                return;
            }
        }

        async void LoadData()
        {
            try
            {


                var RawData = (await App.firebaseDatabase.Child("TBL_CLASS").OnceAsync<TBL_CLASS>()).ToList();
                var RefinedList = new List<View_Class>();
                foreach (var item in RawData)
                {
                    var Degree = (await App.firebaseDatabase.Child("TBL_DEGREE").OnceAsync<TBL_DEGREE>()).FirstOrDefault(x => x.Object.DEGREE_ID == item.Object.DEGREE_FID);
                    

                    RefinedList.Add(new View_Class
                    {
                        CLASS_ID = item.Object.CLASS_ID,
                        CLASS_NAME = item.Object.CLASS_NAME,
                        SECTION = item.Object.SECTION,
                        SESSION = item.Object.SESSION,
                        SEMESTER = item.Object.SEMESTER,
                        SHIFT = item.Object.SHIFT,
                        DEGREE_NAME=Degree.Object.DEGREE_NAME

                    }

                    );

                    DataList.ItemsSource = RefinedList;
                }
            }
            catch (Exception ex)
            {
                LoadingInd.IsRunning = false;
                await DisplayAlert("Error", "Something went wrong Please try again later.\nError:" + ex.Message, "ok");
                return;

            }
        }
    

        private async void DataList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
           var Selected = e.Item as TBL_CLASS;

            var item = (await App.firebaseDatabase.Child("TBL_CLASS").OnceAsync<TBL_CLASS>()).FirstOrDefault(a => a.Object.CLASS_ID == Selected.CLASS_ID);

            var choice = await DisplayActionSheet("Options", "Close", "Delete", "View", "Edit", "FAvoriate", "Archived");
            if (choice == "View")
            {
                //await DisplayAlert("Detail", "" +
                //    "\nCat ID:" + item.Object.CatId +
                //    " \nName:" + item.Object.Name +
                //    "\nEmail:" + item.Object.Email +
                //    "\nPassword:  *******" +
                //    "\nPhone:" + item.Object.Phone +
                //   "", "ok");
                await Navigation.PushAsync(new Class_Detail(Selected));
            }
            if (choice == "Delete")
            {
                var q = DisplayAlert("Confirmation", "Are you sure you want to delete" + item.Object.CLASS_ID, "Yes", "No");
                if (await q)
                {
                    await App.firebaseDatabase.Child("TBL_CLASS").Child(item.Key).DeleteAsync();
                    LoadData();
                    await DisplayAlert("Confirmation", item.Object.CLASS_ID + "Deleted permanently", "ok");
                }
                if (choice == "Edit")
                { }
            }
        }
    }
    }
