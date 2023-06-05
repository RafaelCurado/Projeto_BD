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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace G1Problema3
{
    public partial class RemoveJogadores : Form
    {
        String a = "Data Source = mednat.ieeta.pt\\SQLSERVER,8101; Initial Catalog = p1g1; uid = p1g1; password = apexlol";

        public RemoveJogadores()
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

            string nick = textBox3.Text;


            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    if (nick == "")
                    {
                        MessageBox.Show("Invalid Name");
                    }
                    else
                    {

                        string sqlQuery = @"
                            declare @jogadorId int = 0;
                            SET @jogadorId = (SELECT id FROM Projeto_jogador WHERE nick = 'introduzir_nick');
                            DELETE FROM Projeto_settings WHERE id_jogador = @jogadorID;

                            DELETE FROM Projeto_transactions WHERE id_jogador = @jogadorID;

                            DELETE FROM Projeto_ranking WHERE id_jogador = @jogadorID;

                            DELETE FROM Projeto_jogo WHERE id_equipa1 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador1 = @jogadorID)
                              OR id_equipa2 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador1 = @jogadorID)
                              OR id_equipa1 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador2 = @jogadorID)
                              OR id_equipa2 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador2 = @jogadorID)
                              OR id_equipa1 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador3 = @jogadorID)
                              OR id_equipa2 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador3 = @jogadorID)
                              OR id_equipa1 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador4 = @jogadorID)
                              OR id_equipa2 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador4 = @jogadorID)
                              OR id_equipa1 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador5 = @jogadorID)
                              OR id_equipa2 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador5 = @jogadorID);

                            DELETE FROM Projeto_equipa
                            WHERE id_jogador1 = @jogadorID
                               OR id_jogador2 = @jogadorID
                               OR id_jogador3 = @jogadorID
                               OR id_jogador4 = @jogadorID
                               OR id_jogador5 = @jogadorID;

                            DELETE FROM Projeto_jogador WHERE id = @jogadorID;
                        ";

                        String resultado = sqlQuery.Replace("introduzir_nick",nick);

                        //MessageBox.Show(resultado);

                        using (SqlCommand command = new SqlCommand(resultado, CN ))
                        {
                            command.Parameters.AddWithValue("@jogadorNick", nick);

                            int rowsAffected = command.ExecuteNonQuery();
                            Console.WriteLine($"{rowsAffected} rows deleted.");
                        }
                        MessageBox.Show("Jogador removido com sucesso");
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



    }

}
