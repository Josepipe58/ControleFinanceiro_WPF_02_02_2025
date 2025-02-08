using AcessarBancoDados.ContextoDeDados;
using AcessarBancoDados.Modelos;
using GerenciarDados.Mensagens;

namespace GerenciarDados.AcessarDados
{
    public class Despesa_AD(bool Save = true) : Repositorio<Despesa>(Save)
    {
        public static List<Despesa> ObterDespesaPorAno(int ano)
        {
            try
            {
                using Contexto contexto = new();
                var listaDeDespesas = contexto.TDespesa.Select(d => new Despesa()
                {
                    Id = d.Id,
                    NomeDaCategoria = d.NomeDaCategoria,
                    NomeDaSubCategoria = d.NomeDaSubCategoria,
                    Valor = d.Valor,
                    Tipo = d.Tipo,
                    Data = d.Data.Date,
                    Mes = d.Mes,
                    Ano = d.Ano,
                }).Where(d => d.Ano == ano).OrderByDescending(d => d.Id);

                return [.. listaDeDespesas];
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ObterDespesaPorId";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }
    }
}
