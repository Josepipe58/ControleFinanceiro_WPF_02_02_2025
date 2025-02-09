using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AcessarDadosDoBanco.Modelos
{
    public class Aposentadoria
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data { get; set; }

        public int AnoDoIndice { get; set; }

        public int AnoDoReajuste { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal IndiceDoAumento { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal ValorDoAumento { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal AtualizarValor { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal SaldoAtual { get; set; }
    }
}
