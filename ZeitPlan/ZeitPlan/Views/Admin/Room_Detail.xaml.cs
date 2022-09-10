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
    public partial class Room_Detail : ContentPage
    {
        public Room_Detail(TBL_ROOM r)
        {
            InitializeComponent();
            RoomID.Text = r.ROOM_ID.ToString();
            RoomNumber.Text = r.ROOM_NO;
            DEpartmentFID.Text = r.DEPARTMENT_FID.ToString();
        }
    }
}