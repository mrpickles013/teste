using MySql.Data;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;



namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public class Aluno
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
        }
        private void CarregarDadosComList()
        {
            string conexao = "Server=localhost;Database=bdaula;Uid=root;Pwd=;";
            BindingList<Aluno> lista = new BindingList<Aluno>();

            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM alunos", conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Aluno
                    {
                        Id = reader.GetInt32("id"),
                        Nome = reader.GetString("nome"),
                        Email = reader.GetString("email")
                    });
                }
            }

            dataGridView2.DataSource = lista;
        }
        public void CarregarDados()
        {
            string conexao = "Server=localhost;Database=bdaula;Uid=root;Pwd=";
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM alunos";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            CarregarDados();
            CarregarDadosComList();
        }
    }
    }