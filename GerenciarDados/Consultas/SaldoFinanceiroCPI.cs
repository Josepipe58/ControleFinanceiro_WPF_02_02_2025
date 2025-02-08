using AcessarBancoDados.ContextoDeDados;
using GerenciarDados.Mensagens;

namespace GerenciarDados.Consultas
{
    public class SaldoFinanceiroCPI
    {
        // CPI = Carteira, Poupança e Investimento.
        private static string _nomeDoMetodo = string.Empty;
        private static readonly string[] saldoJurosEDepositos = ["Saldo Anterior", "Juros de Investimentos", "Depósito"];
        private static readonly string[] despesaDebito = ["Despesa", "Débito"];

        public static double SaldoDaCarteira(int ano)
        {
            try
            {
                using var contexto = new Contexto();
                var saldoDaCarteira =
                    (contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Saldo da Carteira").Select(r => r.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque").Select(p => p.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque").Select(i => i.Valor).Sum()) -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito").Select(d => d.Valor).Sum() +
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Tipo == "Despesa").Select(d => d.Valor).Sum() +
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Depósito").Select(i => i.Valor).Sum() +                   
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda").Select(p => p.Valor).Sum());

                return Convert.ToDouble(saldoDaCarteira);
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "SaldoDaCarteira";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return 0;
            }
        }
        public static double SaldoDaPoupanca(int ano)
        {
            try
            {
                using var contexto = new Contexto();
                var saldoDaPoupanca =
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Saldo Anterior").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda").Select(p => p.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito").Select(p => p.Valor).Sum()) -
                    contexto.TPoupanca.Where(p => p.Ano == ano && despesaDebito.Contains(p.Tipo)).Select(p => p.Valor).Sum();

                return Convert.ToDouble(saldoDaPoupanca);
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "SaldoDaPoupanca";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return 0;
            }
        }

        public static double SaldoDeInvestimento(int ano)
        {
            try
            {
                using var contexto = new Contexto();
                var saldoDeInvestimento =
                    contexto.TInvestimento.Where(i => i.Ano == ano && saldoJurosEDepositos.Contains(i.NomeDaSubCategoria)).Select(i => i.Valor).Sum() -
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque").Select(i => i.Valor).Sum();

                return Convert.ToDouble(saldoDeInvestimento);
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "SaldoDeInvestimento";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return 0;
            }
        }
    }
}
