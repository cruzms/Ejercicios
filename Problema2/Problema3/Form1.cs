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

namespace Problema3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox3.Text)){
                MessageBox.Show("Aerolina obligatorio");
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-CP9SEGOO\SQLEXPRESS;Initial Catalog=Problema2.Models+ModelContext;Integrated Security=True");
                con.Open();
                string q = "Select * from Markets where Aerolinea = '" + textBox3.Text+"'";
                if (!String.IsNullOrEmpty(textBox1.Text))
                {
                    q += "AND OriginName = '"+ textBox1.Text + "'";
                }
                if (!String.IsNullOrEmpty(textBox2.Text))
                {
                    q += "AND DestinationName = '" + textBox2.Text + "'";
                }
                if (checkBox1.Checked)
                {
                    int result = DateTime.Compare(dateTimePicker1.Value, dateTimePicker2.Value);
                    if(result < 0)
                    {
                        q += "AND Date between '" + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "' and '" + dateTimePicker2.Value.ToString("dd/MM/yyyy") + "'";
                    }
                    else
                    {
                        MessageBox.Show("Fechas incorrectas");
                        return;
                    }
                }
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = reader.GetString(5);
                    dataGridView1.Rows[n].Cells[1].Value = reader.GetString(6);
                    dataGridView1.Rows[n].Cells[2].Value = reader.GetString(2);

                }
                con.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
