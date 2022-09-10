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
    public partial class Request_Detail : ContentPage
    {
        public Request_Detail(TBL_REQUEST_PORTAL r)
        {
            InitializeComponent();
            RequestID.Text = r.REQUEST_PORTAL_ID.ToString();
            
            DepartmentName.Text = r.DEPARTMENT_FID.ToString();
            StudentName.Text = r.Student_FID.ToString();
            Type.Text = r.TYPE.ToString();
            Message.Text = r.REQUEST_MESSAGE;
            Status.Text = "Pending";

        }
    }
}