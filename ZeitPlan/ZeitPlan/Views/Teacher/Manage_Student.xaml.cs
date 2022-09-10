using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeitPlan.View_Model;

namespace ZeitPlan.Views.Teacher
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Manage_Student : ContentPage
    {
        public Manage_Student()
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


                var RawData = (await App.firebaseDatabase.Child("TBL_STUDENT").OnceAsync<TBL_STUDENT>()).ToList();
                var RefinedList = new List<View_Student>();
                foreach (var item in RawData)
                {
                    var Class = (await App.firebaseDatabase.Child("TBL_CLASS").OnceAsync<TBL_CLASS>()).FirstOrDefault(x => x.Object.CLASS_ID == item.Object.CLASS_FID);


                    RefinedList.Add(new View_Student
                    {
                        STUDENT_ID = item.Object.STUDENT_ID,
                       STUDENT_NAME = item.Object.STUDENT_NAME,
                        STUDENT_EMAIL = item.Object.STUDENT_EMAIL,
                        STUDENT_PASSWORD = item.Object.STUDENT_PASSWORD,
                        CLASS_NAME = Class.Object.CLASS_NAME,
                       

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
            var Selected = e.Item as TBL_STUDENT;

            var item = (await App.firebaseDatabase.Child("TBL_STUDENT").OnceAsync<TBL_STUDENT>()).FirstOrDefault(a => a.Object.STUDENT_ID == Selected.STUDENT_ID);

            var choice = await DisplayActionSheet("Options", "Close", "Delete", "View", "Edit", "FAvoriate", "Archived");
            if (choice == "View")
            {

                await Navigation.PushAsync(new Student_Detail(Selected));
            }
            if (choice == "Delete")
            {
                var q = DisplayAlert("Confirmation", "Are you sure you want to delete" + item.Object.STUDENT_ID, "Yes", "No");
                if (await q)
                {
                    await App.firebaseDatabase.Child("TBL_STUDENT").Child(item.Key).DeleteAsync();
                    LoadData();
                    await DisplayAlert("Confirmation", item.Object.STUDENT_ID + "Deleted permanently", "ok");
                }
                if (choice == "Edit")
                { }
            }

        }
    }
}