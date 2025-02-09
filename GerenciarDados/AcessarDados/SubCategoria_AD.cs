using AcessarDadosDoBanco.ContextoDeDados;
using AcessarDadosDoBanco.Modelos;
using GerenciarDados.Mensagens;

namespace GerenciarDados.AcessarDados
{
    public class SubCategoria_AD(bool Save = true) : Repositorio<SubCategoria>(Save)
    {
        public static List<SubCategoria> ObterSubCategoriasPorId(int id)
        {
            try
            {
                using Contexto contexto = new();
                var listaDeSubCategorias = contexto.TCategoria.Join(contexto.TFiltrarCategoria,
                    c => c.FiltrarCategoriaId,
                    f => f.Id,
                    (c, f) => new { c, f })
                    .Join(contexto.TSubCategoria,
                    cf => cf.c.Id,
                    sc => sc.CategoriaId,
                    (cf, sc) => new SubCategoria
                    {
                        Id = sc.Id,
                        NomeDaSubCategoria = sc.NomeDaSubCategoria,
                        CategoriaId = sc.CategoriaId
                    }).Where(sc => sc.CategoriaId == id)
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

        public static List<SubCategoria> ObterSubCategorias()
        {
            try
            {
                using Contexto contexto = new();
                var listaDeSubCategorias = contexto.TCategoria.Join(contexto.TFiltrarCategoria,
                    c => c.FiltrarCategoriaId,
                    f => f.Id,
                    (c, f) => new { c, f })
                    .Join(contexto.TSubCategoria,
                    cf => cf.c.Id,
                    sc => sc.CategoriaId,
                    (cf, sc) => new SubCategoria
                    {
                        Id = sc.Id,
                        NomeDaSubCategoria = sc.NomeDaSubCategoria,
                        CategoriaId = sc.CategoriaId,
                        NomeDaCategoria = cf.c.NomeDaCategoria,
                        FiltrarCategoriaId = cf.c.FiltrarCategoriaId,
                        NomeDoFiltro = cf.f.NomeDoFiltro
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
    }
}
