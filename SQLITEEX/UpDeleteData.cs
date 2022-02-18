using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLITEEX.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLITEEX
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    class UpDeleteData: Activity
    {
        private EditText myUName;
        private EditText myUSurName;
        private EditText myUMarks;
        private EditText myUId;
        private Button myUpdate;
        private Button myDelete;
        StudentDatabase sDB;
        ViewData viewstuddata;
        private string sutudName;
        private string sutudSurName;
        private int suMarks;
        private int suId;


        private List<string> myUstudentlist;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.updatedeletedata);
            UIReference();
            UIClikevents();

           

        }

        private void UIClikevents()
        {
            myUpdate.Click += MyUpdate_Click;
            myDelete.Click += MyDelete_Click;
        }

        private void MyDelete_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MyUpdate_Click(object sender, EventArgs e)
        {
            sDB = new StudentDatabase();
            viewstuddata = new ViewData();
            Students studs = new Students();

            sutudName = viewstuddata.sstudName;
            sutudSurName = viewstuddata.sstudSurName;
            suMarks = viewstuddata.ssMarks;
            suId = viewstuddata.ssId;

            myUName.Text = sutudName ;
            myUSurName.Text= sutudSurName;
            myUMarks.Text = suMarks.ToString();
            myUId.Text = suId.ToString();



             studs.sName = myUName.Text;
             studs.sName = myUSurName.Text;
             studs.sMarks = int.Parse(myUMarks.Text);
             studs.sMarks = int.Parse(myUId.Text);


             sDB.UpdateStudents(studs);






        }

        private void UIReference()
        {
            myUName = FindViewById<EditText>(Resource.Id.editTextUD1);
            myUSurName = FindViewById<EditText>(Resource.Id.editTextUD2);
            myUMarks = FindViewById<EditText>(Resource.Id.editTextUD3);
            myUId = FindViewById<EditText>(Resource.Id.editTextUD4);
            myUpdate = FindViewById<Button>(Resource.Id.buttonU);
            myDelete = FindViewById<Button>(Resource.Id.buttonD);
        }
    }
}