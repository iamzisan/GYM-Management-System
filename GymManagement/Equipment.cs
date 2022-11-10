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
    public partial class Equipment : Form
    {
        public Equipment()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String EquipName = txtEquipmentName.Text;
            String Description = txtDescription.Text;
            String MUsed = txtMusclesUsed.Text;
            String DDate = dateTimePickerDeliveryDate.Text;
            Int64 cost = Int64.Parse(txtCost.Text);

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-UA2OV4B\SQLEXPRESS;Initial Catalog=gym;Integrated Security=True");
                conn.Open();



                String query = "insert into Equipment(EquipName,EDescription,MUsed,Cost,DDate) VALUES('" + EquipName + "', '" + Description + "', '" + MUsed + "', '" + cost + "', '" + DDate + "')";


                SqlCommand cmd = new SqlCommand(query, conn);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    MessageBox.Show("New Equipment requested successfully");
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
            txtEquipmentName.Clear();
            txtDescription.Clear();
            txtMusclesUsed.Clear();
            txtCost.Clear();
            dateTimePickerDeliveryDate.Value = DateTime.Now;

        }

        private void btnViewEq_Click(object sender, EventArgs e)
        {
            ViewEquipment ve = new ViewEquipment();
            ve.Show();
        }
    }
}
