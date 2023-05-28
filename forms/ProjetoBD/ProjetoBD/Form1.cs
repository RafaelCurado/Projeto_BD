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

namespace ProjetoBD
{
    public partial class Form1 : Form
    {

        private SqlConnection cn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data source= .\\SQLEXPRESS;integrated security=true;initial catalog=ProjetoBD");
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("boas");

            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Projeto_jogador", cn);
            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Player P = new Player();
                P.PlayerID = reader["id"].ToString();   
                P.PlayerName= reader["name"].ToString();
                P.PlayerRegion = reader["region"].ToString();
                MessageBox.Show(P.ToString());
            }
             
            cn.Close();
        }
    }
}
