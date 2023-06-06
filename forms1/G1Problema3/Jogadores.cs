using System;
using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing;
using System.Security.Cryptography;
using static System.Formats.Asn1.AsnWriter;
using forms1;

namespace G1Problema3
{
    public partial class Jogadores : Form
    {
        String a = "Data Source = " + AppData.DB_STRING + "; " + "Initial Catalog = " + AppData.username + "; uid = " + AppData.username + "; " + "password = " + AppData.password;

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
            listView1.Columns.Add("Balance", 100, HorizontalAlignment.Left);
            listView1.View = View.Details;

            listView2.Columns.Add("Name", 200);
            listView2.View = View.Details;

            listView3.Columns.Add("Name", 110);
            listView3.Columns.Add("Descrição", 100, HorizontalAlignment.Left);
            listView3.View = View.Details;
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
                            if (string.IsNullOrEmpty(textBox1.Text))
                            {
                            // A TextBox está vazia
                            //MessageBox.Show("A TextBox está vazia");
                                

                                listView1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                        }
                            
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
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Limpar a lista atual
            listView1.Items.Clear();

            // Determinar a coluna clicada
            string coluna = "";

            switch (e.Column)
            {
                case 0:
                    coluna = "ID";
                    break;
                case 1:
                    coluna = "Name";
                    break;
                case 2:
                    coluna = "Region";
                    break;
                case 3:
                    coluna = "Nick";
                    break;
            }

            // Montar a consulta SQL com a ordenação adequada
            string consultaSQL = $"SELECT * FROM Projeto_jogador ORDER BY {coluna}";
            SqlConnection CN = new SqlConnection(a);
            // Executar a consulta SQL
            SqlCommand sqlcmd = new SqlCommand(consultaSQL, CN);
            da = new SqlDataAdapter(sqlcmd);
            ds = new DataSet();
            da.Fill(ds, "Form1");
            dt = ds.Tables["Form1"];

            // Preencher a listView1 com os resultados
            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listView1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
            }
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];

                string column1Value = selectedItem.SubItems[0].Text;

                SqlConnection CN = new SqlConnection(a);     
                         

                try
                {
                    CN.Open();
                    if (CN.State == ConnectionState.Open)
                    {
                        if (listView1.SelectedItems.Count > 0)
                        {
                            listView2.Items.Clear();
                            listView3.Items.Clear();


                            // Definir largura da primeira coluna para 100 pixels

                            string nick = listView1.SelectedItems[0].SubItems[3].Text;

                            // Executar a query com o valor do nick
                            SqlCommand query = new SqlCommand("SELECT nome_personagem FROM obter_nome_personagem('" + nick + "');",CN);

                            // Resto do código para executar a query e processar os resultados
                            da = new SqlDataAdapter(query);
                            ds = new DataSet();
                            da.Fill(ds, "Form1");
                            dt = ds.Tables["Form1"];
                            int i;
                            for (i = 0; i <= dt.Rows.Count - 1; i++)
                            {
                                listView2.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                                
                            }
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

                SqlConnection CN = new SqlConnection(a);

                try
                {
                    CN.Open();
                    if (CN.State == ConnectionState.Open)
                    {


                        if (listView1.SelectedItems.Count > 0)
                        {
                            listView3.Items.Clear();

                            // Definir largura da primeira coluna para 100 pixels

                            string personagem = listView2.SelectedItems[0].SubItems[0].Text;

                            // Executar a query com o valor do nick
                            SqlCommand query = new SqlCommand("SELECT habilidade_nome, habilidade_descricao FROM obter_habilidades_personagem('" + personagem + "');", CN);

                            // Resto do código para executar a query e processar os resultados
                            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                            da = sqlDataAdapter;
                            ds = new DataSet();
                            da.Fill(ds, "Form1");
                            dt = ds.Tables["Form1"];
                            int i;
                            for (i = 0; i <= dt.Rows.Count - 1; i++)
                            {
                                listView3.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                                listView3.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());

                            }
                            //listView2.Columns[0].Width = 200;
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
            textBox1.Clear();
            SqlConnection CN = new SqlConnection(a);
            var content = getTableContent(CN);

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String nick = textBox1.Text;
            SqlConnection CN = new SqlConnection(a);

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                        try
                        {
                            SqlCommand query = new SqlCommand("SELECT id, name, region, nick FROM Projeto_jogador WITH(INDEX(idx_Projeto_jogador_nick)) WHERE nick = @nick", CN);
                            query.Parameters.AddWithValue("@nick", nick);

                            SqlDataAdapter da = new SqlDataAdapter(query);
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow row in dt.Rows)
                                {
                                    string jogadorId = row["id"].ToString();
                                    string jogadorName = row["name"].ToString();
                                    string jogadorRegion = row["region"].ToString();
                                    string jogadorNick = row["nick"].ToString();

                                    ListViewItem item = new ListViewItem(jogadorId);
                                    item.SubItems.Add(jogadorName);
                                    item.SubItems.Add(jogadorRegion);
                                    item.SubItems.Add(jogadorNick);
                                    listView1.Items.Clear();
                                    listView1.Items.Add(item);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Jogador não encontrado.");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Jogador não encontrado");
                        }
                    // Mudar na linha anterior o nome da table "Hello" para outro nome que esteja na bd
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open connection to database due to the error \r\n" + ex.Message, "Connection Error", MessageBoxButtons.OK);
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
        }


    }
}