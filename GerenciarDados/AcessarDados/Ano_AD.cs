using AcessarBancoDados.Modelos;

namespace GerenciarDados.AcessarDados
{
    public class Ano_AD : Repositorio<Ano>
    {
        public Ano_AD(bool save = true) : base(save) { }
    }
}
