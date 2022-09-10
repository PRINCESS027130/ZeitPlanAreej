﻿using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            DataList.ItemsSource = (await App.firebaseDatabase.Child("TBL_STUDENT").OnceAsync<TBL_STUDENT>()).Select(x => new TBL_STUDENT
            {
                STUDENT_ID = x.Object.STUDENT_ID,
                STUDENT_NAME = x.Object.STUDENT_NAME,
                STUDENT_EMAIL = x.Object.STUDENT_EMAIL,
                STUDENT_PASSWORD = "*******",
                CLASS_FID = x.Object.CLASS_FID,




            }).ToList();
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