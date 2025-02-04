using AcessarBancoDados.ContextoDeDados;
using AcessarBancoDados.Modelos;
using GerenciarDados.Mensagens;

namespace GerenciarDados.AcessarDados
{
    public class Aposentadoria_AD : Repositorio<Aposentadoria>
    {
        public Aposentadoria_AD(bool Save = true) : base(Save) { }

        public static List<Aposentadoria> ConsultarAposentadorias()
        {
            try
            {
                List<Aposentadoria> listaDeAposentorias = new();
                using var contexto = new Contexto();
                listaDeAposentorias = contexto.TAposentadoria.OrderByDescending(a => a.Id).ToList();

                return listaDeAposentorias;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "ConsultarAposentadorias";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new List<Aposentadoria>();
            }
        }
    }
}
