using forms1;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
        String a = "Data Source = " + AppData.DB_STRING + "; " + "Initial Catalog = " + AppData.username + "; uid = " + AppData.username + "; " + "password = " + AppData.password;

        public AddJogadores()
        {
            InitializeComponent();
            using (SqlConnection connection = new SqlConnection(a))
            {
                string query = "SELECT name FROM Projeto_personagem";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["name"].ToString());
                }

                reader.Close();
            }
            comboBox2.Items.Add("PC");
            comboBox2.Items.Add("PS4");
            comboBox2.Items.Add("Xbox");

            comboBox3.Items.Add("English");
            comboBox3.Items.Add("Spanish");
            comboBox3.Items.Add("French");
            comboBox3.Items.Add("German");
            comboBox3.Items.Add("Italian");
        }


        private string getTableContent(SqlConnection CN)
        {
            string name = textBox1.Text;
            String region = textBox2.Text;
            String nick = textBox3.Text;
            string personagem = comboBox1.Text;
            string platform = comboBox2.Text;
            string language = comboBox3.Text;
            int score = 1000;



            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    if (name == "")
                    {
                        MessageBox.Show("Invalid Name");
                    }
                    else {

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

                        using (SqlConnection connection = new SqlConnection(a))
                        {
                            string query = "SELECT MAX(id) FROM Projeto_jogador";

                            SqlCommand co = new SqlCommand(query, connection);
                            connection.Open();

                            int maxID = Convert.ToInt32(co.ExecuteScalar());

                            SqlCommand command = new SqlCommand("insert into [Projeto_settings] (id_jogador,language,platform) values(\'" + maxID + "\',\'" + language + "\', \'" + platform + "\');", CN);
                            int result2 = command.ExecuteNonQuery();

                            // Use o valor maxID conforme necessário
                        }


                        



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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true; // Ignore the space character
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
