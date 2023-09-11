﻿using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repositories
{

    public class JogoRepository : IJogoRepository
    {
       
        private string stringConexao = "Data Source = NOTE11-S14; Initial Catalog = inlock_games; User id = sa; pwd = Senai@134";
        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Jogo(IdEstudio, Nome, Descricao, DataLancamento, Valor) VALUES (@IdEstudio, @Nome, @Descricao, @DataLancamento, @Valor)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);

                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);

                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);

                    cmd.Parameters.AddWithValue("DataLancamento", novoJogo.DataLancamento);

                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdJogo, Jogo.IdEstudio AS IdEstudio, Jogo.Nome AS Jogo, Descricao, DataLancamento, Valor, Estudio.Nome AS Estudio FROM Jogo LEFT JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        JogoDomain jogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                            Nome = Convert.ToString(rdr["Jogo"]),

                            Descricao = Convert.ToString(rdr["Descricao"]),
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),
                            Valor = Convert.ToString(rdr["Valor"]),

                            Estudio = new EstudioDomain()
                            {
                                Nome = Convert.ToString(rdr["Estudio"])
                            }
                        };

                        listaJogos.Add(jogo);
                    }
                }
            }
            return listaJogos;
        }
    }
}

