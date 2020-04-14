using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public class DbCoach
    {
        private SqlConnection cnn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DataSet ds = new DataSet();
        public DbCoach()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\Gym.MDF";
            cnn.ConnectionString = string.Format(@"Data Source=.\SQLExpress;Integrated Security=true; 
                                  AttachDbFilename={0};User Instance=true", path);
        }
        public DataSet GetAllCoach()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "select * from couch";
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
        public DataSet SearchCoachById(int idcoach)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = string.Format("select * from couch where idCoach={0}", idcoach);
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
        public bool FoundCoachByName(string name)
        {
            DataSet ds = new DataSet();
            string str = string.Format("select * from couch where firstname='{0}'", name);
            ds = ReturnDS(str);
            //אם הטבלה לא מכילה אף שורה ז"א מה שחפשנו לא נמצא
            if (ds.Tables[0].Rows.Count == 0)
                return false;
            else
                return true;
        }
        public DataSet SearchCoachByName(string name)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = string.Format("select * from couch where firstname='{0}'", name);
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


        public DataTable GetAllCoach1()
        {
            DataTable dt = new DataTable("couch");
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "select * from couch";
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
        public void insertsCoach(Coach c)
        {
            string SqlStr = string.Format("insert into couch(IdCoach, FirstName, LastName, City, Address, Phone, Age, Gender )values({0},'{1}','{2}','{3}','{4}','{5}',{6},'{7}')", c.IdCoach, c.Firstname, c.Lastname, c.City, c.Address, c.Phone, c.Age, c.Gender);
            InsDelUpd(SqlStr);
        }
        public void DeleteCoach(Coach c)
        {
            string SqlStr = string.Format("delete  from couch where IdCoach={0}", c.IdCoach);
            InsDelUpd(SqlStr);
        }
        public void UpdateCoach(Coach c)
        {
            string sqlstr = string.Format("update couch set FirstName='{0}', LastName='{1}' , City='{2}' ,Address='{3}' , Phone='{4}' ,Age={5}, Gender='{6}' where IdCoach={7}", c.Firstname, c.Lastname, c.City, c.Address, c.Phone, c.Age, c.Gender, c.IdCoach);

            InsDelUpd(sqlstr);
        }
        public bool Found(int IdCoach)
        {
            DataSet ds = new DataSet();
            string str = string.Format("select * from couch where idcoach={0} ", IdCoach);
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
