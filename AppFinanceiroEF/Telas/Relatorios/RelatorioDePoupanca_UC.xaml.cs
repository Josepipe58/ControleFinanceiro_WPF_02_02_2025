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
    public partial class RelatorioDePoupanca_UC : UserControl
    {
        private static string _nomeDoMetodo = string.Empty;

        public RelatorioDePoupanca_UC()
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
            RelatoriosDaPoupanca();
        }

        public void RelatoriosDaPoupanca()
        {
            try
            {
                //Saldo Total da Poupança, Receitas e Investimentos.                
                DtgSaldoTotalDaPoupancaReceitasEInvestimentos.ItemsSource = RelatorioDePoupanca
                    .RelatorioDoSaldoTotalDaPoupancaReceitasEInvestimentos(Convert.ToInt32(CbxAno.Text));

                //Saldo Total da Poupança.
                DtgSaldoTotalDaPoupanca.ItemsSource = RelatorioDePoupanca
                    .RelatorioDoSaldoTotalDaPoupanca(Convert.ToInt32(CbxAno.Text));

                //Juros da Poupança
                DtgJurosDaPoupanca.ItemsSource = RelatorioDePoupanca
                    .RelatorioDosJurosDaPoupanca(Convert.ToInt32(CbxAno.Text));

                //Rendimentos entre Depósitos, Juros e Saques.
                DtgRendimentosDepositoJurosSaques.ItemsSource = RelatorioDePoupanca
                    .RelatorioDosRendimentosEntreDepositosJurosESaques(Convert.ToInt32(CbxAno.Text));

                //Pagamentos e Tranferências.
                DtgPagamentosETransferencia.ItemsSource = RelatorioDePoupanca
                    .RelatorioDePagamentosETranferencias(Convert.ToInt32(CbxAno.Text));
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "RelatoriosDaPoupanca";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
        }

        private void CbxAno_MouseLeave(object sender, MouseEventArgs e)
        {
            RelatoriosDaPoupanca();
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregarComboBoxAno();
        }
    }
}
