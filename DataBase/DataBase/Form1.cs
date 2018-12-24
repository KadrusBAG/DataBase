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

namespace DataBase
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void LoadData_products()
        {
            string query = "SELECT * FROM products ORDER BY id";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[3]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
            }

            reader.Close();

            foreach (string[] s in data) dataGridView1.Rows.Add(s);
        }
        
        private void LoadData_personal()
        {
            string query = "SELECT * FROM personal ORDER BY id";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[4]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
            }

            reader.Close();

            foreach (string[] s in data) dataGridView2.Rows.Add(s);
        }

        private void LoadData_suppliers()
        {
            string query = "SELECT * FROM suppliers ORDER BY id";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[2]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
            }

            reader.Close();

            foreach (string[] s in data) dataGridView3.Rows.Add(s);
        }
        
        private async void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kadru\source\repos\DataBase\DataBase\DB.mdf;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            LoadData_products();
            LoadData_personal();
            LoadData_suppliers();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label22.Visible)
            {
                label22.Visible = false;
            }
            if ((!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text)) &&
                (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [products] (product, quantity)VALUES(@product, @quantity)", sqlConnection);

                command.Parameters.AddWithValue("product", textBox1.Text);
                command.Parameters.AddWithValue("quantity", textBox2.Text);
                await command.ExecuteNonQueryAsync();

                dataGridView1.Rows.Clear();
                LoadData_products();
            }
            else
            {
                label22.Visible = true;
                label22.Text = "Ошибка в заполнении!";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (label23.Visible)
            {
                label23.Visible = false;
            }
            if ((!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text)) &&
                (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text)) &&
                (!string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text)))
            {
                SqlCommand command = new SqlCommand("UPDATE [products] SET [product]=@product, [quantity]=@quantity WHERE [id]=@id", sqlConnection);

                command.Parameters.AddWithValue("id", textBox5.Text);
                command.Parameters.AddWithValue("product", textBox4.Text);
                command.Parameters.AddWithValue("quantity", textBox3.Text);

                await command.ExecuteNonQueryAsync();

                dataGridView1.Rows.Clear();
                LoadData_products();
            }
            else
            {
                label23.Visible = true;
                label23.Text = "Ошибка в заполнении!";
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (label24.Visible)
            {
                label24.Visible = false;
            }
            if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [products] WHERE [id]=@id", sqlConnection);

                command.Parameters.AddWithValue("id", textBox6.Text);

                await command.ExecuteNonQueryAsync();

                dataGridView1.Rows.Clear();
                LoadData_products();
            }
            else
            {
                label24.Visible = true;
                label24.Text = "Ошибка в заполнении!";
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (label25.Visible)
            {
                label25.Visible = false;
            }
            if ((!string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text)) &&
                (!string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text)) &&
                (!string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text)))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [personal] (surname, name, patronymic)VALUES(@surname, @name, @patronymic)", sqlConnection);

                command.Parameters.AddWithValue("surname", textBox7.Text);
                command.Parameters.AddWithValue("name", textBox8.Text);
                command.Parameters.AddWithValue("patronymic", textBox9.Text);

                await command.ExecuteNonQueryAsync();

                dataGridView2.Rows.Clear();
                LoadData_personal();
            }
            else
            {
                label25.Visible = true;
                label25.Text = "Ошибка в заполнении!";
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            if (label26.Visible)
            {
                label26.Visible = false;
            }
            if ((!string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text)) &&
                (!string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrWhiteSpace(textBox11.Text)) &&
                (!string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox12.Text)) &&
                (!string.IsNullOrEmpty(textBox13.Text) && !string.IsNullOrWhiteSpace(textBox13.Text)))
            {
                SqlCommand command = new SqlCommand("UPDATE [personal] SET [surname]=@surname, [name]=@name, [patronymic]=@patronymic WHERE [id]=@id", sqlConnection);

                command.Parameters.AddWithValue("id", textBox10.Text);
                command.Parameters.AddWithValue("surname", textBox13.Text);
                command.Parameters.AddWithValue("name", textBox12.Text);
                command.Parameters.AddWithValue("patronymic", textBox11.Text);

                await command.ExecuteNonQueryAsync();

                dataGridView2.Rows.Clear();
                LoadData_personal();
            }
            else
            {
                label26.Visible = true;
                label26.Text = "Ошибка в заполнении!";
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            if (label27.Visible)
            {
                label27.Visible = false;
            }
            if (!string.IsNullOrEmpty(textBox14.Text) && !string.IsNullOrWhiteSpace(textBox14.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [personal] WHERE [id]=@id", sqlConnection);

                command.Parameters.AddWithValue("id", textBox14.Text);

                await command.ExecuteNonQueryAsync();

                dataGridView2.Rows.Clear();
                LoadData_personal();
            }
            else
            {
                label27.Visible = true;
                label27.Text = "Ошибка в заполнении!";
            }
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            if (label28.Visible)
            {
                label28.Visible = false;
            }
            if (!string.IsNullOrEmpty(textBox16.Text) && !string.IsNullOrWhiteSpace(textBox16.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [suppliers] (supplier)VALUES(@supplier)", sqlConnection);

                command.Parameters.AddWithValue("supplier", textBox16.Text);

                await command.ExecuteNonQueryAsync();

                dataGridView3.Rows.Clear();
                LoadData_suppliers();
            }
            else
            {
                label28.Visible = true;
                label28.Text = "Ошибка в заполнении!";
            }
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            if (label29.Visible)
            {
                label29.Visible = false;
            }
            if ((!string.IsNullOrEmpty(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox15.Text)) &&
                (!string.IsNullOrEmpty(textBox17.Text) && !string.IsNullOrWhiteSpace(textBox17.Text)))
            {
                SqlCommand command = new SqlCommand("UPDATE [suppliers] SET [supplier]=@supplier WHERE [id]=@id", sqlConnection);

                command.Parameters.AddWithValue("id", textBox15.Text);
                command.Parameters.AddWithValue("supplier", textBox17.Text);

                await command.ExecuteNonQueryAsync();

                dataGridView3.Rows.Clear();
                LoadData_suppliers();
            }
            else
            {
                label29.Visible = true;
                label29.Text = "Ошибка в заполнении!";
            }
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            if (label30.Visible)
            {
                label30.Visible = false;
            }
            if (!string.IsNullOrEmpty(textBox18.Text) && !string.IsNullOrWhiteSpace(textBox18.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [suppliers] WHERE [id]=@id", sqlConnection);

                command.Parameters.AddWithValue("id", textBox18.Text);

                await command.ExecuteNonQueryAsync();

                dataGridView3.Rows.Clear();
                LoadData_suppliers();
            }
            else
            {
                label30.Visible = true;
                label30.Text = "Ошибка в заполнении!";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (label31.Visible)
            {
                label31.Visible = false;
            }
            if (!string.IsNullOrEmpty(textBox19.Text) && !string.IsNullOrWhiteSpace(textBox19.Text))
            {
                string equal = textBox19.Text;

                string query = "SELECT * FROM products ORDER BY id";

                SqlCommand command = new SqlCommand(query, sqlConnection);

                SqlDataReader reader = command.ExecuteReader();

                List<string[]> data = new List<string[]>();

                while (reader.Read())
                {
                    if(reader[1].ToString() == equal)
                    {
                        data.Add(new string[3]);

                        data[data.Count - 1][0] = reader[0].ToString();
                        data[data.Count - 1][1] = reader[1].ToString();
                        data[data.Count - 1][2] = reader[2].ToString();
                    }
                }
                reader.Close();

                dataGridView1.Rows.Clear();
                foreach (string[] s in data) dataGridView1.Rows.Add(s);
            }
            else
            {
                label31.Visible = true;
                label31.Text = "Ошибка в заполнении!";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            LoadData_products();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (label33.Visible)
            {
                label33.Visible = false;
            }
            if (!string.IsNullOrEmpty(textBox20.Text) && !string.IsNullOrWhiteSpace(textBox20.Text))
            {
                string equal = textBox20.Text;

                string query = "SELECT * FROM personal ORDER BY id";

                SqlCommand command = new SqlCommand(query, sqlConnection);

                SqlDataReader reader = command.ExecuteReader();

                List<string[]> data = new List<string[]>();

                while (reader.Read())
                {
                    if (reader[1].ToString() == equal)
                    {
                        data.Add(new string[4]);

                        data[data.Count - 1][0] = reader[0].ToString();
                        data[data.Count - 1][1] = reader[1].ToString();
                        data[data.Count - 1][2] = reader[2].ToString();
                        data[data.Count - 1][3] = reader[3].ToString();
                    }
                }
                reader.Close();

                dataGridView2.Rows.Clear();
                foreach (string[] s in data) dataGridView2.Rows.Add(s);
            }
            else
            {
                label33.Visible = true;
                label33.Text = "Ошибка в заполнении!";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            LoadData_personal();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (label35.Visible)
            {
                label35.Visible = false;
            }
            if (!string.IsNullOrEmpty(textBox21.Text) && !string.IsNullOrWhiteSpace(textBox21.Text))
            {
                string equal = textBox21.Text;

                string query = "SELECT * FROM suppliers ORDER BY id";

                SqlCommand command = new SqlCommand(query, sqlConnection);

                SqlDataReader reader = command.ExecuteReader();

                List<string[]> data = new List<string[]>();

                while (reader.Read())
                {
                    if (reader[1].ToString() == equal)
                    {
                        data.Add(new string[2]);

                        data[data.Count - 1][0] = reader[0].ToString();
                        data[data.Count - 1][1] = reader[1].ToString();
                    }
                }
                reader.Close();

                dataGridView3.Rows.Clear();
                foreach (string[] s in data) dataGridView3.Rows.Add(s);
            }
            else
            {
                label35.Visible = true;
                label35.Text = "Ошибка в заполнении!";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            LoadData_suppliers();
        }
    }
}
