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

namespace forms1
{
    public partial class AddTransacao : Form
    {
        String a = "Data Source = " + AppData.DB_STRING + "; " + "Initial Catalog = " + AppData.username + "; uid = " + AppData.username + "; " + "password = " + AppData.password;

        public AddTransacao()
        {
            InitializeComponent();
            comboBox1.Items.Add("Purchase");
            comboBox1.Items.Add("Withdrawal");
            comboBox1.Items.Add("Deposit");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                string nick = textBox2.Text;
                int valor = int.Parse(textBox1.Text);
                string tipoTransacao = comboBox1.SelectedItem.ToString();

                // Verificar se o nick, valor e tipo de transação são válidos antes de prosseguir

                if (string.IsNullOrWhiteSpace(nick) || valor <= 0 || string.IsNullOrWhiteSpace(tipoTransacao))
                {
                    MessageBox.Show("Preencha todos os campos corretamente");
                    return;
                }

                try
                {
                    // Conectar ao banco de dados e criar o comando SQL para obter o ID do jogador
                    using (SqlConnection connection = new SqlConnection(a))
                    {
                        connection.Open();

                    // Criar o comando SQL para obter o ID do jogador
                        SqlCommand command = new SqlCommand("SELECT id FROM Projeto_jogador WHERE nick = @nick", connection);
                        command.Parameters.AddWithValue("@nick", nick);

                        // Executar o comando SQL e obter o ID do jogador
                        int idJogador = (int)command.ExecuteScalar();

                        // Verificar se o jogador com o nick fornecido existe
                        if (idJogador == 0)
                        {
                            MessageBox.Show("Jogador não encontrado");
                            return;
                        }
                        if(tipoTransacao == "Purchase")
                        {
                            SqlCommand saldoCommand = new SqlCommand("SELECT balance FROM Projeto_jogador WHERE nick = @nick", connection);
                            saldoCommand.Parameters.AddWithValue("@nick", nick);

                            decimal saldoAtual = Convert.ToDecimal(saldoCommand.ExecuteScalar());

                            if (saldoAtual >= valor)
                            {
                                // Atualizar o saldo do jogador
                                decimal novoSaldo = saldoAtual - valor;
                                SqlCommand atualizarSaldoCommand = new SqlCommand("UPDATE Projeto_jogador SET balance = @novoSaldo WHERE nick = @nick", connection);
                                atualizarSaldoCommand.Parameters.AddWithValue("@novoSaldo", novoSaldo);
                                atualizarSaldoCommand.Parameters.AddWithValue("@nick", nick);
                                atualizarSaldoCommand.ExecuteNonQuery();

                                // Inserir a transação na tabela Projeto_transactions
                                SqlCommand inserirTransacaoCommand = new SqlCommand("INSERT INTO Projeto_transactions (type, date, value, id_jogador) VALUES (@tipoTransacao, GETDATE(), @valor, @id_jogador)", connection);
                                inserirTransacaoCommand.Parameters.AddWithValue("@tipoTransacao", tipoTransacao);
                                inserirTransacaoCommand.Parameters.AddWithValue("@valor", valor);
                                inserirTransacaoCommand.Parameters.AddWithValue("@id_jogador", idJogador);
                                inserirTransacaoCommand.ExecuteNonQuery();

                                MessageBox.Show("Transação adicionada com sucesso!");
                            }
                            else
                            {
                                MessageBox.Show("Saldo insuficiente para realizar a transação.");
                            }
                        }
                        else if(tipoTransacao == "Deposit")
                        {
                            
                            // Criar o comando SQL para adicionar a transação
                            command = new SqlCommand("INSERT INTO Projeto_transactions (id_jogador, type, date, value) " +
                                                     "VALUES (@idJogador, @tipoTransacao, GETDATE(), @valor)", connection);
                            command.Parameters.AddWithValue("@idJogador", idJogador);
                            command.Parameters.AddWithValue("@tipoTransacao", tipoTransacao);
                            command.Parameters.AddWithValue("@valor", valor);

                            command.ExecuteNonQuery();



                            command = new SqlCommand("UPDATE Projeto_jogador SET balance = balance + @valor WHERE id = @idJogador", connection);
                            command.Parameters.AddWithValue("@idJogador", idJogador);
                            command.Parameters.AddWithValue("@valor", valor);

                            // Executar o comando SQL
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Transação adicionada com sucesso");
                            }
                            else
                            {
                                MessageBox.Show("Falha ao adicionar a transação");
                            }
                        }else if(tipoTransacao == "Withdrawal")
                        {
                            SqlCommand saldoCommand = new SqlCommand("SELECT balance FROM Projeto_jogador WHERE nick = @nick", connection);
                            saldoCommand.Parameters.AddWithValue("@nick", nick);

                            decimal saldoAtual = Convert.ToDecimal(saldoCommand.ExecuteScalar());

                            if (saldoAtual >= valor)
                            {
                                // Atualizar o saldo do jogador
                                decimal novoSaldo = saldoAtual - valor;
                                SqlCommand atualizarSaldoCommand = new SqlCommand("UPDATE Projeto_jogador SET balance = @novoSaldo WHERE nick = @nick", connection);
                                atualizarSaldoCommand.Parameters.AddWithValue("@novoSaldo", novoSaldo);
                                atualizarSaldoCommand.Parameters.AddWithValue("@nick", nick);
                                atualizarSaldoCommand.ExecuteNonQuery();

                                // Inserir a transação na tabela Projeto_transactions
                                SqlCommand inserirTransacaoCommand = new SqlCommand("INSERT INTO Projeto_transactions (type, date, value, id_jogador) VALUES (@tipoTransacao, GETDATE(), @valor, @id_jogador)", connection);
                                inserirTransacaoCommand.Parameters.AddWithValue("@tipoTransacao", tipoTransacao);
                                inserirTransacaoCommand.Parameters.AddWithValue("@valor", valor);
                                inserirTransacaoCommand.Parameters.AddWithValue("@id_jogador", idJogador);
                                inserirTransacaoCommand.ExecuteNonQuery();

                                MessageBox.Show("Transação adicionada com sucesso!");
                            }
                            else
                            {
                                MessageBox.Show("Saldo insuficiente para realizar a transação.");
                            }
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar a transação: " + ex.Message);
                }
            

        }
    }
}
