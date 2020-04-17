using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public class DbKindTreatments
    {
        private SqlConnection cnn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DataSet ds = new DataSet();
        public DbKindTreatments()
        {
            // string path = System.IO.Directory.GetCurrentDirectory() + "\\Garage.MDF";
            string path = @"d:\work\Nora\workspace\nora_work\Garage\Garage.mdf";

            cnn.ConnectionString = string.Format(@"Data Source=.\SQLExpress;Integrated Security=true; 
                                  AttachDbFilename={0};User Instance=true", path);
        }
        public DataSet GetAllKindTreatments()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "select * from KindTreatments";
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
        public DataSet SearchKindTreatmentByKindTreatmentId(int treatKindNum)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = string.Format("select * from KindTreatments where Number ={0}", treatKindNum);
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


        public DataSet SearchKindTreatmentByName(string name)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = string.Format("select * from KindTreatments where (KindTreatment LIKE '%{0}%' )", name);
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
        public void insertTreatmentKind(KindTreatment w)
        {
            string SqlStr = string.Format("insert into KindTreatments(Number, KindTreatment, Price )values({0},'{1}','{2}')", w.Id, w.Kind, w.Price);
            InsDelUpd(SqlStr);
        }
        public void DeleteKindTreatment(KindTreatment w)
        {
            string SqlStr = string.Format("delete  from KindTreatments where Number={0}", w.Id);
            InsDelUpd(SqlStr);
        }
        public void UpdateKindTreatment(KindTreatment w)
        {
            string sqlstr = string.Format("update KindTreatments set Kind='{0}', Price={1}  where Number={2}", w.Kind, w.Price, w.Id);

            InsDelUpd(sqlstr);
        }
        public bool Found(int wid)
        {
            DataSet ds = new DataSet();
            string str = string.Format("select * from KindTreatments where Number={0} ", wid);
            ds = ReturnDS(str);
            if (ds.Tables[0].Rows.Count == 0)
                return false;
            else
                return true;
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

        public bool KindTreatmentExist(int id)
        {
            DataSet ds = new DataSet();
            string str = string.Format("select * from KindTreatments where Number={0} ", id);
            ds = ReturnDS(str);
            //אם הטבלה לא מכילה אף שורה ז"א מה שחפשנו לא נמצא
            if (ds.Tables[0].Rows.Count == 0)
                return false;
            else
                return true;
        }

        public DataSet getKindTreatmentInfo(KindTreatment w)
        {
            DataSet ds = new DataSet();
            string SqlStr = string.Format("select * from KindTreatments where Number={0}", w.Id);
            ds = ReturnDS(SqlStr);
            return ds;
        }


    }
}
