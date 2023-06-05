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
    public partial class Jogos : Form
    {
        String a = "Data Source = mednat.ieeta.pt\\SQLSERVER,8101; Initial Catalog = p1g1; uid = p1g1; password = apexlol";
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;

        private string id_torneio;
        public Jogos(String valor)
        {
            InitializeComponent();
            id_torneio= valor;
            SqlConnection CN = new SqlConnection(a);
            var content = getTableContent(CN);

            listView1.Columns.Add("ID_Jogo", 120);
            listView1.Columns.Add("Equipa 1", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("Equipa 2", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("ID_Torneio", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("Data", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("Resultado", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("Duração", 120, HorizontalAlignment.Left);
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

                    SqlCommand sqlcmd = new SqlCommand("SELECT * FROM Projeto_jogo", CN);

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
                        listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                        listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                        listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                        listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];

                string column1Value = selectedItem.SubItems[1].Text; // ID da equipa 1
                string column2Value = selectedItem.SubItems[2].Text; // ID da equipa 2

                Equipas form = new Equipas(column1Value, column2Value);
                form.Show();
                this.Hide();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Torneio form = new Torneio();
            form.Show();
            this.Hide();
        }

        private void Jogos_Load(object sender, EventArgs e)
        {

        }
    }
}
