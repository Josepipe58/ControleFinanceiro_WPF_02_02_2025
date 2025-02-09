using GerenciarDados.Mensagens;
using GerenciarDados.AcessarDados;
using GerenciarDados.Relatorios;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppControleFinanceiro.Telas.Relatorios
{
    public partial class RelatorioDeInvestimentos_UC : UserControl
    {
        public string _nomeDoMetodo = string.Empty;
        
        public RelatorioDeInvestimentos_UC()
        {
            InitializeComponent();            
            CarregarComboBoxAno();
        }

        public void CarregarComboBoxAno()
        {
            try
            {
                Ano_AD ano_AD = new();
                CbxAno.ItemsSource = ano_AD.SelecionarTodos();
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
            RelatoriosDeInvestimentos();
        }

        public void RelatoriosDeInvestimentos()
        {
            try
            {
                //Saldo Total da Poupança, Receitas e Investimentos.
                DtgSaldoTotalDaPoupancaReceitasEInvestimentos.ItemsSource = RelatorioDePoupanca
                    .RelatorioDoSaldoTotalDaPoupancaReceitasEInvestimentos(Convert.ToInt32(CbxAno.Text));

                //Saldo Total de Investimentos.
                DtgSaldoTotalDeInvestimentos.ItemsSource = RelatorioDeInvestimentos
                    .RelatorioDoSaldoTotalDeInvestimentos(Convert.ToInt32(CbxAno.Text));

                //Juros de Investimentos.
                DtgJurosDeInvestimentos.ItemsSource = RelatorioDeInvestimentos
                    .RelatorioDosJurosDeInvestimentos(Convert.ToInt32(CbxAno.Text));

                //Juros da Poupanca e Investimentos.
                DtgJurosPoupancaInvestimento.ItemsSource = RelatorioDeInvestimentos
                    .RelatorioDeJurosDaPoupancaEInvestimentos(Convert.ToInt32(CbxAno.Text));
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "RelatoriosDeInvestimentos";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
        }

        private void CbxAno_MouseLeave(object sender, MouseEventArgs e)
        {
            RelatoriosDeInvestimentos();
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregarComboBoxAno();
        }
    }
}
