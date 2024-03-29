﻿using forms1;
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
    public partial class Settings : Form
    {
        String a = "Data Source = " + AppData.DB_STRING + "; " + "Initial Catalog = " + AppData.username + "; uid = " + AppData.username + "; " + "password = " + AppData.password;
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;

        public Settings()
        {
            InitializeComponent();
            SqlConnection CN = new SqlConnection(a);
            var content = getTableContent(CN);

            listView1.Columns.Add("Nick", 80);
            listView1.Columns.Add("Language", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("Platform", 80, HorizontalAlignment.Left);
            listView1.View = View.Details;
        }

        private string getTableContent(SqlConnection CN)
        {
            string str = "";

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {

                    SqlCommand sqlcmd = new SqlCommand("SELECT j.nick, s.language, s.platform\r\nFROM settings_view s\r\nJOIN Projeto_jogador j ON j.id = s.id_jogador;\r\n", CN);

                    da = new SqlDataAdapter(sqlcmd);
                    ds = new DataSet();
                    da.Fill(ds, "Form1");
                    dt = ds.Tables["Form1"];
                    int i;
                    for (i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        listView1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                        listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                        listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu form = new Menu();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }
    }
}
