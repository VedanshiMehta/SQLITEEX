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
        private List<string> mystudentlist;
        public event EventHandler<int> ItemClick;
        public Context context;
        List<Students> data ;
        StudentHolder studholder;
     
        public StudentAdapter(List<string> mystudentlist, ViewData viewData)
        {
            this.mystudentlist = mystudentlist;
            this.context = viewData;
            
        }

        public override int ItemCount => mystudentlist.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            studholder = holder as StudentHolder;
            studholder.Binddata(mystudentlist[position]);
            studholder.linear.Click += Linear_Click;
            data = mystudentlist[position];
           
        }

        private void Linear_Click(object sender, EventArgs e)
        {
         
            Intent intent = new Intent(context,typeof(UpDeleteData));
            intent.PutStringArrayListExtra("studentdata", data);
            //Intent i = new Intent(context, typeof(UpDeleteData));
            ////i.PutExtra("data", mystudentlist[e]);
            //context.StartActivity(i);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.studentsdetailslist, parent, false);
            return new StudentHolder(view);
        }

      
        /*private void OnClick(int obj)
        {
            if (ItemClick != null)
            {
                ItemClick?.Invoke(this, obj);
            }

            ItemClick?.Invoke(this, obj);
        }*/
    }

    class StudentHolder : RecyclerView.ViewHolder
    {
        public TextView studentDetails;
        public LinearLayout linear;
       

        public StudentHolder(View itemView) : base(itemView)
        {
            studentDetails = itemView.FindViewById<TextView>(Resource.Id.studentName);
            linear = itemView.FindViewById<LinearLayout>(Resource.Id.linearLayout2);

          

        }

       
        internal void Binddata(string v)
        {
            studentDetails.Text = v;
        }
    }
  


}