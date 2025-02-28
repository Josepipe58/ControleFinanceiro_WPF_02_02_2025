﻿using System.ComponentModel.DataAnnotations;

namespace AcessarDadosDoBanco.Modelos
{
    public class FiltrarCategoria
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(30)]
        public string NomeDoFiltro { get; set; }
    }
}
