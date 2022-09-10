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
    public partial class Class_Detail : ContentPage
    {
        public Class_Detail(TBL_CLASS c)
        {
            InitializeComponent();
            ClassID.Text = c.CLASS_ID.ToString();
            Session.Text = c.SESSION;
            Section.Text = c.SECTION;
            Shift.Text = c.SHIFT;
            DegreeFID.Text = c.DEGREE_FID.ToString();
            
        }
    }
}