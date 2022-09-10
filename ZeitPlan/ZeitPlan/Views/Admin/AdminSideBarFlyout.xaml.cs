using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZeitPlan.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminSideBarFlyout : ContentPage
    {
        public ListView ListView;

        public AdminSideBarFlyout()
        {
            InitializeComponent();

            BindingContext = new AdminSideBarFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class AdminSideBarFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<AdminSideBarFlyoutMenuItem> MenuItems { get; set; }

            public AdminSideBarFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<AdminSideBarFlyoutMenuItem>(new[]
                {
                     new AdminSideBarFlyoutMenuItem { Id = 0, Icon="Home" , Title = "Home" , TargetType=typeof(AdminHome) },
                   new AdminSideBarFlyoutMenuItem { Id = 14,  Icon="icon_feed.png", Title = "Add Department" , TargetType=typeof(Add_Department) },
                  new AdminSideBarFlyoutMenuItem { Id = 15,  Icon="icon_feed.png", Title = "Manage Department" , TargetType=typeof(Manage_Department) },
                  new AdminSideBarFlyoutMenuItem { Id =10,  Icon="Degree", Title = "Add Degree" , TargetType=typeof(Add_Degree) },
                  new AdminSideBarFlyoutMenuItem { Id =11,  Icon="Manage_Degree", Title = "Manage Degree" , TargetType=typeof(Manage_Degree) },
                  new AdminSideBarFlyoutMenuItem { Id = 6,  Icon="Class_Icon", Title = "Add Class" , TargetType=typeof(Add_Class) },
                   new AdminSideBarFlyoutMenuItem { Id = 7,  Icon="Manage_Class", Title = "Manage Class" , TargetType=typeof(Manage_Class) },
                   new AdminSideBarFlyoutMenuItem { Id = 4, Icon="icon_feed.png", Title = "Add Course" , TargetType=typeof(Add_course) },
                   new AdminSideBarFlyoutMenuItem { Id = 5,  Icon="Manage_Course", Title = "Manage Course" , TargetType=typeof(Manage_Course) },
                   new AdminSideBarFlyoutMenuItem { Id = 18,  Icon="icon_feed.png", Title = "Assign Course to class" , TargetType=typeof(Assign_Course_To_Class) },
                  new AdminSideBarFlyoutMenuItem { Id = 19,  Icon="icon_feed.png", Title = "Manage Course Assign" , TargetType=typeof(Manage_Course_Assign) },
                  new AdminSideBarFlyoutMenuItem { Id = 8,  Icon="profile_icon", Title = "Add Teacher" , TargetType=typeof(Add_Teacher) },
                  new AdminSideBarFlyoutMenuItem { Id = 9,  Icon="manage_icon", Title = "Manage Teacher" , TargetType=typeof(Manage_Teacher) },
                  new AdminSideBarFlyoutMenuItem { Id = 20,  Icon="icon_feed.png", Title = "Assign Course to Teacher" , TargetType=typeof(Assign_Course_To_Teacher) },
                  new AdminSideBarFlyoutMenuItem { Id = 21,  Icon="icon_feed.png", Title = "Manage Teacher Course Assign" , TargetType=typeof(Mange_Teacher_Assign) },
                  new AdminSideBarFlyoutMenuItem { Id = 12,  Icon="icon_feed.png", Title = "Add Room" , TargetType=typeof(Add_Room) },
                  new AdminSideBarFlyoutMenuItem { Id = 13,  Icon="Manage_Room", Title = "Manage Room" , TargetType=typeof(Manage_Room) },
                  new AdminSideBarFlyoutMenuItem { Id = 12,  Icon="Slot_Icon", Title = "Add Slot" , TargetType=typeof(Add_Slot) },
                   new AdminSideBarFlyoutMenuItem { Id = 12,  Icon="Manage_Slot", Title = "Manage Slot" , TargetType=typeof(Manage_Slot) },
                  new AdminSideBarFlyoutMenuItem { Id = 16,  Icon="table_icon", Title = "Create TIMETABLE" , TargetType=typeof(Create_Time_Table) },
                  new AdminSideBarFlyoutMenuItem { Id = 17,  Icon="icon_feed.png", Title = "Manage TIMETABLE" , TargetType=typeof(Mange_TimeTable) },
                   new AdminSideBarFlyoutMenuItem { Id = 12,  Icon="Manage_Slot", Title = " Reuest Portal" , TargetType=typeof(Request_Portol) },
                  new AdminSideBarFlyoutMenuItem { Id = 16,  Icon="table_icon", Title = "Manage Request Portal " , TargetType=typeof(Manage_Request_Portal) },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}