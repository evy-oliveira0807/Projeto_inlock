﻿using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi_.Domains
{
        /// <summary>
        /// Classe que representa a entidade Estudio
        /// </summary>
    public class EstudioDomain
    {    
     
            public int IdEstudio { get; set; }

            [Required(ErrorMessage = "O nome do estúdio é obrigatório")]
            public string Nome { get; set; }

      
    }
}
