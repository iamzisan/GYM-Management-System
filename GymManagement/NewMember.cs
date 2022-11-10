using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagement
{
    public partial class NewMember : Form
    {
        public NewMember()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String fname = txtFirstName.Text;
            String lname = txtLastName.Text;
            String gender = "";
            bool isChacked = radioButton1.Checked;

            if(isChacked)
            {
                gender = radioButton1.Text;
            }
            else
            {
                gender = radioButton2.Text;
            }
            String dob = dateTimePickerDOB.Text;
            Int64 mobile = Int64.Parse(txtMobile.Text);
            String email = txtEmail.Text;
            String joindate = dateTimePickerJoinDate.Text;
            String gymtime = comboBoxGymTime.Text;
            String address = txtAddress.Text;
            String membership = comboBoxMembership.Text;



            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-UA2OV4B\SQLEXPRESS;Initial Catalog=gym;Integrated Security=True");
                conn.Open();



                String query = "insert into NewMember (Fname,Lname,Gender,Dob,Mobile,Email,JoinDate,Gymtime,Maddress,MembershipTime) VALUES('" + fname + "', '" + lname + "', '" + gender + "', '" + dob + "', '" + mobile + "', '" + email + "', '" + joindate + "', '" + gymtime + "', '" + address + "', '" + membership + "')";
                
                
                SqlCommand cmd = new SqlCommand(query, conn);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    MessageBox.Show("User registered successfully");
                else
                {
                    MessageBox.Show("Error occured");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtMobile.Clear();
            txtEmail.Clear();
            comboBoxGymTime.ResetText();
            comboBoxMembership.ResetText();
            txtAddress.Clear();
            dateTimePickerDOB.Value = DateTime.Now;
            dateTimePickerJoinDate.Value = DateTime.Now;
             
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
