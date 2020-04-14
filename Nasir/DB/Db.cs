﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Db
    {
        //הגדרת מחלקה להתחברות למסד נתונים
        private SqlConnection cnn = new SqlConnection();
        //מחלקה המגדירה את השאילתות הנשלחות למסד הנתונים
        private SqlCommand cmd = new SqlCommand();
        //מחלקה המגדירה כל הטבלאות והקשרים בינהים שיטענו לזיכרון
        private DataSet ds = new DataSet();
        //Constractor
        public Db()
        {

            //הגדרת מחרוזת התחברות למסד הנתונים שכוללת מיקום מסד נתונים וסוג של מסד נתונים
            string path = System.IO.Directory.GetCurrentDirectory()+"\\Gym.MDF";
            cnn.ConnectionString = string.Format(@"Data Source=.\SQLExpress;Integrated Security=true; 
                                  AttachDbFilename={0};User Instance=true", path);



        }

        public DataSet GetAllWorkStation()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                //Teacher מחרוזת המגדירה שאילתה שמחזירה את כל המורים מטבלת 
                cmd.CommandText = "select * from WorkStation";
                //ביצוע ההתחברות למסד הנתונים
                cmd.Connection = cnn;
                //DataSet ובאמצעותה נבנה DataSet מחלקה המגשרת בין מסד הנתונים לבין ההעתק שנמצא בזכרון 
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //open-close היא מבצעת פתיחה וסגירה התחברות DataSet פעולה הטוענת הנתונים לזכרון
                da.Fill(ds);
            }                                                                   
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public DataTable GetAllWorkStationdt()
        {
            DataTable dt = new DataTable("WorkStation");
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "select * from [WorkStation]";
                cmd.Connection = cnn;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { cnn.Close(); }
            return dt;
        }

        public void InsertTeacher(WorkStation w)
        {
            string SqlStr = string.Format("insert into WorkStation (IdWorkStation,name,Amount,Place,Floor)values({0},'{1}',{2},'{3}','{4}')",w.idworkstation,w.name,w.amount,w.place,w.floor);
            //ביצוע עדכון למסד הנתונים לאחר השינוי
            InsDelUpd(SqlStr);
        }
        public void DeleteWorkStation(WorkStation w)
        {
            string SqlStr = string.Format("delete  from WorkStation where idworkstation={0}", w.idworkstation);
            InsDelUpd(SqlStr);
        }
       
        public DataSet GetworkstaionInfo(WorkStation w)
        {
            DataSet ds = new DataSet();
            string SqlStr = string.Format("select * from workstation where idworkstation={0}", w.idworkstation);
            ds = ReturnDS(SqlStr);
            return ds;
        }

        public bool Found(int IdWorkStation)
        {
            DataSet ds = new DataSet();
            string str = string.Format("select * from workstation where idworkstation={0} ", IdWorkStation);
            ds = ReturnDS(str);
            //אם הטבלה לא מכילה אף שורה ז"א מה שחפשנו לא נמצא
            if (ds.Tables[0].Rows.Count == 0)
                return false;
            else
                return true;
        }


            public void UpdateTeacher(WorkStation w)
        {
            string SqlStr = string.Format("update workstation  set  name='{0}' ,amount={1}, place='{2}', floor='{3}' where IdWorkStation={4}", w.name, w.amount, w.place, w.floor, w.idworkstation);
            InsDelUpd(SqlStr);
        }
          
        public void InsDelUpd(string SqlStr)
        {
            /*          טענת כניסה: הפונקציה מקבלת מחרוזת פקודה
                   טענת יציאה : הפונקציה מעדכנת את בסיס הנתונים       
            */
            SqlCommand cmd = new SqlCommand();
            try
            {
                // פתיחת ההתחברות עם בסיס הנתונים 
                cnn.Open();
                cmd.Connection = cnn;
                // sql  מאפיין אשר מאפשר  לקבל את הוראת :CommandText המאפיין   
                cmd.CommandText = SqlStr;
                // (Delete,Update,Insert) לעדכון בסיס הנתונים sql מתודה שמבצעת הוראת 
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // סגירת ההתחברות (סגירת הקשר עם בסיס הנתונים חיונית בשביל לתרום ליעילות האפליקציה
                cnn.Close();
            }
        }

        public DataSet ReturnDS(string SqlStr)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                //  sql מאפיין אשר מאפשר לקבוע או לקבל את הוראת :CommandText
                cmd.CommandText = SqlStr;
                //  OleDbConnection מאפיין אשר מאפשר לקבוע או לקבל את אובייקט ההתחברות מהמחלקה :Connection
                cmd.Connection = cnn;
                //DataSet ומשימה שנייה בכדי לעדכן את בסיס הנתונים בהתאם למידע שהתרחש ב  DataSet יצירת מופע למחלקה המייצגת אובייקט ההתחברות לבסיס הנתונים. ייצוג זה דרוש לשתי משימות משימה ראשונה בכדי להעביר נתונים מבסיס הנתונים ל 
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                // DataSet טוענת את הנתונים לתוך אובייקט  Fill המתודה 
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
          
            return ds;
        }

        //פעולת חיפוש מורה
        public DataSet SearchWorkStationbycode(int IdWorkStation)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = string.Format("select * from WorkStation where IdWorkStation={0}", IdWorkStation);
                cmd.Connection = cnn;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            return ds;
        }
       }
    }


   


