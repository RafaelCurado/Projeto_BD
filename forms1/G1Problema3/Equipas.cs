using forms1;
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

namespace G1Problema3
{
    public partial class Equipas : Form
    {
        private string equipa_1;
        private string equipa_2;
        String a = "Data Source = " + AppData.DB_STRING + "; " + "Initial Catalog = " + AppData.username + "; uid = " + AppData.username + "; " + "password = " + AppData.password;
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;
        public Equipas(String equipa1, String equipa2)
        {
            InitializeComponent();
            equipa_1 = equipa1;
            equipa_2 = equipa2;
            SqlConnection CN = new SqlConnection(a);
            var content = getTableContent(CN);

            listView1.Columns.Add("Nome", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("País", 150, HorizontalAlignment.Left);
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

                    SqlCommand sqlcmd = new SqlCommand("select * from Projeto_equipa", CN);

                    da = new SqlDataAdapter(sqlcmd);
                    ds = new DataSet();
                    da.Fill(ds, "Form1");
                    dt = ds.Tables["Form1"];
                    int i;
                    for (i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        listView1.Items.Add(dt.Rows[i].ItemArray[6].ToString());
                        listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[7].ToString());
                        listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[8].ToString());

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

        private void Equipas_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Jogos form = new Jogos(null);
            form.Show();
            this.Hide();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
