using System.Collections.Generic;
using MySqlConnector;

namespace MauiMYSQL.Models
{
    public class Estado
    {
        public string nome { get; set; }
        public string sigla { get; set; }
        public string bandeira_url { get; set; }
    }

    public class Estados
    {
        public List<Estado> listaEstados { get; private set; } = new List<Estado>();
        public string conexao_status;

        public bool Estados_Consulta()
        {
            listaEstados.Clear();

            var conecta = new Conecta();
            if (!conecta.Conexao())
                return false;

            string query = "SELECT nome, sigla, bandeira_url FROM estados";

            try
            {
                using var cmd = new MySqlCommand(query, conecta.Conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    listaEstados.Add(new Estado()
                    {
                        nome = reader.GetString("nome"),
                        sigla = reader.GetString("sigla"),
                        bandeira_url = reader.GetString("bandeira_url")
                    });
                }

                return true;
            }
            catch (MySqlException ex)
            {
                conexao_status = ex.Message;
                return false;
            }
            finally
            {
                conecta.Conn.Close();
            }
        }

        public bool Estados_Add(string nome, string sigla, string bandeiraUrl)
        {
            var conecta = new Conecta();
            if (!conecta.Conexao())
                return false;

            string query = "INSERT INTO estados (nome, sigla, bandeira_url) VALUES (@nome, @sigla, @bandeira_url)";

            try
            {
                using var cmd = new MySqlCommand(query, conecta.Conn);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@sigla", sigla);
                cmd.Parameters.AddWithValue("@bandeira_url", bandeiraUrl);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                conexao_status = ex.Message;
                return false;
            }
            finally
            {
                conecta.Conn.Close();
            }
        }
    }
}
