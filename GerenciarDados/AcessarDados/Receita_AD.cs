using AcessarBancoDados.ContextoDeDados;
using AcessarBancoDados.Modelos;
using GerenciarDados.Mensagens;

namespace GerenciarDados.AcessarDados
{
    public class Receita_AD(bool Save = true) : Repositorio<Receita>(Save)
    {
        public static List<Receita> ObterReceitaPorAno(int ano)
        {
            try
            {
                using Contexto contexto = new();
                var listaDeReceitas = contexto.TReceita.Select(d => new Receita()
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

                return [.. listaDeReceitas];
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ObterReceitaPorId";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }
    }
}
