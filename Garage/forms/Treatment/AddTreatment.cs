using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.forms.Treatment
{
    public partial class AddTreatment : Form
    {
        public AddTreatment()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddTreatment_Load(object sender, EventArgs e)
        {
            DbKindTreatments db = new DbKindTreatments();
            DataSet ds = db.GetAllKindTreatments();
            DataSet ds2 = ds.Clone();
            dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                dataGridView2.Columns.Add((DataGridViewColumn)col.Clone());
            }


            DbClients dbc = new DbClients();
            comboBox2.DisplayMember = "ClientId";
            comboBox2.ValueMember = "ClientId";
            comboBox2.DataSource = dbc.GetAllClients().Tables[0].Columns[0].Table;


            comboBox3.DisplayMember = "WorkerId";
            comboBox3.ValueMember = "WorkerId";
            DbWorker dbw = new DbWorker();
            comboBox3.DataSource = dbw.GetAllWorkers().Tables[0].Columns[0].Table;


            comboBox4.DisplayMember = "ProductCode";
            comboBox4.ValueMember = "ProductCode";
            DbCars dbca = new DbCars();
            comboBox4.DataSource = dbca.GetAllCars().Tables[0].Columns[0].Table;


            textBox9.Text = "0";
        }


        //Should add selected treatment to datagrid2
        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (r.Selected)
                {
                    DataGridViewRow r2 = (DataGridViewRow)r.Clone();
                    for (Int32 index = 0; index < r.Cells.Count; index++)
                    {
                        r2.Cells[index].Value = r.Cells[index].Value;
                    }
                    dataGridView2.Rows.Add(r2);
                    dataGridView2.Refresh();
                }
            }
            updatePrice();
        }

        //Should remove selected treatment from datagrid 2
        private void button6_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView2.Rows)
            {
                if (r.Selected)
                {
                    dataGridView2.Rows.Remove(r);
                }
            }
            updatePrice();
        }

        void updatePrice()
        {
            int sum = 0;
            foreach (DataGridViewRow r in dataGridView2.Rows)
            {
                    DataGridViewRow r2 = (DataGridViewRow)r.Clone();
                if (r.Cells[2].Value!= null)
                {
                    sum += int.Parse(r.Cells[2].Value.ToString());
                 }

            }


            textBox9.Text = string.Format("{0}",sum);


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateBoxes();
        }


        void updateBoxes()
        {
            DbClients dbc = new DbClients();
            int ClientId = int.Parse(comboBox2.Text);
            textBox6.Text = (string)dbc.GetClientInfo(ClientId).Tables[0].Rows[0]["FirstName"];
            //textBox6.Text = dbc.GetClientInfo(2).Tables[0].Columns[0].Table.ToString();
            //textBox7.Text=dbc.GetClientInfo(2).Tables[0].Columns[0].Table.ToString();

            DbCars dbca = new DbCars();
            if (comboBox4.Text != "")
            {
                int carId = int.Parse(comboBox4.Text);
                textBox4.Text = (string)dbca.getCarInfo(carId).Tables[0].Rows[0]["Kind"];
            }


            DbWorker dbw = new DbWorker();
            if (comboBox3.Text != "")
            {
                int wId = int.Parse(comboBox3.Text);
                textBox7.Text = (string)dbw.getWorkerInfo(wId).Tables[0].Rows[0]["FirstName"];
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateBoxes();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateBoxes();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DbTreatments db = new DbTreatments();
            WindowsFormsApplication1.Treatment w = new WindowsFormsApplication1.Treatment();
            try
            {
                w.Id = int.Parse(textBox1.Text);
                w.CustometId = int.Parse(comboBox2.Text);
                w.CustomerName = textBox6.Text;
                w.WorkerId = int.Parse(comboBox3.Text);
                w.WorkerName = textBox7.Text;
                w.Date = dateTimePicker2.Text;
                w.Time = "";
                w.CarId = int.Parse(comboBox4.Text);
                w.CarKind = textBox4.Text;
                w.Total = int.Parse(textBox9.Text);

            }
            catch (Exception exception)
            {
                MessageBox.Show("Invalid parameters", "Error");
                return;
            }

            if(db.TreatmentExist(w.Id))
            {
                MessageBox.Show("Treatment ID already exist , pick other ID", "Error");
                return;
            }


            db.insertTreatment(w);



            WindowsFormsApplication1.InvoiceDetails invoice = new WindowsFormsApplication1.InvoiceDetails();

            invoice.CodeTreatment = w.Id;
            invoice.InvoiceNumber = w.Id;
            invoice.ClientId = w.CustometId;
            invoice.Kind = w.CarKind;
            invoice.Price = w.Total;

            db.insertInvoice(invoice);




            MessageBox.Show("add Treatment Success");
        }
    }
}
