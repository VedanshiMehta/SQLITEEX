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
    class StudentAdapter : RecyclerView.Adapter
    {
        private List<Students> studentslist;
        public Context context;
        private StudentHolder studholder;

        public StudentAdapter(List<Students> mystudentlist, ViewData viewData)
        {
            this.studentslist = mystudentlist;
            this.context = viewData;

        }

        public override int ItemCount => studentslist.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            studholder = holder as StudentHolder;
            studholder.Binddata(studentslist[position]);

            studholder.linear.Click += (s, e) => {

                Intent i = new Intent(context, typeof(UpDeleteData));
                i.PutExtra("StudentDetails", studentslist[position].sId);
                context.StartActivity(i);
            
            };
        

        }

        
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.studentsdetailslist, parent, false);
            return new StudentHolder(view);
        }


    }

    class StudentHolder : RecyclerView.ViewHolder
    {
        public TextView mstudentName;
        public TextView mstudentSurName;
        public TextView mstudentMarks;
        public TextView mstudentId;
        public LinearLayout linear;
    



        public StudentHolder(View itemView) : base(itemView)
        {

            mstudentName = itemView.FindViewById<TextView>(Resource.Id.studentName);
            mstudentSurName = itemView.FindViewById<TextView>(Resource.Id.studentSurName);
            mstudentMarks =itemView.FindViewById<TextView>(Resource.Id.studentMarks);
            mstudentId = itemView.FindViewById<TextView>(Resource.Id.studentId);
            linear = itemView.FindViewById<LinearLayout>(Resource.Id.linearLayout2);
          


        }


        

        internal void Binddata(Students students)
        {
            mstudentName.Text = students.sName;
            mstudentSurName.Text = students.sSurname;
            mstudentMarks.Text = students.sMarks.ToString();
            mstudentId.Text = students.sId.ToString();
        }
    }



}