using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;



namespace SQLITEEX.Model
{
    [Table("student_table")]
    class Students
    {
        [Column("Student_Name")]
        public string sName { get; set; }


        [Column("Student_Surname")]
        public string sSurname { get; set; }

        [Column("Student_Marks")]
        [MaxLength(2)]
        public int sMarks { get; set; }

        [PrimaryKey, AutoIncrement]
        public int sId { get; set; }



    }
}