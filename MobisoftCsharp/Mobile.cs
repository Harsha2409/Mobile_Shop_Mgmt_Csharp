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

namespace MobisoftCsharp
{
    public partial class Mobile : Form
    {
        public Mobile()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\afwadmin\Documents\MobiSoftDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void populate()
        {
            Con.Open();
            String query = "select * from MobileTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            MobileDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(Mobidtb.Text=="" || brandtb.Text == "" || modeltb.Text == "" || pricetb.Text == "" || stocktb.Text =="" || cameratb.Text =="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "insert into MobileTbl values("+Mobidtb.Text+",'"+brandtb.Text+"','"+modeltb.Text+"',"+pricetb.Text+","+stocktb.Text+","+ramcb.SelectedItem.ToString()+","+romcb.SelectedItem.ToString()+","+cameratb.Text+")";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile Added Successfully");
                    Con.Close();
                    populate();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Mobile_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void MobileDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Mobidtb.Text = MobileDGV.SelectedRows[0].Cells[0].Value.ToString();
            brandtb.Text = MobileDGV.SelectedRows[0].Cells[1].Value.ToString();
            modeltb.Text = MobileDGV.SelectedRows[0].Cells[2].Value.ToString();
            pricetb.Text = MobileDGV.SelectedRows[0].Cells[3].Value.ToString();
            stocktb.Text = MobileDGV.SelectedRows[0].Cells[4].Value.ToString();
            ramcb.SelectedItem = MobileDGV.SelectedRows[0].Cells[5].Value.ToString();
            romcb.SelectedItem = MobileDGV.SelectedRows[0].Cells[6].Value.ToString();
            cameratb.Text = MobileDGV.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Mobidtb.Text = "";
            brandtb.Text = "";
            modeltb.Text = "";
            pricetb.Text = "";
            stocktb.Text = "";
            cameratb.Text = "";
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if(Mobidtb.Text == "")
            {
                MessageBox.Show("Enter The mobile to Be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from MobileTbl where MobId=" + Mobidtb.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile Deleted");
                    Con.Close();
                    populate();
                }catch(Exception Ex)
                {

                }
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (Mobidtb.Text == "" || brandtb.Text == "" || modeltb.Text == "" || pricetb.Text == "" || stocktb.Text == "" || cameratb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "update MobileTbl set Mbrand='"+brandtb.Text+"', MModel='"+modeltb.Text+"',MPrice="+pricetb.Text+",Mstock="+stocktb.Text+",MRam="+ramcb.SelectedItem.ToString()+",MRom="+romcb.SelectedItem.ToString()+",MCam="+cameratb.Text+" where MobId="+Mobidtb.Text+";";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mobile Updated Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {

            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
