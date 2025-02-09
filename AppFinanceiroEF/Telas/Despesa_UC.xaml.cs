using AcessarDadosDoBanco.Modelos;
using GerenciarDados.AcessarDados;
using GerenciarDados.Consultas;
using GerenciarDados.Listas;
using GerenciarDados.Mensagens;
using GerenciarDados.Relatorios;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppFinanceiroEF.Telas
{
    public partial class Despesa_UC : UserControl
    {
        public string _nomeDoMetodo = string.Empty;
        public Despesa_UC()
        {
            InitializeComponent();
            CarregarComboBoxes();
        }

        private void CarregarComboBoxes()
        {
            //Atualizar com a Data do Sistema
            if (DtpData.Text == "")
            {
                DtpData.Text = Convert.ToString(DateTime.Today);
            }
            else
            {
                DtpData.Text = Convert.ToString(DateTime.Today);
            }
            try
            {
                //Combobox de Categorias
                Categoria_AD categoria_AD = new();
                CbxCategoria.ItemsSource = Categoria_AD.ObterCategoriasPorId(1);
                CbxCategoria.DisplayMemberPath = "NomeDaCategoria";
                CbxCategoria.SelectedValuePath = "Id";
                CbxCategoria.SelectedIndex = 0;
                TxtValor.Focus();

                Ano_AD ano_AD = new();
                CbxAno.ItemsSource = ano_AD.SelecionarTodos();
                CbxAno.DisplayMemberPath = "AnoDoCadastro";
                CbxAno.SelectedValuePath = "Id";
                CbxAno.SelectedIndex = 0;

                CbxMes.ItemsSource = ListaDeStringMeses.CarregarComboBoxDeMeses();                
                CbxMes.SelectedIndex = 0;

                //Combobox de Tipo de Despesa;
                CbxTipo.Items.Add("Despesa");               
                CbxTipo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "CarregarComboBoxes";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
            LimparEAtualizarDados();
        }

        private void CbxCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CbxSubCategoria.ItemsSource = SubCategoria_AD.ObterSubCategoriasPorId(Convert.ToInt32(CbxCategoria.SelectedValue));
            CbxSubCategoria.DisplayMemberPath = "NomeDaSubCategoria";
            CbxSubCategoria.SelectedValuePath = "Id";
            CbxSubCategoria.SelectedIndex = 0;
            TxtValor.Focus();
        }

        public void CarregarDataGridDeDadosEValores()
        {
            try
            {
                DtgDados.ItemsSource = Despesa_AD.ObterDespesaPorAno(Convert.ToInt32(CbxAno.Text));

                DtgValores.ItemsSource = RelatorioDeDespesas.RelatorioDeDespesasGerais(Convert.ToInt32(CbxAno.Text));
                LblTituloDtgValores.Content = "Despesas Totais - Mensal e Anual";
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "CarregarDataGridDeDadosEValores";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
            TxtValor.Focus();
            SaldoDaCarteiraPoupancaEInvestimentos();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text == "" && TxtValor.Text != "")
            {
                try
                {
                    Despesa_AD despesa_AD = new();
                    Despesa despesa = new()
                    {
                        NomeDaCategoria = CbxCategoria.Text,
                        NomeDaSubCategoria = CbxSubCategoria.Text,
                        Valor = Convert.ToDecimal(TxtValor.Text.Replace("R$", "")),
                        Tipo = CbxTipo.Text,
                        Data = Convert.ToDateTime(DtpData.Text),
                        Mes = CbxMes.Text,
                        Ano = Convert.ToInt32(CbxAno.Text)
                    };
                    despesa_AD.Cadastrar(despesa);

                    GerenciarMensagens.SucessoAoCadastrar(despesa.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnCadastrar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
            }
            else if (TxtId.Text != "" && TxtValor.Text != "")
            {
                GerenciarMensagens.ErroAoCadastrar();
                TxtValor.Focus();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                TxtValor.Focus();
                return;
            }
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text != "" && TxtValor.Text != "")
            {
                try
                {
                    Despesa_AD despesa_AD = new();
                    Despesa despesa = new()
                    {
                        Id = Convert.ToInt32(TxtId.Text),
                        NomeDaCategoria = CbxCategoria.Text,
                        NomeDaSubCategoria = CbxSubCategoria.Text,
                        Valor = Convert.ToDecimal(TxtValor.Text.Replace("R$", "")),
                        Tipo = CbxTipo.Text,
                        Data = Convert.ToDateTime(DtpData.Text),
                        Mes = CbxMes.Text,
                        Ano = Convert.ToInt32(CbxAno.Text)
                    };
                    despesa_AD.Alterar(despesa);

                    GerenciarMensagens.SucessoAoAlterar(despesa.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnAlterar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
            }
            else if (TxtId.Text == "" && TxtValor.Text != "")
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
                TxtValor.Focus();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                TxtValor.Focus();
                return;
            }
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text != "" && TxtValor.Text != "")
            {
                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(Convert.ToInt32(TxtId.Text));
                if (resultado == MessageBoxResult.Yes)
                {
                    try
                    {
                        Despesa_AD despesa_AD = new();
                        Despesa despesa = new()
                        {
                            Id = Convert.ToInt32(TxtId.Text)
                        };
                        despesa_AD.Excluir(despesa.Id);

                        GerenciarMensagens.SucessoAoExcluir(despesa.Id);
                        LimparEAtualizarDados();
                    }
                    catch (Exception ex)
                    {
                        _nomeDoMetodo = "BtnExcluir_Click";
                        GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    }
                }
                else
                {
                    LimparEAtualizarDados();
                    return;
                }
            }
            else if (TxtId.Text == "" && TxtValor.Text != "")
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
                TxtValor.Focus();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                TxtValor.Focus();
                return;
            }
        }

        private void DtgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DtgDados.SelectedIndex >= 0)
            {
                if (DtgDados.SelectedItems.Count >= 0)
                {
                    if (DtgDados.SelectedItems[0].GetType() == typeof(Despesa))
                    {
                        Despesa despesa = (Despesa)DtgDados.SelectedItems[0];
                        TxtId.Text = despesa.Id.ToString();
                        CbxCategoria.Text = despesa.NomeDaCategoria.ToString();
                        CbxSubCategoria.Text = despesa.NomeDaSubCategoria.ToString();
                        TxtValor.Text = despesa.Valor.ToString();
                        CbxTipo.Text = despesa.Tipo.ToString();
                        DtpData.Text = despesa.Data.ToString();
                        CbxMes.Text = despesa.Mes.ToString();
                        CbxAno.Text = despesa.Ano.ToString();
                        TxtValor.Focus();
                    }
                }
            }
        }

        public void SaldoDaCarteiraPoupancaEInvestimentos()
        {
            try
            {
                //====================================| Saldo da Carteira |=======================================================================                    
                TxtCarteira.Text = Convert.ToString(SaldoFinanceiroCPI.SaldoDaCarteira(Convert.ToInt32(CbxAno.Text)));
                double saldoDaCarteira = Convert.ToDouble(TxtCarteira.Text.ToString().Replace("R$", ""));
                TxtCarteira.Text = string.Format("{0:c}", saldoDaCarteira);
                //====================================| Saldo da Poupança |======================================================================= 
                TxtPoupanca.Text = Convert.ToString(SaldoFinanceiroCPI.SaldoDaPoupanca(Convert.ToInt32(CbxAno.Text)));
                double saldoDaPoupanca = Convert.ToDouble(TxtPoupanca.Text.ToString().Replace("R$", ""));
                TxtPoupanca.Text = string.Format("{0:c}", saldoDaPoupanca);
                //====================================| Saldo de Investimentos |================================================================== 
                TxtInvestimento.Text = Convert.ToString(SaldoFinanceiroCPI.SaldoDeInvestimento(Convert.ToInt32(CbxAno.Text)));
                double saldoDeInvestimento = Convert.ToDouble(TxtInvestimento.Text.ToString().Replace("R$", ""));
                TxtInvestimento.Text = string.Format("{0:c}", saldoDeInvestimento);
                //=====================================| Saldo Total da Poupança e de Investimentos |=============================================                    
                double saldoTotalDaPoupancaEInvestimento = Convert.ToDouble(TxtPoupancaEInvestimento.Text.ToString().Replace("R$", ""));
                TxtPoupancaEInvestimento.Text = string.Format("{0:c}", saldoTotalDaPoupancaEInvestimento = saldoDaPoupanca + saldoDeInvestimento);
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "SaldoDaCarteiraPoupancaEInvestimentos";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
        }

        private void CbxNomeDeFiltros_MouseLeave(object sender, MouseEventArgs e)
        {           
            CarregarDataGridDeDadosEValores();
        }

        private void CbxAno_MouseLeave(object sender, MouseEventArgs e)
        {
            CarregarDataGridDeDadosEValores();
        }

        private void TxtValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                double formatarValor = Convert.ToDouble(TxtValor.Text.ToString().Replace("R$", ""));
                TxtValor.Text = string.Format("{0:c}", formatarValor);
            }
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {

            CbxTipo.SelectedIndex = 0;
            CbxMes.SelectedIndex = 0;
            CbxAno.SelectedIndex = 0;            
            CbxCategoria.SelectedIndex = 0;
            CbxSubCategoria.SelectedIndex = 0;
            DtpData.SelectedDate = DateTime.Now;
            LimparEAtualizarDados();

        }

        private void LimparEAtualizarDados()
        {
            TxtId.Text = null;
            TxtValor.Text = null;
            CarregarDataGridDeDadosEValores();
        }
    }
}
