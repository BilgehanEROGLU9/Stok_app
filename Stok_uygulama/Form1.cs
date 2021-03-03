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

namespace Stok_uygulama
{
    public partial class Form1 : Form
    {
        String yes = "evet";
        SqlDataAdapter adp;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
            goster();
        }
        public string conString = "Data Source=DESKTOP-BA5NEFA;Initial Catalog=stok1;Integrated Security=True";
        
        
        private SqlCommand cmd;
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "INSERT INTO StokA(stok_no,stok_isim,aktarildi)values('" + textBox1.Text.ToString() + "','" + textBox2.Text + "','" + yes +"')";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                
                
                MessageBox.Show("Stok eklendi");
                goster();
            }
        }
        public void goster()
        {
            adp = new SqlDataAdapter("select * from stokA", conString);
            dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
            

        {

        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
