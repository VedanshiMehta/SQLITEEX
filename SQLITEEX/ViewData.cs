using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using SQLITEEX.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLITEEX
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class ViewData : Activity
    {
        private RecyclerView myRecycleView;



        public List<string> mystudentlist;
        ListView mystudListView;
        RecyclerView.LayoutManager myLayoutmanager;
        private StudentAdapter sadapter;
        StudentDatabase sDB;
        public string sstudName;
        public string sstudSurName;
        public int ssMarks;
        public int ssId;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.viewdatalayout);

            myRecycleView = FindViewById<RecyclerView>(Resource.Id.recyclerView1);
            mystudListView = FindViewById<ListView>(Resource.Id.listView1);

            GetStudentsDetails();

            myLayoutmanager = new LinearLayoutManager(this);
            myRecycleView.SetLayoutManager(myLayoutmanager);

            sadapter = new StudentAdapter(mystudentlist,this);
            myRecycleView.SetAdapter(sadapter);

            
           
        }

       

       public List<string> GetStudentsDetails()
        {
            sDB = new StudentDatabase();
            mystudentlist = new List<string>();
         
        

            foreach (var data in sDB.ReadStudents())
            {
                sstudName = data.sName;
                sstudSurName = data.sSurname;
                ssMarks = int.Parse(data.sMarks.ToString());
                ssId = int.Parse(data.sId.ToString());

                Console.WriteLine(sstudName);
                Console.WriteLine(sstudSurName);
                Console.WriteLine(ssMarks);
                Console.WriteLine(ssId);

                mystudentlist.Add("Name: " + sstudName);
                mystudentlist.Add("SurName: " + sstudSurName);
                mystudentlist.Add("Marks: " + ssMarks);
                mystudentlist.Add("Id: " + ssId);
            }



            return mystudentlist;


        }

        
    }
}