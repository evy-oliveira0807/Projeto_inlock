using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

     
        private string stringConexao = "Data Source = NOTE11-S14; Initial Catalog = inlock_games; User id = sa; pwd = Senai@134";

        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectUser = "SELECT IdUsuario, Usuario.IdTipoUsuario, Email, Titulo FROM Usuario LEFT JOIN TiposUsuario ON TiposUsuario.IdTipoUsuario = Usuario.IdTipoUsuario WHERE Email = @Email AND Senha = @Senha";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectUser, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    cmd.Parameters.AddWithValue("@Senha", senha);

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuarioEncontrado = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            Email = Convert.ToString(rdr["Email"]),

                            TipoUsuario = new TiposUsuarioDomain()
                            {

                                Titulo = Convert.ToString(rdr["Titulo"])
                            }
                        };

                        if (usuarioEncontrado.Email != null)
                        {
                            return usuarioEncontrado;
                        }
                    }
                }
            }

            return null;
        }

        public UsuarioDomain Login(object email, object senha)
        {
            throw new NotImplementedException();
        }
    }
}

