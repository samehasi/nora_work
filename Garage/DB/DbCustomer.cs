using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class DbCustomer
    {
        private SqlConnection cnn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DataSet ds = new DataSet();

        public DbCustomer()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\Garage.MDF";
            cnn.ConnectionString = string.Format(@"Data Source=.\SQLExpress;Integrated Security=true; 
                                  AttachDbFilename={0};User Instance=true", path);
        }
        public DataSet GetAllCustomer()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "select * from Clients";
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

        public DataTable GetAllCustomer1()
        {
            DataTable dt = new DataTable("Customer");
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "select * from Clients";
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



        public DataSet SearchCustomerById(int IdCustomer)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = string.Format("select * from Customer where IdCustomer={0}", IdCustomer);
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



        public void InsertCustomer(Customer c)
        {
            string sqlstr = "insert into Customer(IdCustomer,FirstName,LastName,City,Street,Picture1,Date,DateStart,DateEnd,Age,pelephoneNumber,idCoach)values(@IdCustomer,@FirstName,@LastName,@City,@Street,@Picture1,@Date,@DateStart,@DateEnd,@Age,@pelephoneNumber,@idCoach)";  
            InsDelUpd(sqlstr, c);
        }

        
       
        public void DeleteCustomer(Customer c)
        {
            string SqlStr = string.Format("delete  from Customer where IdCustomer={0}", c.idCustomer);
            
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

        public void UpdateCustomer(Customer c)
        {
             string sqlstr;
            if (c.picture!=null)
                sqlstr = "update Customer  set FirstName=@FirstName,LastName=@LastName,City=@City,Street=@Street,Picture1=@Picture1,Date=@Date,DateStart=@DateStart,DateEnd=@DateEnd,Age=@Age,PelephoneNumber=@PelephoneNumber,idcoach=@idcoach where IdCustomer=@IdCustomer";
            else
                sqlstr = "update Customer  set FirstName=@FirstName,LastName=@LastName,City=@City,Street=@Street,Date=@Date,DateStart=@DateStart,DateEnd=@DateEnd,Age=@Age,PelephoneNumber=@PelephoneNumber,idcoach=@idcoach where IdCustomer=@IdCustomer";

            InsDelUpd(sqlstr,c);
        }
        public bool Found(int IdCustomer)
        {
            DataSet ds = new DataSet();
            string str = string.Format("select * from customer where idcustomer={0} ", IdCustomer);
            ds = ReturnDS(str);
            if (ds.Tables[0].Rows.Count == 0)
                return false;
            else
                return true;
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
        public void InsDelUpd(string SqlStr,Customer c)
        {

            SqlCommand cmd = new SqlCommand();
            try
            {

                //Initialize SqlCommand object for insert.
                SqlCommand SqlCom = new SqlCommand(SqlStr, cnn);

                //We are passing Original Image Path and Image byte data as sql parameters.
                SqlCom.Parameters.Add(new SqlParameter("@IdCustomer", (object)c.idCustomer));
                SqlCom.Parameters.Add(new SqlParameter("@FirstName", (object)c.firstName));
                SqlCom.Parameters.Add(new SqlParameter("@LastName", (object)c.lastname));
                SqlCom.Parameters.Add(new SqlParameter("@City", (object)c.city));
                SqlCom.Parameters.Add(new SqlParameter("@Street", (object)c.street));
                SqlCom.Parameters.Add(new SqlParameter("@Date", (object)c.date));
                SqlCom.Parameters.Add(new SqlParameter("@DateStart", (object)c.dateStart));
                SqlCom.Parameters.Add(new SqlParameter("@DateEnd", (object)c.dateEnd));
                SqlCom.Parameters.Add(new SqlParameter("@Age", (object)c.age));
                SqlCom.Parameters.Add(new SqlParameter("@PelephoneNumber", (object)c.pelephoneNumber));
                SqlCom.Parameters.Add(new SqlParameter("@idcoach", (object)c.IdCoach));
                if (c.picture!=null)
                {
                    SqlCom.Parameters.Add(new SqlParameter("@picture1", (object)c.picture));
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

