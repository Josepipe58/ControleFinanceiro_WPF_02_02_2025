using AcessarDadosDoBanco.ContextoDeDados;
using GerenciarDados.Listas;
using GerenciarDados.Mensagens;

namespace GerenciarDados.Relatorios
{
    public class RelatorioDeReceitas
    {
        private static string _nomeDoMetodo = string.Empty;
        private static readonly string[] saldoDaCarteiraRenda = ["Saldo da Carteira", "Renda", "Renda de Investimentos"]; 
        private static readonly string[] rendaTotal = ["Renda", "Renda de Investimentos"];
        
        public static ListaDeMeses RelatorioDeBenefíciosDoINSS(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Janeiro").Select(p => p.Valor).Sum();
                meses.Fevereiro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum();
                meses.Marco =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Março").Select(p => p.Valor).Sum();
                meses.Abril =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Abril").Select(p => p.Valor).Sum();
                meses.Maio =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Maio").Select(p => p.Valor).Sum();
                meses.Junho =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Junho").Select(p => p.Valor).Sum();
                meses.Julho =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Julho").Select(p => p.Valor).Sum();
                meses.Agosto =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Agôsto").Select(p => p.Valor).Sum();
                meses.Setembro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Setembro").Select(p => p.Valor).Sum();
                meses.Outubro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Outubro").Select(p => p.Valor).Sum();
                meses.Novembro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Novembro").Select(p => p.Valor).Sum();
                meses.Dezembro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita" && p.Mes == "Dezembro").Select(p => p.Valor).Sum();
                meses.TotalAno =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Tipo == "Receita").Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);
                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "RelatorioDeBenefíciosDoINSS";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses RelatorioDeBenefíciosDoINSSJurosDaPoupancaEBonus(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
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
            catch (Exception ex)
            {
                _nomeDoMetodo = "RelatorioDeBenefíciosDoINSSJurosDaPoupancaEBonus";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses RelatorioDeDescontosNoBeneficioDoINSS(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Janeiro").Select(p => p.Valor).Sum();
                meses.Fevereiro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum();
                meses.Marco =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Março").Select(p => p.Valor).Sum();
                meses.Abril =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Abril").Select(p => p.Valor).Sum();
                meses.Maio =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Maio").Select(p => p.Valor).Sum();
                meses.Junho =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Junho").Select(p => p.Valor).Sum();
                meses.Julho =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Julho").Select(p => p.Valor).Sum();
                meses.Agosto =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Agôsto").Select(p => p.Valor).Sum();
                meses.Setembro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Setembro").Select(p => p.Valor).Sum();
                meses.Outubro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Outubro").Select(p => p.Valor).Sum();
                meses.Novembro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Novembro").Select(p => p.Valor).Sum();
                meses.Dezembro =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS" && p.Mes == "Dezembro").Select(p => p.Valor).Sum();
                meses.TotalAno =
                    contexto.TReceita.Where(p => p.Ano == ano && p.NomeDaCategoria == "Descontos no Benefício do INSS").Select(p => p.Valor).Sum();

                listaDeMeses.Add(meses);
                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "RelatorioDeDescontosNoBeneficioDoINSS";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses RelatorioDoFluxoDeCaixaReceitasMenosDespesas(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TReceita.Where(r => r.Ano == ano && saldoDaCarteiraRenda.Contains(r.NomeDaCategoria) && r.Mes == "Janeiro").Select(r => r.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Janeiro").Select(p => p.Valor).Sum() +
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Janeiro").Select(d => d.Valor).Sum());
                meses.Fevereiro =
                    contexto.TReceita.Where(r => r.Ano == ano && saldoDaCarteiraRenda.Contains(r.NomeDaCategoria) && r.Mes == "Fevereiro").Select(r => r.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum() +
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Fevereiro").Select(d => d.Valor).Sum());
                meses.Marco =
                     contexto.TReceita.Where(r => r.Ano == ano && rendaTotal.Contains(r.NomeDaCategoria) && r.Mes == "Março").Select(r => r.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Março").Select(p => p.Valor).Sum() +
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Março").Select(d => d.Valor).Sum());
                meses.Abril =
                     contexto.TReceita.Where(r => r.Ano == ano && rendaTotal.Contains(r.NomeDaCategoria) && r.Mes == "Abril").Select(r => r.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Abril").Select(p => p.Valor).Sum() +
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Abril").Select(d => d.Valor).Sum());
                meses.Maio = 
                    contexto.TReceita.Where(r => r.Ano == ano && rendaTotal.Contains(r.NomeDaCategoria) && r.Mes == "Maio").Select(r => r.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Maio").Select(p => p.Valor).Sum() +
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Maio").Select(d => d.Valor).Sum());
                meses.Junho =
                    contexto.TReceita.Where(r => r.Ano == ano && rendaTotal.Contains(r.NomeDaCategoria) && r.Mes == "Junho").Select(r => r.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Junho").Select(p => p.Valor).Sum() +
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Junho").Select(d => d.Valor).Sum());
                meses.Julho =
                    contexto.TReceita.Where(r => r.Ano == ano && rendaTotal.Contains(r.NomeDaCategoria) && r.Mes == "Julho").Select(r => r.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Julho").Select(p => p.Valor).Sum() +
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Julho").Select(d => d.Valor).Sum());
                meses.Agosto =
                    contexto.TReceita.Where(r => r.Ano == ano && rendaTotal.Contains(r.NomeDaCategoria) && r.Mes == "Agôsto").Select(r=> r.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Agôsto").Select(p => p.Valor).Sum() +
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Agôsto").Select(d => d.Valor).Sum());
                meses.Setembro =
                    contexto.TReceita.Where(r => r.Ano == ano && rendaTotal.Contains(r.NomeDaCategoria) && r.Mes == "Setembro").Select(r => r.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Setembro").Select(p => p.Valor).Sum() +
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Setembro").Select(d => d.Valor).Sum());
                meses.Outubro =
                    contexto.TReceita.Where(r => r.Ano == ano && rendaTotal.Contains(r.NomeDaCategoria) && r.Mes == "Outubro").Select(r => r.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Outubro").Select(p => p.Valor).Sum() +
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Outubro").Select(d => d.Valor).Sum());
                meses.Novembro =
                    contexto.TReceita.Where(r => r.Ano == ano && rendaTotal.Contains(r.NomeDaCategoria) && r.Mes == "Novembro").Select(r => r.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Novembro").Select(p => p.Valor).Sum() +
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Novembro").Select(d => d.Valor).Sum());
                meses.Dezembro =
                    contexto.TReceita.Where(r => r.Ano == ano && rendaTotal.Contains(r.NomeDaCategoria) && r.Mes == "Dezembro").Select(r => r.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Dezembro").Select(p => p.Valor).Sum() +
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Dezembro").Select(d => d.Valor).Sum());
                meses.TotalAno =
                    contexto.TReceita.Where(r => r.Ano == ano && saldoDaCarteiraRenda.Contains(r.NomeDaCategoria)).Select(r => r.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa").Select(p => p.Valor).Sum() +
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Tipo == "Despesa").Select(d => d.Valor).Sum());

                listaDeMeses.Add(meses);
                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "RelatorioDoFluxoDeCaixaReceitasMenosDespesas";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }

        public static ListaDeMeses RelatorioDoSaldoDaCarteiraPorMesEAno(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                meses.Janeiro =
                  (contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Saldo da Carteira" && r.Mes == "Janeiro").Select(r => r.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Janeiro").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Janeiro").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Janeiro").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Janeiro").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Janeiro").Select(r => r.Valor).Sum());

                meses.Fevereiro =
                  (contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Saldo da Carteira" && r.Mes == "Fevereiro").Select(r => r.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Fevereiro").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Fevereiro").Select(r => r.Valor).Sum());
                meses.Fevereiro = meses.Janeiro + meses.Fevereiro;

                meses.Marco =
                  (contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Março").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Março").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Março").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Março").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Março").Select(r => r.Valor).Sum());
                meses.Marco = meses.Fevereiro + meses.Marco;

                meses.Abril =
                  (contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Abril").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Abril").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Abril").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Abril").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Abril").Select(r => r.Valor).Sum());
                meses.Abril = meses.Marco + meses.Abril;

                meses.Maio =
                  (contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Maio").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Maio").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Maio").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Maio").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Maio").Select(r => r.Valor).Sum());
                meses.Maio = meses.Abril + meses.Maio;

                meses.Junho =
                  (contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Junho").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Junho").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Junho").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Junho").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Junho").Select(r => r.Valor).Sum());
                meses.Junho = meses.Maio + meses.Junho;

                meses.Julho =
                  (contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Julho").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Julho").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Julho").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Julho").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Julho").Select(r => r.Valor).Sum());
                meses.Julho = meses.Junho + meses.Julho;

                meses.Agosto =
                  (contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Agôsto").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Agôsto").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Agôsto").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Agôsto").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Agôsto").Select(r => r.Valor).Sum());
                meses.Agosto = meses.Julho + meses.Agosto;

                meses.Setembro =
                  (contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Setembro").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Setembro").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Setembro").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Setembro").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Setembro").Select(r => r.Valor).Sum());
                meses.Setembro = meses.Agosto + meses.Setembro;

                meses.Outubro =
                  (contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Outubro").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Outubro").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Outubro").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Outubro").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Outubro").Select(r => r.Valor).Sum());
                meses.Outubro = meses.Setembro + meses.Outubro;

                meses.Novembro =
                  (contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Novembro").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Novembro").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Novembro").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Novembro").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Novembro").Select(r => r.Valor).Sum());
                meses.Novembro = meses.Outubro + meses.Novembro;

                meses.Dezembro =
                  (contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Dezembro").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Dezembro").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Dezembro").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Depósito" && p.Mes == "Dezembro").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Dezembro").Select(r => r.Valor).Sum());
                meses.Dezembro = meses.Novembro + meses.Dezembro;

                meses.SaldoCarteira = meses.Dezembro;

                listaDeMeses.Add(meses);

                return listaDeMeses;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "RelatorioDoSaldoDaCarteiraPorMesEAno";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return [];
            }
        }
    }
}
