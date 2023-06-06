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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace G1Problema3
{
    public partial class RemoveJogadores : Form
    {
        String a = "Data Source = " + AppData.DB_STRING + "; " + "Initial Catalog = " + AppData.username + "; uid = " + AppData.username + "; " + "password = " + AppData.password;

        public RemoveJogadores()
        {
            InitializeComponent();
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
                            DECLARE @jogadorId INT = 0; 

                            BEGIN TRANSACTION; 
                            BEGIN TRY 
                                SET @jogadorId = (SELECT id FROM Projeto_jogador WHERE nick = 'introduzir_nick'); 
                                DELETE FROM Projeto_settings WHERE id_jogador = @jogadorId; 
                                DELETE FROM Projeto_transactions WHERE id_jogador = @jogadorId; 
                                DELETE FROM Projeto_ranking WHERE id_jogador = @jogadorId; 
                                DELETE FROM Projeto_jogo WHERE id_equipa1 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador1 = @jogadorId) 
                                    OR id_equipa2 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador1 = @jogadorId) 
                                    OR id_equipa1 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador2 = @jogadorId) 
                                    OR id_equipa2 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador2 = @jogadorId) 
                                    OR id_equipa1 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador3 = @jogadorId) 
                                    OR id_equipa2 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador3 = @jogadorId) 
                                    OR id_equipa1 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador4 = @jogadorId) 
                                    OR id_equipa2 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador4 = @jogadorId) 
                                    OR id_equipa1 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador5 = @jogadorId) 
                                    OR id_equipa2 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_jogador5 = @jogadorId); 
                                DELETE FROM Projeto_equipa 
                                WHERE id_jogador1 = @jogadorId 
                                    OR id_jogador2 = @jogadorId 
                                    OR id_jogador3 = @jogadorId 
                                    OR id_jogador4 = @jogadorId 
                                    OR id_jogador5 = @jogadorId; 
                                DELETE FROM Projeto_jogador WHERE id = @jogadorId; 
                                COMMIT; 
                            END TRY 
                            BEGIN CATCH 
                                ROLLBACK; 
                                -- Realize qualquer tratamento de erro necessário ou lance uma exceção, se desejado 
                                SELECT ERROR_MESSAGE() AS mensagem_de_erro; 
                            END CATCH; 
                        ";

                        String resultado = sqlQuery.Replace("introduzir_nick", nick);

                        //MessageBox.Show(resultado);

                        using (SqlCommand command = new SqlCommand(resultado, CN))
                        {
                            //command.Parameters.AddWithValue("@jogadorNick", nick);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                Console.WriteLine($"{rowsAffected} rows deleted.");
                                MessageBox.Show("Jogador removido com sucesso");
                            }
                            else
                            {
                                MessageBox.Show("O jogador não existe!");
                            }
                        }

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

        private void RemoveJogadores_Load(object sender, EventArgs e)
        {

        }
    }

}
