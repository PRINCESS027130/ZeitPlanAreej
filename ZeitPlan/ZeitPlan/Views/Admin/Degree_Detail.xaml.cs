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
    public partial class Degree_Detail : ContentPage
    {
        public Degree_Detail(TBL_DEGREE de)
        {
            InitializeComponent();
            DegreeID.Text = de.DEGREE_ID.ToString();
            DegreeName.Text = de.DEGREE_NAME;
            DepartmentFID.Text= de.DEPARTMENT_FID.ToString();
        }
    }
}