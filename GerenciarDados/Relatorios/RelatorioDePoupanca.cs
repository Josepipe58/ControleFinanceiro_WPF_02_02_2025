using AcessarBancoDados.ContextoDeDados;
using GerenciarDados.Listas;
using GerenciarDados.Mensagens;

namespace GerenciarDados.Relatorios
{
    public static class RelatorioDePoupanca
    {
        private static string _nomeDoMetodo = string.Empty;

        public static ListaDeMeses RelatorioDoSaldoTotalDaPoupancaReceitasEInvestimentos(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Saldo Anterior" && cd.Mes == "Janeiro").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria) && cd.Mes == "Janeiro")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Janeiro").Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Janeiro")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Janeiro").Select(cd => cd.Valor).Sum());

                meses.Fevereiro =
                    meses.Janeiro +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria) && cd.Mes == "Fevereiro")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Fevereiro").Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Fevereiro")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Fevereiro").Select(cd => cd.Valor).Sum());

                meses.Marco =
                    meses.Fevereiro +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria) && cd.Mes == "Março")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Março").Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Março")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Março").Select(cd => cd.Valor).Sum());


                meses.Abril =
                    meses.Marco +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria) && cd.Mes == "Abril")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Abril").Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Abril")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Abril").Select(cd => cd.Valor).Sum());

                meses.Maio =
                    meses.Abril +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria) && cd.Mes == "Maio")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Maio").Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Maio")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Maio").Select(cd => cd.Valor).Sum());

                meses.Junho =
                    meses.Maio +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria) && cd.Mes == "Junho")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Junho").Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Junho")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Junho").Select(cd => cd.Valor).Sum());

                meses.Julho =
                    meses.Junho +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria) && cd.Mes == "Julho")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Julho").Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Julho")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Julho").Select(cd => cd.Valor).Sum());

                meses.Agosto =
                    meses.Julho +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria) && cd.Mes == "Agôsto")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Agôsto").Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Agôsto")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Agôsto").Select(cd => cd.Valor).Sum());

                meses.Setembro =
                    meses.Agosto +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria) && cd.Mes == "Setembro")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Setembro").Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Setembro")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Setembro").Select(cd => cd.Valor).Sum());

                meses.Outubro =
                    meses.Setembro +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria) && cd.Mes == "Outubro")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Outubro").Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Outubro")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Outubro").Select(cd => cd.Valor).Sum());

                meses.Novembro =
                    meses.Outubro +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria) && cd.Mes == "Novembro")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Depósito", "Depósito Inicial" }.Contains(cd.NomeDaSubCategoria)
                    && cd.Mes == "Novembro").Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Novembro")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Novembro").Select(cd => cd.Valor).Sum());

                meses.Dezembro =
                    meses.Novembro +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria) && cd.Mes == "Dezembro")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Dezembro").Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Dezembro")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Dezembro").Select(cd => cd.Valor).Sum());

                meses.TotalAno = meses.Dezembro;

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "RelatorioDoSaldoTotalDaPoupancaReceitasEInvestimentos";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses RelatorioDoSaldoTotalDaPoupanca(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Saldo Anterior" && cd.Mes == "Janeiro")
                    .Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria)
                    && cd.Mes == "Janeiro").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Janeiro")
                    .Select(cd => cd.Valor).Sum() -
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Despesa", "Débito" }.Contains(cd.Tipo)
                    && cd.Mes == "Janeiro").Select(cd => cd.Valor).Sum();
                meses.Fevereiro =
                    meses.Janeiro +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria)
                    && cd.Mes == "Fevereiro").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Fevereiro")
                    .Select(cd => cd.Valor).Sum() -
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Despesa", "Débito" }.Contains(cd.Tipo)
                    && cd.Mes == "Fevereiro").Select(cd => cd.Valor).Sum();
                meses.Marco =
                    meses.Fevereiro +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria)
                    && cd.Mes == "Março").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Março")
                    .Select(cd => cd.Valor).Sum() -
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Despesa", "Débito" }.Contains(cd.Tipo)
                    && cd.Mes == "Março").Select(cd => cd.Valor).Sum();
                meses.Abril =
                    meses.Marco +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria)
                    && cd.Mes == "Abril").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Abril")
                    .Select(cd => cd.Valor).Sum() -
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Despesa", "Débito" }.Contains(cd.Tipo)
                    && cd.Mes == "Abril").Select(cd => cd.Valor).Sum();
                meses.Maio =
                    meses.Abril +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria)
                    && cd.Mes == "Maio").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Maio")
                    .Select(cd => cd.Valor).Sum() -
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Despesa", "Débito" }.Contains(cd.Tipo)
                    && cd.Mes == "Maio").Select(cd => cd.Valor).Sum();
                meses.Junho =
                    meses.Maio +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria)
                    && cd.Mes == "Junho").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Junho")
                    .Select(cd => cd.Valor).Sum() -
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Despesa", "Débito" }.Contains(cd.Tipo)
                    && cd.Mes == "Junho").Select(cd => cd.Valor).Sum();
                meses.Julho =
                    meses.Junho +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria)
                    && cd.Mes == "Julho").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Julho")
                    .Select(cd => cd.Valor).Sum() -
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Despesa", "Débito" }.Contains(cd.Tipo)
                    && cd.Mes == "Julho").Select(cd => cd.Valor).Sum();
                meses.Agosto =
                    meses.Julho +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria)
                    && cd.Mes == "Agôsto").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Agôsto")
                    .Select(cd => cd.Valor).Sum() -
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Despesa", "Débito" }.Contains(cd.Tipo)
                    && cd.Mes == "Agôsto").Select(cd => cd.Valor).Sum();
                meses.Setembro =
                    meses.Agosto +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria)
                    && cd.Mes == "Setembro").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Setembro")
                    .Select(cd => cd.Valor).Sum() -
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Despesa", "Débito" }.Contains(cd.Tipo)
                    && cd.Mes == "Setembro").Select(cd => cd.Valor).Sum();

                meses.Outubro =
                    meses.Setembro +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria)
                    && cd.Mes == "Outubro").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Outubro")
                    .Select(cd => cd.Valor).Sum() -
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Despesa", "Débito" }.Contains(cd.Tipo)
                    && cd.Mes == "Outubro").Select(cd => cd.Valor).Sum();

                meses.Novembro =
                    meses.Outubro +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria)
                    && cd.Mes == "Novembro").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Novembro")
                    .Select(cd => cd.Valor).Sum() -
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Despesa", "Débito" }.Contains(cd.Tipo)
                    && cd.Mes == "Novembro").Select(cd => cd.Valor).Sum();

                meses.Dezembro =
                    meses.Novembro +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Renda", "Venda" }.Contains(cd.NomeDaCategoria)
                    && cd.Mes == "Dezembro").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Dezembro")
                    .Select(cd => cd.Valor).Sum() -
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Despesa", "Débito" }.Contains(cd.Tipo)
                    && cd.Mes == "Dezembro").Select(cd => cd.Valor).Sum();
                meses.TotalAno = meses.Dezembro;

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "RelatorioDoSaldoTotalDaPoupanca";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses RelatorioDosJurosDaPoupanca(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros da Poupança" && cd.Mes == "Janeiro")
                    .Select(cd => cd.Valor).Sum();
                meses.Fevereiro =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros da Poupança" && cd.Mes == "Fevereiro")
                    .Select(cd => cd.Valor).Sum();
                meses.Marco =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros da Poupança" && cd.Mes == "Março")
                    .Select(cd => cd.Valor).Sum();
                meses.Abril =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros da Poupança" && cd.Mes == "Abril")
                    .Select(cd => cd.Valor).Sum();
                meses.Maio =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros da Poupança" && cd.Mes == "Maio")
                    .Select(cd => cd.Valor).Sum();
                meses.Junho =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros da Poupança" && cd.Mes == "Junho")
                    .Select(cd => cd.Valor).Sum();
                meses.Julho =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros da Poupança" && cd.Mes == "Julho")
                    .Select(cd => cd.Valor).Sum();
                meses.Agosto =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros da Poupança" && cd.Mes == "Agôsto")
                    .Select(cd => cd.Valor).Sum();
                meses.Setembro =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros da Poupança" && cd.Mes == "Setembro")
                    .Select(cd => cd.Valor).Sum();
                meses.Outubro =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros da Poupança" && cd.Mes == "Outubro")
                    .Select(cd => cd.Valor).Sum();
                meses.Novembro =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros da Poupança" && cd.Mes == "Novembro")
                    .Select(cd => cd.Valor).Sum();
                meses.Dezembro =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros da Poupança" && cd.Mes == "Dezembro")
                    .Select(cd => cd.Valor).Sum();
                meses.TotalAno =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Juros da Poupança").Select(cd => cd.Valor).Sum();

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

        public static ListaDeMeses RelatorioDosRendimentosEntreDepositosJurosESaques(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Crédito", "Receita" }.Contains(cd.Tipo) && cd.Mes == "Janeiro")
                    .Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Janeiro").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Janeiro")
                    .Select(cd => cd.Valor).Sum());

                meses.Fevereiro =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Crédito", "Receita" }.Contains(cd.Tipo) && cd.Mes == "Fevereiro")
                    .Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Fevereiro").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Fevereiro")
                    .Select(cd => cd.Valor).Sum());

                meses.Marco =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Crédito", "Receita" }.Contains(cd.Tipo) && cd.Mes == "Março")
                    .Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Março").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Março")
                    .Select(cd => cd.Valor).Sum());

                meses.Abril =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Crédito", "Receita" }.Contains(cd.Tipo) && cd.Mes == "Abril")
                    .Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Abril").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Abril")
                    .Select(cd => cd.Valor).Sum());

                meses.Maio =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Crédito", "Receita" }.Contains(cd.Tipo) && cd.Mes == "Maio")
                    .Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Maio").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Maio")
                    .Select(cd => cd.Valor).Sum());

                meses.Junho =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Crédito", "Receita" }.Contains(cd.Tipo) && cd.Mes == "Junho")
                    .Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Junho").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Junho")
                    .Select(cd => cd.Valor).Sum());

                meses.Julho =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Crédito", "Receita" }.Contains(cd.Tipo) && cd.Mes == "Julho")
                    .Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Julho").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Julho")
                    .Select(cd => cd.Valor).Sum());

                meses.Agosto =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Crédito", "Receita" }.Contains(cd.Tipo) && cd.Mes == "Agôsto")
                    .Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Agôsto").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Agôsto")
                    .Select(cd => cd.Valor).Sum());

                meses.Setembro =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Crédito", "Receita" }.Contains(cd.Tipo) && cd.Mes == "Setembro")
                    .Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Setembro").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Setembro")
                    .Select(cd => cd.Valor).Sum());

                meses.Outubro =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Crédito", "Receita" }.Contains(cd.Tipo) && cd.Mes == "Outubro")
                    .Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Outubro").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Outubro")
                    .Select(cd => cd.Valor).Sum());

                meses.Novembro =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Crédito", "Receita" }.Contains(cd.Tipo) && cd.Mes == "Novembro")
                    .Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Novembro").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Novembro")
                    .Select(cd => cd.Valor).Sum());

                meses.Dezembro =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Crédito", "Receita" }.Contains(cd.Tipo) && cd.Mes == "Dezembro")
                    .Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Dezembro").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Dezembro")
                    .Select(cd => cd.Valor).Sum());

                meses.TotalAno =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && new[] { "Crédito", "Receita" }.Contains(cd.Tipo)).Select(cd => cd.Valor).Sum() -
                    (contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Débito").Select(cd => cd.Valor).Sum() +
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa").Select(cd => cd.Valor).Sum());

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "RelatorioDosRendimentosEntreDepositosJurosESaques";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses RelatorioDePagamentosETranferencias(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Janeiro")
                    .Select(cd => cd.Valor).Sum();
                meses.Fevereiro =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Fevereiro")
                    .Select(cd => cd.Valor).Sum();
                meses.Marco =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Março")
                    .Select(cd => cd.Valor).Sum();
                meses.Abril =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Abril")
                    .Select(cd => cd.Valor).Sum();
                meses.Maio =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Maio")
                    .Select(cd => cd.Valor).Sum();
                meses.Junho =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Junho")
                    .Select(cd => cd.Valor).Sum();
                meses.Julho =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Julho")
                    .Select(cd => cd.Valor).Sum();
                meses.Agosto =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Agôsto")
                    .Select(cd => cd.Valor).Sum();
                meses.Setembro =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Setembro")
                    .Select(cd => cd.Valor).Sum();
                meses.Outubro =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Outubro")
                    .Select(cd => cd.Valor).Sum();
                meses.Novembro =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Novembro")
                    .Select(cd => cd.Valor).Sum();
                meses.Dezembro =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Dezembro")
                    .Select(cd => cd.Valor).Sum();
                meses.TotalAno =
                    contexto.TPoupanca.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa").Select(cd => cd.Valor).Sum();

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "RelatorioDePagamentosETranferencias";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }
    }
}
