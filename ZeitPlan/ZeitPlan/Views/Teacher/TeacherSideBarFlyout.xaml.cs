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

namespace ZeitPlan.Views.Teacher
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeacherSideBarFlyout : ContentPage
    {
        public ListView ListView;

        public TeacherSideBarFlyout()
        {
            InitializeComponent();

            BindingContext = new TeacherSideBarFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class TeacherSideBarFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<TeacherSideBarFlyoutMenuItem> MenuItems { get; set; }

            public TeacherSideBarFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<TeacherSideBarFlyoutMenuItem>(new[]
                {
                    new TeacherSideBarFlyoutMenuItem { Id = 0, Icon="home_icon.png"  , Title = "Home" ,TargetType=typeof(TeacherHome) },
                    new TeacherSideBarFlyoutMenuItem { Id = 1, Icon="table_icon.png", Title = "View table",TargetType=typeof(ViewTable) },
                    new TeacherSideBarFlyoutMenuItem { Id = 2, Icon="Progress_icon.png", Title = "Student Progress" },
                    new TeacherSideBarFlyoutMenuItem { Id = 3, Icon="icon_feed.png", Title = "Teacher Diary" },
                    new TeacherSideBarFlyoutMenuItem { Id = 4, Icon="icon_feed.png", Title = "Teacher List", TargetType=typeof(Teacher_List) },
                    new TeacherSideBarFlyoutMenuItem { Id = 5, Icon="icon_feed.png", Title = "Request Portol", TargetType=typeof(Request_Portol) },
                    new TeacherSideBarFlyoutMenuItem { Id = 6, Icon="profile_icon", Title = "Add Student", TargetType=typeof(Add_Student) },
                    new TeacherSideBarFlyoutMenuItem { Id = 7, Icon="manage_icon", Title = "Manage Student", TargetType=typeof(Manage_Student) },

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