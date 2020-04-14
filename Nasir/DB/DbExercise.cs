using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class DbExercise
    {
        private SqlConnection cnn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DataSet ds = new DataSet();

        public DbExercise()
        {
            cnn.ConnectionString = @"Data Source=.\SQLExpress;Integrated Security=true; 
                                  AttachDbFilename=C:\Nasir\Nasir\Gym.MDF;User Instance=true";
        }
        public DataSet GetAllExercise()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "select IdExercise,ExerciseName,WorkStation,'imag' from Exercise";
                cmd.Connection = cnn;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { cnn.Close(); }
            return ds;
        }
        public DataSet SearchExerciseById(int IdExerecise)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = string.Format("select * from Exercise where IdExercise={0}", IdExerecise);
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



        public DataTable GetAllExercise1()
        {
            DataTable dt = new DataTable("Exercise");
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "select * from Exercise";
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
            catch { }
            finally
            {
                cnn.Close();
            }
            return ds;
        }


        public void DeleteExercise(Exercise e)
        {
            string SqlStr = string.Format("delete  from Exercise where IdExercise={0}", e.idexercise);
            SqlCommand cmd = new SqlCommand();
            try
            {
                // פתיחת ההתחברות עם בסיס הנתונים 
                cnn.Open();
                cmd.Connection = cnn;
                // sql  מאפיין אשר מאפשר לקבוע או לקבל את הוראת :CommandText המאפיין   
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

        public void InsertExercise(Exercise e)
        {
            string sqlstr = "insert into Exercise(IdExercise,ExerciseName,WorkStation,picture)values(@IdExercise,@ExerciseName,@WorkStation,@picture)";
            InsDelUpd(sqlstr, e);
        }
        public void UpdateExercise(Exercise e)
        {
              string sqlstr;
            if (e.picture!=null)
                sqlstr = "update Exercise set ExerciseName=@ExerciseName, WorkStation=@WorkStation, picture=@picture where IdExercise=@IdExercise";
            else
                sqlstr = "update Exercise set ExerciseName=@ExerciseName, WorkStation=@WorkStation where IdExercise=@IdExercise";
            InsDelUpd(sqlstr, e);
        }

        public bool Found(int IdExercise)
        {
            DataSet ds = new DataSet();
            string str = string.Format("select * from Exercise where IdExercise={0} ", IdExercise);
            ds = ReturnDS(str);
            if (ds.Tables[0].Rows.Count == 0)
                return false;
            else
                return true;
        }


        public void InsDelUpd(string SqlStr, Exercise ee)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {

                //Initialize SqlCommand object for insert.
                SqlCommand SqlCom = new SqlCommand(SqlStr, cnn);

                //We are passing Original Image Path and Image byte data as sql parameters.
                SqlCom.Parameters.Add(new SqlParameter("@IdExercise", (object)ee.idexercise));
                SqlCom.Parameters.Add(new SqlParameter("@ExerciseName", (object)ee.exerciseName));
                SqlCom.Parameters.Add(new SqlParameter("@WorkStation", (object)ee.workstation));

                if (ee.picture != null)
                {
                    SqlCom.Parameters.Add(new SqlParameter("@picture", (object)ee.picture));
                }


                // פתיחת ההתחברות עם בסיס הנתונים 
                cnn.Open();
                SqlCom.ExecuteNonQuery();


                cnn.Close();

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


    }
}


