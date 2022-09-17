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
                   new AdminSideBarFlyoutMenuItem { Id = 14,  Icon="department_icon", Title = "Add Department" , TargetType=typeof(Add_Department) },
                  new AdminSideBarFlyoutMenuItem { Id = 15,  Icon="manage_department", Title = "Manage Department" , TargetType=typeof(Manage_Department) },
                  new AdminSideBarFlyoutMenuItem { Id =10,  Icon="DEGREE", Title = "Add Degree" , TargetType=typeof(Add_Degree) },
                  new AdminSideBarFlyoutMenuItem { Id =11,  Icon="manage_degree", Title = "Manage Degree" , TargetType=typeof(Manage_Degree) },
                  new AdminSideBarFlyoutMenuItem { Id = 6,  Icon="class_icon", Title = "Add Class" , TargetType=typeof(Add_Class) },
                   new AdminSideBarFlyoutMenuItem { Id = 7,  Icon="manage_class", Title = "Manage Class" , TargetType=typeof(Manage_Class) },
                   new AdminSideBarFlyoutMenuItem { Id = 4, Icon="Diary_icon", Title = "Add Course" , TargetType=typeof(Add_course) },
                   new AdminSideBarFlyoutMenuItem { Id = 5,  Icon="manage_coursesse", Title = "Manage Course" , TargetType=typeof(Manage_Course) },
                   new AdminSideBarFlyoutMenuItem { Id = 18,  Icon="Assign_course_class", Title = "Assign Course to class" , TargetType=typeof(Assign_Course_To_Class) },
                  new AdminSideBarFlyoutMenuItem { Id = 19,  Icon="Manage_course_class", Title = "Manage Course Assign" , TargetType=typeof(Manage_Course_Assign) },
                  new AdminSideBarFlyoutMenuItem { Id = 8,  Icon="profile_icon", Title = "Add Teacher" , TargetType=typeof(Add_Teacher) },
                  new AdminSideBarFlyoutMenuItem { Id = 9,  Icon="manage_icon", Title = "Manage Teacher" , TargetType=typeof(Manage_Teacher) },
                  new AdminSideBarFlyoutMenuItem { Id = 20,  Icon="course_teacher_icon", Title = "Assign Course to Teacher" , TargetType=typeof(Assign_Course_To_Teacher) },
                  new AdminSideBarFlyoutMenuItem { Id = 21,  Icon="Manage_course_teacher", Title = "Manage Teacher Course Assign" , TargetType=typeof(Mange_Teacher_Assign) },
                  new AdminSideBarFlyoutMenuItem { Id = 12,  Icon="room_icon", Title = "Add Room" , TargetType=typeof(Add_Room) },
                  new AdminSideBarFlyoutMenuItem { Id = 13,  Icon="Manage_Room", Title = "Manage Room" , TargetType=typeof(Manage_Room) },
                  new AdminSideBarFlyoutMenuItem { Id = 12,  Icon="Slot_Icon", Title = "Add Slot" , TargetType=typeof(Add_Slot) },
                   new AdminSideBarFlyoutMenuItem { Id = 12,  Icon="Manage_Slot", Title = "Manage Slot" , TargetType=typeof(Manage_Slot) },
                  new AdminSideBarFlyoutMenuItem { Id = 16,  Icon="table_icon", Title = "Create TIMETABLE" , TargetType=typeof(Create_Time_Table) },
                  new AdminSideBarFlyoutMenuItem { Id = 17,  Icon="manage_time", Title = "Manage TIMETABLE" , TargetType=typeof(Mange_TimeTable) },
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