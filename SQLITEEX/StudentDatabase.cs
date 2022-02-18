using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using SQLITEEX.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Environment = System.Environment;

namespace SQLITEEX
{
    class StudentDatabase
    {

        public static string DBname = "SQLite.db3";
        public static string DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DBname);

        SQLiteConnection sqliteConnection;

        public StudentDatabase()
        {
            try
            {
                Console.WriteLine(DBPath);
                sqliteConnection = new SQLiteConnection(DBPath);
                Console.WriteLine("Succefully Database Created!....");
                //Toast.MakeText(Application.Context, "Succefully Database Created!....", ToastLength.Short).Show();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);
               // Toast.MakeText(Application.Context,"Database Exception" + ex, ToastLength.Short).Show();
            }
        }

        public void StudentTable()
        {
            try
            {
                var created = sqliteConnection.CreateTable<Students>();
                Console.WriteLine("Succefully Table Created!....");
                //Toast.MakeText(Application.Context, "Succefully Table Created!....", ToastLength.Short).Show();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);
                //Toast.MakeText(Application.Context,"Database Exception" + ex, ToastLength.Short).Show();
            }

        }

        public void InstertStudents(Students students)
        {

            try
            {
                var result = sqliteConnection.Insert(students);
                Console.WriteLine("Succefully Inserted Data "+ result);
               // Toast.MakeText(Application.Context, "Succefully Data Inserted Created:", ToastLength.Short).Show();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);
                // Toast.MakeText(Application.Context,"Database Exception" + ex, ToastLength.Short).Show();
            }

        }
        public void UpdateStudents(Students students)
        {
            try
            {
                var result= sqliteConnection.Update(students);
                Console.WriteLine("Succefully Update Data " + result);
                // Toast.MakeText(Application.Context, "Succefully Table Created!....", ToastLength.Short).Show();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);
                // Toast.MakeText(Application.Context,"Database Exception" + ex, ToastLength.Short).Show();
            }


        }

        public List<Students> ReadStudents()
        {
            try
            { 
               return sqliteConnection.Table<Students>().ToList();
              
            }

            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);
                // Toast.MakeText(Application.Context,"Database Exception" + ex, ToastLength.Short).Show();
                return null;
            }

        }

        public Students GetByUserName(string studentName)
        {
            var user = sqliteConnection.Table<Students>().Where(u => u.sName == studentName).FirstOrDefault();
          
            return user;

        }

        public Students GetByUserSurName(string studentSurName)
        {
            var userSurName = sqliteConnection.Table<Students>().Where(u => u.sSurname == studentSurName ).FirstOrDefault();

            return userSurName;

        }
    }
}