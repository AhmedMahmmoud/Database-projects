using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRUD_ADo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-VUV2U09\\MSSQLSERVER2023;Initial Catalog=TestSP_DB;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            int empid= int.Parse(textBox1.Text);
            string empname = textBox2.Text,City = comboBox1.Text,Contact= textBox4.Text, sex = "";
            double age = double.Parse(textBox3.Text);
            DateTime joindate = DateTime.Parse(dateTimePicker1.Text);
            if (radioButton1.Checked == true)
            {
                sex = "Male";
            }
            else { sex = "Female"; }
            con.Open();
            SqlCommand c = new SqlCommand("exec InsertEmp_SP '" + empid + "','" + empname + "','" + City + "','" + age + "','" + sex + "','" + joindate+ "','" + Contact + "'", con);
            c.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Inserted....","Inserted");
            GetEmpList();

        }
        void GetEmpList()
        {
            SqlCommand c = new SqlCommand("exec ListEmp_SP", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource= dt;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetEmpList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Update
            int empid = int.Parse(textBox1.Text);
            string empname = textBox2.Text, City = comboBox1.Text, Contact = textBox4.Text, sex = "";
            double age = double.Parse(textBox3.Text);
            string joindate = dateTimePicker1.Text;
            if (radioButton1.Checked == true)
            {
                sex = "Male";
            }
            else { sex = "Female"; }
            con.Open();
            SqlCommand c = new SqlCommand("exec UpdateEmp_SP '" + empid + "','" + empname + "','" + City + "','" + age + "','" + sex + "','" + joindate + "','" + Contact + "'", con);
            c.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated....", "Updated");
            GetEmpList();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Delete -- just select id
            if (MessageBox.Show("Are you sure to delete?", "Delete Document", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int empid = int.Parse(textBox1.Text);

                con.Open();
                SqlCommand c = new SqlCommand("exec DeleteEmp_SP'" + empid + "'", con);
                c.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully Deleted....", "Deleted");
                GetEmpList();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Load specific employee

            int empid = int.Parse(textBox1.Text);          
            SqlCommand c = new SqlCommand("exec LoadEmp_SP'" + empid + "'", con);           
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = "";
            dateTimePicker1.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
    }
}
