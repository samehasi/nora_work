using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public class DbCars
    {
        private SqlConnection cnn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DataSet ds = new DataSet();
        public DbCars()
        {
            // string path = System.IO.Directory.GetCurrentDirectory() + "\\Garage.MDF";
            string path = @"d:\work\Nora\workspace\nora_work\Garage\Garage.mdf";

            cnn.ConnectionString = string.Format(@"Data Source=.\SQLExpress;Integrated Security=true; 
                                  AttachDbFilename={0};User Instance=true", path);
        }
        public DataSet GetAllCars()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "select * from Cars";
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
        public DataSet SearchCarByProductCode(int CarCode)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = string.Format("select * from Cars where ProductCode ={0}", CarCode);
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

        public DataSet SearchCarByClientId(int ClientId)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = string.Format("select * from Cars where ClientId={0}", ClientId);
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
        public void insertCar(Car w)
        {
            string SqlStr = string.Format("insert into Cars(ProductCode, Kind, Color, ClientId, History)values({0},'{1}','{2}',{3},{4})", w.Id, w.Kind, w.Color, w.ClientId, w.History);
            InsDelUpd(SqlStr);
        }
        public void DeleteCar(Car w)
        {
            string SqlStr = string.Format("delete  from Cars where ProductCode={0}", w.Id);
            InsDelUpd(SqlStr);
        }
        public void UpdateCar(Car w)
        {
            string sqlstr = string.Format("update Cars set  Kind='{0}' , Color='{1}' ,ClientId={2} , History={3} where ProductCode={4}", w.Kind, w.Color, w.ClientId, w.History, w.Id);

            InsDelUpd(sqlstr);
        }
        public bool Found(int wid)
        {
            DataSet ds = new DataSet();
            string str = string.Format("select * from Cars where ProductCode={0} ", wid);
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

        public bool CarExist(int id)
        {
            DataSet ds = new DataSet();
            string str = string.Format("select * from Cars where ProductCode={0} ", id);
            ds = ReturnDS(str);
            //אם הטבלה לא מכילה אף שורה ז"א מה שחפשנו לא נמצא
            if (ds.Tables[0].Rows.Count == 0)
                return false;
            else
                return true;
        }

        public DataSet getCarInfo(Car w)
        {
            DataSet ds = new DataSet();
            string SqlStr = string.Format("select * from Cars where ProductCode={0}", w.Id);
            ds = ReturnDS(SqlStr);
            return ds;
        }

        public DataSet getCarInfo(int id)
        {
            DataSet ds = new DataSet();
            string SqlStr = string.Format("select * from Cars where ProductCode={0}", id);
            ds = ReturnDS(SqlStr);
            return ds;
        }


    }
}
