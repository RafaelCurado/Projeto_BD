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
    public partial class AddTreinadores : Form
    {
        String a = "Data Source = " + AppData.DB_STRING + "; " + "Initial Catalog = " + AppData.username + "; uid = " + AppData.username + "; " + "password = " + AppData.password;

        public AddTreinadores()
        {
            InitializeComponent();
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

                    
                    

                        SqlCommand sqlcmd = new SqlCommand("insert into [Projeto_treinador] (name,region) values(\'" + name + "\', \'" + region + "\');", CN);
                        //SqlCommand sqlcmd = new SqlCommand("SET IDENTITY_INSERT Projeto_jogador ON insert into [Projeto_jogador] (id, name,region,nick,personagem_name) values(14, 'pedro', 'guarda', 'zezoca', 'Personagem 2');", CN);
                        //sqlcmd.ExecuteNonQuery();

                        int result = sqlcmd.ExecuteNonQuery();



                        MessageBox.Show("Treinador adicionado com sucesso");
                        this.Hide();



                    
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

        private void AddTreinadores_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection CN = new SqlConnection(a);
            var content = getTableContent(CN);
        }
    }
}
