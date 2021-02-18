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
    public partial class Accessories : Form
    {
        public Accessories()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\afwadmin\Documents\MobiSoftDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            String query = "select * from AccessorieTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            AccessorieDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (AidTb.Text == "" || AbrandTb.Text == "" || ApriceTb.Text == "" || AmodelTb.Text == "" || AStock.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "insert into AccessorieTbl values(" + AidTb.Text + ",'" + AbrandTb.Text + "','" + AmodelTb.Text + "'," + AStock.Text + "," + ApriceTb.Text + ")";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accessorie Added Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Accessories_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            AidTb.Text = "";
            AbrandTb.Text = "";
            AmodelTb.Text = "";
            ApriceTb.Text = "";
            AStock.Text = "";

        }

        private void AccessorieDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AidTb.Text = AccessorieDGV.SelectedRows[0].Cells[0].Value.ToString();
            AbrandTb.Text = AccessorieDGV.SelectedRows[0].Cells[1].Value.ToString();
            AmodelTb.Text = AccessorieDGV.SelectedRows[0].Cells[2].Value.ToString();
            AStock.Text = AccessorieDGV.SelectedRows[0].Cells[3].Value.ToString();
            ApriceTb.Text = AccessorieDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (AidTb.Text == "")
            {
                MessageBox.Show("Enter The Accessorie to Be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from AccessorieTbl where AId=" + AidTb.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accessorie Deleted");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (AidTb.Text == "" || AbrandTb.Text == "" || AmodelTb.Text == "" || AStock.Text == "" || ApriceTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    String sql = "update AccessorieTbl set Abrand='" + AbrandTb.Text + "', AModel='" + AmodelTb.Text + "',AStock=" + AStock.Text + ",Aprice=" + ApriceTb.Text + " where AId=" + AidTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(sql, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Accessorie Updated Successfully");
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
