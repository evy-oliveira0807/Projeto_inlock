using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi_.Domains
{
    public class TiposUsuarioDomain
    {
      
            public int IdTipoUsuario { get; set; }

            [Required(ErrorMessage = "O titulo é obrigatório")]
            public string? Titulo { get; set; }
       
    }
}
