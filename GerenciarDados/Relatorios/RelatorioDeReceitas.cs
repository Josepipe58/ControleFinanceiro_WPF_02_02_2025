using AcessarDadosDoBanco.ContextoDeDados;
using GerenciarDados.Listas;
using GerenciarDados.Mensagens;

namespace GerenciarDados.Relatorios
{
    public class RelatorioDeReceitas
    {
        private static string _nomeDoMetodo = string.Empty;
        private static readonly string[] rendaAposentadoriaEDecimoTerceiro = ["Aposentadoria", "Décimo Terceiro"];
        private static readonly string[] fluxoDeCaixaSaldoDaCarteiraRenda = ["Renda", "Renda de Investimentos"]; 
        private static readonly string[] rendaTotal = ["Renda", "Renda de Investimentos"];
        private static readonly string[] rendaCreditosPoupanca = ["Renda", "Créditos da Poupança"];
        private static readonly string[] saldoDaCarteiraRenda = ["Saldo da Carteira", "Renda"];

        public static ListaDeMeses RelatorioDeBenefíciosDoINSS(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TReceita.Where(r => r.Ano == ano && rendaAposentadoriaEDecimoTerceiro.Contains(r.NomeDaSubCategoria) && r.Mes == "Janeiro").Select(r => r.Valor).Sum();
                meses.Fevereiro =
                    contexto.TReceita.Where(r => r.Ano == ano && rendaAposentadoriaEDecimoTerceiro.Contains(r.NomeDaSubCategoria) && r.Mes == "Fevereiro").Select(r => r.Valor).Sum();
                meses.Marco =
                    contexto.TReceita.Where(r => r.Ano == ano && rendaAposentadoriaEDecimoTerceiro.Contains(r.NomeDaSubCategoria) && r.Mes == "Março").Select(r => r.Valor).Sum();
                meses.Abril =
                    contexto.TReceita.Where(r => r.Ano == ano && rendaAposentadoriaEDecimoTerceiro.Contains(r.NomeDaSubCategoria) && r.Mes == "Abril").Select(r => r.Valor).Sum();
                meses.Maio =
                    contexto.TReceita.Where(r => r.Ano == ano && rendaAposentadoriaEDecimoTerceiro.Contains(r.NomeDaSubCategoria) && r.Mes == "Maio").Select(r => r.Valor).Sum();
                meses.Junho =
                    contexto.TReceita.Where(r => r.Ano == ano && rendaAposentadoriaEDecimoTerceiro.Contains(r.NomeDaSubCategoria) && r.Mes == "Junho").Select(r => r.Valor).Sum();
                meses.Julho =
                    contexto.TReceita.Where(r => r.Ano == ano && rendaAposentadoriaEDecimoTerceiro.Contains(r.NomeDaSubCategoria) && r.Mes == "Julho").Select(r => r.Valor).Sum();
                meses.Agosto =
                    contexto.TReceita.Where(r => r.Ano == ano && rendaAposentadoriaEDecimoTerceiro.Contains(r.NomeDaSubCategoria) && r.Mes == "Agôsto").Select(r => r.Valor).Sum();
                meses.Setembro =
                    contexto.TReceita.Where(r => r.Ano == ano && rendaAposentadoriaEDecimoTerceiro.Contains(r.NomeDaSubCategoria) && r.Mes == "Setembro").Select(r => r.Valor).Sum();
                meses.Outubro =
                    contexto.TReceita.Where(r => r.Ano == ano && rendaAposentadoriaEDecimoTerceiro.Contains(r.NomeDaSubCategoria) && r.Mes == "Outubro").Select(r => r.Valor).Sum();
                meses.Novembro =
                    contexto.TReceita.Where(r => r.Ano == ano && rendaAposentadoriaEDecimoTerceiro.Contains(r.NomeDaSubCategoria) && r.Mes == "Novembro").Select(r => r.Valor).Sum();
                meses.Dezembro =
                    contexto.TReceita.Where(r => r.Ano == ano && rendaAposentadoriaEDecimoTerceiro.Contains(r.NomeDaSubCategoria) && r.Mes == "Dezembro").Select(r => r.Valor).Sum();
                meses.TotalAno =
                    contexto.TReceita.Where(r => r.Ano == ano && rendaAposentadoriaEDecimoTerceiro.Contains(r.NomeDaSubCategoria)).Select(r => r.Valor).Sum();

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

        public static ListaDeMeses RelatorioDeTodasAsReceitas(int ano)
        {
            try
            {
                Meses meses = new();
                ListaDeMeses listaDeMeses = [];
                using var contexto = new Contexto();
                meses.Janeiro =
                    contexto.TReceita.Where(r => r.Ano == ano && rendaTotal.Contains(r.NomeDaCategoria) && r.Mes == "Janeiro").Select(r => r.Valor).Sum();
                meses.Fevereiro =
                    contexto.TReceita.Where(r => r.Ano == ano && rendaTotal.Contains(r.NomeDaCategoria) && r.Mes == "Fevereiro").Select(r => r.Valor).Sum();
                meses.Marco =                                   
                    contexto.TReceita.Where(r => r.Ano == ano && rendaTotal.Contains(r.NomeDaCategoria) && r.Mes == "Março").Select(r => r.Valor).Sum();
                meses.Abril =                                   
                    contexto.TReceita.Where(r => r.Ano == ano && rendaTotal.Contains(r.NomeDaCategoria) && r.Mes == "Abril").Select(r => r.Valor).Sum();
                meses.Maio =                                    
                    contexto.TReceita.Where(r => r.Ano == ano && rendaTotal.Contains(r.NomeDaCategoria) && r.Mes == "Maio").Select(r => r.Valor).Sum();
                meses.Junho =                                    
                    contexto.TReceita.Where(r => r.Ano == ano && rendaTotal.Contains(r.NomeDaCategoria) && r.Mes == "Junho").Select(r => r.Valor).Sum();
                meses.Julho =                                    
                    contexto.TReceita.Where(r => r.Ano == ano && rendaTotal.Contains(r.NomeDaCategoria) && r.Mes == "Julho").Select(r => r.Valor).Sum();
                meses.Agosto =                                   
                    contexto.TReceita.Where(r => r.Ano == ano && rendaTotal.Contains(r.NomeDaCategoria) && r.Mes == "Agôsto").Select(r => r.Valor).Sum();
                meses.Setembro =                                 
                    contexto.TReceita.Where(r => r.Ano == ano && rendaTotal.Contains(r.NomeDaCategoria) && r.Mes == "Setembro").Select(r => r.Valor).Sum();
                meses.Outubro =                                  
                    contexto.TReceita.Where(r => r.Ano == ano && rendaTotal.Contains(r.NomeDaCategoria) && r.Mes == "Outubro").Select(r => r.Valor).Sum();
                meses.Novembro =                                 
                    contexto.TReceita.Where(r => r.Ano == ano && rendaTotal.Contains(r.NomeDaCategoria) && r.Mes == "Novembro").Select(r => r.Valor).Sum();
                meses.Dezembro =                                 
                    contexto.TReceita.Where(r => r.Ano == ano && rendaTotal.Contains(r.NomeDaCategoria) && r.Mes == "Dezembro").Select(r => r.Valor).Sum();
                meses.TotalAno =                                 
                    contexto.TReceita.Where(r => r.Ano == ano && rendaTotal.Contains(r.NomeDaCategoria)).Select(r => r.Valor).Sum();

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
                    contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Descontos no Benefício do INSS" && r.Mes == "Janeiro").Select(r => r.Valor).Sum();
                meses.Fevereiro =
                    contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Descontos no Benefício do INSS" && r.Mes == "Fevereiro").Select(r => r.Valor).Sum();
                meses.Marco =
                    contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Descontos no Benefício do INSS" && r.Mes == "Março").Select(r => r.Valor).Sum();
                meses.Abril =
                    contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Descontos no Benefício do INSS" && r.Mes == "Abril").Select(r => r.Valor).Sum();
                meses.Maio =
                    contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Descontos no Benefício do INSS" && r.Mes == "Maio").Select(r => r.Valor).Sum();
                meses.Junho =
                    contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Descontos no Benefício do INSS" && r.Mes == "Junho").Select(r => r.Valor).Sum();
                meses.Julho =
                    contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Descontos no Benefício do INSS" && r.Mes == "Julho").Select(r => r.Valor).Sum();
                meses.Agosto =
                    contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Descontos no Benefício do INSS" && r.Mes == "Agôsto").Select(r => r.Valor).Sum();
                meses.Setembro =
                    contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Descontos no Benefício do INSS" && r.Mes == "Setembro").Select(r => r.Valor).Sum();
                meses.Outubro =
                    contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Descontos no Benefício do INSS" && r.Mes == "Outubro").Select(r => r.Valor).Sum();
                meses.Novembro =
                    contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Descontos no Benefício do INSS" && r.Mes == "Novembro").Select(r => r.Valor).Sum();
                meses.Dezembro =
                    contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Descontos no Benefício do INSS" && r.Mes == "Dezembro").Select(r => r.Valor).Sum();
                meses.TotalAno =
                    contexto.TReceita.Where(r => r.Ano == ano && r.NomeDaCategoria == "Descontos no Benefício do INSS").Select(r => r.Valor).Sum();

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
                    contexto.TReceita.Where(r => r.Ano == ano && fluxoDeCaixaSaldoDaCarteiraRenda.Contains(r.NomeDaCategoria) && r.Mes == "Janeiro").Select(r => r.Valor).Sum() -
                    (contexto.TPoupanca.Where(p => p.Ano == ano && p.Tipo == "Despesa" && p.Mes == "Janeiro").Select(p => p.Valor).Sum() +
                    contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Janeiro").Select(d => d.Valor).Sum());
                meses.Fevereiro =
                    contexto.TReceita.Where(r => r.Ano == ano && fluxoDeCaixaSaldoDaCarteiraRenda.Contains(r.NomeDaCategoria) && r.Mes == "Fevereiro").Select(r => r.Valor).Sum() -
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
                    contexto.TReceita.Where(r => r.Ano == ano && fluxoDeCaixaSaldoDaCarteiraRenda.Contains(r.NomeDaCategoria)).Select(r => r.Valor).Sum() -
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
                  (contexto.TReceita.Where(r => r.Ano == ano && saldoDaCarteiraRenda.Contains(r.NomeDaCategoria) && r.Mes == "Janeiro").Select(r => r.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Janeiro").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Janeiro").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Janeiro").Select(r => r.Valor).Sum());

                meses.Fevereiro =
                  (contexto.TReceita.Where(r => r.Ano == ano && saldoDaCarteiraRenda.Contains(r.NomeDaCategoria) && r.Mes == "Fevereiro").Select(r => r.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Fevereiro").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Fevereiro").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Fevereiro").Select(r => r.Valor).Sum());
                meses.Fevereiro = meses.Janeiro + meses.Fevereiro;

                meses.Marco =
                  (contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Março").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Março").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Março").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Março").Select(r => r.Valor).Sum());
                meses.Marco = meses.Fevereiro + meses.Marco;

                meses.Abril =
                  (contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Abril").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Abril").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Abril").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Abril").Select(r => r.Valor).Sum());
                meses.Abril = meses.Marco + meses.Abril;

                meses.Maio =
                  (contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Maio").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Maio").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Maio").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Maio").Select(r => r.Valor).Sum());
                meses.Maio = meses.Abril + meses.Maio;

                meses.Junho =
                  (contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Junho").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Junho").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Junho").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Junho").Select(r => r.Valor).Sum());
                meses.Junho = meses.Maio + meses.Junho;

                meses.Julho =
                  (contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Julho").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Julho").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Julho").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Julho").Select(r => r.Valor).Sum());
                meses.Julho = meses.Junho + meses.Julho;

                meses.Agosto =
                  (contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Agôsto").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Agôsto").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Agôsto").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Agôsto").Select(r => r.Valor).Sum());
                meses.Agosto = meses.Julho + meses.Agosto;

                meses.Setembro =
                  (contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Setembro").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Setembro").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Setembro").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Setembro").Select(r => r.Valor).Sum());
                meses.Setembro = meses.Agosto + meses.Setembro;

                meses.Outubro =
                  (contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Outubro").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Outubro").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Outubro").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Outubro").Select(r => r.Valor).Sum());
                meses.Outubro = meses.Setembro + meses.Outubro;

                meses.Novembro =
                  (contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Novembro").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Novembro").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Novembro").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Novembro").Select(r => r.Valor).Sum());
                meses.Novembro = meses.Outubro + meses.Novembro;

                meses.Dezembro =
                  (contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaCategoria == "Renda" && p.Mes == "Dezembro").Select(p => p.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && p.NomeDaSubCategoria == "Saque" && p.Mes == "Dezembro").Select(p => p.Valor).Sum()) -

                  (contexto.TDespesa.Where(d => d.Ano == ano && d.Mes == "Dezembro").Select(d => d.Valor).Sum() +
                  contexto.TPoupanca.Where(p => p.Ano == ano && rendaCreditosPoupanca.Contains(p.NomeDaCategoria) && p.Mes == "Dezembro").Select(r => r.Valor).Sum());
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
