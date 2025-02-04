using AcessarBancoDados.ContextoDeDados;
using AcessarBancoDados.Modelos;
using GerenciarDados.Mensagens;

namespace GerenciarDados.AcessarDados
{
    public class SubCategoria_AD : Repositorio<SubCategoria>
    {
        public SubCategoria_AD(bool Save = true) : base(Save) { }

        public List<SubCategoria> ObterSubCategoriasPorId(int id)
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

                return listaDeSubCategorias.ToList();
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "ObterSubCategoriasPorId";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);

                return new List<SubCategoria>();
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

                return listaDeSubCategorias.ToList();
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "ObterSubCategorias";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);

                return new List<SubCategoria>();
            }
        }
    }
}
