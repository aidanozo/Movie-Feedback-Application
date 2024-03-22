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

namespace Aplicatie
{
    public partial class Utilizatori : Form
    {
        public Utilizatori()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Utilizatori_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Utilizatori_Shown(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-AIDA\SQLEXPRESS;Initial Catalog=Cinemania;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Utilizator", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-AIDA\SQLEXPRESS;Initial Catalog=Cinemania;Integrated Security=True"))
            {
                conn.Open();
                String username;
                String password;
                username = textBox4.Text;
                password = textBox1.Text;



                // Creează o comandă SQL pentru inserarea unui nou rând
                string insertQuery = "INSERT INTO Utilizator (username, password) VALUES (@username, @password)";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    // Setează parametrii pentru valorile de inserat
                    insertCmd.Parameters.AddWithValue("@username", username); // Poți înlocui cu datele reale
                    insertCmd.Parameters.AddWithValue("@password", password);


                    // Execută comanda de inserare
                    insertCmd.ExecuteNonQuery();
                }

                // Actualizează afișarea datelor în DataGridView
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Utilizator", conn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obține identificatorul unic al liniei selectate (de exemplu, idFilm)
                int idRegizor = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Utilizatori"].Value);

                // Deschide conexiunea la baza de date
                using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-AIDA\SQLEXPRESS;Initial Catalog=Cinemania;Integrated Security=True"))
                {
                    conn.Open();

                    // Creează comanda SQL pentru ștergerea liniei cu identificatorul specificat
                    string deleteQuery = "DELETE FROM Utilizator WHERE ID_Utilizatori = @ID_Utilizatori";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@ID_Utilizatori", idRegizor);

                        // Execută comanda de ștergere
                        deleteCmd.ExecuteNonQuery();
                    }

                    // Actualizează afișarea datelor în DataGridView
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Utilizator", conn))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dataGridView1.DataSource = dt;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Selectați o linie pentru a șterge.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                String username;
                String password;
                username = textBox2.Text;
                password = textBox3.Text;

                int idUtilizatori = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Utilizatori"].Value);

                using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-AIDA\SQLEXPRESS;Initial Catalog=Cinemania;Integrated Security=True"))
                {

                    conn.Open();

                    string updateQuery = "UPDATE Utilizator SET username = @username, password = @password WHERE ID_Utilizatori = @ID_Utilizatori";
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@ID_Utilizatori", idUtilizatori);
                        updateCmd.Parameters.AddWithValue("@username", username);
                        updateCmd.Parameters.AddWithValue("@password", password);

                        updateCmd.ExecuteNonQuery();
                    }


                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Utilizator", conn))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dataGridView1.DataSource = dt;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Selectați o linie pentru a o updata.");
            }
        }
    }
}
