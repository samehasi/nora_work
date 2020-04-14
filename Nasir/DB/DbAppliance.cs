using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
        public class DbAppliance
        {
        private SqlConnection cnn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DataSet ds = new DataSet();
     
         public DbAppliance()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\Gym.MDF";
            cnn.ConnectionString = string.Format(@"Data Source=.\SQLExpress;Integrated Security=true; 
                                  AttachDbFilename={0};User Instance=true", path);
        }
        public DataSet GetAllAppliance()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "select * from Appliance";
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
        public DataSet SearchApplianceById(int IdAppliance)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = string.Format("select * from Appliance where IdAppliance={0}", IdAppliance);
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



        public DataTable GetAllAppliance1()
        {
            DataTable dt = new DataTable("Appliance");
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "select * from Appliance";
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
        public void insertsAppliance(Appliance a)
        {
            string SqlStr = string.Format("insert into Appliance(IdAppliance, Active, IdWorkstation, used )values({0},'{1}',{2},'{3}')", a.IdAppliance, a.active, a.idWorkstation, a.used);
            InsDelUpd(SqlStr);
        }
        public void DeleteAppliance(Appliance a)
        {
            string SqlStr = string.Format("delete  from Appliance where IdAppliance={0}", a.IdAppliance);
            InsDelUpd(SqlStr);
        }
        public void UpdateAppliance(Appliance a)
        {
            string sqlstr = string.Format("update appliance set active='{0}', IdWorkstation={1} , used='{2}' where IdAppliance={3}", a.active,a.idWorkstation, a.used, a.IdAppliance);

            InsDelUpd(sqlstr);
        }
        public bool Found(int IdAppliance)
        {
            DataSet ds = new DataSet();
            string str = string.Format("select * from appliance where idappliance={0} ", IdAppliance);
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
       
            public bool FoundByidAppliance(int IdAppliance)
        {
            DataSet ds = new DataSet();
            string str = string.Format("select * from Appliance where IdAppliance={0} ", IdAppliance);
            ds = ReturnDS(str);
            if (ds.Tables[0].Rows.Count == 0)
                return false;
            else
                return true;
        }
            public DataSet GetApplianceInfo(Appliance a)
            {
                DataSet ds = new DataSet();
                string SqlStr = string.Format("select * from Appliance where IdAppliance={0}", a.IdAppliance);
                ds = ReturnDS(SqlStr);
                return ds;
            }


    }
}

