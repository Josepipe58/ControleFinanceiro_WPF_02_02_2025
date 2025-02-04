using AcessarBancoDados.ContextoDeDados;
using GerenciarDados.Listas;
using GerenciarDados.Mensagens;

namespace GerenciarDados.Relatorios
{
    public class RelatorioDeReceitas
    {
        private static string _nomeDoMetodo = string.Empty;

        public static ListaDeMeses RelatorioDeBenefíciosDoINSS(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Tipo == "Receita" && cd.Mes == "Janeiro")
                    .Select(cd => cd.Valor).Sum();
                meses.Fevereiro =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Tipo == "Receita" && cd.Mes == "Fevereiro")
                    .Select(cd => cd.Valor).Sum();
                meses.Marco =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Tipo == "Receita" && cd.Mes == "Março")
                    .Select(cd => cd.Valor).Sum();
                meses.Abril =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Tipo == "Receita" && cd.Mes == "Abril")
                    .Select(cd => cd.Valor).Sum();
                meses.Maio =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Tipo == "Receita" && cd.Mes == "Maio")
                    .Select(cd => cd.Valor).Sum();
                meses.Junho =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Tipo == "Receita" && cd.Mes == "Junho")
                    .Select(cd => cd.Valor).Sum();
                meses.Julho =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Tipo == "Receita" && cd.Mes == "Julho")
                    .Select(cd => cd.Valor).Sum();
                meses.Agosto =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Tipo == "Receita" && cd.Mes == "Agôsto")
                    .Select(cd => cd.Valor).Sum();
                meses.Setembro =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Tipo == "Receita" && cd.Mes == "Setembro")
                    .Select(cd => cd.Valor).Sum();
                meses.Outubro =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Tipo == "Receita" && cd.Mes == "Outubro")
                    .Select(cd => cd.Valor).Sum();
                meses.Novembro =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Tipo == "Receita" && cd.Mes == "Novembro")
                    .Select(cd => cd.Valor).Sum();
                meses.Dezembro =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Tipo == "Receita" && cd.Mes == "Dezembro")
                    .Select(cd => cd.Valor).Sum();
                meses.TotalAno =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Tipo == "Receita").Select(cd => cd.Valor).Sum();

                listaDeMeses.Add(meses);
                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "RelatorioDeBenefíciosDoINSS";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses RelatorioDeBenefíciosDoINSSJurosDaPoupancaEBonus(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Janeiro").Select(cd => cd.Valor).Sum();
                meses.Fevereiro =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Fevereiro").Select(cd => cd.Valor).Sum();
                meses.Marco =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Março").Select(cd => cd.Valor).Sum();
                meses.Abril =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Abril").Select(cd => cd.Valor).Sum();
                meses.Maio =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Maio").Select(cd => cd.Valor).Sum();
                meses.Junho =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Junho").Select(cd => cd.Valor).Sum();
                meses.Julho =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Julho").Select(cd => cd.Valor).Sum();
                meses.Agosto =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Agôsto").Select(cd => cd.Valor).Sum();
                meses.Setembro =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Setembro").Select(cd => cd.Valor).Sum();
                meses.Outubro =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Outubro").Select(cd => cd.Valor).Sum();
                meses.Novembro =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Novembro").Select(cd => cd.Valor).Sum();
                meses.Dezembro =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Dezembro").Select(cd => cd.Valor).Sum();
                meses.TotalAno =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda").Select(cd => cd.Valor).Sum();

                listaDeMeses.Add(meses);
                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "RelatorioDeBenefíciosDoINSSJurosDaPoupancaEBonus";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses RelatorioDeDescontosNoBeneficioDoINSS(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Descontos no Benefício do INSS" && cd.Mes == "Janeiro")
                    .Select(cd => cd.Valor).Sum();
                meses.Fevereiro =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Descontos no Benefício do INSS" && cd.Mes == "Fevereiro")
                    .Select(cd => cd.Valor).Sum();
                meses.Marco =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Descontos no Benefício do INSS" && cd.Mes == "Março")
                    .Select(cd => cd.Valor).Sum();
                meses.Abril =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Descontos no Benefício do INSS" && cd.Mes == "Abril")
                    .Select(cd => cd.Valor).Sum();
                meses.Maio =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Descontos no Benefício do INSS" && cd.Mes == "Maio")
                    .Select(cd => cd.Valor).Sum();
                meses.Junho =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Descontos no Benefício do INSS" && cd.Mes == "Junho")
                    .Select(cd => cd.Valor).Sum();
                meses.Julho =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Descontos no Benefício do INSS" && cd.Mes == "Julho")
                    .Select(cd => cd.Valor).Sum();
                meses.Agosto =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Descontos no Benefício do INSS" && cd.Mes == "Agôsto")
                    .Select(cd => cd.Valor).Sum();
                meses.Setembro =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Descontos no Benefício do INSS" && cd.Mes == "Setembro")
                    .Select(cd => cd.Valor).Sum();
                meses.Outubro =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Descontos no Benefício do INSS" && cd.Mes == "Outubro")
                    .Select(cd => cd.Valor).Sum();
                meses.Novembro =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Descontos no Benefício do INSS" && cd.Mes == "Novembro")
                    .Select(cd => cd.Valor).Sum();
                meses.Dezembro =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Descontos no Benefício do INSS" && cd.Mes == "Dezembro")
                    .Select(cd => cd.Valor).Sum();
                meses.TotalAno =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Descontos no Benefício do INSS")
                    .Select(cd => cd.Valor).Sum();

                listaDeMeses.Add(meses);
                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "RelatorioDeDescontosNoBeneficioDoINSS";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses RelatorioDoFluxoDeCaixaReceitasMenosDespesas(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TReceita.Where(cd => cd.Ano == ano && new[] { "Saldo da Carteira", "Renda" }.Contains(cd.NomeDaCategoria) && cd.Mes == "Janeiro")
                    .Select(cd => cd.Valor).Sum() -
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Janeiro").Select(cd => cd.Valor).Sum();
                meses.Fevereiro =
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Fevereiro").Select(cd => cd.Valor).Sum() -
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Fevereiro").Select(cd => cd.Valor).Sum();
                meses.Marco =
                     contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Março").Select(cd => cd.Valor).Sum() -
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Março").Select(cd => cd.Valor).Sum();
                meses.Abril =
                     contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Abril").Select(cd => cd.Valor).Sum() -
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Abril").Select(cd => cd.Valor).Sum();
                meses.Maio =
                     contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Maio").Select(cd => cd.Valor).Sum() -
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Maio").Select(cd => cd.Valor).Sum();
                meses.Junho =
                     contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Junho").Select(cd => cd.Valor).Sum() -
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Junho").Select(cd => cd.Valor).Sum();
                meses.Julho =
                     contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Julho").Select(cd => cd.Valor).Sum() -
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Julho").Select(cd => cd.Valor).Sum();
                meses.Agosto =
                     contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Agôsto").Select(cd => cd.Valor).Sum() -
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Agôsto").Select(cd => cd.Valor).Sum();
                meses.Setembro =
                     contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Setembro").Select(cd => cd.Valor).Sum() -
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Setembro").Select(cd => cd.Valor).Sum();
                meses.Outubro =
                     contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Outubro").Select(cd => cd.Valor).Sum() -
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Outubro").Select(cd => cd.Valor).Sum();
                meses.Novembro =
                     contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Novembro").Select(cd => cd.Valor).Sum() -
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Novembro").Select(cd => cd.Valor).Sum();
                meses.Dezembro =
                     contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Dezembro").Select(cd => cd.Valor).Sum() -
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Dezembro").Select(cd => cd.Valor).Sum();
                meses.TotalAno =
                     contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda").Select(cd => cd.Valor).Sum() -
                    contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa").Select(cd => cd.Valor).Sum();

                listaDeMeses.Add(meses);
                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "RelatorioDoFluxoDeCaixaReceitasMenosDespesas";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }

        public static ListaDeMeses RelatorioDoSaldoDaCarteiraPorMesEAno(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = new();
                using var contexto = new Contexto();
                meses.Janeiro =
                  contexto.TReceita.Where(cd => cd.Ano == ano && new[] { "Saldo da Carteira", "Renda" }.Contains(cd.NomeDaCategoria) && cd.Mes == "Janeiro")
                  .Select(cd => cd.Valor).Sum() +
                  contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Janeiro").Select(cd => cd.Valor).Sum() -
                  (contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Janeiro")
                  .Select(cd => cd.Valor).Sum() +
                  contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Janeiro")
                  .Select(cd => cd.Valor).Sum() +
                  contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Janeiro")
                  .Select(cd => cd.Valor).Sum());

                meses.Fevereiro =
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Fevereiro")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Fevereiro").Select(cd => cd.Valor).Sum() -
                   (contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Fevereiro")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Fevereiro")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Fevereiro")
                   .Select(cd => cd.Valor).Sum());
                meses.Fevereiro = meses.Janeiro + meses.Fevereiro;

                meses.Marco =
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Março")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Março").Select(cd => cd.Valor).Sum() -
                   (contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Março")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Março")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Março")
                   .Select(cd => cd.Valor).Sum());
                meses.Marco = meses.Fevereiro + meses.Marco;

                meses.Abril =
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Abril")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Abril").Select(cd => cd.Valor).Sum() -
                   (contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Abril")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Abril")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Abril")
                   .Select(cd => cd.Valor).Sum());
                meses.Abril = meses.Marco + meses.Abril;

                meses.Maio =
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Maio")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Maio").Select(cd => cd.Valor).Sum() -
                   (contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Maio")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Maio")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Maio")
                   .Select(cd => cd.Valor).Sum());
                meses.Maio = meses.Abril + meses.Maio;

                meses.Junho =
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Junho")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Junho").Select(cd => cd.Valor).Sum() -
                   (contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Junho")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Junho")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Junho")
                   .Select(cd => cd.Valor).Sum());
                meses.Junho = meses.Maio + meses.Junho;

                meses.Julho =
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Julho")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Julho").Select(cd => cd.Valor).Sum() -
                   (contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Julho")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Julho")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Julho")
                   .Select(cd => cd.Valor).Sum());
                meses.Julho = meses.Junho + meses.Julho;

                meses.Agosto =
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Agôsto")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Agôsto").Select(cd => cd.Valor).Sum() -
                   (contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Agôsto")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Agôsto")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Agôsto")
                   .Select(cd => cd.Valor).Sum());
                meses.Agosto = meses.Julho + meses.Agosto;

                meses.Setembro =
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Setembro")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Setembro").Select(cd => cd.Valor).Sum() -
                   (contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Setembro")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Setembro")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Setembro")
                   .Select(cd => cd.Valor).Sum());
                meses.Setembro = meses.Agosto + meses.Setembro;

                meses.Outubro =
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Outubro")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Outubro").Select(cd => cd.Valor).Sum() -
                   (contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Outubro")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Outubro")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Outubro")
                   .Select(cd => cd.Valor).Sum());
                meses.Outubro = meses.Setembro + meses.Outubro;

                meses.Novembro =
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Novembro")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Novembro").Select(cd => cd.Valor).Sum() -
                   (contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Novembro")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && new[] { "Depósito", "Depósito Inicial" }.Contains(cd.NomeDaSubCategoria) && cd.Mes == "Novembro")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Novembro")
                   .Select(cd => cd.Valor).Sum());
                meses.Novembro = meses.Outubro + meses.Novembro;

                meses.Dezembro =
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Dezembro")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Débito" && cd.Mes == "Dezembro").Select(cd => cd.Valor).Sum() -
                   (contexto.TReceita.Where(cd => cd.Ano == ano && cd.Tipo == "Despesa" && cd.Mes == "Dezembro")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaSubCategoria == "Depósito" && cd.Mes == "Dezembro")
                   .Select(cd => cd.Valor).Sum() +
                   contexto.TReceita.Where(cd => cd.Ano == ano && cd.NomeDaCategoria == "Renda" && cd.Mes == "Dezembro")
                   .Select(cd => cd.Valor).Sum());
                meses.Dezembro = meses.Novembro + meses.Dezembro;

                meses.SaldoCarteira = meses.Dezembro;

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception erro)
            {
                _nomeDoMetodo = "RelatorioDoSaldoDaCarteiraPorMesEAno";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(erro, _nomeDoMetodo);
                return new ListaDeMeses();
            }
        }
    }
}
