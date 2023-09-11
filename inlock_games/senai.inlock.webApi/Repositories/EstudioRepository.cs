using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
       
        private string stringConexao = "Data Source = NOTE11-S14; Initial Catalog = inlock_games; User id = sa; pwd = Senai@134";


        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT Estudio.IdEstudio, Estudio.Nome AS Estudio, IdJogo, Jogo.Nome AS Jogo, Descricao, DataLancamento, Valor FROM Estudio LEFT JOIN Jogo ON Jogo.IdEstudio = Estudio.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = Convert.ToString(rdr["Estudio"]),

                         
                        };



                        listaEstudios.Add(estudio);
                    }
                }
            }

            return listaEstudios;
        }
    }
}

