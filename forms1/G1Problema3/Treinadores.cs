using G1Problema3;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace forms1
{
    public partial class Treinadores : Form
    {
        String a = "Data Source = mednat.ieeta.pt\\SQLSERVER,8101; Initial Catalog = p1g1; uid = p1g1; password = apexlol";
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;
        public Treinadores()
        {
            InitializeComponent();
            SqlConnection CN = new SqlConnection(a);
            var content = getTableContent(CN);

            listView1.Columns.Add("ID", 30);
            listView1.Columns.Add("Name", 140, HorizontalAlignment.Left);
            listView1.Columns.Add("Region", 150, HorizontalAlignment.Left);
            listView1.View = View.Details;
        }

        private string getTableContent(SqlConnection CN)
        {
            string str = "";

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {

                    SqlCommand sqlcmd = new SqlCommand("SELECT * FROM Projeto_treinador", CN);

                    da = new SqlDataAdapter(sqlcmd);
                    ds = new DataSet();
                    da.Fill(ds, "Form1");
                    dt = ds.Tables["Form1"];
                    int i;
                    for (i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        listView1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                        listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                        listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open connection to database due to the error \r\n" + ex.Message, "Connection Error", MessageBoxButtons.OK);
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();

            return str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            G1Problema3.Menu form = new G1Problema3.Menu();
            form.Show();
            this.Hide();
        }

        private void Treinadores_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            SqlConnection CN = new SqlConnection(a);
            var content = getTableContent(CN);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddTreinadores form = new AddTreinadores();
            form.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            RemoverTreinadores form = new RemoverTreinadores();
            form.Show();
        }
    }
}
