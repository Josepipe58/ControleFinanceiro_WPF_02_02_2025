using AcessarDadosDoBanco.Modelos;
using GerenciarDados.AcessarDados;
using GerenciarDados.Mensagens;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppControleFinanceiro.Telas
{
    public partial class Aposentadoria_UC : UserControl
    {
        public string _nomeDoMetodo = string.Empty;

        public Aposentadoria_UC()
        {
            InitializeComponent();
            ComboBoxesDeAposentadorias();
        }

        private void ComboBoxesDeAposentadorias()
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
                //ComboBox ds SaldoAnterior.
                Aposentadoria_AD aposentadoria_AD = new();
                CbxSaldoAnterior.ItemsSource = Aposentadoria_AD.ConsultarAposentadorias();
                CbxSaldoAnterior.DisplayMemberPath = "SaldoAtual";
                CbxSaldoAnterior.SelectedValuePath = "Id";
                CbxSaldoAnterior.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "ComboBoxesDeAposentadorias";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
            LimparEAtualizarDados();
        }

        public void DataGridDeAposentadorias()
        {
            try
            {
                DtgDados.ItemsSource = Aposentadoria_AD.ConsultarAposentadorias();
            }
            catch (Exception ex)
            {
                _nomeDoMetodo = "DataGridDeAposentadorias";
                GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                return;
            }
            TxtAnoDoIndice.Focus();
        }

        public void CalcularReajusteDaAposentadoria()
        {
            double saldoAnterior = 0;
            if (CbxSaldoAnterior.Text != "")
            {
                saldoAnterior = Convert.ToDouble(CbxSaldoAnterior.Text);
            }

            double indiceINPC = 0;
            if (TxtIndiceDoAumento.Text != "")
            {
                indiceINPC = Convert.ToDouble(TxtIndiceDoAumento.Text.Replace("%", ""));
            }

            double valorDoAumento = saldoAnterior * indiceINPC / 100;
            TxtValorDoAumento.Text = Convert.ToString(valorDoAumento);
            if (TxtValorDoAumento.Text != "")
            {
                double formatarValor = Convert.ToDouble(TxtValorDoAumento.Text.ToString());
                TxtValorDoAumento.Text = string.Format("{0:C}", formatarValor);
            }

            double beneficio = saldoAnterior + valorDoAumento;
            TxtSaldoAtual.Text = Convert.ToString(beneficio);
            double formatarSaldoAtual = Convert.ToDouble(TxtSaldoAtual.Text.ToString());
            TxtSaldoAtual.Text = string.Format("{0:C}", formatarSaldoAtual);

            if (TxtAtualizarValor.Text != "")
            {

                double atualizarvalor = Convert.ToDouble(TxtAtualizarValor.Text);
                TxtSaldoAtual.Text = Convert.ToString(beneficio);
                beneficio = Convert.ToDouble(TxtSaldoAtual.Text.ToString().Replace("R$", ""));
                TxtSaldoAtual.Text = string.Format("{0:c}", beneficio + atualizarvalor);
            }
            TxtAnoDoIndice.Focus();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text == "" && TxtAnoDoIndice.Text != "" && TxtAnoDoReajuste.Text != "" && TxtIndiceDoAumento.Text != "")
            {
                try
                {
                    Aposentadoria aposentadoria = new();
                    Aposentadoria_AD aposentadoria_AD = new();

                    aposentadoria.Data = Convert.ToDateTime(DtpData.Text);
                    aposentadoria.AnoDoIndice = Convert.ToInt32(TxtAnoDoIndice.Text);
                    aposentadoria.AnoDoReajuste = Convert.ToInt32(TxtAnoDoReajuste.Text);
                    //INPC
                    aposentadoria.IndiceDoAumento = Convert.ToDecimal(TxtIndiceDoAumento.Text.Replace("%", ""));
                    aposentadoria.ValorDoAumento = Convert.ToDecimal(TxtValorDoAumento.Text.Replace("R$", ""));
                    aposentadoria.AtualizarValor = Convert.ToDecimal(TxtAtualizarValor.Text);
                    aposentadoria.SaldoAtual = Convert.ToDecimal(TxtSaldoAtual.Text.Replace("R$", ""));

                    aposentadoria_AD.Cadastrar(aposentadoria);
                    GerenciarMensagens.SucessoAoCadastrar(aposentadoria.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnCadastrar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
            }
            else if (TxtId.Text != "" && TxtAnoDoIndice.Text != "" && TxtAnoDoReajuste.Text != "" && TxtIndiceDoAumento.Text != "")
            {
                GerenciarMensagens.ErroAoCadastrar();
                TxtAnoDoIndice.Focus();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                TxtAnoDoIndice.Focus();
                return;
            }
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text != "" && TxtAnoDoIndice.Text != "" && TxtAnoDoReajuste.Text != "" && TxtIndiceDoAumento.Text != "")
            {
                try
                {
                    Aposentadoria aposentadoria = new();
                    Aposentadoria_AD aposentadoria_AD = new();

                    aposentadoria.Id = Convert.ToInt32(TxtId.Text);
                    aposentadoria.Data = Convert.ToDateTime(DtpData.Text);
                    aposentadoria.AnoDoIndice = Convert.ToInt32(TxtAnoDoIndice.Text);
                    aposentadoria.AnoDoReajuste = Convert.ToInt32(TxtAnoDoReajuste.Text);
                    //INPC
                    aposentadoria.IndiceDoAumento = Convert.ToDecimal(TxtIndiceDoAumento.Text.Replace("%", ""));
                    aposentadoria.ValorDoAumento = Convert.ToDecimal(TxtValorDoAumento.Text.Replace("R$", ""));
                    aposentadoria.AtualizarValor = Convert.ToDecimal(TxtAtualizarValor.Text);
                    aposentadoria.SaldoAtual = Convert.ToDecimal(TxtSaldoAtual.Text.Replace("R$", ""));

                    aposentadoria_AD.Alterar(aposentadoria);
                    GerenciarMensagens.SucessoAoAlterar(aposentadoria.Id);
                    LimparEAtualizarDados();
                }
                catch (Exception ex)
                {
                    _nomeDoMetodo = "BtnAlterar_Click";
                    GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                    return;
                }
            }
            else if (TxtId.Text == "" && TxtAnoDoIndice.Text != "" && TxtAnoDoReajuste.Text != "" && TxtIndiceDoAumento.Text != "")
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
                TxtAnoDoIndice.Focus();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                TxtAnoDoIndice.Focus();
                return;
            }
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (TxtId.Text != "" && TxtAnoDoIndice.Text != "" && TxtAnoDoReajuste.Text != "" && TxtIndiceDoAumento.Text != "")
            {
                Aposentadoria aposentadoria = new();
                Aposentadoria_AD aposentadoria_AD = new();

                aposentadoria.Id = Convert.ToInt32(TxtId.Text);

                MessageBoxResult resultado = GerenciarMensagens.ConfirmarExcluir(aposentadoria.Id);
                if (resultado == MessageBoxResult.Yes)
                {
                    try
                    {
                        aposentadoria_AD.Excluir(aposentadoria.Id);
                        GerenciarMensagens.SucessoAoExcluir(aposentadoria.Id);
                        LimparEAtualizarDados();
                    }
                    catch (Exception ex)
                    {
                        _nomeDoMetodo = "BtnExcluir_Click";
                        GerenciarMensagens.ErroDeExcecaoENomeDoMetodo(ex, _nomeDoMetodo);
                        return;
                    }
                }
                else
                {
                    LimparEAtualizarDados();
                    return;
                }
            }
            else if (TxtId.Text == "" && TxtAnoDoIndice.Text != "" && TxtAnoDoReajuste.Text != "" && TxtIndiceDoAumento.Text != "")
            {
                GerenciarMensagens.ErroAoAlterarOuExcluir();
                TxtAnoDoIndice.Focus();
                return;
            }
            else
            {
                GerenciarMensagens.PreencherCampoVazio();
                TxtAnoDoIndice.Focus();
                return;
            }
        }

        private void DtgDados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DtgDados.SelectedIndex >= 0)
            {
                if (DtgDados.SelectedItems.Count >= 0)
                {
                    if (DtgDados.SelectedItems[0].GetType() == typeof(Aposentadoria))
                    {
                        Aposentadoria aposentadoria = (Aposentadoria)DtgDados.SelectedItems[0];
                        TxtId.Text = aposentadoria.Id.ToString();
                        CbxSaldoAnterior.Text = aposentadoria.SaldoAtual.ToString();
                        DtpData.Text = aposentadoria.Data.ToString();
                        TxtAnoDoIndice.Text = aposentadoria.AnoDoIndice.ToString();
                        TxtAnoDoReajuste.Text = aposentadoria.AnoDoReajuste.ToString();
                        TxtIndiceDoAumento.Text = aposentadoria.IndiceDoAumento.ToString();
                        TxtValorDoAumento.Text = aposentadoria.ValorDoAumento.ToString();
                        TxtAtualizarValor.Text = aposentadoria.AtualizarValor.ToString();
                        TxtSaldoAtual.Text = aposentadoria.SaldoAtual.ToString();
                        TxtAnoDoIndice.Focus();
                    }
                }
            }
        }

        private void CbxSaldoAnterior_MouseLeave(object sender, MouseEventArgs e)
        {
            CalcularReajusteDaAposentadoria();
        }

        private void CbxAno_MouseLeave(object sender, MouseEventArgs e)
        {
            DataGridDeAposentadorias();
        }

        private void TxtIndiceDoAumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                double formatarValor = Convert.ToDouble(TxtIndiceDoAumento.Text.ToString().Replace("%", ""));
                TxtIndiceDoAumento.Text = string.Format("{0:P}", formatarValor / 100);
                CalcularReajusteDaAposentadoria();
            }
        }

        private void TxtAtualizarValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CalcularReajusteDaAposentadoria();
            }
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxesDeAposentadorias();
            TxtAtualizarValor.Text = "0,00";
        }

        private void LimparEAtualizarDados()
        {
            TxtId.Text = null;
            TxtAnoDoIndice.Text = null;
            TxtAnoDoReajuste.Text = null;
            TxtIndiceDoAumento.Text = null;
            TxtValorDoAumento.Text = null;
            TxtSaldoAtual.Text = null;
            DataGridDeAposentadorias();
        }
    }
}
