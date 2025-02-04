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
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Janeiro")
                    .Select(p => p.Valor).Sum();
                meses.Fevereiro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Fevereiro")
                    .Select(p => p.Valor).Sum();
                meses.Marco =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Março")
                    .Select(p => p.Valor).Sum();
                meses.Abril =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Abril")
                    .Select(p => p.Valor).Sum();
                meses.Maio =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Maio")
                    .Select(p => p.Valor).Sum();
                meses.Junho =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Junho")
                    .Select(p => p.Valor).Sum();
                meses.Julho =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Julho")
                    .Select(p => p.Valor).Sum();
                meses.Agosto =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Agôsto")
                    .Select(p => p.Valor).Sum();
                meses.Setembro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Setembro")
                    .Select(p => p.Valor).Sum();
                meses.Outubro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Outubro")
                    .Select(p => p.Valor).Sum();
                meses.Novembro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Novembro")
                    .Select(p => p.Valor).Sum();
                meses.Dezembro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Dezembro")
                    .Select(p => p.Valor).Sum();
                meses.TotalAno =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita").Select(p => p.Valor).Sum();

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
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Janeiro").Select(p => p.Valor).Sum();
                meses.Fevereiro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum();
                meses.Marco =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Março").Select(p => p.Valor).Sum();
                meses.Abril =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Abril").Select(p => p.Valor).Sum();
                meses.Maio =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Maio").Select(p => p.Valor).Sum();
                meses.Junho =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Junho").Select(p => p.Valor).Sum();
                meses.Julho =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Julho").Select(p => p.Valor).Sum();
                meses.Agosto =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Agôsto").Select(p => p.Valor).Sum();
                meses.Setembro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Setembro").Select(p => p.Valor).Sum();
                meses.Outubro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Outubro").Select(p => p.Valor).Sum();
                meses.Novembro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Novembro").Select(p => p.Valor).Sum();
                meses.Dezembro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Dezembro").Select(p => p.Valor).Sum();
                meses.TotalAno =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda").Select(p => p.Valor).Sum();

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
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Janeiro")
                    .Select(p => p.Valor).Sum();
                meses.Fevereiro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Fevereiro")
                    .Select(p => p.Valor).Sum();
                meses.Marco =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Março")
                    .Select(p => p.Valor).Sum();
                meses.Abril =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Abril")
                    .Select(p => p.Valor).Sum();
                meses.Maio =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Maio")
                    .Select(p => p.Valor).Sum();
                meses.Junho =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Junho")
                    .Select(p => p.Valor).Sum();
                meses.Julho =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Julho")
                    .Select(p => p.Valor).Sum();
                meses.Agosto =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Agôsto")
                    .Select(p => p.Valor).Sum();
                meses.Setembro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Setembro")
                    .Select(p => p.Valor).Sum();
                meses.Outubro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Outubro")
                    .Select(p => p.Valor).Sum();
                meses.Novembro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Novembro")
                    .Select(p => p.Valor).Sum();
                meses.Dezembro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Dezembro")
                    .Select(p => p.Valor).Sum();
                meses.TotalAno =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS")
                    .Select(p => p.Valor).Sum();

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
                    contexto.TReceita.Where(p => p.Ano == ano && new[] { "Saldo da Carteira", "Renda" }.Contains(p.NomeDaCategoria) && p.Mes == "Janeiro")
                    .Select(p => p.Valor).Sum() -
                    contexto.TReceita.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Janeiro").Select(p => p.Valor).Sum();
                meses.Fevereiro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum() -
                    contexto.TReceita.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum();
                meses.Marco =
                     contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Março").Select(p => p.Valor).Sum() -
                    contexto.TReceita.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Março").Select(p => p.Valor).Sum();
                meses.Abril =
                     contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Abril").Select(p => p.Valor).Sum() -
                    contexto.TReceita.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Abril").Select(p => p.Valor).Sum();
                meses.Maio =
                     contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Maio").Select(p => p.Valor).Sum() -
                    contexto.TReceita.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Maio").Select(p => p.Valor).Sum();
                meses.Junho =
                     contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Junho").Select(p => p.Valor).Sum() -
                    contexto.TReceita.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Junho").Select(p => p.Valor).Sum();
                meses.Julho =
                     contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Julho").Select(p => p.Valor).Sum() -
                    contexto.TReceita.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Julho").Select(p => p.Valor).Sum();
                meses.Agosto =
                     contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Agôsto").Select(p => p.Valor).Sum() -
                    contexto.TReceita.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Agôsto").Select(p => p.Valor).Sum();
                meses.Setembro =
                     contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Setembro").Select(p => p.Valor).Sum() -
                    contexto.TReceita.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Setembro").Select(p => p.Valor).Sum();
                meses.Outubro =
                     contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Outubro").Select(p => p.Valor).Sum() -
                    contexto.TReceita.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Outubro").Select(p => p.Valor).Sum();
                meses.Novembro =
                     contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Novembro").Select(p => p.Valor).Sum() -
                    contexto.TReceita.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Novembro").Select(p => p.Valor).Sum();
                meses.Dezembro =
                     contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Dezembro").Select(p => p.Valor).Sum() -
                    contexto.TReceita.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Dezembro").Select(p => p.Valor).Sum();
                meses.TotalAno =
                     contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda").Select(p => p.Valor).Sum() -
                    contexto.TReceita.Where(p => p.Ano == ano && p.Tipo == "Despesa").Select(p => p.Valor).Sum();

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
                  contexto.TReceita.Where(r => r.Ano == ano && new[] { "Saldo da Carteira", "Renda" }.Contains(r.NomeDaCategoria) && r.Mes == "Janeiro")
                  .Select(r => r.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Janeiro").Select(p => p.Valor).Sum() -
                  (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Janeiro").Select(p => p.Valor).Sum() +

                  contexto.TDespesa.Where(d => d.Ano == ano && d.Tipo == "Despesa" && d.Mes == "Janeiro").Select(d => d.Valor).Sum() +

                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Janeiro")
                  .Select(p => p.Valor).Sum() +
                  contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Renda" && r.Mes == "Janeiro")
                  .Select(r => r.Valor).Sum());

                meses.Fevereiro =
                   contexto.TReceita.Where(r => r.Ano == ano && new[] { "Saldo da Carteira", "Renda" }.Contains(r.NomeDaCategoria) && r.Mes == "Fevereiro")
                   .Select(r => r.Valor).Sum() +
                   contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum() -
                   (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum() +

                   contexto.TDespesa.Where(d => d.Ano == ano && d.Tipo == "Despesa" && d.Mes == "Fevereiro").Select(d => d.Valor).Sum() +

                   contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Fevereiro")
                   .Select(p => p.Valor).Sum() +
                   contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Renda" && r.Mes == "Fevereiro")
                   .Select(r => r.Valor).Sum());
                meses.Fevereiro = meses.Janeiro + meses.Fevereiro;

                meses.Marco =
                   contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Renda" && r.Mes == "Março")
                   .Select(r => r.Valor).Sum() +
                   contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Março").Select(p => p.Valor).Sum() -
                   (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Março").Select(p => p.Valor).Sum() +

                    contexto.TDespesa.Where(d => d.Ano == ano && d.Tipo == "Despesa" && d.Mes == "Mrço").Select(d => d.Valor).Sum() +

                   contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Março")
                   .Select(p => p.Valor).Sum() +
                   contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Renda" && r.Mes == "Março")
                   .Select(r => r.Valor).Sum());
                meses.Marco = meses.Fevereiro + meses.Marco;

                meses.Abril =
                   contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Renda" && r.Mes == "Abril")
                   .Select(r => r.Valor).Sum() +
                   contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Abril").Select(p => p.Valor).Sum() -
                   (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Abril").Select(p => p.Valor).Sum() +

                    contexto.TDespesa.Where(d => d.Ano == ano && d.Tipo == "Despesa" && d.Mes == "Abril").Select(d => d.Valor).Sum() +

                   contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Abril")
                   .Select(p => p.Valor).Sum() +
                   contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Renda" && r.Mes == "Abril")
                   .Select(r => r.Valor).Sum());
                meses.Abril = meses.Marco + meses.Abril;

                meses.Maio =
                   contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Renda" && r.Mes == "Maio")
                   .Select(r => r.Valor).Sum() +
                   contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Maio").Select(p => p.Valor).Sum() -
                   (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Maio").Select(p => p.Valor).Sum() +

                    contexto.TDespesa.Where(d => d.Ano == ano && d.Tipo == "Despesa" && d.Mes == "Maio").Select(d => d.Valor).Sum() +

                   contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Maio")
                   .Select(p => p.Valor).Sum() +
                   contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Renda" && r.Mes == "Maio")
                   .Select(r => r.Valor).Sum());
                meses.Maio = meses.Abril + meses.Maio;

                meses.Junho =
                   contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Renda" && r.Mes == "Junho")
                   .Select(r => r.Valor).Sum() +
                   contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Junho").Select(p => p.Valor).Sum() -
                   (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Junho").Select(p => p.Valor).Sum() +

                    contexto.TDespesa.Where(d => d.Ano == ano && d.Tipo == "Despesa" && d.Mes == "Junho").Select(d => d.Valor).Sum() +

                   contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Junho")
                   .Select(p => p.Valor).Sum() +
                   contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Renda" && r.Mes == "Junho")
                   .Select(r => r.Valor).Sum());
                meses.Junho = meses.Maio + meses.Junho;

                meses.Julho =
                   contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Renda" && r.Mes == "Julho")
                   .Select(r => r.Valor).Sum() +
                   contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Julho").Select(p => p.Valor).Sum() -
                   (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Julho").Select(p => p.Valor).Sum() +

                    contexto.TDespesa.Where(d => d.Ano == ano && d.Tipo == "Despesa" && d.Mes == "Julho").Select(d => d.Valor).Sum() +

                   contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Julho")
                   .Select(p => p.Valor).Sum() +
                   contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Renda" && r.Mes == "Julho")
                   .Select(r => r.Valor).Sum());
                meses.Julho = meses.Junho + meses.Julho;

                meses.Agosto =
                   contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Renda" && r.Mes == "Agôsto")
                   .Select(r => r.Valor).Sum() +
                   contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Agôsto").Select(p => p.Valor).Sum() -
                   (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Agôsto").Select(p => p.Valor).Sum() +

                    contexto.TDespesa.Where(d => d.Ano == ano && d.Tipo == "Despesa" && d.Mes == "Agôsto").Select(d => d.Valor).Sum() +

                   contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Agôsto")
                   .Select(p => p.Valor).Sum() +
                   contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Renda" && r.Mes == "Agôsto")
                   .Select(r => r.Valor).Sum());
                meses.Agosto = meses.Julho + meses.Agosto;

                meses.Setembro =
                   contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Renda" && r.Mes == "Setembro")
                   .Select(r => r.Valor).Sum() +
                   contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Setembro").Select(p => p.Valor).Sum() -
                   (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Setembro").Select(p => p.Valor).Sum() +

                    contexto.TDespesa.Where(d => d.Ano == ano && d.Tipo == "Despesa" && d.Mes == "Setembro").Select(d => d.Valor).Sum() +

                   contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Setembro")
                   .Select(p => p.Valor).Sum() +
                   contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Renda" && r.Mes == "Setembro")
                   .Select(r => r.Valor).Sum());
                meses.Setembro = meses.Agosto + meses.Setembro;

                meses.Outubro =
                   contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Renda" && r.Mes == "Outubro")
                   .Select(r => r.Valor).Sum() +
                   contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Outubro").Select(p => p.Valor).Sum() -
                   (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Outubro").Select(p => p.Valor).Sum() +

                    contexto.TDespesa.Where(d => d.Ano == ano && d.Tipo == "Despesa" && d.Mes == "Outubro").Select(d => d.Valor).Sum() +

                   contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Outubro")
                   .Select(p => p.Valor).Sum() +
                   contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Renda" && r.Mes == "Outubro")
                   .Select(r => r.Valor).Sum());
                meses.Outubro = meses.Setembro + meses.Outubro;

                meses.Novembro =
                   contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Renda" && r.Mes == "Novembro")
                   .Select(r => r.Valor).Sum() +
                   contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Novembro").Select(p => p.Valor).Sum() -
                   (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Novembro").Select(p => p.Valor).Sum() +

                    contexto.TDespesa.Where(d => d.Ano == ano && d.Tipo == "Despesa" && d.Mes == "Novembro").Select(d => d.Valor).Sum() +

                   contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Novembro")
                   .Select(p => p.Valor).Sum() +
                   contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Renda" && r.Mes == "Novembro")
                   .Select(r => r.Valor).Sum());
                meses.Novembro = meses.Outubro + meses.Novembro;

                meses.Dezembro =
                   contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Renda" && r.Mes == "Dezembro")
                   .Select(r => r.Valor).Sum() +
                   contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Débito" && p.Mes == "Dezembro").Select(p => p.Valor).Sum() -
                   (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Dezembro").Select(p => p.Valor).Sum() +

                    contexto.TDespesa.Where(d => d.Ano == ano && d.Tipo == "Despesa" && d.Mes == "Dezembro").Select(d => d.Valor).Sum() +

                   contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Dezembro")
                   .Select(p => p.Valor).Sum() +
                   contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Renda" && r.Mes == "Dezembro")
                   .Select(r => r.Valor).Sum());
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
