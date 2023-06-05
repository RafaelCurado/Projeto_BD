using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class AddJogadores : Form
    {
        String a = "Data Source = mednat.ieeta.pt\\SQLSERVER,8101; Initial Catalog = p1g1; uid = p1g1; password = apexlol";

        public AddJogadores()
        {
            InitializeComponent();
        }


        private string getTableContent(SqlConnection CN)
        {
            string name = textBox1.Text;
            String region = textBox2.Text;
            String nick = textBox3.Text;
            string personagem = "Personagem 1";
            int score = 1000;



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
                    else {

                        //SqlCommand sqlcmd = new SqlCommand("insert into [Projeto_jogador] (name,region,nick,personagem_name) values(\'" + name + "\', \'" + region + "\', \'" + nick + "\', 'Personagem 3');", CN);
                        //SqlCommand sqlcmd = new SqlCommand("SET IDENTITY_INSERT Projeto_jogador ON insert into [Projeto_jogador] (id, name,region,nick,personagem_name) values(14, 'pedro', 'guarda', 'zezoca', 'Personagem 2');", CN);
                        //sqlcmd.ExecuteNonQuery();

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = CN;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                        cmd.Parameters.Add("@region", SqlDbType.VarChar).Value = region;
                        cmd.Parameters.Add("@nick", SqlDbType.VarChar).Value = nick;
                        cmd.Parameters.Add("@personagem_name", SqlDbType.VarChar).Value = personagem;
                        cmd.Parameters.Add("@score", SqlDbType.Int).Value = score;

                        cmd.CommandText = "sp_add_jogador";

                        int result = cmd.ExecuteNonQuery();



                        MessageBox.Show("Jogador adicionado com sucesso");
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection(a);
            var content = getTableContent(CN);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
