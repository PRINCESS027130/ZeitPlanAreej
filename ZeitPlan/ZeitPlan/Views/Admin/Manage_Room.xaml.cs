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
    public partial class Manage_Room : ContentPage
    {
        public Manage_Room()
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


                var RawData = (await App.firebaseDatabase.Child("TBL_ROOM").OnceAsync<TBL_ROOM>()).ToList();
                var RefinedList = new List<View_Room>();
                foreach (var item in RawData)
                {
                    var Department = (await App.firebaseDatabase.Child("TBL_DEPARTMENT").OnceAsync<TBL_DEPARTMENT>()).FirstOrDefault(x => x.Object.DEPARTMENT_ID == item.Object.DEPARTMENT_FID);


                    RefinedList.Add(new View_Room
                    {
                       ROOM_ID = item.Object.ROOM_ID,
                        DEPARTMENT_NAME = Department.Object.DEPARTMENT_NAME,
                        ROOM_NO = item.Object.ROOM_NO,

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
            var selected = e.Item as TBL_ROOM;

            var item = (await App.firebaseDatabase.Child("ROOM").OnceAsync<TBL_ROOM>()).FirstOrDefault(a => a.Object.ROOM_ID == selected.ROOM_ID);

            var choice = await DisplayActionSheet("Options", "Close", "Delete", "View", "Edit", "FAvoriate", "Archived");
            if (choice == "View")
            {
               
                await Navigation.PushAsync(new Room_Detail(selected));
            }
            if (choice == "Delete")
            {
                var q = DisplayAlert("Confirmation", "Are you sure you want to delete" + item.Object.ROOM_ID, "Yes", "No");
                if (await q)
                {
                    await App.firebaseDatabase.Child("TBL_ROOM").Child(item.Key).DeleteAsync();
                    LoadData();
                    await DisplayAlert("Confirmation", item.Object.ROOM_ID + "Deleted permanently", "ok");
                }
                if (choice == "Edit")
                { }
            }
        }

    }
}
