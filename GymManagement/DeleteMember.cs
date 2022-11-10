using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagement
{
    public partial class DeleteMember : Form
    {
        public DeleteMember()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will delete your data, Confirm?", "Delete Data", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-UA2OV4B\SQLEXPRESS;Initial Catalog=gym;Integrated Security=True");
                    conn.Open();
                    string query = "delete from NewMember where MID= " + textBox1.Text + "";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    
                    //dataGridView1.AutoGenerateColumns = false;

                    dataGridView1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                this.Activate();
                try
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-UA2OV4B\SQLEXPRESS;Initial Catalog=gym;Integrated Security=True");
                    conn.Open();
                    string query = "select * from NewMember";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    dataGridView1.DataSource = dt;
                    //dataGridView1.AutoGenerateColumns = false;

                    dataGridView1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void DeleteMember_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-UA2OV4B\SQLEXPRESS;Initial Catalog=gym;Integrated Security=True");
                conn.Open();
                string query = "select * from NewMember";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                //dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
