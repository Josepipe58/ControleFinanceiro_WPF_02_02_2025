using AcessarDadosDoBanco.ContextoDeDados;
using GerenciarDados.Listas;
using GerenciarDados.Mensagens;

namespace GerenciarDados.Relatorios
{
    public static class RelatorioDeInvestimentos
    {
        private static string _nomeDoMetodo = string.Empty;
        private static readonly string[] saldoDeInvestimento = ["Saldo Anterior", "Juros de Investimentos", "Depósito"];
        private static readonly string[] jurosInvestimentoDeposito = ["Juros de Investimentos", "Depósito"];

        public static ListaDeMeses RelatorioDoSaldoTotalDeInvestimentos(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TInvestimento.Where(i => i.Ano == ano && saldoDeInvestimento.Contains(i.NomeDaSubCategoria) && i.Mes == "Janeiro").Select(i => i.Valor).Sum() -
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque" && i.Mes == "Janeiro").Select(i => i.Valor).Sum();

                meses.Fevereiro = meses.Janeiro +
                    contexto.TInvestimento.Where(i => i.Ano == ano && saldoDeInvestimento.Contains(i.NomeDaSubCategoria) && i.Mes == "Fevereiro").Select(i => i.Valor).Sum() -
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque" && i.Mes == "Fevereiro").Select(i => i.Valor).Sum();

                meses.Marco = meses.Fevereiro +
                    contexto.TInvestimento.Where(i => i.Ano == ano && jurosInvestimentoDeposito.Contains(i.NomeDaSubCategoria) && i.Mes == "Março").Select(i => i.Valor).Sum() -
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque" && i.Mes == "Março").Select(i => i.Valor).Sum();

                meses.Abril = meses.Marco +
                    contexto.TInvestimento.Where(i => i.Ano == ano && jurosInvestimentoDeposito.Contains(i.NomeDaSubCategoria) && i.Mes == "Abril").Select(i => i.Valor).Sum() -
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque" && i.Mes == "Abril").Select(i => i.Valor).Sum();

                meses.Maio = meses.Abril +
                    contexto.TInvestimento.Where(i => i.Ano == ano && jurosInvestimentoDeposito.Contains(i.NomeDaSubCategoria) && i.Mes == "Maio").Select(i => i.Valor).Sum() -
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque" && i.Mes == "Maio").Select(i => i.Valor).Sum();

                meses.Junho = meses.Maio +
                    contexto.TInvestimento.Where(i => i.Ano == ano && jurosInvestimentoDeposito.Contains(i.NomeDaSubCategoria) && i.Mes == "Junho").Select(i => i.Valor).Sum() -
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque" && i.Mes == "Junho").Select(i => i.Valor).Sum();

                meses.Julho = meses.Junho +
                    contexto.TInvestimento.Where(i => i.Ano == ano && jurosInvestimentoDeposito.Contains(i.NomeDaSubCategoria) && i.Mes == "Julho").Select(i => i.Valor).Sum() -
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque" && i.Mes == "Julho").Select(i => i.Valor).Sum();

                meses.Agosto = meses.Julho +
                    contexto.TInvestimento.Where(i => i.Ano == ano && jurosInvestimentoDeposito.Contains(i.NomeDaSubCategoria) && i.Mes == "Agôsto").Select(i => i.Valor).Sum() -
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque" && i.Mes == "Agôsto").Select(i => i.Valor).Sum();

                meses.Setembro = meses.Agosto +
                     contexto.TInvestimento.Where(i => i.Ano == ano && jurosInvestimentoDeposito.Contains(i.NomeDaSubCategoria) && i.Mes == "Setembro").Select(i => i.Valor).Sum() -
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque" && i.Mes == "Setembro").Select(i => i.Valor).Sum();

                meses.Outubro = meses.Setembro +
                    contexto.TInvestimento.Where(i => i.Ano == ano && jurosInvestimentoDeposito.Contains(i.NomeDaSubCategoria) && i.Mes == "Outubro").Select(i => i.Valor).Sum() -
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque" && i.Mes == "Outubro").Select(i => i.Valor).Sum();

                meses.Novembro = meses.Outubro +
                    contexto.TInvestimento.Where(i => i.Ano == ano && jurosInvestimentoDeposito.Contains(i.NomeDaSubCategoria) && i.Mes == "Novembro").Select(i => i.Valor).Sum() -
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque" && i.Mes == "Novembro").Select(i => i.Valor).Sum();

                meses.Dezembro = meses.Novembro +
                    contexto.TInvestimento.Where(i => i.Ano == ano && jurosInvestimentoDeposito.Contains(i.NomeDaSubCategoria) && i.Mes == "Dezembro").Select(i => i.Valor).Sum() -
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Saque"  && i.Mes == "Dezembro").Select(i => i.Valor).Sum();

                meses.TotalAno = meses.Dezembro;

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "RelatorioDoSaldoTotalDeInvestimentos";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses RelatorioDosJurosDeInvestimentos(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Janeiro").Select(i => i.Valor).Sum();
                meses.Fevereiro =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Fevereiro").Select(i => i.Valor).Sum();
                meses.Marco =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Março").Select(i => i.Valor).Sum();
                meses.Abril =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Abril").Select(i => i.Valor).Sum();
                meses.Maio =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Maio").Select(i => i.Valor).Sum();
                meses.Junho =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Junho").Select(i => i.Valor).Sum();
                meses.Julho =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Julho").Select(i => i.Valor).Sum();
                meses.Agosto =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Agôsto").Select(i => i.Valor).Sum();
                meses.Setembro =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Setembro").Select(i => i.Valor).Sum();
                meses.Outubro =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Outubro").Select(i => i.Valor).Sum();
                meses.Novembro =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Novembro").Select(i => i.Valor).Sum();
                meses.Dezembro =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Dezembro").Select(i => i.Valor).Sum();
                meses.TotalAno =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos").Select(i => i.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "RelatorioDosJurosDeInvestimentos";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses RelatorioDeJurosDaPoupancaEInvestimentos(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Janeiro").Select(i => i.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Janeiro").Select(p => p.Valor).Sum();
                meses.Fevereiro =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Fevereiro").Select(i => i.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum();
                meses.Marco =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Março").Select(i => i.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Março").Select(p => p.Valor).Sum();
                meses.Abril =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Abril").Select(i => i.Valor).Sum() +
                     contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Abril").Select(p => p.Valor).Sum();
                meses.Maio =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Maio").Select(i => i.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Maio").Select(p => p.Valor).Sum();
                meses.Junho =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Junho").Select(i => i.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Junho").Select(p => p.Valor).Sum();
                meses.Julho =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Julho").Select(i => i.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Julho").Select(p => p.Valor).Sum();
                meses.Agosto =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Agôsto").Select(i => i.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Agôsto").Select(p => p.Valor).Sum();
                meses.Setembro =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Setembro").Select(i => i.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Setembro").Select(p => p.Valor).Sum();
                meses.Outubro =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Outubro").Select(i => i.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Outubro").Select(p => p.Valor).Sum();
                meses.Novembro =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Novembro").Select(i => i.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Novembro").Select(p => p.Valor).Sum();
                meses.Dezembro =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos" && i.Mes == "Dezembro").Select(i => i.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança" && p.Mes == "Dezembro").Select(p => p.Valor).Sum();
                meses.TotalAno =
                    contexto.TInvestimento.Where(i => i.Ano == ano && i.NomeDaSubCategoria == "Juros de Investimentos").Select(i => i.Valor).Sum() +
                    contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Juros da Poupança").Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "RelatorioDeJurosDaPoupancaEInvestimentos";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }
    }
}
