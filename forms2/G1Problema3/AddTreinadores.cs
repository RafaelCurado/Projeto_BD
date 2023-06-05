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
    public partial class AddTreinadores : Form
    {
        String a = "Data Source = mednat.ieeta.pt\\SQLSERVER,8101; Initial Catalog = p1g1; uid = p1g1; password = apexlol";

        public AddTreinadores()
        {
            InitializeComponent();
        }

        private void TestDBConnection(string dbServer, string dbName, string userName, string userPass)
        {
            //SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
            //"; uid = " + userName + ";" + "password = " + userPass);
            String a = "Data Source = mednat.ieeta.pt\\SQLSERVER,8101; Initial Catalog = p1g1; uid = p1g1; password = apexlol";
            SqlConnection CN = new SqlConnection(a);

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    MessageBox.Show("Successful connection to database " + CN.Database + " on the " + CN.DataSource + " server", "Connection Test", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open connection to database due to the error \r\n" + ex.Message, "Connection Test", MessageBoxButtons.OK);
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
        }

        private string getTableContent(SqlConnection CN)
        {
            string name = textBox1.Text;
            String region = textBox2.Text;

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    //SqlCommand cmd = new SqlCommand("select max(id) from Projeto_jogador");

                    if (name == "")
                    {
                        MessageBox.Show("Invalid Name");
                    }
                    else
                    {

                        //SqlCommand sqlcmd = new SqlCommand("insert into [Projeto_jogador] (name,region,nick,personagem_name) values(\'" + name + "\', \'" + region + "\', \'" + nick + "\', 'Personagem 3');", CN);
                        ////SqlCommand sqlcmd = new SqlCommand("SET IDENTITY_INSERT Projeto_jogador ON insert into [Projeto_jogador] (id, name,region,nick,personagem_name) values(14, 'pedro', 'guarda', 'zezoca', 'Personagem 2');", CN);
                        //sqlcmd.ExecuteNonQuery();
                        MessageBox.Show("Treinador adicionado com sucesso");
                        this.Hide();



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

            return null;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
