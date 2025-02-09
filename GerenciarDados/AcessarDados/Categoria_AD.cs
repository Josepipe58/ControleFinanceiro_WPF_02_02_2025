using AcessarDadosDoBanco.ContextoDeDados;
using AcessarDadosDoBanco.Modelos;
using GerenciarDados.Mensagens;

namespace GerenciarDados.AcessarDados
{
    public class Categoria_AD(bool Save = true) : Repositorio<Categoria>(Save)
    {
        public static List<Categoria> ObterCategoriasPorId(int id)
        {
            try
            {
                List<Categoria> listaDeCategorias = [];
                using var contexto = new Contexto();
                listaDeCategorias = contexto.TCategoria
                    .Where(c => c.FiltrarCategoriaId == id).OrderBy(c => c.NomeDaCategoria).ToList();

                return listaDeCategorias;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ObterCategoriasPorId";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static List<Categoria> ObterCategorias()
        {
            try
            {
                using Contexto contexto = new();
                List<Categoria> lCategorias = contexto.TCategoria.ToList();
                List<FiltrarCategoria> lFiltroDeControles = contexto.TFiltrarCategoria.ToList();
                var listaDeCategorias = lCategorias.GroupJoin(lCategorias,
                    c => c.FiltrarCategoriaId,
                    fc => fc.Id,
                    (c, scGrupo) => new Categoria(
                        c.Id,
                        c.NomeDaCategoria,
                        c.FiltrarCategoriaId,
                        c.FiltrarCategoria.NomeDoFiltro
                        )).OrderByDescending(c => c.Id);

                return listaDeCategorias.ToList();
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ObterCategorias";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);

                return [];
            }
        }
    }
}
