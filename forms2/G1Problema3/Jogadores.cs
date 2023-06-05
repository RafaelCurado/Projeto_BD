using System;
using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing;
using System.Security.Cryptography;

namespace G1Problema3
{
    public partial class Jogadores : Form
    {
        String a = "Data Source = mednat.ieeta.pt\\SQLSERVER,8101; Initial Catalog = p1g1; uid = p1g1; password = apexlol";
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;
        public Jogadores()
        {
            InitializeComponent();
            SqlConnection CN = new SqlConnection(a);
            var content = getTableContent(CN);

            listView1.Columns.Add("ID", 30);
            listView1.Columns.Add("Name", 140, HorizontalAlignment.Left);
            listView1.Columns.Add("Region", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Nick", 100, HorizontalAlignment.Left);
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
                        
                        SqlCommand sqlcmd = new SqlCommand("SELECT * FROM Projeto_jogador", CN);
                        
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
            

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddJogadores form = new AddJogadores();
            form.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];

                string column1Value = selectedItem.SubItems[0].Text;

                SqlConnection CN = new SqlConnection(a);

                listView2.Columns.Add("Name", 110);
                listView2.Columns.Add("Habilidade 1", 100, HorizontalAlignment.Left);
                listView2.Columns.Add("Habilidade 2", 100, HorizontalAlignment.Left);
                listView2.Columns.Add("Habilidade 3", 100, HorizontalAlignment.Left);
                listView2.View = View.Details;

                try
                {
                    CN.Open();
                    if (CN.State == ConnectionState.Open)
                    {

                        SqlCommand sqlcmd = new SqlCommand("SELECT * FROM Projeto_personagem", CN);

                        da = new SqlDataAdapter(sqlcmd);
                        ds = new DataSet();
                        da.Fill(ds, "Form1");
                        dt = ds.Tables["Form1"];
                        int i;
                        for (i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            listView2.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                            listView2.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                            listView2.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                            listView2.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to open connection to database due to the error \r\n" + ex.Message, "Connection Error", MessageBoxButtons.OK);
                }

                if (CN.State == ConnectionState.Open)
                    CN.Close();

                // Faça o processamento desejado com os valores da linha selecionada
                // ...
            }

        }



        private void button2_Click(object sender, EventArgs e)
        {
            RemoveJogadores form = new RemoveJogadores();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu form = new Menu();
            form.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];

                string column1Value = selectedItem.SubItems[0].Text;
                //string column2Value = selectedItem.SubItems[1].Text;
                //string column3Value = selectedItem.SubItems[2].Text;
                //string column4Value = selectedItem.SubItems[3].Text;

                SqlConnection CN = new SqlConnection(a);

                listView3.Columns.Add("Name", 110);
                listView3.Columns.Add("Descrição", 100, HorizontalAlignment.Left);
                listView3.View = View.Details;

                try
                {
                    CN.Open();
                    if (CN.State == ConnectionState.Open)
                    {

                        SqlCommand sqlcmd = new SqlCommand("SELECT * FROM Projeto_habilidade", CN);

                        da = new SqlDataAdapter(sqlcmd);
                        ds = new DataSet();
                        da.Fill(ds, "Form1");
                        dt = ds.Tables["Form1"];
                        int i;
                        for (i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            listView3.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                            listView3.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to open connection to database due to the error \r\n" + ex.Message, "Connection Error", MessageBoxButtons.OK);
                }

                if (CN.State == ConnectionState.Open)
                    CN.Close();

                // Faça o processamento desejado com os valores da linha selecionada
                // ...
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            SqlConnection CN = new SqlConnection(a);
            var content = getTableContent(CN);

        }
    }
}