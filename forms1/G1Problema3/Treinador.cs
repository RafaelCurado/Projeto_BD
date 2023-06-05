using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1Problema3
{
    public class Treinador : Form
    {
        String a = "Data Source = mednat.ieeta.pt\\SQLSERVER,8101; Initial Catalog = p1g1; uid = p1g1; password = apexlol";
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;
        private Button button5;
        private Button button3;
        private Button button2;
        private Button button4;
        private ListView listView1;

        public Treinador()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(178, 408);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(104, 37);
            this.button5.TabIndex = 28;
            this.button5.Text = "Atualizar";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 20);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 31);
            this.button3.TabIndex = 23;
            this.button3.Text = "Menu";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(302, 408);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 37);
            this.button2.TabIndex = 22;
            this.button2.Text = "Remover Treinador";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 408);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 37);
            this.button4.TabIndex = 21;
            this.button4.Text = "Adicionar Treinador";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // listView1
            // 
            this.listView1.BackgroundImageTiled = true;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(12, 105);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(438, 295);
            this.listView1.TabIndex = 20;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Treinador
            // 
            this.ClientSize = new System.Drawing.Size(946, 588);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.listView1);
            this.Name = "Treinador";
            this.Load += new System.EventHandler(this.Treinador_Load);
            this.ResumeLayout(false);

            SqlConnection CN = new SqlConnection(a);
            var content = getTableContent(CN);

            listView1.Columns.Add("ID", 30);
            listView1.Columns.Add("Name", 140, HorizontalAlignment.Left);
            listView1.Columns.Add("Region", 100, HorizontalAlignment.Left);
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

                    SqlCommand sqlcmd = new SqlCommand("SELECT * FROM Projeto_treinador", CN);

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

        private void button4_Click(object sender, EventArgs e)
        {
            AddTreinadores form = new AddTreinadores();
            form.Show();
        }

        private void Treinador_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu form = new Menu();
            form.Show();
            this.Hide();
        }
    }
}
