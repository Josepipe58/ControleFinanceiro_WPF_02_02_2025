using AcessarBancoDados.ContextoDeDados;
using AcessarBancoDados.Modelos;
using GerenciarDados.Mensagens;

namespace GerenciarDados.AcessarDados
{
    public class Investimento_AD : Repositorio<Investimento>
    {
        public Investimento_AD(bool Save = true) : base(Save) { }
        public static List<Investimento> ObterInvestimentoPorAno(int ano)
        {
            try
            {
                using Contexto contexto = new();
                var listaDeInvestimentos = contexto.TInvestimento.Select(i => new Investimento()
                {
                    Id = i.Id,
                    NomeDaCategoria = i.NomeDaCategoria,
                    NomeDaSubCategoria = i.NomeDaSubCategoria,
                    Valor = i.Valor,
                    Tipo = i.Tipo,
                    Data = i.Data.Date,
                    Mes = i.Mes,
                    Ano = i.Ano,
                }).Where(i => i.Ano == ano).OrderByDescending(i => i.Id);

                return listaDeInvestimentos.ToList();
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "ObterInvestimentoPorId";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new List<Investimento>();
            }
        }
    }
}
