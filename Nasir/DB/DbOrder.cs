using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public class DbOrder
    {
        private SqlConnection cnn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DataSet ds = new DataSet();
        public DbOrder()
        {
            cnn.ConnectionString = @"Data Source=.\SQLExpress;Integrated Security=true; 
                                  AttachDbFilename=C:\Nasir\Nasir\Gym.MDF;User Instance=true";
        }
        public DataSet GetAllOrder()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "select * from [order]";
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

        public DataTable GetAllOrder1()
        {
            DataTable dt = new DataTable("order");
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "select * from [order]";
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

        public DataSet SearchOrderByIdCoach(int idcoach)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = string.Format("select * from [order] where idcoach={0}", idcoach);
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
        public DataSet SearchOrderById(int idorder)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = string.Format("select * from [order] where idorder={0}", idorder);
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
        public void insertsorder(Order o)
        {
            string SqlStr = string.Format("insert into [order] (idorder,dateord,timeord,idcoach,codeappliance,amountord,noteord)values({0},'{1}','{2}',{3},'{4}',{5},'{6}')", o.Idorder, o.Dateord, o.Timeord, o.Idcoach, o.Codeappliance, o.Amountord, o.Noteord);
            InsDelUpd(SqlStr);
        }
        public void DeleteOrder(Order o)
        {
            string SqlStr = string.Format("delete  from [order] where idorder={0}", o.Idorder);
            InsDelUpd(SqlStr);
        }
        public void UpdateOrder(Order o )
        {
            string sqlstr = string.Format("update [order] set dateord='{0}',timeord='{1}',idcoach={2},codeappliance='{3}',amountord={4},noteord='{5}' where idorder={6}", o.Dateord, o.Timeord, o.Idcoach, o.Codeappliance, o.Amountord, o.Noteord,o.Idorder);

            InsDelUpd(sqlstr);
        }
        public bool Found(int idorder)
        {
            DataSet ds = new DataSet();
            string str = string.Format("select * from [order] where idorder={0} ", idorder);
            ds = ReturnDS(str);
            if (ds.Tables[0].Rows.Count == 0)
                return false;
            else
                return true;
        }

        public bool FoundCoach(int idcoach)
        {
            DataSet ds = new DataSet();
            string str = string.Format("select * from [order] where idcoach={0} ", idcoach);
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


    }
}
