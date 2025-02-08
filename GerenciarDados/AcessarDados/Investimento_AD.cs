using AcessarBancoDados.ContextoDeDados;
using AcessarBancoDados.Modelos;
using GerenciarDados.Mensagens;

namespace GerenciarDados.AcessarDados
{
    public class Investimento_AD(bool Save = true) : Repositorio<Investimento>(Save)
    {
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

                return [.. listaDeInvestimentos];
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ObterInvestimentoPorId";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }
    }
}
