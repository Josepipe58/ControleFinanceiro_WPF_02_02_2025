using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AcessarDadosDoBanco.Modelos
{
    public class ModeloBase
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string NomeDaCategoria { get; set; }

        [Required, StringLength(100)]
        public string NomeDaSubCategoria { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Valor { get; set; }

        [Required, StringLength(30)]
        public string Tipo { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data { get; set; }

        [Required, StringLength(20)]
        public string Mes { get; set; }

        public int Ano { get; set; }
    }
}
