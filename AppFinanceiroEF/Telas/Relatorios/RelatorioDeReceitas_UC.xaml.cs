using GerenciarDados.Mensagens;
using GerenciarDados.AcessarDados;
using GerenciarDados.Relatorios;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppFinanceiroEF.Telas.Relatorios
{
    public partial class RelatorioDeReceitas_UC : UserControl
    {
        private static string _nomeDoMetodo = string.Empty;

        public RelatorioDeReceitas_UC()
        {
            InitializeComponent();
            CarregarComboBoxAno();
        }

        public void CarregarComboBoxAno()
        {
            try
            {
                Ano_AD ano_AD = new();
                CbxAno.ItemsSource = ano_AD.SelecionarTodos().ToList();
                CbxAno.DisplayMemberPath = "AnoDoCadastro";
                CbxAno.SelectedValuePath = "Id";
                CbxAno.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "CarregarComboBoxAno";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
            RelatoriosDeReceitas();
        }

        public void RelatoriosDeReceitas()
        {
            try
            {
                //Benefícios do INSS.
                DtgBeneficiosDoINSS.ItemsSource = RelatorioDeReceitas
                    .RelatorioDeBenefíciosDoINSS(Convert.ToInt32(CbxAno.Text));

                //Benefícios do INSS, Juros da Poupança e Investimrntos.
                DtgBeneficiosJurosEInvestimentos.ItemsSource = RelatorioDeReceitas
                    .RelatorioDeBenefíciosDoINSSJurosDaPoupancaEBonus(Convert.ToInt32(CbxAno.Text));

                //Fluxo de Caixa - Receitas Menos Despesas.
                DtgFluxoDeCaixa.ItemsSource = RelatorioDeReceitas
                    .RelatorioDoFluxoDeCaixaReceitasMenosDespesas(Convert.ToInt32(CbxAno.Text));

                //Descontos no Benefício.
                DtgDescontosNoBeneficio.ItemsSource = RelatorioDeReceitas
                    .RelatorioDeDescontosNoBeneficioDoINSS(Convert.ToInt32(CbxAno.Text));

                //Saldo da Carteira.
                DtgSaldoCarteira.ItemsSource = RelatorioDeReceitas
                    .RelatorioDoSaldoDaCarteiraPorMesEAno(Convert.ToInt32(CbxAno.Text));
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "RelatoriosDeReceitas";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
        }

        private void CbxAno_MouseLeave(object sender, MouseEventArgs e)
        {
            RelatoriosDeReceitas();
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregarComboBoxAno();
        }
    }
}
