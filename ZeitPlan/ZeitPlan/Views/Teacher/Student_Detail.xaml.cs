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
    public partial class Student_Detail : ContentPage
    {
        public Student_Detail(TBL_STUDENT s)
        {
            InitializeComponent();
            StudentID.Text = s.STUDENT_ID.ToString();
            StudentName.Text = s.STUDENT_NAME;
            StudentEmail.Text = s.STUDENT_EMAIL;
            StudentPassword.Text = s.STUDENT_PASSWORD;
            
        }
    }
}