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

namespace forms1
{
    public partial class RemoverTreinadores : Form
    {
        String a = "Data Source = mednat.ieeta.pt\\SQLSERVER,8101; Initial Catalog = p1g1; uid = p1g1; password = apexlol";

        public RemoverTreinadores()
        {
            InitializeComponent();
        }

        private string getTableContent(SqlConnection CN)
        {

            string nick = textBox1.Text;


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
                            DECLARE @treinadorId INT = 0; 
                            BEGIN TRANSACTION; 
                            BEGIN TRY 
                                SET @treinadorId = (SELECT id FROM Projeto_treinador WHERE name = 'introduzir_nome'); 
                                DELETE FROM Projeto_jogo 
		                        WHERE  id_equipa1 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_treinador = @treinadorId) 
                                    OR id_equipa2 IN (SELECT id_equipa FROM Projeto_equipa WHERE id_treinador = @treinadorId) 
                                DELETE FROM Projeto_equipa WHERE id_treinador = @treinadorId; 
                                DELETE FROM Projeto_treinador WHERE id = @treinadorId; 
                                COMMIT; 
                            END TRY 
                            BEGIN CATCH 
                                ROLLBACK; 
                                -- Realize qualquer tratamento de erro necessário ou lance uma exceção, se desejado 
                                SELECT ERROR_MESSAGE() AS mensagem_de_erro; 
                            END CATCH; 
                        ";

                        String resultado = sqlQuery.Replace("introduzir_nome", nick);

                        //MessageBox.Show(resultado);

                        using (SqlCommand command = new SqlCommand(resultado, CN))
                        {
                            //command.Parameters.AddWithValue("@jogadorNick", nick);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                Console.WriteLine($"{rowsAffected} rows deleted.");
                                MessageBox.Show("Treinador removido com sucesso");
                            }
                            else
                            {
                                MessageBox.Show("O treinador não existe!");
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
    }
}
