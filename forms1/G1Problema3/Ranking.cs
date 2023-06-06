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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace G1Problema3
{
    public partial class Ranking : Form
    {

        String a = "Data Source = " + AppData.DB_STRING + "; " + "Initial Catalog = " + AppData.username + "; uid = " + AppData.username + "; " + "password = " + AppData.password;
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;

        public Ranking()
        {
            InitializeComponent();
            SqlConnection CN = new SqlConnection(a);
            var content = getTableContent(CN);

            listView1.Columns.Add("Pos", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Name", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Score", 70, HorizontalAlignment.Left);
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

                    String query = "SELECT r.position, j.name, r.score\r\nFROM Projeto_ranking r\r\nJOIN Projeto_jogador j ON r.id_jogador = j.id\r\norder by score DESC";
                    SqlCommand sqlcmd = new SqlCommand("SELECT * from rank_view order by score DESC", CN);

                    da = new SqlDataAdapter(sqlcmd);
                    ds = new DataSet();
                    da.Fill(ds, "Form1");
                    dt = ds.Tables["Form1"];
                    int i;
                    for (i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = (i + 1).ToString(); // Define o número da posição na primeira coluna
                        item.SubItems.Add(dt.Rows[i].ItemArray[0].ToString()); // Adiciona o nome na segunda coluna
                        item.SubItems.Add(dt.Rows[i].ItemArray[1].ToString()); // Adiciona a pontuação na terceira coluna
                        listView1.Items.Add(item);
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu form = new Menu();
            form.Show();
            this.Hide();
        }

        private void Ranking_Load(object sender, EventArgs e)
        {

        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    SqlConnection CN = new SqlConnection(a);
        //    var content = getTableContent(CN);


        //    listView1.Columns.Add("Name", 150, HorizontalAlignment.Left);
        //    listView1.Columns.Add("Score", 70, HorizontalAlignment.Left);
        //    listView1.View = View.Details;
        //}
    }
}
