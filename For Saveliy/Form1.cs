using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace For_Saveliy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        void GetList()
        {
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=CashAccounting; Integrated Security=True");
            da = new SqlDataAdapter("Select *From CashAccountingTable1", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "CashAccountingTable1");
            dataGridView1.DataSource = ds.Tables["CashAccountingTable1"];
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetList();
            dataGridView1.Columns["id"].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            if (label2.Visible)
                label2.Visible = false;

            if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
                !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) &&
                !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text))
            {
                cmd.CommandText = "insert into CashAccountingTable1(Session,Description,Places,Price,Sold,Free,Cash) values " +
                "('" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "','" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox7.Text +
                "', '" + Convert.ToInt32(textBox4.Text) * Convert.ToInt32(textBox5.Text) + "')";
                cmd.ExecuteNonQuery();
            }
            else
            {
                label2.Visible = true;
                label2.Text = "Поля 'Название сеанса', 'Описание сеанса', 'Всего мест', 'Свободных мест', 'Продано билетов', 'Стоймость билета' должны быть заполнены!";
            }
            con.Close();
            GetList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Session LIKE '%{textBox1.Text}%'";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            if (label23.Visible)
                label23.Visible = false;

            if (!string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text))
            {
                cmd.CommandText = $"delete from CashAccountingTable1 where Session LIKE '%{textBox8.Text}%'";
                cmd.ExecuteNonQuery();
            }
            else
            {
                label23.Visible = true;
                label23.Text = "Поле 'Введите название сеанса' должны быть заполнены!"; 
            }
            con.Close();
            GetList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            if (label15.Visible)
                label15.Visible = false;

            if ((!string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text) &&
                !string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text) &&
                !string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrWhiteSpace(textBox11.Text) &&
                !string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox12.Text) &&
                !string.IsNullOrEmpty(textBox13.Text) && !string.IsNullOrWhiteSpace(textBox13.Text) &&
                !string.IsNullOrEmpty(textBox14.Text) && !string.IsNullOrWhiteSpace(textBox14.Text)))
            {
                cmd.CommandText = "update  CashAccountingTable1 set Description='" + textBox14.Text + "', Places='" + textBox9.Text +
                    "', Price='" + textBox10.Text + "', Sold='" + textBox13.Text + "', Free='" + textBox11.Text + "', Cash='" + Convert.ToInt32(textBox10.Text) * 
                    Convert.ToInt32(textBox13.Text) + $"' where Session LIKE '%{textBox12.Text}%'"; 
                cmd.ExecuteNonQuery();
            }
            else
            {
                label15.Visible = true;
                label15.Text = "Поля 'Название сеанса', 'Описание сеанса', 'Всего мест', 'Свободных мест', 'Продано билетов', 'Стоймость билета' должны быть заполнены!";
            }
            con.Close();
            GetList();
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
