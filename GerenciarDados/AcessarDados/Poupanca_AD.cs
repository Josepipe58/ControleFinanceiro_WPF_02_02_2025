using AcessarBancoDados.ContextoDeDados;
using AcessarBancoDados.Modelos;
using GerenciarDados.Mensagens;

namespace GerenciarDados.AcessarDados
{
    public class Poupanca_AD(bool Save = true) : Repositorio<Poupanca>(Save)
    {
        public static List<Poupanca> ObterPoupancaPorAno(int ano)
        {
            try
            {
                using Contexto contexto = new();
                var listaDePoupanca = contexto.TPoupanca.Select(p => new Poupanca()
                {
                    Id = p.Id,
                    NomeDaCategoria = p.NomeDaCategoria,
                    NomeDaSubCategoria = p.NomeDaSubCategoria,
                    Valor = p.Valor,
                    Tipo = p.Tipo,
                    Data = p.Data.Date,
                    Mes = p.Mes,
                    Ano = p.Ano,
                }).Where(p => p.Ano == ano).OrderByDescending(p => p.Id);

                return [.. listaDePoupanca];
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ObterPoupancaPorId";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }
    }
}
