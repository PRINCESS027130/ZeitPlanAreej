﻿using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZeitPlan.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add_Room : ContentPage
    {
        public Add_Room()
        {
            InitializeComponent();
            LoadData();
        }
        async void LoadData()
        {
            var firebaseList = (await App.firebaseDatabase.Child("TBL_DEPARTMENT").OnceAsync<TBL_DEPARTMENT>()).Select(x => new TBL_DEPARTMENT
            {

                DEPARTMENT_NAME = x.Object.DEPARTMENT_NAME,

            }).ToList();
            var refinedList = firebaseList.Select(x => x.DEPARTMENT_NAME).ToList();
            ddlDepartment.ItemsSource = refinedList;
        }



        private async void btnRoom_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRNO.Text) )
                {
                    await DisplayAlert("Error", "please fill all the required fields try again", "ok");
                    return;
                }

                if (ddlDepartment.SelectedItem == null)
                {
                    await DisplayAlert("Error", "please select Degree and try again", "ok");
                    return;
                }



                var check = (await App.firebaseDatabase.Child("TBL_ROOM").OnceAsync<TBL_ROOM>()).FirstOrDefault(x => x.Object.ROOM_NO == txtRNO.Text);

                if (check != null)
                {
                    await DisplayAlert("Error", check.Object.ROOM_NO + "This ROOM NO is already Picked .", "ok");
                    return;
                }
                LoadingInd.IsRunning = true;
                int LastID, NewID = 1;

                var LastRecord = (await App.firebaseDatabase.Child("TBL_ROOM").OnceAsync<TBL_ROOM>()).FirstOrDefault();
                if (LastRecord != null)
                {
                    LastID = (await App.firebaseDatabase.Child("TBL_ROOM").OnceAsync<TBL_ROOM>()).Max(a => a.Object.ROOM_ID);
                    NewID = ++LastID;
                }
                List<TBL_DEPARTMENT> degs = (await App.firebaseDatabase.Child("TBL_DEPARTMENT").OnceAsync<TBL_DEPARTMENT>()).Select(x => new TBL_DEPARTMENT
                {
                    DEPARTMENT_ID = x.Object.DEPARTMENT_ID,
                    DEPARTMENT_NAME = x.Object.DEPARTMENT_NAME

                }).ToList();
                int selected = degs[ddlDepartment.SelectedIndex].DEPARTMENT_ID;


                TBL_ROOM r = new TBL_ROOM()
                {
                    ROOM_ID = NewID,
                    ROOM_NO = txtRNO.Text,

                    DEPARTMENT_FID=selected
                };

                await App.firebaseDatabase.Child("TBL_ROOM").PostAsync(r);
                LoadingInd.IsRunning = false;
                await DisplayAlert("Success", "ROOM Added  ", "Ok");

            }
            catch (Exception ex)
            {
                LoadingInd.IsRunning = false;
                await DisplayAlert("Error", "Something went wrong Please try again later.\nError:" + ex.Message, "ok");
                return;
            }
        }
    }
}
       