using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public class DbTreatments
    {
        private SqlConnection cnn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DataSet ds = new DataSet();
        public DbTreatments()
        {
            // string path = System.IO.Directory.GetCurrentDirectory() + "\\Garage.MDF";
            string path = @"d:\work\Nora\workspace\nora_work\Garage\Garage.mdf";

            cnn.ConnectionString = string.Format(@"Data Source=.\SQLExpress;Integrated Security=true; 
                                  AttachDbFilename={0};User Instance=true", path);
        }
        public DataSet GetAllTreatments()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "select * from Treatments";
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

        public DataSet GetAllInvoices()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "select * from InvoiceDetails";
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
        public void insertTreatment(Treatment w)
        {
            string SqlStr = string.Format("insert into Treatments(Idtreatment, IdCustomer, NameCustomer, IdWorker, NameWorker,Time, Date,IdCar,KindCar,Total)values({0},{1},'{2}',{3},'{4}','{5}','{6}',{7},'{8}',{9})", w.Id, w.CustometId, w.CustomerName, w.WorkerId, w.WorkerName, w.Date,w.Time,w.CarId,w.CarKind,w.Total);
            InsDelUpd(SqlStr);
        }

        public void insertInvoice(WindowsFormsApplication1.InvoiceDetails w)
        {
            string SqlStr = string.Format("insert into InvoiceDetails(CodeTreatment, InvoiceNumber, ClientId, Price, Kind)values({0},{1},{2},{3},'{4}')", w.CodeTreatment ,w.InvoiceNumber,w.ClientId,w.Price,w.Kind );
            InsDelUpd(SqlStr);
        }
        public bool TreatmentExist(int TreatmentId)
        {
            DataSet ds = new DataSet();
            string str = string.Format("select * from Treatments where Idtreatment={0} ", TreatmentId);
            ds = ReturnDS(str);
            //אם הטבלה לא מכילה אף שורה ז"א מה שחפשנו לא נמצא
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


        public DataSet getTreatmentInfo(Treatment w)
        {
            DataSet ds = new DataSet();
            string SqlStr = string.Format("select * from Treatments where Idtreatment={0}", w.Id);
            ds = ReturnDS(SqlStr);
            return ds;
        }


    }
}
