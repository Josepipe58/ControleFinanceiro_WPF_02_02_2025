using AcessarDadosDoBanco.ContextoDeDados;
using AcessarDadosDoBanco.Modelos;
using GerenciarDados.Mensagens;

namespace GerenciarDados.AcessarDados
{
    public class Aposentadoria_AD(bool Save = true) : Repositorio<Aposentadoria>(Save)
    {
        public static List<Aposentadoria> ConsultarAposentadorias()
        {
            try
            {
                List<Aposentadoria> listaDeAposentorias = [];
                using var contexto = new Contexto();
                listaDeAposentorias = contexto.TAposentadoria.OrderByDescending(a => a.Id).ToList();

                return listaDeAposentorias;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ConsultarAposentadorias";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }
    }
}
