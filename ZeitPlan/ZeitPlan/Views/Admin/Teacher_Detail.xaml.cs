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
    public partial class Teacher_Detail : ContentPage
    {
        public Teacher_Detail(TBL_TEACHER t)
        {
            InitializeComponent();
            TeacherID.Text = t.TEACHER_ID.ToString();
            TeacherName.Text = t.TEACHER_NAME;
            TeacherEmail.Text = t.TEACHER_EMAIL;
            TeacherPassword.Text = t.TEACHER_PASSWORD;
            TeacherAddress.Text = t.TEACHER_ADDRESS;
            TeacherPhone.Text = t.TEACHER_PHNO;
            DepartmentFID.Text=t.DEPARTMENT_FID.ToString();
            //TIMETABLE_FID=t.TIMETABLE_FID;
        }
    }
}