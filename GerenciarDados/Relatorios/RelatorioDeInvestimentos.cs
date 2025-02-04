using AcessarBancoDados.ContextoDeDados;
using GerenciarDados.Listas;
using GerenciarDados.Mensagens;

namespace GerenciarDados.Relatorios
{
    public static class RelatorioDeInvestimentos
    {
        private static string _nomeDoMetodo = string.Empty;

        public static ListaDeMeses RelatorioDoSaldoTotalDeInvestimentos(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && new[] { "Saldo Anterior",
                        "Juros de Investimentos", "Depósito" }.Contains(cd.NomeDaSubCategoria) && cd.Mes == "Janeiro").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Janeiro").Select(cd => cd.Valor).Sum();

                meses.Fevereiro = meses.Janeiro +
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && new[] { "Saldo Anterior", "Juros de Investimentos", "Depósito" }
                    .Contains(cd.NomeDaSubCategoria) && cd.Mes == "Fevereiro").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Fevereiro").Select(cd => cd.Valor).Sum();

                meses.Marco = meses.Fevereiro +
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && new[] { "Juros de Investimentos", "Depósito" }
                    .Contains(cd.NomeDaSubCategoria) && cd.Mes == "Março").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Março").Select(cd => cd.Valor).Sum();

                meses.Abril = meses.Marco +
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && new[] { "Juros de Investimentos", "Depósito" }
                    .Contains(cd.NomeDaSubCategoria) && cd.Mes == "Abril").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Abril").Select(cd => cd.Valor).Sum();

                meses.Maio = meses.Abril +
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && new[] { "Juros de Investimentos", "Depósito" }
                    .Contains(cd.NomeDaSubCategoria) && cd.Mes == "Maio").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Maio").Select(cd => cd.Valor).Sum();

                meses.Junho = meses.Maio +
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && new[] { "Juros de Investimentos", "Depósito" }
                    .Contains(cd.NomeDaSubCategoria) && cd.Mes == "Junho").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Junho").Select(cd => cd.Valor).Sum();

                meses.Julho = meses.Junho +
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && new[] { "Juros de Investimentos", "Depósito" }
                    .Contains(cd.NomeDaSubCategoria) && cd.Mes == "Julho").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Julho").Select(cd => cd.Valor).Sum();

                meses.Agosto = meses.Julho +
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && new[] { "Juros de Investimentos", "Depósito" }
                    .Contains(cd.NomeDaSubCategoria) && cd.Mes == "Agôsto").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Agôsto").Select(cd => cd.Valor).Sum();

                meses.Setembro = meses.Agosto +
                     contexto.TInvestimento.Where(cd => cd.Ano == ano && new[] { "Juros de Investimentos", "Depósito" }
                    .Contains(cd.NomeDaSubCategoria) && cd.Mes == "Setembro").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Setembro").Select(cd => cd.Valor).Sum();

                meses.Outubro = meses.Setembro +
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && new[] { "Juros de Investimentos", "Depósito" }
                    .Contains(cd.NomeDaSubCategoria) && cd.Mes == "Outubro").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Outubro").Select(cd => cd.Valor).Sum();

                meses.Novembro = meses.Outubro +
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && new[] { "Juros de Investimentos", "Depósito",
                        "Depósito Inicial" }.Contains(cd.NomeDaSubCategoria) && cd.Mes == "Novembro").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Novembro").Select(cd => cd.Valor).Sum();

                meses.Dezembro = meses.Novembro +
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && new[] { "Juros de Investimentos", "Depósito" }
                    .Contains(cd.NomeDaSubCategoria) && cd.Mes == "Dezembro").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Dezembro").Select(cd => cd.Valor).Sum();

                meses.TotalAno = meses.Dezembro;

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "RelatorioDoSaldoTotalDeInvestimentos";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses RelatorioDosJurosDeInvestimentos(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros de Investimentos" && cd.Mes == "Janeiro")
                    .Select(cd => cd.Valor).Sum();
                meses.Fevereiro =
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros de Investimentos" && cd.Mes == "Fevereiro")
                    .Select(cd => cd.Valor).Sum();
                meses.Marco =
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros de Investimentos" && cd.Mes == "Março")
                    .Select(cd => cd.Valor).Sum();
                meses.Abril =
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros de Investimentos" && cd.Mes == "Abril")
                    .Select(cd => cd.Valor).Sum();
                meses.Maio =
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros de Investimentos" && cd.Mes == "Maio")
                    .Select(cd => cd.Valor).Sum();
                meses.Junho =
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros de Investimentos" && cd.Mes == "Junho")
                    .Select(cd => cd.Valor).Sum();
                meses.Julho =
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros de Investimentos" && cd.Mes == "Julho")
                    .Select(cd => cd.Valor).Sum();
                meses.Agosto =
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros de Investimentos" && cd.Mes == "Agôsto")
                    .Select(cd => cd.Valor).Sum();
                meses.Setembro =
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros de Investimentos" && cd.Mes == "Setembro")
                    .Select(cd => cd.Valor).Sum();
                meses.Outubro =
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros de Investimentos" && cd.Mes == "Outubro")
                    .Select(cd => cd.Valor).Sum();
                meses.Novembro =
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros de Investimentos" && cd.Mes == "Novembro")
                    .Select(cd => cd.Valor).Sum();
                meses.Dezembro =
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros de Investimentos" && cd.Mes == "Dezembro")
                    .Select(cd => cd.Valor).Sum();
                meses.TotalAno =
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros de Investimentos").Select(cd => cd.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "RelatorioDosJurosDaPoupanca";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses RelatorioDosRendimentosDeInvestimentosEntreDepositosJurosESaques(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.Tipo == "Crédito"
                    && cd.Mes == "Janeiro").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Janeiro").Select(cd => cd.Valor).Sum();

                meses.Fevereiro =
                   contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.Tipo == "Crédito"
                    && cd.Mes == "Fevereiro").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Fevereiro").Select(cd => cd.Valor).Sum();

                meses.Marco =
                   contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.Tipo == "Crédito"
                    && cd.Mes == "Março").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Março").Select(cd => cd.Valor).Sum();

                meses.Abril =
                   contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.Tipo == "Crédito"
                    && cd.Mes == "Abril").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Abril").Select(cd => cd.Valor).Sum();

                meses.Maio =
                   contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.Tipo == "Crédito"
                    && cd.Mes == "Maio").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Maio").Select(cd => cd.Valor).Sum();

                meses.Junho =
                   contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.Tipo == "Crédito"
                    && cd.Mes == "Junho").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Junho").Select(cd => cd.Valor).Sum();

                meses.Julho =
                   contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.Tipo == "Crédito"
                    && cd.Mes == "Julho").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Julho").Select(cd => cd.Valor).Sum();

                meses.Agosto =
                   contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.Tipo == "Crédito"
                    && cd.Mes == "Agôsto").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Agôsto").Select(cd => cd.Valor).Sum();

                meses.Setembro =
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.Tipo == "Crédito"
                    && cd.Mes == "Setembro").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Setembro").Select(cd => cd.Valor).Sum();

                meses.Outubro =
                   contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.Tipo == "Crédito"
                    && cd.Mes == "Outubro").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Outubro").Select(cd => cd.Valor).Sum();

                meses.Novembro =
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.Tipo == "Crédito"
                    && cd.Mes == "Novembro").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Novembro").Select(cd => cd.Valor).Sum();

                meses.Dezembro =
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.Tipo == "Crédito"
                    && cd.Mes == "Dezembro").Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque"
                    && cd.Mes == "Dezembro").Select(cd => cd.Valor).Sum();

                meses.TotalAno =
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.Tipo == "Crédito")
                    .Select(cd => cd.Valor).Sum() -
                    contexto.TInvestimento.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Saque")
                    .Select(cd => cd.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "RelatorioDosRendimentosDeInvestimentosEntreDepositosJurosESaques";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }
    }
}
