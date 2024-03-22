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

namespace Aplicatie
{
    public partial class FormFilme : Form
    {

        public FormFilme()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormFilme_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        // Se afiseaza toate campurile
        private void FormFilme_Shown(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-AIDA\SQLEXPRESS;Initial Catalog=Cinemania;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Categorii", conn))
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


        // Insert pe tabela 1
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-AIDA\SQLEXPRESS;Initial Catalog=Cinemania;Integrated Security=True"))
            {
                conn.Open();
                String Denumire;
                String Popularitate;
                Popularitate = textBox1.Text;

                int AB;

                AB = Convert.ToInt32(Popularitate);

                Denumire = textBox4.Text;



                // Creează o comandă SQL pentru inserarea unui nou rând
                string insertQuery = "INSERT INTO Categorii (Denumire, Popularitate) VALUES (@Denumire, @Popularitate)";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    // Setează parametrii pentru valorile de inserat
                    insertCmd.Parameters.AddWithValue("@Denumire", Denumire); // Poți înlocui cu datele reale
                    insertCmd.Parameters.AddWithValue("@Popularitate", AB);


                    // Execută comanda de inserare
                    insertCmd.ExecuteNonQuery();
                }

                // Actualizează afișarea datelor în DataGridView
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Categorii", conn))
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        // Delete pe tabela 1
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obține identificatorul unic al liniei selectate (de exemplu, idFilm)
                int idRegizor = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Categorie"].Value);

                // Deschide conexiunea la baza de date
                using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-AIDA\SQLEXPRESS;Initial Catalog=Cinemania;Integrated Security=True"))
                {
                    conn.Open();

                    // Creează comanda SQL pentru ștergerea liniei cu identificatorul specificat
                    string deleteQuery = "DELETE FROM Categorii WHERE ID_Categorie = @ID_Categorie";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@ID_Categorie", idRegizor);

                        // Execută comanda de ștergere
                        deleteCmd.ExecuteNonQuery();
                    }

                    // Actualizează afișarea datelor în DataGridView
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Categorii", conn))
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

        private void label1_Click(object sender, EventArgs e)
        {

        }


        // Update pe tabela 1
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                String Denumire;
                String Popularitate;
                Denumire = textBox2.Text;
                Popularitate = textBox3.Text;

                int idCAtegorie = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_Categorie"].Value);

                using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-AIDA\SQLEXPRESS;Initial Catalog=Cinemania;Integrated Security=True"))
                {

                    conn.Open();

                    string updateQuery = "UPDATE Categorii SET Denumire = @Denumire, Popularitate = @Popularitate WHERE ID_Categorie = @ID_Categorie";
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@ID_Categorie", idCAtegorie);
                        updateCmd.Parameters.AddWithValue("@Denumire", Denumire);
                        updateCmd.Parameters.AddWithValue("@Popularitate", Popularitate);

                        updateCmd.ExecuteNonQuery();
                    }


                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Categorii", conn))
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        // Interogare simpla 1 - Parametru variabil
        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-AIDA\SQLEXPRESS;Initial Catalog=Cinemania;Integrated Security=True"))
            {
                conn.Open();

                String Categorie;
                Categorie = textBox5.Text;


                // Creează o comandă SQL pentru inserarea unui nou rând
                string insertQuery = "SELECT Filme.Titlu FROM Filme INNER JOIN \"Categorii Filme\" ON Filme.ID_Film = \"Categorii Filme\".ID_Film INNER JOIN Categorii ON \"Categorii Filme\".ID_Categorie = Categorii.ID_Categorie WHERE Categorii.Denumire = @Categorie;";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    // Setează parametrii pentru valorile de inserat
                    insertCmd.Parameters.AddWithValue("@Categorie", Categorie); // Poți înlocui cu datele reale

                    // Execută comanda de inserare
                    insertCmd.ExecuteNonQuery();


                    using (SqlDataAdapter sda = new SqlDataAdapter(insertCmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView2.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // Interogare simpla 2
        private void button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-AIDA\SQLEXPRESS;Initial Catalog=Cinemania;Integrated Security=True"))
            {
                conn.Open();

                string selectQuery = @"SELECT TOP 3 f.Titlu, c.Denumire
                FROM Categorii c

                INNER JOIN ""Categorii Filme"" cp
                ON c.ID_Categorie = cp.ID_Categorie

                INNER JOIN Filme f
                ON cp.ID_Film = f.ID_Film

                ORDER BY f.Anul_Lansarii DESC ";

                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView2.DataSource = dt;
                    }
                }
            }
        }

        // Interogare simpla 3
        private void button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-AIDA\SQLEXPRESS;Initial Catalog=Cinemania;Integrated Security=True"))
            {
                conn.Open();

                string selectQuery = @"SELECT f.Titlu, r.Continutul_Recenziei

                FROM Recenzii r

                INNER JOIN Filme f
                ON r.ID_Film = f.ID_Film";

                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView2.DataSource = dt;
                    }
                }
            }
        }

        // Interogare simpla 4
        private void button8_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-AIDA\SQLEXPRESS;Initial Catalog=Cinemania;Integrated Security=True"))
            {
                conn.Open();

                string selectQuery = @"SELECT 
                        Regizori.Nume, 
                        Regizori.Prenume, 
                        COUNT(Filme.ID_Film) AS NumarFilme
                    FROM 
                        Regizori
                    LEFT JOIN 
                        Filme ON Regizori.ID_Regizor = Filme.ID_Regizor
                    GROUP BY 
                        Regizori.Nume, Regizori.Prenume";

                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView2.DataSource = dt;
                    }
                }
            }

        }

        // Interogare simpla 5
        private void button7_Click(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-AIDA\SQLEXPRESS;Initial Catalog=Cinemania;Integrated Security=True"))
            {
                conn.Open();

                string selectQuery = @"SELECT TOP 1 f.Titlu
                FROM Categorii c

                INNER JOIN ""Categorii Filme"" cp
                ON c.ID_Categorie = cp.ID_Categorie

                INNER JOIN Filme f
                ON cp.ID_Film = f.ID_Film

                ORDER BY c.Popularitate DESC ";

                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView2.DataSource = dt;
                    }
                }
            }


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        // Interogare simpla 6
        private void button9_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-AIDA\SQLEXPRESS;Initial Catalog=Cinemania;Integrated Security=True"))
            {
                conn.Open();

                string selectQuery = @"SELECT a.Nume, a.Prenume, af.Rol, f.Titlu

                FROM Actori a

                INNER JOIN ""Actori Filme"" af

                ON a.ID_Actor = af.ID_Actor
		
		        INNER JOIN Filme f
		
		        ON af.ID_Film = f.ID_Film";

                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView2.DataSource = dt;
                    }
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        // Interogare complexa 1 - parametru variabil
        private void button10_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-AIDA\SQLEXPRESS;Initial Catalog=Cinemania;Integrated Security=True"))
            {
                conn.Open();

                String Anul_Lansarii;
                Anul_Lansarii = textBox6.Text;


                // Creează o comandă SQL pentru inserarea unui nou rând
                string insertQuery = "SELECT f.Titlu, f.Anul_Lansarii, c.Denumire FROM Filme f JOIN \"Categorii Filme\" cf ON f.ID_Film = cf.ID_Film JOIN Categorii c ON cf.ID_Categorie = c.ID_Categorie WHERE f.ID_Film IN (SELECT ID_Film FROM Filme WHERE Anul_Lansarii > @Anul_Lansarii)";
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    // Setează parametrii pentru valorile de inserat
                    insertCmd.Parameters.AddWithValue("@Anul_Lansarii", Anul_Lansarii); // Poți înlocui cu datele reale

                    // Execută comanda de inserare
                    insertCmd.ExecuteNonQuery();


                    using (SqlDataAdapter sda = new SqlDataAdapter(insertCmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView3.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-AIDA\SQLEXPRESS;Initial Catalog=Cinemania;Integrated Security=True"))
            {
                conn.Open();

                string selectQuery = @"SELECT TOP 1 f.Titlu, c.Denumire AS Categorie, f.Rating_IMBD AS ""Rating IMBD""

                FROM Filme f

                JOIN ""Categorii Filme"" cf

                ON f.ID_Film = cf.ID_Film

                JOIN Categorii c

                ON cf.ID_Categorie = c.ID_Categorie

                ORDER BY ABS(f.Rating_IMBD - (SELECT AVG(Rating_IMBD) FROM Filme)) ASC;
                ";

                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView3.DataSource = dt;
                    }
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-AIDA\SQLEXPRESS;Initial Catalog=Cinemania;Integrated Security=True"))
            {
                conn.Open();

                string selectQuery = @"SELECT s.Nume, s.Anul_Fondarii AS ""Anul Fodarii"", s.Sediul_Central AS ""Sediul Central""

		        FROM Studiouri s

		        JOIN Filme f

		        ON s.ID_Studio = f.ID_Studio

		        WHERE ID_Film 

		        IN (SELECT ID_Film FROM Filme WHERE Buget > 15000000)";

                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView3.DataSource = dt;
                    }
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-AIDA\SQLEXPRESS;Initial Catalog=Cinemania;Integrated Security=True"))
            {
                conn.Open();

                string selectQuery = @"SELECT COUNT(DISTINCT a.ID_Actor) AS Numar_Actori

                FROM Actori a

                LEFT JOIN ""Actori Filme"" af ON a.ID_Actor = af.ID_Actor

                LEFT JOIN Filme f ON af.ID_Film = f.ID_Film

                JOIN (SELECT ID_Actor FROM Actori WHERE YEAR(Data_Nasterii) > 2000) subq

                ON a.ID_Actor = subq.ID_Actor;
";

                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView3.DataSource = dt;
                    }
                }
            }
        }
    }


}



