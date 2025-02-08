using AcessarBancoDados.ContextoDeDados;
using AcessarBancoDados.Modelos;
using GerenciarDados.Mensagens;

namespace GerenciarDados.AcessarDados
{
    public class SubCategoriaConsultarDespesa_AD(bool Save = true) : Repositorio<SubCategoriaConsultarDespesa>(Save)
    {
        public static List<SubCategoriaConsultarDespesa> ObterSubCategoriasPorId(int id)
        {
            try
            {
                using Contexto contexto = new();
                var listaDeSubCategorias = contexto.TCategoriaConsultarDespesa
                    .Join(contexto.TSubCategoriaConsultarDespesa,
                    c => c.Id,
                    sc => sc.CategoriaConsultarDespesaId,
                    (c, sc) => new SubCategoriaConsultarDespesa
                    {
                        Id = sc.Id,
                        NomeDaSubCategoria = sc.NomeDaSubCategoria,
                        CategoriaConsultarDespesaId = sc.CategoriaConsultarDespesaId
                    }).Where(sc => sc.CategoriaConsultarDespesaId == id)
                    .OrderBy(sc => sc.NomeDaSubCategoria).ToList();

                return [.. listaDeSubCategorias];
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ObterSubCategoriasPorId";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);

                return [];
            }
        }

        public static List<SubCategoriaConsultarDespesa> ObterSubCategorias()
        {
            try
            {
                using Contexto contexto = new();
                var listaDeSubCategorias = contexto.TCategoriaConsultarDespesa
                    .Join(contexto.TSubCategoriaConsultarDespesa,
                    c => c.Id,
                    sc => sc.CategoriaConsultarDespesaId,
                    (c, sc) => new SubCategoriaConsultarDespesa
                    {
                        Id = sc.Id,
                        NomeDaSubCategoria = sc.NomeDaSubCategoria,
                        CategoriaConsultarDespesaId = sc.CategoriaConsultarDespesaId,
                        NomeDaCategoria = sc.CategoriaConsultarDespesa.NomeDaCategoria                        
                    }).OrderByDescending(sc => sc.Id);

                return [.. listaDeSubCategorias];
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ObterSubCategorias";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);

                return [];
            }
        }
}   }
