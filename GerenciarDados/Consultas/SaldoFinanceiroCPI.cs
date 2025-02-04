using AcessarBancoDados.ContextoDeDados;
using GerenciarDados.Mensagens;

namespace GerenciarDados.Consultas
{
    public class SaldoFinanceiroCPI
    {
        // CPI = Carteira, Poupança e Investimento.
        private static string _nomeDoMetodo = string.Empty;

        public static double SaldoDaCarteira(int ano)
        {
            try
            {
                //new[] { "Saldo da Carteira", "Renda" }.Contains(r.NomeDaCategoria)
                using var contexto = new Contexto();
                var saldoDaCarteira =
                    contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Saldo da Carteira").Select(r => r.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque").Select(p => p.Valor).Sum() -

                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa").Select(d => d.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito").Select(d => d.Valor).Sum() +
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Tipo == "Despesa").Select(d => d.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && new[] { "Depósito", "Depósito Inicial" }
                    .Contains(i.NomeDaSubCategoria)).Select(i => i.Valor).Sum() +
                    contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Saldo da Carteira").Select(r => r.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda").Select(cd => cd.Valor).Sum());

                return Convert.ToDouble(saldoDaCarteira);
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "SaldoDaCarteira";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return 0;
            }
        }
        public static double SaldoDaPoupanca(int ano)
        {
            try
            {
                using var contexto = new Contexto();
                var saldoDaPoupanca =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Saldo Anterior")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }
                    .Contains(cd.NomeDaCategoria)).Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito")
                    .Select(cd => cd.Valor).Sum() -
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Despesa", "Débito" }
                    .Contains(cd.Tipo)).Select(cd => cd.Valor).Sum();

                return Convert.ToDouble(saldoDaPoupanca);
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "SaldoDaPoupanca";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return 0;
            }
        }

        public static double SaldoDeInvestimento(int ano)
        {
            try
            {
                using var contexto = new Contexto();
                var saldoDaPoupanca =
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && new[] { "Depósito Inicial",
                        "Saldo do Ano Anterior", "Juros de Investimentos", "Depósito"}.Contains(cd.NomeDaSubCategoria))
                    .Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque")
                    .Select(cd => cd.Valor).Sum();

                return Convert.ToDouble(saldoDaPoupanca);
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "SaldoDeInvestimento";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return 0;
            }
        }
    }
}
