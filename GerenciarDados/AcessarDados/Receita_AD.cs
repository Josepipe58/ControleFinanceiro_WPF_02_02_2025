using AcessarBancoDados.ContextoDeDados;
using AcessarBancoDados.Modelos;
using GerenciarDados.Mensagens;

namespace GerenciarDados.AcessarDados
{
    public class Receita_AD : Repositorio<Receita>
    {
        public Receita_AD(bool Save = true) : base(Save) { }
        public static List<Receita> ObterReceitaPorId(int ano)
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

                return listaDeReceitas.ToList();
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "ObterReceitaPorId";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new List<Receita>();
            }
        }
    }
}
