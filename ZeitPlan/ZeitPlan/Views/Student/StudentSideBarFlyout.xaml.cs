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

namespace ZeitPlan.Views.Student
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentSideBarFlyout : ContentPage
    {
        public ListView ListView;

        public StudentSideBarFlyout()
        {
            InitializeComponent();

            BindingContext = new StudentSideBarFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class StudentSideBarFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<StudentSideBarFlyoutMenuItem> MenuItems { get; set; }

            public StudentSideBarFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<StudentSideBarFlyoutMenuItem>(new[]
                {
                    new StudentSideBarFlyoutMenuItem { Id = 0, Icon="home_icon.png"  , Title = "Home" ,TargetType=typeof(StudentHome) },
                    new StudentSideBarFlyoutMenuItem { Id = 1, Icon="table_icon.png", Title = "View table",TargetType=typeof(ViewTable) },
                    new StudentSideBarFlyoutMenuItem { Id = 2, Icon="Progress_icon.png", Title = "Student Progress" },
                    new StudentSideBarFlyoutMenuItem { Id = 3, Icon="icon_feed.png", Title = "Teacher Diary" },
                    new StudentSideBarFlyoutMenuItem { Id = 4, Icon="icon_feed.png", Title = "View Student List", TargetType=typeof(Student_List) },
                    new StudentSideBarFlyoutMenuItem { Id = 4, Icon="icon_feed.png", Title = "Request portal", TargetType=typeof(Request_Portol) },
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